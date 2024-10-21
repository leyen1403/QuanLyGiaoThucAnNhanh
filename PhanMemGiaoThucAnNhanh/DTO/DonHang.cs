using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DonHang
    {
        public string MaDonHang { get; set; }
        public DateTime ThoiGianDat { get; set; }
        public DateTime ThoiGianGiao { get; set; }
        public int GiamGia { get; set; }
        public int DiemTichLuySuDung { get; set; }
        public double TongTien { get; set; }
        public double SoTienThanhToan { get; set; }
        public string TrangThai { get; set; }
        public List<MonAnDonHang> MonAnDonHang { get; set; }

        public DonHang(string maDonHang, DateTime thoiGianDat, DateTime thoiGianGiao, int giamGia, int diemTichLuySuDung, double tongTien, double soTienThanhToan, string trangThai, List<MonAnDonHang> monAnDonHang)
        {
            MaDonHang = maDonHang;
            ThoiGianDat = thoiGianDat;
            ThoiGianGiao = thoiGianGiao;
            GiamGia = giamGia;
            DiemTichLuySuDung = diemTichLuySuDung;
            TongTien = tongTien;
            SoTienThanhToan = soTienThanhToan;
            TrangThai = trangThai;
            MonAnDonHang = monAnDonHang;
        }
        public DonHang()
        {

        }
    }
}
