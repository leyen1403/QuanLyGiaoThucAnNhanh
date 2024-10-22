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
    public partial class frmDangKy : Form
    {
        string maCuaHang = "kfc-store-001";
        MongoDB_BLL bll = new MongoDB_BLL();
        public frmDangKy()
        {
            InitializeComponent();
            this.Load += FrmDangKy_Load;
            this.cbHienMatKhau.CheckedChanged += CbHienMatKhau_CheckedChanged;
            btnDangKy.Click += BtnDangKy_Click;
        }

        private void BtnDangKy_Click(object sender, EventArgs e)
        {
            string tenDN = txt_TenDangNhap.Text;
            string matKhau = txtMatKhau.Text;
            string nhapLaiMK = txtNhapLaiMK.Text;
            if (matKhau != nhapLaiMK)
            {
                MessageBox.Show("Mật khẩu không trùng khớp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string HoTen = txtHoTen.Text;
            string std = txtSDT.Text;
            string email = txtEmail.Text;
            string diaChi = txtDiaChi.Text;
            if (tenDN == "" || matKhau == "" || HoTen == "" || std == "" || email == "" || diaChi == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            KhachHang kh = new KhachHang();
            kh.MaKhachHang = tenDN;
            kh.MatKhau = matKhau;
            kh.TenKhachHang = HoTen;
            kh.DiaChi = diaChi;
            kh.Email = email;
            kh.HoatDong = true;
            kh.DiemTichLuyHienCo = 0;
            kh.SoDienThoai = txtSDT.Text;
            if (bll.TaoTaiKhoanKhachHang(maCuaHang, kh))
            {
                MessageBox.Show("Đăng ký thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Đăng ký thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CbHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if(txtMatKhau.UseSystemPasswordChar == true)
            {
                txtMatKhau.UseSystemPasswordChar = false;
                txtNhapLaiMK.UseSystemPasswordChar = false;
            }
            else
            {
                txtMatKhau.UseSystemPasswordChar = true;
                txtNhapLaiMK.UseSystemPasswordChar = true;
            }
        }

        private void FrmDangKy_Load(object sender, EventArgs e)
        {
            // Thiết lập hiển thị mật khẩu trong TextBox
            txtMatKhau.UseSystemPasswordChar = true;
            txtNhapLaiMK.UseSystemPasswordChar = true;
        }
    }
}
