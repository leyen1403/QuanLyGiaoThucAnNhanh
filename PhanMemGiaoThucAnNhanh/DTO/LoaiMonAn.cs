﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LoaiMonAn
    {
        public string MaLoaiMon { get; set; }
        public string TenLoaiMon { get; set; }
        public string AnhLoaiMon { get; set; }
        public List<MonAn> MonAn { get; set; }
        public LoaiMonAn() { }
    }
}
