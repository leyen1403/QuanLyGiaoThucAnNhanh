using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using MongoDB.Bson;
using MongoDB.Driver;
using DTO;
using System.ComponentModel.Design.Serialization;

namespace BLL
{
    public class MongoDB_BLL
    {
        MongoDB_DAL dal = new MongoDB_DAL();
        public IMongoCollection<BsonDocument> GetAllDocuments(string collectionName)
        {
            return dal.GetCollection(collectionName);
        }

        public void AddDocument(string collectionName, BsonDocument document)
        {
            dal.Insert(collectionName, document);
        }
        //Cửa hàng
        public BsonDocument GetOneCuaHang(string maCuaHang)
        {
            return dal.GetOneCuaHang(maCuaHang);
        }
        public bool IsValidCuaHang(string maCuaHang, string matKhauDangNhap)
        {
            return dal.IsValidCuaHang(maCuaHang, matKhauDangNhap);
        }
        //Cập nhật cửa hàng
        public bool CapNhatCuaHang(BsonDocument cuaHang, string maCuaHang)
        {
            return dal.CapNhatCuaHang(cuaHang, maCuaHang);
        }
        //Cập nhật khách hàng
        public bool CapNhatKhachHang(BsonDocument khachHang, string maKhachHang, string maCuaHang)
        {
            return dal.CapNhatKhachHang(khachHang, maKhachHang, maCuaHang);
        }
        //Loại món
        public List<BsonDocument> GetAllLoaiMon(string maCuaHang)
        {
            return dal.GetLoaiMonFromCuaHang(maCuaHang);
        }
        public bool LuuLoaiMon(DataTable dtDsLoaiMon, string maCuaHang)
        {
            return dal.LuuLoaiMon(dtDsLoaiMon, maCuaHang);
        }
        //Món ăn
        public List<BsonDocument> GetDanhSachMonByMaLoaiMon(string maLoai)
        {
            return dal.GetDanhSachMonByMaLoaiMon(maLoai);
        }

        //Lấy toàn bộ món ăn bao gồm mã loại món
        public List<BsonDocument> GetDanhSachMon()
        {
            return dal.GetDanhSachMon();
        }
        public BsonDocument GetMonAnByMaMon(string maMon)
        {
            return dal.GetMonAnByMaMon(maMon);
        }
        public bool LuuMonAn(DataTable dsMonAn, string maCuaHang, string maLoaiMon)
        {
            return dal.LuuMonAn(dsMonAn, maCuaHang, maLoaiMon);
        }
        public List<LoaiMonAn> LayDanhSachLoaiMonAn(string maCuaHang)
        {
            return dal.LayDanhSachLoaiMonAn(maCuaHang);
        }

        public List<MonAn> TimMonAnTheoTen(string tenMon)
        {
            return dal.TimMonAnTheoTen(tenMon);
        }
        //Thống kê
        public DataTable GetTongTienTheoNgayHoanThanhDataTable()
        {
            return dal.GetTongTienTheoNgayHoanThanhDataTable();
        }
        public DataTable GetTongTienTheoNgayHoanThanhDataTable(string ngay_bat_dau, string ngay_ket_thuc)
        {
            return dal.GetTongTienTheoNgayHoanThanhDataTable(ngay_bat_dau, ngay_ket_thuc);
        }
        public DataTable GetMonAnBanChayDataTable()
        {
            return dal.GetMonAnBanChayDataTable();
        }

        //Lấy toàn bộ món ăn từ cửa hàng
        public List<MonAn> GetDanhSachMonAn(string maCuaHang)
        {
            return dal.GetDanhSachMonAn(maCuaHang);
        }

        // Lấy danh sách món ăn theo tên
        public List<MonAn> GetDanhSachMonAnTheoTen(string maCuaHang, string tenMon)
        {
            return dal.GetDanhSachMonAnTheoTen(maCuaHang, tenMon);
        }

        // Lấy danh sách khách hàng
        public List<KhachHang> LayDanhSachKhachHang()
        {
            return dal.LayDanhSachKhachHang();
        }
        //Lấy một khách hàng
        public KhachHang LayMotKhachHang(string maKH)
        {
            return dal.LayMotKhachHang(maKH);
        }
        public List<KhachHang> LayKhachHangTheoTenHoacMa(string maHoacTenKhachHang)
        {
            return dal.LayKhachHangTheoTenHoacMa(maHoacTenKhachHang);
        }

        // Kiểm tra khách hàng đăng nhập
        public int KiemTraDangNhapKhachHang(string maKH, string matKhau)
        {
            return dal.KiemTraDangNhapKhachHang(maKH, matKhau);
        }

