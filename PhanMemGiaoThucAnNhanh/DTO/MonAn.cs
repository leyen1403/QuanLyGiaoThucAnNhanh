using MongoDB.Driver.Core.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class MonAn
    {
        public string MaMon { get; set; }
        public string TenMon { get; set; }
        public string HinhAnh { get; set; }
        public double GiaMon { get; set; }
        public string MoTa { get; set; }
        public bool HienThi { get; set; }
        public MonAn(string maMon, string tenMon, string hinhAnh, double giaMon, string moTa, bool hienThi)
        {
            MaMon = maMon;
            TenMon = tenMon;
            HinhAnh = hinhAnh;
            GiaMon = giaMon;
            MoTa = moTa;
            HienThi = hienThi;
        }
    }
}
