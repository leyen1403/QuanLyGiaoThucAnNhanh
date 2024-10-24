using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PHIEUBAOCAO
    {
        public string STT { get; set; }
        public string MAMONAN {  get; set; }
        public string TENMONAN { get; set; }
        public int SOLUONG { get; set; }
        public double DONGIA { get; set; }
        public double THANHTIEN { get; set; }
        
        public DateTime NGAY { get; set; }
        public PHIEUBAOCAO()
        {

        }
    }
}
