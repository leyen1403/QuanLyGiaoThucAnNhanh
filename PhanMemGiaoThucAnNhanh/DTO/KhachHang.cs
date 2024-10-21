using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhachHang
    {
        public string MaKhachHang { get; set; }
        public string TenKhachHang { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public int DiemTichLuyHienCo { get; set; }
        public bool HoatDong { get; set; }
        public string MatKhau { get; set; }
        public List<DonHang> DonHang { get; set; }

        public KhachHang(string maKhachHang, string tenKhachHang, string soDienThoai, string diaChi, string email, int diemTichLuyHienCo, bool hoatDong, string matKhau, List<DonHang> donHang)
        {
            MaKhachHang = maKhachHang;
            TenKhachHang = tenKhachHang;
            SoDienThoai = soDienThoai;
            DiaChi = diaChi;
            Email = email;
            DiemTichLuyHienCo = diemTichLuyHienCo;
            HoatDong = hoatDong;
            MatKhau = matKhau;
            DonHang = donHang;
        }
        public KhachHang()
        {

        }
    }
}
