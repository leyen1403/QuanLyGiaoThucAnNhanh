using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Data;

namespace DAL
{
    public class MongoDB_DAL
    {
        string connectionString = "mongodb://localhost:27017";
        string databaseName = "DoAnNoSQL_GiaoThucAnNhanh";
        private readonly IMongoDatabase _database;

        public MongoDB_DAL()
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }
        public IMongoCollection<BsonDocument> GetCollection(string collectionName)
        {
            return _database.GetCollection<BsonDocument>(collectionName);
        }

        public void Insert(string collectionName, BsonDocument document)
        {
            var collection = this.GetCollection(collectionName);
            collection.InsertOne(document);
        }
        public BsonDocument GetOneCuaHang(string maCuaHang, string matKhau)
        {
            var collection = this.GetCollection("CuaHangGiaoThucAnNhanh");
            var filter = Builders<BsonDocument>.Filter.Eq("ma_cua_hang", maCuaHang) & Builders<BsonDocument>.Filter.Eq("mat_khau_dang_nhap", matKhau);
            return collection.Find(filter).FirstOrDefault();
        }
        public bool IsValidCuaHang(string maCuaHang, string matKhauDangNhap)
        {
            var collection = this.GetCollection("CuaHangGiaoThucAnNhanh");
            var filter = Builders<BsonDocument>.Filter.Eq("cua_hang.ma_cua_hang", maCuaHang) & Builders<BsonDocument>.Filter.Eq("cua_hang.mat_khau_dang_nhap", matKhauDangNhap);

            var result = collection.Find(filter).Any(); // Kiểm tra xem có bất kỳ tài liệu nào khớp với bộ lọc không

            return result; // Trả về true nếu có, false nếu không
        }

        public List<BsonDocument> GetLoaiMonFromCuaHang(string maCuaHang)
        {
            var collection = this.GetCollection("CuaHangGiaoThucAnNhanh");
            var filter = Builders<BsonDocument>.Filter.Eq("cua_hang.ma_cua_hang", maCuaHang);

            // Tìm một cửa hàng dựa trên mã cửa hàng
            var cuaHang = collection.Find(filter).FirstOrDefault();

            // Nếu cửa hàng tồn tại và có trường menu
            if (cuaHang != null && cuaHang.Contains("cua_hang") && cuaHang["cua_hang"].AsBsonDocument.Contains("menu"))
            {
                var menu = cuaHang["cua_hang"]["menu"].AsBsonArray;
                var loaiMonList = new List<BsonDocument>();

                foreach (var item in menu)
                {
                    loaiMonList.Add(item.AsBsonDocument);
                }

                return loaiMonList; // Trả về danh sách các loại món ăn
            }

            return new List<BsonDocument>(); // Trả về danh sách rỗng nếu không tìm thấy
        }
        public bool LuuLoaiMon(DataTable dtDsLoaiMon, string maCuaHang)
        {
            var collection = this.GetCollection("CuaHangGiaoThucAnNhanh");
            var filter = Builders<BsonDocument>.Filter.Eq("cua_hang.ma_cua_hang", maCuaHang);
            var cuaHangDocument = collection.Find(filter).FirstOrDefault();

            if (cuaHangDocument == null)
            {
                throw new Exception("Document không tồn tại trong MongoDB.");
            }

            var menuArray = cuaHangDocument["cua_hang"]["menu"].AsBsonArray;
            var existingMenuItems = new HashSet<string>(menuArray.Select(m => m["ma_loai_mon"].ToString()));
            var updatedMenuItems = new HashSet<string>();

            // Thêm và cập nhật bản ghi
            foreach (DataRow row in dtDsLoaiMon.Rows)
            {
                var maLoaiMon = row["ma_loai_mon"].ToString();
                updatedMenuItems.Add(maLoaiMon);

                if (!existingMenuItems.Contains(maLoaiMon))
                {
                    // Bản ghi mới: thêm vào mảng menu
                    var newMenuItem = new BsonDocument
                    {
                        { "ma_loai_mon", maLoaiMon },
                        { "ten_loai_mon", row["ten_loai_mon"].ToString() },
                        { "anh_loai_mon", row["anh_loai_mon"].ToString() }, // Giả định đây là hình ảnh nhị phân
                        { "mon_an", new BsonArray() }
                    };           
                    menuArray.Add(newMenuItem);
                }
                else
                {
                    // Cập nhật nếu có sự thay đổi
                    var existingMenuItem = menuArray.First(m => m["ma_loai_mon"] == maLoaiMon);
                    existingMenuItem["ten_loai_mon"] = row["ten_loai_mon"].ToString();
                    existingMenuItem["anh_loai_mon"] = row["anh_loai_mon"].ToString(); // Cập nhật hình ảnh
                }
            }

            // Xóa các món không còn trong DataTable
            var itemsToRemove = menuArray
                .Where(m => !updatedMenuItems.Contains(m["ma_loai_mon"].ToString()))
                .ToList();

            foreach (var item in itemsToRemove)
            {
                menuArray.Remove(item);
            }

            // Cập nhật document trong MongoDB
            cuaHangDocument["cua_hang"]["menu"] = menuArray;
            collection.ReplaceOne(Builders<BsonDocument>.Filter.Eq("_id", cuaHangDocument["_id"]), cuaHangDocument);

            return true; // Trả về true nếu thành công
        }


    }
}
