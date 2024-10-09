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
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
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
            this.btn_Xoa.Click += Btn_Xoa_Click;
        }

        // Xoa thong tin dang nhap
        private void Btn_Xoa_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                HienThiLoi(ex);
            }
        }

        // Tao tai khoan
        private void Lbl_TaoTaiKhoan_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                HienThiLoi(ex);
            }
        }

        // An/hien mat khau
        private void Cb_HienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_HienMatKhau.Checked)
            {
                txt_MatKhau.PasswordChar = '\0';
            }
            else
            {
                txt_MatKhau.PasswordChar = '*';
            }
        }

        // Load form
        private void FrmDangNhap_Load(object sender, EventArgs e)
        {

        }

        // Dang nhap click
        private void Btn_DangNhap_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đăng nhập thành công");
        }

        // Hien thi loi
        private void HienThiLoi(Exception ex)
        {
            MessageBox.Show("Lỗi: " + ex.Message);
        }

        // Tai su kien

    }
}