        // Lấy danh sách đơn hàng của khách hàng
        public List<DonHang> LayDanhSachDonHangCuaKhachHang(string maKH)
        {
            return dal.LayDanhSachDonHangCuaKhachHang(maKH);
        }

        // Lấy số lượng đơn hàng của khách hàng
        public int SoLuongDonHangCuaKhachHang(string maKH)
        {
            return LayDanhSachDonHangCuaKhachHang(maKH).Count;
        }

       

        // Thêm đơn hàng
        public bool ThemDonHang(string maKH, DonHang donHang)
        {
            return dal.ThemDonHang(maKH, donHang);
        }

        // Lấy danh sách loại món ăn từ MongoDB
        public List<LoaiMonAn> LayDanhSachLoaiMon()
        {
            return dal.LayDanhSachLoaiMon();
        }

        // Lấy danh sách món ăn từ cửa hàng
        public List<MonAnCuaHang> LayDanhSachMonAn()
        {
            return dal.LayDanhSachMonAn();
        }

        // Lấy danh sách món ăn từ cửa hàng theo tên món
        public List<MonAnCuaHang> LayDanhSachMonTheoTenMon(string tenMon)
        {
            return dal.LayDanhSachMonTheoTenMon(tenMon);
        }

        //Thêm mới món ăn vào menu
        public bool ThemMonAnVaoMenu(string maCuaHang, string maLoaiMon, MonAnCuaHang monAnMoi)
        {
            return dal.ThemMonAnVaoMenu(maCuaHang, maLoaiMon, monAnMoi);
        }

        //Xoá món ăn
        public bool XoaMonAn(string maCuaHang, string maMonAn, string maLoai)
        {
            return dal.XoaMonAn(maCuaHang, maMonAn, maLoai);
        }

        //Cập nhật món ăn
        public bool CapNhatMonAn(string maCuahang, string maLoai, MonAnCuaHang monAn)
        {
            return dal.CapNhatMonAn(maCuahang, maLoai, monAn);
        }

        //Lấy danh sách món ăn từ cửa hàng theo mã loại món
        public List<MonAnCuaHang> LayDanhSachMonAnTheoLoaiMon(string maLoai)
        {
            List<MonAnCuaHang> dsMonAn = LayDanhSachMonAn();
            
            return dsMonAn.Where(m=>m.MaLoaiMonAn == maLoai).ToList();
        }

        // Tạo tài khoản khách hàng
        public bool TaoTaiKhoanKhachHang(string maCuaHang, KhachHang kh)
        {
            return dal.TaoTaiKhoanKhachHang(maCuaHang, kh);
        }
        
        //Xóa khách hàng
        public bool XoaKhachHang(string maCuaHang, string maKhachHang)
        {
            return dal.XoaKhachHang(maCuaHang, maKhachHang);
        }

        //Cập nhật khách hàng
        public bool CapNhatKhachHang(string maCuahang, KhachHang khachHang)
        {
            return dal.CapNhatKhachHang(maCuahang, khachHang);
        }
        
        public List<DonHang> LayToanBoDanhSachDonHang()
        {
            return dal.LayToanBoDanhSachDonHang();
        }
        
        //TÌm thông tin đơn hàng theo mã khách hàng
        public List<DonHang> TimDonHangTheoMaKhachHang(string maKH)
        {
            return dal.TimDonHangTheoMaKhachHang(maKH);
        }


        // Tìm đơn hàng theo tình trạng
        public List<DonHang> TimDonHangTheoTinhTrang(string tinhTrang)
        {
            return dal.TimDonHangTheoTinhTrang(tinhTrang);
        }



        // Cập nhật trạng thái món ăn
        public bool CapNhatTrangThaiDonHang(string maCuaHang, string maKhachHang, string maDonHang, string trangThaiMoi)
        {
            return dal.CapNhatTrangThaiDonHang(maCuaHang, maKhachHang, maDonHang, trangThaiMoi);
        }

        public string TimMaKhachHangTheoMaDonHang(string maCuaHang, string maDonHang)
        {
            return dal.TimMaKhachHangTheoMaDonHang(maCuaHang, maDonHang);
        }
        public List<PHIEUBAOCAO> LayPhieuBaoCao(string maCuaHang, string ngayBatDau, string ngayKetThuc)
        {
            return dal.LayPhieuBaoCao(maCuaHang,ngayBatDau,ngayKetThuc);
        }

        // cập nhật đơn hàng
        public bool CapNhatDonHang(string maCuaHang, string maKhachHang, string maDonHang, DonHang donHangMoi)
        {
            return dal.CapNhatDonHang(maCuaHang, maKhachHang, maDonHang, donHangMoi);
        }

    }
}
