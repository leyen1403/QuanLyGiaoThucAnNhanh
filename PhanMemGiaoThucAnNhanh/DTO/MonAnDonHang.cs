using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class MonAnDonHang
    {
        public string MaMonAn { get; set; }
        public string TenMon { get; set; }
        public string HinhAnh { get; set; }
        public double Gia { get; set; }
        public int SoLuong { get; set; }
        public double ThanhTien { get; set; }
        public string MoTa { get; set; }

        public MonAnDonHang(string maMonAn, string tenMon, string hinhAnh, double gia, int soLuong, double thanhTien, string moTa)
        {
            MaMonAn = maMonAn;
            TenMon = tenMon;
            HinhAnh = hinhAnh;
            Gia = gia;
            SoLuong = soLuong;
            ThanhTien = thanhTien;
            MoTa = moTa;
        }
        public MonAnDonHang()
        {

        }
    }
}
