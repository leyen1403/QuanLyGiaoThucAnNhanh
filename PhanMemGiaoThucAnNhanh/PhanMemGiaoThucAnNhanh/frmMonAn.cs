using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using System.IO;
using MongoDB.Driver.Core.Operations;
using DTO;
using Amazon.Runtime.Internal.Transform;

namespace PhanMemGiaoThucAnNhanh
{
    public partial class frmMonAn : Form
    {
        string maCuaHang = "kfc-store-001";
        MongoDB_BLL bll = new MongoDB_BLL();
        List<LoaiMonAn> dsLoaiMon = new List<LoaiMonAn>();
        List<MonAnCuaHang> dsMonAn = new List<MonAnCuaHang>();
        public frmMonAn()
        {
            InitializeComponent();
            dsLoaiMon = bll.LayDanhSachLoaiMon();
            dsMonAn = bll.LayDanhSachMonAn();
            dtgvMonAn.ReadOnly = true;
            this.Load += FrmMonAn_Load;
            this.dtgvMonAn.SelectionChanged += DtgvMonAn_SelectionChanged;
            this.btnSearch.Click += BtnSearch_Click;
            this.btnThem.Click += BtnThem_Click;
            this.btnXoa.Click += BtnXoa_Click;
            this.btnLuuDuLieu.Click += BtnLuuDuLieu_Click;
            this.cbbLocLoaiMon.SelectedIndexChanged += CbbLocLoaiMon_SelectedIndexChanged;
        }

        private void CbbLocLoaiMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem giá trị đã được chọn chưa và giá trị có hợp lệ không
            if (cbbLocLoaiMon.SelectedValue != null)
            {
                string maLoai = cbbLocLoaiMon.SelectedValue.ToString();

                // Gọi phương thức để lấy danh sách món ăn theo mã loại
                dsMonAn = bll.LayDanhSachMonAnTheoLoaiMon(maLoai);

                // Kiểm tra danh sách món ăn có được cập nhật không
                if (dsMonAn != null && dsMonAn.Count > 0)
                {
                    // Tải lại DataGridView để hiển thị danh sách món ăn mới
                    loadDataGridView();
                }
                else
                {
                    return;
                }
            }
        }


