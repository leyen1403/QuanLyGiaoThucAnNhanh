using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Windows.Forms;

namespace PhanMemGiaoThucAnNhanh
{
    public partial class frmDangNhap : Form
    {
        MongoDB_BLL bll = new MongoDB_BLL();

        public frmDangNhap()
        {
            InitializeComponent();
            this.txt_MatKhau.UseSystemPasswordChar = true;
            loadSuKien();
        }
        private void loadSuKien()
        {
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += FrmDangNhap_Load;
            this.btn_DangNhap.Click += Btn_DangNhap_Click;
            this.cb_HienMatKhau.CheckedChanged += Cb_HienMatKhau_CheckedChanged;
            this.lbl_TaoTaiKhoan.Click += Lbl_TaoTaiKhoan_Click;
            this.btnDangNhapKhachHang.Click += BtnDangNhapKhachHang_Click;
            
        }

        private void BtnDangNhapKhachHang_Click(object sender, EventArgs e)
        {
            string matKhau = txt_MatKhau.Text;
            string tenDN = txt_TenDangNhap.Text;
            if (bll.KiemTraDangNhapKhachHang(tenDN, matKhau) == 1)
            {
                frmDatMon f = new frmDatMon(tenDN);
                this.Hide();
                f.Show();
            }
            else if(bll.KiemTraDangNhapKhachHang(tenDN, matKhau) == 2)
            {
                MessageBox.Show("Tên đăng nhập hoặc tài khoản không chính xác");
                return;
            }
            else
            {
                MessageBox.Show("Tài khoản đã bị khoá, hãy liên hệ cửa hàng để được hỗ trợ");
                return;
            }
        }

        // Tao tai khoan
        private void Lbl_TaoTaiKhoan_Click(object sender, EventArgs e)
        {
            try
            {
                frmDangKy f = new frmDangKy();
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                HienThiLoi(ex);
            }
        }

        // An/hien mat khau
        private void Cb_HienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (txt_MatKhau.UseSystemPasswordChar == true)
            {
                txt_MatKhau.UseSystemPasswordChar = false;
            }
            else
            {
                txt_MatKhau.UseSystemPasswordChar = true;
            }
        }

        // Load form
        private void FrmDangNhap_Load(object sender, EventArgs e)
        {

        }

        // Dang nhap cua hang click
        private void Btn_DangNhap_Click(object sender, EventArgs e)
        {
            if (txt_TenDangNhap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập : " + lbl_TenDangNhap.Text);
                txt_TenDangNhap.Focus();
                return;
            }
            if (txt_MatKhau.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập : " + lbl_MatKhau.Text);
                txt_MatKhau.Focus();
                return;
            }
            string tendangnhap = txt_TenDangNhap.Text;
            string matkhau = txt_MatKhau.Text;
            bool kq = bll.IsValidCuaHang(tendangnhap, matkhau);
            if (kq == true)
            {
                MessageBox.Show("Đăng nhập thành công !!!");
                frmMain f = new frmMain();
                this.Hide();
                f.Show();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc tài khoản không chính xác");
                return;
            }
        }

        // Hien thi loi
        private void HienThiLoi(Exception ex)
        {
            MessageBox.Show("Lỗi: " + ex.Message);
        }


    }
}
