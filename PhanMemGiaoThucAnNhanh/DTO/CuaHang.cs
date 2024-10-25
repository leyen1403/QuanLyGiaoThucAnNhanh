using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CuaHang
    {
        public string MaCuaHang { get; set; }
        public string TenCuaHang { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }

        public List<LoaiMonAn> Menu { get; set; } = new List<LoaiMonAn>(); // Khởi tạo danh sách
        public CuaHang () { }
    }
}
