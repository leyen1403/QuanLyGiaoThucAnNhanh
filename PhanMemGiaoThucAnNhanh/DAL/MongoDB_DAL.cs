﻿using System;
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
        public DataTable GetTongTienTheoNgayHoanThanhDataTable()
        {
            var collection = GetCollection("CuaHangGiaoThucAnNhanh");
            var cursor = collection.Find(new BsonDocument()).ToCursor();

            var result = new Dictionary<DateTime, decimal>();

            foreach (var document in cursor.ToEnumerable())
            {
                var khachHangList = document["cua_hang"]["khach_hang"].AsBsonArray;

                foreach (var khachHang in khachHangList)
                {
                    var donHangList = khachHang["don_hang"].AsBsonArray;

                    foreach (var donHang in donHangList)
                    {
                        if (donHang["trang_thai"].AsString == "hoàn thành")
                        {
                            // Chuyển đổi từ BsonString sang DateTime
                            DateTime thoiGianDat = DateTime.Parse(donHang["thoi_gian_dat"].AsString);
                            var ngay = thoiGianDat.Date;
                            var tongTien = donHang["tong_tien"].ToDecimal();

                            if (result.ContainsKey(ngay))
                            {
                                result[ngay] += tongTien;
                            }
                            else
                            {
                                result[ngay] = tongTien;
                            }
                        }
                    }
                }
            }

            // Tạo DataTable
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Ngày", typeof(DateTime));
            dataTable.Columns.Add("Tổng tiền", typeof(decimal));

            // Thêm dữ liệu vào DataTable
            foreach (var item in result)
            {
                dataTable.Rows.Add(item.Key, item.Value);
            }

            return dataTable;
        }
        public DataTable GetTongTienTheoNgayHoanThanhDataTable(string ngay_bat_dau, string ngay_ket_thuc)
        {
            // Chuyển đổi chuỗi thành DateTime
            DateTime startDate = DateTime.Parse(ngay_bat_dau);
            DateTime endDate = DateTime.Parse(ngay_ket_thuc);

            var collection = GetCollection("CuaHangGiaoThucAnNhanh");
            var cursor = collection.Find(new BsonDocument()).ToCursor();

            var result = new Dictionary<DateTime, decimal>();

            foreach (var document in cursor.ToEnumerable())
            {
                var khachHangList = document["cua_hang"]["khach_hang"].AsBsonArray;

                foreach (var khachHang in khachHangList)
                {
                    var donHangList = khachHang["don_hang"].AsBsonArray;

                    foreach (var donHang in donHangList)
                    {
                        if (donHang["trang_thai"].AsString == "hoàn thành")
                        {
                            // Chuyển đổi từ BsonString sang DateTime
                            DateTime thoiGianDat = DateTime.Parse(donHang["thoi_gian_dat"].AsString);
                            var ngay = thoiGianDat.Date;
                            var tongTien = donHang["tong_tien"].ToDecimal();

                            // Kiểm tra xem ngày có nằm trong khoảng không
                            if (ngay >= startDate && ngay <= endDate)
                            {
                                if (result.ContainsKey(ngay))
                                {
                                    result[ngay] += tongTien;
                                }
                                else
                                {
                                    result[ngay] = tongTien;
                                }
                            }
                        }
                    }
                }
            }

            // Tạo DataTable
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Ngày", typeof(DateTime));
            dataTable.Columns.Add("Tổng tiền", typeof(decimal));

            // Thêm dữ liệu vào DataTable
            foreach (var item in result)
            {
                dataTable.Rows.Add(item.Key, item.Value);
            }

            return dataTable;
        }
        public DataTable GetMonAnBanChayDataTable()
        {
            var collection = GetCollection("CuaHangGiaoThucAnNhanh");
            var cursor = collection.Find(new BsonDocument()).ToCursor();

            var monAnTongSoLuong = new Dictionary<string, (string TenMon, int TongSoLuong)>();

            foreach (var document in cursor.ToEnumerable())
            {
                var khachHangList = document["cua_hang"]["khach_hang"].AsBsonArray;

                foreach (var khachHang in khachHangList)
                {
                    var donHangList = khachHang["don_hang"].AsBsonArray;

                    foreach (var donHang in donHangList)
                    {
                        var monAnDonHang = donHang["mon_an_don_hang"].AsBsonArray;

                        foreach (var monAn in monAnDonHang)
                        {
                            var maMonAn = monAn["ma_mon_an"].AsString;
                            var tenMonAn = monAn["ten_mon"].AsString;
                            var soLuong = monAn["so_luong"].ToInt32();

                            if (monAnTongSoLuong.ContainsKey(maMonAn))
                            {
                                monAnTongSoLuong[maMonAn] = (tenMonAn, monAnTongSoLuong[maMonAn].TongSoLuong + soLuong);
                            }
                            else
                            {
                                monAnTongSoLuong[maMonAn] = (tenMonAn, soLuong);
                            }
                        }
                    }
                }
            }

            // Tạo DataTable
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Mã món ăn", typeof(string));
            dataTable.Columns.Add("Tên món ăn", typeof(string));
            dataTable.Columns.Add("Tổng số lượng", typeof(int));

            // Thêm dữ liệu vào DataTable
            foreach (var item in monAnTongSoLuong)
            {
                dataTable.Rows.Add(item.Key, item.Value.TenMon, item.Value.TongSoLuong);
            }

            // Sắp xếp DataTable theo tổng số lượng giảm dần
            DataView view = dataTable.DefaultView;
            view.Sort = "Tổng số lượng DESC";
            DataTable sortedTable = view.ToTable();

            return sortedTable;
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
        public bool CapNhatKhachHang(BsonDocument khachHang, string maKhachHang, string maCuaHang)
        {
            var collection = this.GetCollection("CuaHangGiaoThucAnNhanh");

            // Tạo bộ lọc để tìm cửa hàng và khách hàng
            var filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Eq("cua_hang.ma_cua_hang", maCuaHang),
                Builders<BsonDocument>.Filter.ElemMatch("cua_hang.khach_hang", Builders<BsonDocument>.Filter.Eq("ma_khach_hang", maKhachHang))
            );

            // Tạo cập nhật các trường cho khách hàng
            var update = Builders<BsonDocument>.Update
                .Set("cua_hang.khach_hang.$.ten_khach_hang", khachHang["ten_khach_hang"])
                .Set("cua_hang.khach_hang.$.so_dien_thoai", khachHang["so_dien_thoai"])
                .Set("cua_hang.khach_hang.$.dia_chi", khachHang["dia_chi"])
                .Set("cua_hang.khach_hang.$.email", khachHang["email"])
                .Set("cua_hang.khach_hang.$.mat_khau", khachHang["mat_khau"]);

            // Cập nhật khách hàng
            var result = collection.UpdateOne(filter, update);

            return result.ModifiedCount > 0; // Trả về true nếu có bản ghi được cập nhật
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

        // Lấy danh sách món ăn từ MongoDB
        public List<MonAn> GetDanhSachMonAn(string maCuaHang)
        {
            var collection = this.GetCollection("CuaHangGiaoThucAnNhanh");
            var filter = Builders<BsonDocument>.Filter.Eq("cua_hang.ma_cua_hang", maCuaHang);
            var cuaHangDoc = collection.Find(filter).FirstOrDefault();

            if (cuaHangDoc != null && cuaHangDoc.Contains("cua_hang") && cuaHangDoc["cua_hang"].AsBsonDocument.Contains("menu"))
            {
                var menuArray = cuaHangDoc["cua_hang"]["menu"].AsBsonArray;
                List<MonAn> danhSachMonAn = new List<MonAn>();

                foreach (var loaiMon in menuArray)
                {
                    if (loaiMon.AsBsonDocument.Contains("mon_an"))
                    {
                        var monAnArray = loaiMon["mon_an"].AsBsonArray;

                        foreach (var monAnDoc in monAnArray)
                        {
                            var monAn = monAnDoc.AsBsonDocument;
                            if (monAn["hien_thi"].AsBoolean) // Kiểm tra xem món ăn có được hiển thị không
                            {
                                double giaMonDouble = 0;
                                var giaMonValue = monAn["gia_mon"];

                                if (giaMonValue.IsDecimal128)
                                {
                                    giaMonDouble = (double)giaMonValue.AsDecimal128;
                                }
                                else if (giaMonValue.IsDouble)
                                {
                                    giaMonDouble = giaMonValue.AsDouble;
                                }
                                else if (giaMonValue.IsInt32)
                                {
                                    giaMonDouble = giaMonValue.AsInt32;
                                }

                                var newMonAn = new MonAn(
                                    monAn["ma_mon_an"].AsString,
                                    monAn["ten_mon"].AsString,
                                    monAn["hinh_anh"].AsString,
                                    giaMonDouble,
                                    monAn["mo_ta"].AsString,
                                    monAn["hien_thi"].AsBoolean
                                );

                                danhSachMonAn.Add(newMonAn);
                            }
                        }
                    }
                }

                return danhSachMonAn;
            }

            return new List<MonAn>(); // Trả về danh sách rỗng nếu không tìm thấy món ăn
        }

        // Lấy danh sách menu từ MongoDB
        public List<LoaiMonAn> GetDanhSachMenu(string maCuaHang)
        {
            var collection = this.GetCollection("CuaHangGiaoThucAnNhanh");
            var filter = Builders<BsonDocument>.Filter.Eq("cua_hang.ma_cua_hang", maCuaHang);
            var cuaHangDoc = collection.Find(filter).FirstOrDefault();

            if (cuaHangDoc != null && cuaHangDoc.Contains("cua_hang") && cuaHangDoc["cua_hang"].AsBsonDocument.Contains("menu"))
            {
                var menuArray = cuaHangDoc["cua_hang"]["menu"].AsBsonArray;
                List<LoaiMonAn> danhSachMenu = new List<LoaiMonAn>();

                foreach (var loaiMon in menuArray)
                {
                    var loaiMonDoc = loaiMon.AsBsonDocument;
                    var monAnList = new List<MonAn>();
                    if (loaiMonDoc.Contains("mon_an"))
                    {
                        var monAnArray = loaiMonDoc["mon_an"].AsBsonArray;
                        foreach (var monAnDoc in monAnArray)
                        {
                            var monAn = monAnDoc.AsBsonDocument;
                            // Chỉ thêm món ăn nếu nó được hiển thị
                            if (monAn["hien_thi"].AsBoolean)
                            {
                                double giaMonDouble = 0;
                                var giaMonValue = monAn["gia_mon"];

                                if (giaMonValue.IsDecimal128)
                                {
                                    giaMonDouble = (double)giaMonValue.AsDecimal128;
                                }
                                else if (giaMonValue.IsDouble)
                                {
                                    giaMonDouble = giaMonValue.AsDouble;
                                }
                                else if (giaMonValue.IsInt32)
                                {
                                    giaMonDouble = giaMonValue.AsInt32;
                                }
                                var newMonAn = new MonAn(
                                    monAn["ma_mon_an"].AsString,
                                    monAn["ten_mon"].AsString,
                                    monAn["hinh_anh"].AsString,
                                    giaMonDouble,
                                    monAn["mo_ta"].AsString,
                                    monAn["hien_thi"].AsBoolean
                                );

                                monAnList.Add(newMonAn);
                            }
                        }
                    }
                    // Khởi tạo Loại Món
                    var newLoaiMonAn = new LoaiMonAn
                    {
                        MaLoaiMon = loaiMonDoc["ma_loai_mon"].AsString,
                        TenLoaiMon = loaiMonDoc["ten_loai_mon"].AsString,
                        AnhLoaiMon = loaiMonDoc["anh_loai_mon"].AsString,
                        MonAn = monAnList
                    };
                    danhSachMenu.Add(newLoaiMonAn);
                }
                return danhSachMenu;
            }
            return new List<LoaiMonAn>(); // Trả về danh sách rỗng nếu không tìm thấy menu
        }
        public List<MonAn> GetDanhSachMonAnTheoTen(string maCuaHang, string tenMon)
        {
            var collection = this.GetCollection("CuaHangGiaoThucAnNhanh");
            var filter = Builders<BsonDocument>.Filter.Eq("cua_hang.ma_cua_hang", maCuaHang);
            var cuaHangDoc = collection.Find(filter).FirstOrDefault();

            if (cuaHangDoc != null && cuaHangDoc.Contains("cua_hang") && cuaHangDoc["cua_hang"].AsBsonDocument.Contains("menu"))
            {
                var menuArray = cuaHangDoc["cua_hang"]["menu"].AsBsonArray;
                List<MonAn> danhSachMonAn = new List<MonAn>();

                foreach (var loaiMon in menuArray)
                {
                    if (loaiMon.AsBsonDocument.Contains("mon_an"))
                    {
                        var monAnArray = loaiMon["mon_an"].AsBsonArray;

                        foreach (var monAnDoc in monAnArray)
                        {
                            var monAn = monAnDoc.AsBsonDocument;

                            // Kiểm tra tên món ăn có chứa từ khóa tìm kiếm và món có hiển thị không
                            if (monAn["ten_mon"].AsString.IndexOf(tenMon, StringComparison.OrdinalIgnoreCase) >= 0 && monAn["hien_thi"].AsBoolean)
                            {
                                double giaMonDouble = 0;
                                var giaMonValue = monAn["gia_mon"];

                                // Xử lý giá trị gia_mon thành double
                                if (giaMonValue.IsDecimal128)
                                {
                                    giaMonDouble = (double)giaMonValue.AsDecimal128;
                                }
                                else if (giaMonValue.IsDouble)
                                {
                                    giaMonDouble = giaMonValue.AsDouble;
                                }
                                else if (giaMonValue.IsInt32)
                                {
                                    giaMonDouble = giaMonValue.AsInt32;
                                }

                                var newMonAn = new MonAn(
                                    monAn["ma_mon_an"].AsString,
                                    monAn["ten_mon"].AsString,
                                    monAn["hinh_anh"].AsString,
                                    giaMonDouble,
                                    monAn["mo_ta"].AsString,
                                    monAn["hien_thi"].AsBoolean
                                );

                                danhSachMonAn.Add(newMonAn);
                            }
                        }
                    }
                }

                return danhSachMonAn;
            }

            return new List<MonAn>(); // Trả về danh sách rỗng nếu không tìm thấy món ăn
        }

        // Lấy danh sách khách hàng từ MongoDB
        public List<KhachHang> LayDanhSachKhachHang()
        {
            var collection = GetCollection("CuaHangGiaoThucAnNhanh");
            List<KhachHang> danhSachKhachHang = new List<KhachHang>();
            var cuaHangDocs = collection.Find(new BsonDocument()).ToList();

            foreach (var cuaHangDoc in cuaHangDocs)
            {
                // Kiểm tra xem cửa hàng có chứa danh sách khách hàng không
                if (cuaHangDoc.Contains("cua_hang") && cuaHangDoc["cua_hang"].AsBsonDocument.Contains("khach_hang"))
                {
                    var khachHangList = cuaHangDoc["cua_hang"]["khach_hang"].AsBsonArray;

                    // Duyệt qua danh sách khách hàng và chuyển đổi sang đối tượng KhachHang
                    foreach (var khachHangDoc in khachHangList)
                    {
                        var khachHang = new KhachHang
                        {
                            MaKhachHang = khachHangDoc["ma_khach_hang"].AsString,
                            TenKhachHang = khachHangDoc["ten_khach_hang"].AsString,
                            SoDienThoai = khachHangDoc["so_dien_thoai"].AsString,
                            DiaChi = khachHangDoc["dia_chi"].AsString,
                            Email = khachHangDoc["email"].AsString,
                            DiemTichLuyHienCo = khachHangDoc["diem_tich_luy_hien_co"].AsInt32,
                            HoatDong = khachHangDoc["hoat_dong"].AsBoolean,
                            MatKhau = khachHangDoc["mat_khau"].AsString
                        };

                        danhSachKhachHang.Add(khachHang); // Thêm khách hàng vào danh sách
                    }
                }
            }

            // Trả về danh sách khách hàng
            return danhSachKhachHang;
        }
        public KhachHang LayMotKhachHang(string maKhachHang)
        {
            var collection = GetCollection("CuaHangGiaoThucAnNhanh");
            List<KhachHang> danhSachKhachHang = new List<KhachHang>();
            var cuaHangDocs = collection.Find(new BsonDocument()).ToList();

            foreach (var cuaHangDoc in cuaHangDocs)
            {
                // Kiểm tra xem cửa hàng có chứa danh sách khách hàng không
                if (cuaHangDoc.Contains("cua_hang") && cuaHangDoc["cua_hang"].AsBsonDocument.Contains("khach_hang"))
                {
                    var khachHangList = cuaHangDoc["cua_hang"]["khach_hang"].AsBsonArray;

                    // Duyệt qua danh sách khách hàng và chuyển đổi sang đối tượng KhachHang
                    foreach (var khachHangDoc in khachHangList)
                    {
                        if (khachHangDoc["ma_khach_hang"].AsString.Equals(maKhachHang))
                        {
                            var khachHang = new KhachHang
                            {
                                MaKhachHang = khachHangDoc["ma_khach_hang"].AsString,
                                TenKhachHang = khachHangDoc["ten_khach_hang"].AsString,
                                SoDienThoai = khachHangDoc["so_dien_thoai"].AsString,
                                DiaChi = khachHangDoc["dia_chi"].AsString,
                                Email = khachHangDoc["email"].AsString,
                                DiemTichLuyHienCo = khachHangDoc["diem_tich_luy_hien_co"].AsInt32,
                                HoatDong = khachHangDoc["hoat_dong"].AsBoolean,
                                MatKhau = khachHangDoc["mat_khau"].AsString
                            };
                            return khachHang;
                        }
                    }
                }
            }

            // Trả về danh sách khách hàng
            return null;
        }

        // Kiểm tra đăng nhập
        public bool KiemTraDangNhapKhachHang(string maKH, string matKhau)
        {
            List<KhachHang> danhSachKhachHang = LayDanhSachKhachHang();
            KhachHang khachHang = danhSachKhachHang.FirstOrDefault(kh => kh.MaKhachHang == maKH);

            if (khachHang != null && khachHang.MatKhau == matKhau)
            {
                return true;
            }

            return false;
        }

        public List<DonHang> LayDanhSachDonHangCuaKhachHang(string maKH)
        {
            var collection = GetCollection("CuaHangGiaoThucAnNhanh");
            List<DonHang> danhSachDonHang = new List<DonHang>();

            // Tìm tất cả các cửa hàng
            var cuaHangDocs = collection.Find(new BsonDocument()).ToList();

            // Duyệt qua từng cửa hàng
            foreach (var cuaHangDoc in cuaHangDocs)
            {
                // Kiểm tra có trường 'khach_hang'
                if (cuaHangDoc.Contains("cua_hang") && cuaHangDoc["cua_hang"].AsBsonDocument.Contains("khach_hang"))
                {
                    var khachHangList = cuaHangDoc["cua_hang"]["khach_hang"].AsBsonArray;

                    // Duyệt qua từng khách hàng
                    foreach (var khachHangDoc in khachHangList)
                    {
                        // Kiểm tra mã khách hàng
                        if (khachHangDoc["ma_khach_hang"].AsString == maKH)
                        {
                            // Nếu tìm thấy khách hàng, lặp qua đơn hàng của khách hàng
                            if (khachHangDoc["don_hang"] != BsonNull.Value && khachHangDoc["don_hang"].AsBsonArray.Count > 0)
                            {
                                var donHangList = khachHangDoc["don_hang"].AsBsonArray;

                                // Duyệt qua từng đơn hàng
                                foreach (var donHangDoc in donHangList)
                                {
                                    DonHang donHang = new DonHang();
                                    donHang.MaDonHang = donHangDoc["ma_don_hang"].AsString;
                                    donHang.ThoiGianDat = donHangDoc["thoi_gian_dat"].IsBsonDateTime
    ? donHangDoc["thoi_gian_dat"].AsBsonDateTime.ToUniversalTime()
    : DateTime.Parse(donHangDoc["thoi_gian_dat"].AsString);

                                    donHang.ThoiGianGiao = donHangDoc["thoi_gian_giao"].IsBsonDateTime
                                        ? donHangDoc["thoi_gian_giao"].AsBsonDateTime.ToUniversalTime()
                                        : DateTime.Parse(donHangDoc["thoi_gian_giao"].AsString);

                                    donHang.GiamGia = donHangDoc["giam_gia"].AsInt32;
                                    donHang.DiemTichLuySuDung = donHangDoc["diem_tich_luy_su_dung"].AsInt32;
                                    donHang.TongTien = donHangDoc["tong_tien"].IsInt32 ? donHangDoc["tong_tien"].AsInt32 : donHangDoc["tong_tien"].AsDouble;
                                    donHang.SoTienThanhToan = donHangDoc["so_tien_thanh_toan"].IsInt32 ? donHangDoc["so_tien_thanh_toan"].AsInt32 : donHangDoc["so_tien_thanh_toan"].AsDouble;
                                    donHang.TrangThai = donHangDoc["trang_thai"].AsString;
                                    donHang.MonAnDonHang = donHangDoc["mon_an_don_hang"].AsBsonArray.Select(monAnDoc => new MonAnDonHang())
                                        .Select((monAn, index) =>
                                        {
                                            monAn.MaMonAn = donHangDoc["mon_an_don_hang"][index]["ma_mon_an"].AsString;
                                            monAn.TenMon = donHangDoc["mon_an_don_hang"][index]["ten_mon"].AsString;
                                            monAn.Gia = donHangDoc["mon_an_don_hang"][index]["gia"].IsInt32 ? donHangDoc["mon_an_don_hang"][index]["gia"].AsInt32 : donHangDoc["mon_an_don_hang"][index]["gia"].AsDouble;
                                            monAn.SoLuong = donHangDoc["mon_an_don_hang"][index]["so_luong"].IsInt32 ? donHangDoc["mon_an_don_hang"][index]["so_luong"].AsInt32 : (int)donHangDoc["mon_an_don_hang"][index]["so_luong"].AsDouble;
                                            monAn.ThanhTien = donHangDoc["mon_an_don_hang"][index]["thanh_tien"].IsInt32 ? donHangDoc["mon_an_don_hang"][index]["thanh_tien"].AsInt32 : donHangDoc["mon_an_don_hang"][index]["thanh_tien"].AsDouble;
                                            return monAn;
                                        }).ToList();


                                    danhSachDonHang.Add(donHang);
                                }
                            }
                        }
                    }
                }
            }

            return danhSachDonHang;
        }
        public bool ThemDonHang(string maKH, DonHang donHang)
        {
            var collection = GetCollection("CuaHangGiaoThucAnNhanh");

            // Tìm tất cả các cửa hàng
            var cuaHangDocs = collection.Find(new BsonDocument()).ToList();

            // Duyệt qua từng cửa hàng
            foreach (var cuaHangDoc in cuaHangDocs)
            {
                // Kiểm tra xem có khách hàng trong cửa hàng không
                var khachHangList = cuaHangDoc["cua_hang"]["khach_hang"].AsBsonArray;
                foreach (var khachHang in khachHangList)
                {
                    if (khachHang["ma_khach_hang"] == maKH)
                    {
                        // Nếu tìm thấy khách hàng, thêm đơn hàng vào danh sách đơn hàng
                        var donHangList = khachHang["don_hang"].AsBsonArray;

                        // Chuyển đổi đối tượng DonHang thành BsonDocument
                        var donHangDoc = new BsonDocument
                {
                    { "ma_don_hang", donHang.MaDonHang },
                    { "thoi_gian_dat", donHang.ThoiGianDat },
                    { "thoi_gian_giao", donHang.ThoiGianGiao },
                    { "giam_gia", donHang.GiamGia },
                    { "diem_tich_luy_su_dung", donHang.DiemTichLuySuDung },
                    { "tong_tien", donHang.TongTien },
                    { "so_tien_thanh_toan", donHang.SoTienThanhToan },
                    { "trang_thai", donHang.TrangThai },
                    { "mon_an_don_hang", new BsonArray(donHang.MonAnDonHang.Select(m => new BsonDocument
                        {
                            { "ma_mon_an", m.MaMonAn },
                            { "ten_mon", m.TenMon },
                            { "gia", m.Gia },
                            { "so_luong", m.SoLuong },
                            { "thanh_tien", m.ThanhTien }
                        }))
                    }
                };

                        // Thêm đơn hàng vào danh sách đơn hàng
                        donHangList.Add(donHangDoc);

                        // Cập nhật tài liệu cửa hàng
                        var filter = Builders<BsonDocument>.Filter.Eq("_id", cuaHangDoc["_id"]);
                        var update = Builders<BsonDocument>.Update.Set("cua_hang.khach_hang.$[kh].don_hang", donHangList);
                        var options = new UpdateOptions
                        {
                            ArrayFilters = new List<ArrayFilterDefinition<BsonDocument>>
                            {
                                new BsonDocumentArrayFilterDefinition<BsonDocument>(new BsonDocument("kh.ma_khach_hang", maKH))
                            }
                        };

                        collection.UpdateOne(filter, update, options);

                        return true; // Thêm đơn hàng thành công
                    }
                }
            }

            return false; // Không tìm thấy khách hàng
        }
    }
}
