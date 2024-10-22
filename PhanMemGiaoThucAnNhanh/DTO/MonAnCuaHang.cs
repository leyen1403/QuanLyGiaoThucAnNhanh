using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class MonAnCuaHang
    {
        public string MaLoaiMonAn { get; set; }
        public string MaMonAn { get; set; }
        public string TenMon { get; set; }
        public string HinhAnh { get; set; }
        public double GiaMon { get; set; }
        public string MoTa { get; set; }
        public bool HienThi { get; set; }
        public MonAnCuaHang() { }
        public MonAnCuaHang(string maMonAn, string tenMon, string hinhAnh, double giaMon, string moTa, bool hienThi)
        {
            MaMonAn = maMonAn;
            TenMon = tenMon;
            HinhAnh = hinhAnh;
            GiaMon = giaMon;
            MoTa = moTa;
            HienThi = hienThi;
        }
    }
}
