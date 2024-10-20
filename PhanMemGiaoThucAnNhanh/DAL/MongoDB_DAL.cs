using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Data;
using DTO;

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
        public BsonDocument GetOneCuaHang(string maCuaHang)
        {
            var collection = this.GetCollection("CuaHangGiaoThucAnNhanh");
            var filter = Builders<BsonDocument>.Filter.Eq("cua_hang.ma_cua_hang", maCuaHang);
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
        public bool CapNhatCuaHang(BsonDocument cuaHang, string maCuaHang)
        {
            var collection = this.GetCollection("CuaHangGiaoThucAnNhanh");
            var filter = Builders<BsonDocument>.Filter.Eq("cua_hang.ma_cua_hang", maCuaHang);
            var cuaHangDocument = collection.Find(filter).FirstOrDefault();

            if (cuaHangDocument == null)
            {
                throw new Exception("Document không tồn tại trong MongoDB.");
            }
            // Cập nhật các trường mà bạn đã cung cấp
            var cuaHangFields = cuaHang["cua_hang"].AsBsonDocument;

            if (cuaHangFields.Contains("ten_cua_hang"))
                cuaHangDocument["cua_hang"]["ten_cua_hang"] = cuaHangFields["ten_cua_hang"];

            if (cuaHangFields.Contains("so_dien_thoai"))
                cuaHangDocument["cua_hang"]["so_dien_thoai"] = cuaHangFields["so_dien_thoai"];

            if (cuaHangFields.Contains("dia_chi"))
                cuaHangDocument["cua_hang"]["dia_chi"] = cuaHangFields["dia_chi"];

            if (cuaHangFields.Contains("email"))
                cuaHangDocument["cua_hang"]["email"] = cuaHangFields["email"];

            if (cuaHangFields.Contains("hinh_anh_dai_dien"))
                cuaHangDocument["cua_hang"]["hinh_anh_dai_dien"] = cuaHangFields["hinh_anh_dai_dien"];

            if (cuaHangFields.Contains("mat_khau_dang_nhap"))
                cuaHangDocument["cua_hang"]["mat_khau_dang_nhap"] = cuaHangFields["mat_khau_dang_nhap"];

            if (cuaHangFields.Contains("dang_hoat_dong"))
                cuaHangDocument["cua_hang"]["dang_hoat_dong"] = cuaHangFields["dang_hoat_dong"];
            // Cập nhật các trường trong document


            // Cập nhật document trong MongoDB
            collection.ReplaceOne(Builders<BsonDocument>.Filter.Eq("_id", cuaHangDocument["_id"]), cuaHangDocument);

            return true; // Trả về true nếu thành công
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

        // Lay danh sach mon an theo ma loai mon
        public List<BsonDocument> GetDanhSachMonByMaLoaiMon(string maLoai)
        {
            var collection = this.GetCollection("CuaHangGiaoThucAnNhanh");
            var filter = Builders<BsonDocument>.Filter.ElemMatch<BsonDocument>("cua_hang.menu", Builders<BsonDocument>.Filter.Eq("ma_loai_mon", maLoai));
            var cuaHang = collection.Find(filter).FirstOrDefault();
            if (cuaHang != null && cuaHang.Contains("cua_hang") && cuaHang["cua_hang"].AsBsonDocument.Contains("menu"))
            {
                var menuArray = cuaHang["cua_hang"]["menu"].AsBsonArray;
                var loaiMon = menuArray.FirstOrDefault(m => m["ma_loai_mon"] == maLoai);
                if (loaiMon != null && loaiMon.AsBsonDocument.Contains("mon_an"))
                {
                    var monAnArray = loaiMon["mon_an"].AsBsonArray;
                    return monAnArray.Select(m => m.AsBsonDocument).ToList();
                }
            }

            return new List<BsonDocument>();
        }

        // Lay danh sach mon an co trong menu
        public List<BsonDocument> GetDanhSachMon()
        {
            var collection = this.GetCollection("CuaHangGiaoThucAnNhanh");
            var cuaHangList = collection.Find(new BsonDocument()).ToList();
            var danhSachMonAn = new List<BsonDocument>();

            foreach (var cuaHang in cuaHangList)
            {
                // Kiểm tra xem cửa hàng có trường "menu" không
                if (cuaHang.Contains("cua_hang") && cuaHang["cua_hang"].AsBsonDocument.Contains("menu"))
                {
                    var menuArray = cuaHang["cua_hang"]["menu"].AsBsonArray;

                    // Duyệt qua từng loại món trong menu
                    foreach (var loaiMon in menuArray)
                    {
                        // Kiểm tra xem loại món có danh sách món ăn không
                        if (loaiMon.AsBsonDocument.Contains("mon_an"))
                        {
                            var monAnArray = loaiMon["mon_an"].AsBsonArray;

                            // Thêm các món ăn vào danh sách
                            foreach (var monAn in monAnArray)
                            {
                                var monAnDocument = monAn.AsBsonDocument;
                                // Thêm trường ma_loai_mon vào từng món ăn
                                monAnDocument.Add("ma_loai_mon", loaiMon["ma_loai_mon"].AsString);

                                danhSachMonAn.Add(monAnDocument);
                            }
                        }
                    }
                }
            }

            return danhSachMonAn; // Trả về danh sách toàn bộ các món ăn có thêm ma_loai_mon
        }

        // Lay mon an theo ma mon an    
        public BsonDocument GetMonAnByMaMon(string maMon)
        {
            var collection = this.GetCollection("CuaHangGiaoThucAnNhanh");
            var cuaHangList = collection.Find(new BsonDocument()).ToList();
            foreach (var cuaHang in cuaHangList)
            {
                if (cuaHang.Contains("cua_hang") && cuaHang["cua_hang"].AsBsonDocument.Contains("menu"))
                {
                    var menuArray = cuaHang["cua_hang"]["menu"].AsBsonArray;
                    foreach (var loaiMon in menuArray)
                    {
                        if (loaiMon.AsBsonDocument.Contains("mon_an"))
                        {
                            var monAnArray = loaiMon["mon_an"].AsBsonArray;
                            var monAn = monAnArray.FirstOrDefault(m => m["ma_mon_an"].ToString() == maMon);
                            if (monAn != null)
                            {
                                return monAn.AsBsonDocument;
                            }
                        }
                    }
                }
            }

            return null;
        }

        // Lay danh sach loai mon an
        public List<LoaiMonAn> LayDanhSachLoaiMonAn(string maCuaHang)
        {
            var collection = this.GetCollection("CuaHangGiaoThucAnNhanh");
            var filter = Builders<BsonDocument>.Filter.Eq("cua_hang.ma_cua_hang", maCuaHang);

            var cuaHang = collection.Find(filter).FirstOrDefault();

            if (cuaHang != null && cuaHang.Contains("cua_hang") && cuaHang["cua_hang"].AsBsonDocument.Contains("menu"))
            {
                var menu = cuaHang["cua_hang"]["menu"].AsBsonArray;
                var loaiMonList = new List<LoaiMonAn>();

                foreach (var item in menu)
                {
                    loaiMonList.Add(new LoaiMonAn
                    {
                        MaLoaiMon = item["ma_loai_mon"].AsString,
                        TenLoaiMon = item["ten_loai_mon"].AsString
                    });
                }

                return loaiMonList;
            }

            return new List<LoaiMonAn>();
        }

        // Luu mon an
        public bool LuuMonAn(DataTable dsMonAn, string maCuaHang, string maLoaiMon)
        {
            try
            {
                var collection = this.GetCollection("CuaHangGiaoThucAnNhanh");
                var filter = Builders<BsonDocument>.Filter.Eq("cua_hang.ma_cua_hang", maCuaHang);
                var cuaHangDocument = collection.Find(filter).FirstOrDefault();

                if (cuaHangDocument == null)
                {
                    throw new Exception("Document cửa hàng không tồn tại trong MongoDB.");
                }

                var menuArray = cuaHangDocument["cua_hang"]["menu"].AsBsonArray;
                var loaiMon = menuArray.FirstOrDefault(m => m["ma_loai_mon"] == maLoaiMon);

                if (loaiMon == null)
                {
                    throw new Exception("Loại món không tồn tại trong menu.");
                }

                var monAnArray = loaiMon["mon_an"].AsBsonArray;
                var existingMonAnIds = new HashSet<string>(monAnArray.Select(m => m["ma_mon_an"].AsString));
                var updatedMonAnIds = new HashSet<string>();

                foreach (DataRow row in dsMonAn.Rows)
                {
                    var maMonAn = row["ma_mon_an"].ToString();
                    updatedMonAnIds.Add(maMonAn);

                    if (existingMonAnIds.Contains(maMonAn))
                    {
                        // Cập nhật món ăn đã tồn tại
                        var existingMonAn = monAnArray.First(m => m["ma_mon_an"] == maMonAn);
                        existingMonAn["ten_mon"] = row["ten_mon"].ToString();
                        existingMonAn["gia_mon"] = Convert.ToDecimal(row["gia_mon"]);
                        existingMonAn["hien_thi"] = Convert.ToBoolean(row["hien_thi"]);
                        existingMonAn["mo_ta"] = row["mo_ta"].ToString();
                        existingMonAn["hinh_anh"] = row["hinh_anh"].ToString();
                    }
                    else
                    {
                        // Thêm món ăn mới
                        var newMonAn = new BsonDocument
                {
                    { "ma_mon_an", maMonAn },
                    { "ten_mon", row["ten_mon"].ToString() },
                    { "gia_mon", Convert.ToDecimal(row["gia_mon"]) },
                    { "hien_thi", Convert.ToBoolean(row["hien_thi"]) },
                    { "mo_ta", row["mo_ta"].ToString() },
                    { "hinh_anh", row["hinh_anh"].ToString() }
                };
                        monAnArray.Add(newMonAn);
                    }
                }

                // Xóa các món ăn không còn trong DataTable
                var itemsToRemove = monAnArray
                    .Where(m => !updatedMonAnIds.Contains(m["ma_mon_an"].AsString))
                    .ToList();

                foreach (var item in itemsToRemove)
                {
                    monAnArray.Remove(item);
                }

                // Cập nhật lại danh sách món ăn vào loại món
                loaiMon["mon_an"] = monAnArray;

                // Cập nhật document cửa hàng vào collection
                collection.ReplaceOne(Builders<BsonDocument>.Filter.Eq("_id", cuaHangDocument["_id"]), cuaHangDocument);

                return true; // Trả về true nếu thành công
            }
            catch (Exception ex)
            {
                // Xử lý lỗi (log lỗi nếu cần)
                Console.WriteLine($"Lỗi: {ex.Message}");
                return false; // Trả về false nếu có lỗi xảy ra
            }
        }

        // Them mon an vao loai mon
        public bool ThemMonAnVaoLoaiMon(string maCuaHang, string maLoai, MonAn monAn)
        {
            try
            {
                // Lấy collection CuaHangGiaoThucAnNhanh
                var collection = this.GetCollection("CuaHangGiaoThucAnNhanh");
                var filter = Builders<BsonDocument>.Filter.Eq("cua_hang.ma_cua_hang", maCuaHang);
                var cuaHangDocument = collection.Find(filter).FirstOrDefault();

                if (cuaHangDocument == null)
                {
                    throw new Exception("Document cửa hàng không tồn tại trong MongoDB.");
                }

                var menuArray = cuaHangDocument["cua_hang"]["menu"].AsBsonArray;
                var loaiMon = menuArray.FirstOrDefault(m => m["ma_loai_mon"] == maLoai);

                if (loaiMon == null)
                {
                    throw new Exception("Loại món không tồn tại trong menu.");
                }

                var monAnArray = loaiMon["mon_an"].AsBsonArray;

                // Kiểm tra xem món ăn đã tồn tại hay chưa
                var existingMonAn = monAnArray.FirstOrDefault(m => m["ma_mon_an"] == monAn.MaMon);
                if (existingMonAn != null)
                {
                    throw new Exception("Món ăn đã tồn tại trong loại món này.");
                }

                // Thêm món ăn mới vào danh sách món ăn
                var newMonAn = new BsonDocument
        {
            { "ma_mon_an", monAn.MaMon },
            { "ten_mon", monAn.TenMon },
            { "gia_mon", monAn.GiaMon },
            { "hien_thi", monAn.HienThi },
            { "mo_ta", monAn.MoTa },
            { "hinh_anh", monAn.HinhAnh }
        };

                monAnArray.Add(newMonAn);

                // Cập nhật lại danh sách món ăn vào loại món
                loaiMon["mon_an"] = monAnArray;

                // Cập nhật document cửa hàng vào collection
                collection.ReplaceOne(Builders<BsonDocument>.Filter.Eq("_id", cuaHangDocument["_id"]), cuaHangDocument);

                return true; // Trả về true nếu thành công
            }
            catch (Exception ex)
            {
                // Xử lý lỗi (log lỗi nếu cần)
                Console.WriteLine($"Lỗi: {ex.Message}");
                return false; // Trả về false nếu có lỗi xảy ra
            }
        }

        // xoa mon an
        public bool XoaMonAn(string maCuaHang, string maLoai, MonAn monAn)
        {
            try
            {
                var collection = this.GetCollection("CuaHangGiaoThucAnNhanh");
                var filter = Builders<BsonDocument>.Filter.Eq("cua_hang.ma_cua_hang", maCuaHang);
                var cuaHangDocument = collection.Find(filter).FirstOrDefault();

                if (cuaHangDocument == null)
                {
                    throw new Exception("Document cửa hàng không tồn tại trong MongoDB.");
                }

                var menuArray = cuaHangDocument["cua_hang"]["menu"].AsBsonArray;
                var loaiMon = menuArray.FirstOrDefault(m => m["ma_loai_mon"] == maLoai);

                if (loaiMon == null)
                {
                    throw new Exception("Loại món không tồn tại trong menu.");
                }

                var monAnArray = loaiMon["mon_an"].AsBsonArray;
                var monAnToRemove = monAnArray.FirstOrDefault(m => m["ma_mon_an"] == monAn.MaMon);

                if (monAnToRemove != null)
                {
                    // Xóa món ăn
                    monAnArray.Remove(monAnToRemove);

                    // Cập nhật lại danh sách món ăn vào loại món
                    loaiMon["mon_an"] = monAnArray;

                    // Cập nhật document cửa hàng vào collection
                    collection.ReplaceOne(Builders<BsonDocument>.Filter.Eq("_id", cuaHangDocument["_id"]), cuaHangDocument);

                    return true; // Trả về true nếu xóa thành công
                }
                else
                {
                    throw new Exception("Món ăn không tồn tại trong loại món.");
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi (log lỗi nếu cần)
                Console.WriteLine($"Lỗi: {ex.Message}");
                return false; // Trả về false nếu có lỗi xảy ra
            }
        }

        // Cap nhat thong tin mon an
        public bool CapNhatThongTinMonAn(string maCuaHang, string maLoai, MonAn monAn)
        {
            try
            {
                var collection = this.GetCollection("CuaHangGiaoThucAnNhanh");
                var filter = Builders<BsonDocument>.Filter.Eq("cua_hang.ma_cua_hang", maCuaHang);
                var cuaHangDocument = collection.Find(filter).FirstOrDefault();

                if (cuaHangDocument == null)
                {
                    throw new Exception("Document cửa hàng không tồn tại trong MongoDB.");
                }

                var menuArray = cuaHangDocument["cua_hang"]["menu"].AsBsonArray;
                var loaiMon = menuArray.FirstOrDefault(m => m["ma_loai_mon"] == maLoai);

                if (loaiMon == null)
                {
                    throw new Exception("Loại món không tồn tại trong menu.");
                }

                var monAnArray = loaiMon["mon_an"].AsBsonArray;
                var existingMonAn = monAnArray.FirstOrDefault(m => m["ma_mon_an"] == monAn.MaMon);

                if (existingMonAn != null)
                {
                    // Cập nhật thông tin món ăn
                    existingMonAn["ten_mon"] = monAn.TenMon;
                    existingMonAn["gia_mon"] = monAn.GiaMon;
                    existingMonAn["hien_thi"] = monAn.HienThi;
                    existingMonAn["mo_ta"] = monAn.MoTa;
                    existingMonAn["hinh_anh"] = monAn.HinhAnh;

                    // Cập nhật lại danh sách món ăn vào loại món
                    loaiMon["mon_an"] = monAnArray;

                    // Cập nhật document cửa hàng vào collection
                    collection.ReplaceOne(Builders<BsonDocument>.Filter.Eq("_id", cuaHangDocument["_id"]), cuaHangDocument);

                    return true; // Trả về true nếu cập nhật thành công
                }
                else
                {
                    throw new Exception("Món ăn không tồn tại trong loại món.");
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi (log lỗi nếu cần)
                Console.WriteLine($"Lỗi: {ex.Message}");
                return false; // Trả về false nếu có lỗi xảy ra
            }
        }

        public List<MonAn> TimMonAnTheoTen(string tenMon)
        {
            var collection = this.GetCollection("CuaHangGiaoThucAnNhanh");
            var cuaHangList = collection.Find(new BsonDocument()).ToList();
            var danhSachMonAn = new List<MonAn>();

            foreach (var cuaHang in cuaHangList)
            {
                if (cuaHang.Contains("cua_hang") && cuaHang["cua_hang"].AsBsonDocument.Contains("menu"))
                {
                    var menuArray = cuaHang["cua_hang"]["menu"].AsBsonArray;

                    foreach (var loaiMon in menuArray)
                    {
                        if (loaiMon.AsBsonDocument.Contains("mon_an"))
                        {
                            var monAnArray = loaiMon["mon_an"].AsBsonArray;

                            foreach (var monAnDoc in monAnArray)
                            {
                                var monAn = monAnDoc.AsBsonDocument;
                                if (monAn["ten_mon"].AsString.IndexOf(tenMon, StringComparison.OrdinalIgnoreCase) >= 0)
                                {
                                    // Xử lý giá trị của gia_mon
                                    var giaMonValue = monAn["gia_mon"];
                                    double giaMonDouble;

                                    if (giaMonValue.IsDecimal128)
                                    {
                                        giaMonDouble = (double)giaMonValue.AsDecimal128; // Chuyển Decimal128 thành double
                                    }
                                    else if (giaMonValue.IsDouble)
                                    {
                                        giaMonDouble = giaMonValue.AsDouble;
                                    }
                                    else if (giaMonValue.IsInt32)
                                    {
                                        giaMonDouble = giaMonValue.AsInt32;
                                    }
                                    else
                                    {
                                        throw new InvalidCastException("Unsupported type for gia_mon");
                                    }

                                    // Khởi tạo đối tượng MonAn với đầy đủ tham số
                                    var newMonAn = new MonAn(
                                        monAn["ma_mon_an"].AsString,
                                        monAn["ten_mon"].AsString,
                                        monAn["hinh_anh"].AsString,
                                        giaMonDouble,  // Truyền giaMonDouble thay vì string
                                        monAn["mo_ta"].AsString,
                                        monAn["hien_thi"].AsBoolean
                                    );

                                    danhSachMonAn.Add(newMonAn);
                                }
                            }
                        }
                    }
                }
            }

            return danhSachMonAn; // Trả về danh sách món ăn tìm được
        }



    }
}
