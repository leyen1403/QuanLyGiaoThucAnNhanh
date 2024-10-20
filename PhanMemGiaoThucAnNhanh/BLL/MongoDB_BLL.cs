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
        public bool CapNhatCuaHang(BsonDocument cuaHang, string maCuaHang)
        {
            return dal.CapNhatCuaHang(cuaHang, maCuaHang);
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
        public bool ThemMonAnVaoLoaiMon(string maCuaHang, string maLoai, MonAn monAn)
        {
            return dal.ThemMonAnVaoLoaiMon(maCuaHang, maLoai, monAn);
        }
        public bool XoaMonAn(string maCuaHang, string maLoai, MonAn monAn)
        {
            return dal.XoaMonAn(maCuaHang, maLoai, monAn);
        }
        public bool CapNhatThongTinMonAn(string maCuaHang, string maLoai, MonAn monAn)
        {
            return dal.CapNhatThongTinMonAn(maCuaHang, maLoai, monAn);
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
    }
}
