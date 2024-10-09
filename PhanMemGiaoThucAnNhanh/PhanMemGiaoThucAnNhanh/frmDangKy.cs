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
        public frmDangKy()
        {
            InitializeComponent();
            loadSuKien();
        }

        private void loadSuKien()
        {
            this.Text = "Đăng ký tài khoản";
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += FrmDangKy_Load;
            this.cb_HienMatKhau.CheckedChanged += Cb_HienMatKhau_CheckedChanged;
            this.btn_DangKy.Click += Btn_DangKy_Click;
            this.btn_Xoa.Click += Btn_Xoa_Click;
        }

        // Xoa thong tin nhap
        private void Btn_Xoa_Click(object sender, EventArgs e)
        {
            txt_TenDangNhap.Text = "";
            txt_MatKhau.Text = "";
            txt_NhapLaiMatKhau.Text = "";
            txt_TenDangNhap.Focus();
        }

        // Dang ky tai khoan
        private void Btn_DangKy_Click(object sender, EventArgs e)
        {
            if (txt_TenDangNhap.Text == "" || txt_MatKhau.Text == "" || txt_NhapLaiMatKhau.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txt_MatKhau.Text != txt_NhapLaiMatKhau.Text)
            {
                MessageBox.Show("Mật khẩu không trùng khớp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                // Kiem tra ten dang nhap da ton tai chua                 
            }
            catch (Exception ex)
            {
                HienThiLoi(ex);
            }
        }

        //Hien thi loi khi xay ra exception
        private void HienThiLoi(Exception ex)
        {
            MessageBox.Show("Lỗi\n" + ex.Message);
        }

        // An/Hien mat khau
        private void Cb_HienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if(cb_HienMatKhau.Checked)
            {
                txt_MatKhau.PasswordChar = '\0';
                txt_NhapLaiMatKhau.PasswordChar = '\0';
            }
            else
            {
                txt_MatKhau.PasswordChar = '*';
                txt_NhapLaiMatKhau.PasswordChar = '*';
            }
        }

        // Load form
        private void FrmDangKy_Load(object sender, EventArgs e)
        {
            
        }
    }
}
