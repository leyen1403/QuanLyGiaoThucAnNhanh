using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;
using MongoDB.Bson;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace PhanMemGiaoThucAnNhanh
{
    public partial class frmCapNhatThongTinKhachHang : Form
    {
        public string MaCuaHang { get; set; }
        public string MaKhachHang {get; set;}
        
        MongoDB_BLL bll = new MongoDB_BLL();
        public frmCapNhatThongTinKhachHang(string maKhachHang)
        {
            InitializeComponent();
            MaCuaHang = "kfc-store-001";
            MaKhachHang = maKhachHang;
            this.Load += FrmCuaHang_Load;
            btnCapNhat.Click += BtnCapNhat_Click;
        }

        private void BtnCapNhat_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtTenKhachHang.Text.Trim()) || String.IsNullOrEmpty(txtSoDienThoai.Text.Trim()) || String.IsNullOrEmpty(txtDiaChi.Text.Trim()) || String.IsNullOrEmpty(txtEmail.Text.Trim()) || String.IsNullOrEmpty(txtMatKhauDangNhap.Text.Trim()))
            {
                MessageBox.Show("Các giá trị không được để trống !!!");
                return;
            }
            var khachHang = new BsonDocument
            {
                { "ten_khach_hang", txtTenKhachHang.Text },
                { "so_dien_thoai", txtSoDienThoai.Text },
                { "dia_chi", txtDiaChi.Text },
                { "email", txtEmail.Text },
                { "mat_khau", txtMatKhauDangNhap.Text }
            };


            var result = bll.CapNhatKhachHang(khachHang, MaKhachHang, MaCuaHang);
            if (result)
            {
                MessageBox.Show("Cập nhật thành công!");
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!");
            }
            LoadThongTinKhachHang();
            this.Invalidate();
            this.Refresh();
        }

        private void FrmCuaHang_Load(object sender, EventArgs e)
        {
            LoadThongTinKhachHang();
        }

        private void LoadThongTinKhachHang()
        {
            KhachHang kh = bll.LayMotKhachHang(MaKhachHang);
            txtTenKhachHang.Text = kh.TenKhachHang;
            txtDiaChi.Text = kh.DiaChi;
            txtSoDienThoai.Text = kh.SoDienThoai;
            txtDiemTichLuy.Text = kh.DiemTichLuyHienCo.ToString();
            txtEmail.Text = kh.Email;
            txtMatKhauDangNhap.Text = kh.MatKhau;
        }
    }
}
