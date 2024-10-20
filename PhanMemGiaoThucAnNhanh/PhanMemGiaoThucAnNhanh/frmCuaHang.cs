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
using MongoDB.Bson;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace PhanMemGiaoThucAnNhanh
{
    public partial class frmCuaHang : Form
    {
        string maCuaHang = "kfc-store-001";
        MongoDB_BLL bll = new MongoDB_BLL();
        public frmCuaHang()
        {
            InitializeComponent();
            this.Load += FrmCuaHang_Load;
            btnCapNhat.Click += BtnCapNhat_Click;
        }

        private void BtnCapNhat_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtTenCuaHang.Text.Trim()) || String.IsNullOrEmpty(txtSoDienThoai.Text.Trim()) || String.IsNullOrEmpty(txtDiaChi.Text.Trim()) || String.IsNullOrEmpty(txtEmail.Text.Trim()) || String.IsNullOrEmpty(txtHinhAnhThuongHieu.Text.Trim()) || String.IsNullOrEmpty(txtMatKhauDangNhap.Text.Trim()) )
            {
                MessageBox.Show("Các giá trị không được để trống !!!");
                return;
            }
            string dangHoatDong = cbbTrangThaiHoatDong.SelectedValue.ToString();
            var cuaHang = new BsonDocument
            {
                { "cua_hang", new BsonDocument
                    {
                        { "ten_cua_hang", txtTenCuaHang.Text },
                        { "so_dien_thoai", txtSoDienThoai.Text },
                        { "dia_chi", txtDiaChi.Text },
                        { "email", txtEmail.Text },
                        { "hinh_anh_dai_dien", txtHinhAnhThuongHieu.Text },
                        { "mat_khau_dang_nhap", txtMatKhauDangNhap.Text },
                        { "dang_hoat_dong", dangHoatDong }
                    }
                }
            };

            var result = bll.CapNhatCuaHang(cuaHang, maCuaHang);
            if (result)
            {
                MessageBox.Show("Cập nhật thành công!");
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!");
            }
            LoadThongTinCuaHang();
            this.Invalidate();
            this.Refresh();
        }

        private void FrmCuaHang_Load(object sender, EventArgs e)
        {
            LoadThongTinCuaHang();
        }

        private void LoadThongTinCuaHang()
        {
            pictureBoxLogoThuongHieu.SizeMode = PictureBoxSizeMode.StretchImage;
            var cuaHang = bll.GetOneCuaHang(maCuaHang);
            var tenCuaHang = cuaHang["cua_hang"]["ten_cua_hang"];
            var soDienThoai = cuaHang["cua_hang"]["so_dien_thoai"];
            var diaChi = cuaHang["cua_hang"]["dia_chi"];
            var email = cuaHang["cua_hang"]["email"];
            var matkhau = cuaHang["cua_hang"]["mat_khau_dang_nhap"];
            var hinhAnhDaiDien = cuaHang["cua_hang"]["hinh_anh_dai_dien"];
            var trangThaiHoatDong = cuaHang["cua_hang"]["dang_hoat_dong"];
            txtDiaChi.Text = diaChi.ToString();
            txtSoDienThoai.Text = soDienThoai.ToString();
            txtTenCuaHang.Text = tenCuaHang.ToString();
            txtEmail.Text = email.ToString();
            txtMatKhauDangNhap.Text = matkhau.ToString();
            txtHinhAnhThuongHieu.Text = hinhAnhDaiDien.ToString();
            LoadComboBoxTrangThai();
            if (trangThaiHoatDong.ToString() == "True")
            {
                cbbTrangThaiHoatDong.SelectedIndex = 0;
            }
            else
            {
                cbbTrangThaiHoatDong.SelectedIndex = 1;
            }
            string imagePath = hinhAnhDaiDien.ToString(); // Giả sử cột chứa đường dẫn là "DuongDanHinh"
            string url = Path.Combine(Application.StartupPath, @"Resources\" + imagePath);

            if (File.Exists(url))
            {
                // Nếu tệp hình ảnh tồn tại, tải và gán hình ảnh cho cột "hinh_anh"
                Image image = Image.FromFile(url);
                pictureBoxLogoThuongHieu.Image = image;
            }
            else
            {
                // Nếu không, đặt hình ảnh mặc định
                pictureBoxLogoThuongHieu.Image = Properties.Resources.icons8_save_35;
            }
        }

        private void LoadComboBoxTrangThai()
        {
            // Tạo DataTable
            DataTable dtTrangThai = new DataTable();
            dtTrangThai.Columns.Add("Value", typeof(bool)); // Cột chứa giá trị true/false
            dtTrangThai.Columns.Add("Display", typeof(string)); // Cột hiển thị

            // Thêm dữ liệu vào DataTable
            dtTrangThai.Rows.Add(true, "Hoạt động");
            dtTrangThai.Rows.Add(false, "Không hoạt động");

            // Thiết lập DataSource cho ComboBox
            cbbTrangThaiHoatDong.DataSource = dtTrangThai;
            cbbTrangThaiHoatDong.DisplayMember = "Display"; // Cột hiển thị
            cbbTrangThaiHoatDong.ValueMember = "Value"; // Cột giá trị

        }
    }
}
