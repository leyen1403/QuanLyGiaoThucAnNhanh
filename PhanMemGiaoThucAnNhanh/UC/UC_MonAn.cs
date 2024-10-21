using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using System.Runtime.CompilerServices;

namespace UC
{
    public partial class UC_MonAn: UserControl
    {
        string maMon;
        public string MaMon { get => maMon; set => maMon = value; }
        public string TenMonAn
        {
            get => lblTenMonAn.Text;
            set => lblTenMonAn.Text = value;
        }        
        public string MoTa
        {
            get => lblMoTa.Text;
            set => lblMoTa.Text = value;
        }
        public double Gia
        {
            get
            {
                double gia;
                if (double.TryParse(lblGiaMonAn.Text, out gia))
                {
                    return gia;
                }
                return 0; // Hoặc một giá trị mặc định khi có lỗi chuyển đổi
            }
            set => lblGiaMonAn.Text = value.ToString("N0");
        }
        public int SoLuong
        {
            get
            {
                int soLuong;
                if (int.TryParse(lbl_SoLuongDaChon.Text, out soLuong))
                {
                    return soLuong;
                }
                return 0; // Giá trị mặc định nếu có lỗi
            }
            set => lbl_SoLuongDaChon.Text = value.ToString("N0"); // Hiển thị phân cách hàng nghìn
        }

        public Image HinhAnh
        {
            get { return ptbHinhAnh.Image; }
            set
            {
                ptbHinhAnh.Image = value;
                ptbHinhAnh.SizeMode = PictureBoxSizeMode.StretchImage; // Đặt chế độ lấp đầy hình ảnh
            }
        }
        public EventHandler TangSoLuong;
        public EventHandler GiamSoLuong;
        public UC_MonAn()
        {
            InitializeComponent();
            this.Load += UC_MonAn_Load;
            this.btnTang.Click += BtnTang_Click;
            this.btnGiam.Click += BtnGiam_Click;            
        }

        private void BtnGiam_Click(object sender, EventArgs e)
        {
            SoLuong--;
            if(SoLuong < 0)
            {
                SoLuong = 0;
            }
            this.GiamSoLuong?.Invoke(this, EventArgs.Empty);
        }

        private void BtnTang_Click(object sender, EventArgs e)
        {
            SoLuong++;
            this.TangSoLuong?.Invoke(this, EventArgs.Empty);
        }

        private void UC_MonAn_Load(object sender, EventArgs e)
        {
            
        }
    }
}
