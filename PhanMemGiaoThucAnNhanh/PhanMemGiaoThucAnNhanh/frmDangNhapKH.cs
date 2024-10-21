using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanMemGiaoThucAnNhanh
{
    public partial class frmDangNhapKH : Form
    {
        MongoDB_BLL bll = new MongoDB_BLL();
        public frmDangNhapKH()
        {
            InitializeComponent();
            this.btnDangNhap.Click += BtnDangNhap_Click;
            List<KhachHang> dsKhachHang = bll.LayDanhSachKhachHang();
        }

        private void BtnDangNhap_Click(object sender, EventArgs e)
        {
            string tenDN = txtTenDangNhap.Text;
            string matKhau = txtMatKhau.Text;
            if(bll.KiemTraDangNhapKhachHang(tenDN, matKhau))
            {
                frmDatMon f = new frmDatMon(tenDN);
                this.Hide();
                f.Show();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc tài khoản không chính xác");
                return;
            }
        }
    }
}