        private void BtnLuuDuLieu_Click(object sender, EventArgs e)
        {
            string maLoai = cbbLoaiMon.SelectedValue.ToString();
            MonAnCuaHang monAn = new MonAnCuaHang();
            monAn.MaMonAn = txtMaMonAn.Text;
            monAn.TenMon = txtTenMonAn.Text;
            monAn.GiaMon = Convert.ToDouble(txtGiaMonAn.Text);
            monAn.MoTa = txtMoTa.Text;
            monAn.HienThi = Convert.ToBoolean(cbTrangThai.SelectedValue);
            monAn.HinhAnh = txtHinhAnh.Text;
            monAn.MaLoaiMonAn = cbbLoaiMon.SelectedValue.ToString();
            if(bll.CapNhatMonAn(maCuaHang,maLoai, monAn))
            {
                MessageBox.Show("Lưu thành công!");
                dsMonAn = bll.LayDanhSachMonAn();
                loadDataGridView();
            }
            else
            {
                MessageBox.Show("Lưu không thành công!");
                return;
            }
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            string maMonAn = txtMaMonAn.Text;
            string maLoai = cbbLoaiMon.SelectedValue.ToString();
            if (bll.XoaMonAn(maCuaHang ,maMonAn, maLoai))
            {
                MessageBox.Show("Xóa thành công!");
                dsMonAn = bll.LayDanhSachMonAn();
                loadDataGridView();
            }
            else
            {
                MessageBox.Show("Xóa không thành công!");
                return;
            }
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            MonAnCuaHang monAn = new MonAnCuaHang();
            monAn.MaMonAn = txtMaMonAn.Text;
            monAn.TenMon = txtTenMonAn.Text;
            monAn.GiaMon = Convert.ToDouble(txtGiaMonAn.Text);
            monAn.MoTa = txtMoTa.Text;
            monAn.HienThi = Convert.ToBoolean(cbTrangThai.SelectedValue);
            monAn.HinhAnh = txtHinhAnh.Text;
            monAn.MaLoaiMonAn = cbbLoaiMon.SelectedValue.ToString();
            if (bll.ThemMonAnVaoMenu(maCuaHang, monAn.MaLoaiMonAn, monAn))
            {
                MessageBox.Show("Thêm thành công!");
                dsMonAn = bll.LayDanhSachMonAn();
                loadDataGridView();
            }
            else
            {
                MessageBox.Show("Thêm không thành công!");
                return;
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string tenMon = txtSearch.Text;
            dsMonAn = bll.LayDanhSachMonTheoTenMon(tenMon);
            loadDataGridView();
        }

        private void DtgvMonAn_SelectionChanged(object sender, EventArgs e)
        {
            txtMaMonAn.Text = dtgvMonAn.CurrentRow.Cells["MaMonAn"].Value.ToString();
            txtTenMonAn.Text = dtgvMonAn.CurrentRow.Cells["TenMon"].Value.ToString();
            txtGiaMonAn.Text = dtgvMonAn.CurrentRow.Cells["GiaMon"].Value.ToString();
            txtMoTa.Text = dtgvMonAn.CurrentRow.Cells["MoTa"].Value.ToString();
            bool hienThi = Convert.ToBoolean(dtgvMonAn.CurrentRow.Cells["HienThi"].Value);
            cbTrangThai.SelectedValue = hienThi;
            txtHinhAnh.Text = dtgvMonAn.CurrentRow.Cells["HinhAnh"].Value.ToString();
            string imagePath = txtHinhAnh.Text;
            string url = Path.Combine(Application.StartupPath, @"Resources\" + imagePath);
            Image img;
            if (File.Exists(url))
            {
                img = Image.FromFile(url);
            }
            else
            {
                img = Properties.Resources.icons8_folder_35; // Hình ảnh mặc định
            }
            pictureBoxMonAn.Image = img;
            pictureBoxMonAn.SizeMode = PictureBoxSizeMode.StretchImage;
            cbbLoaiMon.SelectedValue = dtgvMonAn.CurrentRow.Cells["MaLoai"].Value.ToString();
        }

        private void FrmMonAn_Load(object sender, EventArgs e)
        {
            loadDataGridView();
            loadComboBox();
        }

        private void loadComboBox()
        {
            cbbLocLoaiMon.DataSource = dsLoaiMon;
            cbbLocLoaiMon.DisplayMember = "TenLoaiMon";
            cbbLocLoaiMon.ValueMember = "MaLoaiMon";

            cbTrangThai.DataSource = new List<KeyValuePair<bool, string>>()
            {
                new KeyValuePair<bool, string>(true, "Hiển thị"),
                new KeyValuePair<bool, string>(false, "Ẩn")
            };

            cbTrangThai.DisplayMember = "Value";
            cbTrangThai.ValueMember = "Key";

            cbbLoaiMon.DataSource = bll.LayDanhSachLoaiMon();
            cbbLoaiMon.DisplayMember = "TenLoaiMon";
            cbbLoaiMon.ValueMember = "MaLoaiMon";
        }

        private void loadDataGridView()
        {
            dtgvMonAn.Columns.Clear();
            // Tạo cột hình ảnh
            DataGridViewImageColumn imgColumn = new DataGridViewImageColumn();
            imgColumn.HeaderText = "Hình ảnh";
            imgColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dtgvMonAn.Columns.Add(imgColumn);

            dtgvMonAn.Columns.Add("MaMonAn", "Mã món ăn");
            dtgvMonAn.Columns.Add("TenMon", "Tên món ăn");
            dtgvMonAn.Columns.Add("GiaMon", "Giá món");
            dtgvMonAn.Columns.Add("MoTa", "Mô tả");
            dtgvMonAn.Columns.Add("HienThi", "Hiển thị");
            dtgvMonAn.Columns.Add("HinhAnh", "Hình ảnh");
            dtgvMonAn.Columns.Add("MaLoai", "Mã loại");
            dtgvMonAn.Columns["MaLoai"].Visible = false;
            dtgvMonAn.RowTemplate.Height = 50;
            foreach (var item in dsMonAn)
            {
                string imagePath = item.HinhAnh;
                string url = Path.Combine(Application.StartupPath, @"Resources\" + imagePath);
                Image img;
                if (File.Exists(url))
                {
                    img = Image.FromFile(url);
                }
                else
                {
                    img = Properties.Resources.icons8_folder_35; // Hình ảnh mặc định
                }
                dtgvMonAn.Rows.Add(img, item.MaMonAn, item.TenMon, item.GiaMon, item.MoTa, item.HienThi, item.HinhAnh, item.MaLoaiMonAn);
            }
        }

        private void cbTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
