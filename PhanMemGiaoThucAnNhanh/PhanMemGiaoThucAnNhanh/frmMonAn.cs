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

namespace PhanMemGiaoThucAnNhanh
{
    public partial class frmMonAn : Form
    {
        MongoDB_BLL bll = new MongoDB_BLL();
        public frmMonAn()
        {
            InitializeComponent();
            this.Load += FrmMonAn_Load1;
            this.dtgvMonAn.SelectionChanged += DtgvMonAn_SelectionChanged;
            this.cbbLocLoaiMon.SelectedIndexChanged += CbbLocLoaiMon_SelectedIndexChanged;
            this.btnThem.Click += BtnThem_Click;
            this.btnXoa.Click += BtnXoa_Click;
            this.btnLuuDuLieu.Click += BtnLuuDuLieu_Click;
            this.btnSearch.Click += BtnSearch_Click;
        }
        // Tim mon an theo ten
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string tenMon = txtSearch.Text;
            this.btnXoa.Enabled = false;
            this.btnLuuDuLieu.Enabled = false;
            // Tìm kiếm món ăn theo tên
            List<MonAn> list = bll.TimMonAnTheoTen(tenMon);

            // Chuyển đổi danh sách kết quả sang DataTable để hiển thị trên DataGridView
            DataTable dt = new DataTable();
            dt.Columns.Add("ma_mon_an");
            dt.Columns.Add("ten_mon");
            dt.Columns.Add("hinh_anh");
            dt.Columns.Add("gia_mon");
            dt.Columns.Add("mo_ta");
            dt.Columns.Add("hien_thi");
            dt.Columns.Add("image", typeof(Image));
            foreach (var monAn in list)
            {
                dt.Rows.Add(monAn.MaMon, monAn.TenMon, monAn.HinhAnh, monAn.GiaMon, monAn.MoTa, monAn.HienThi);
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string imagePath = dt.Rows[i]["hinh_anh"].ToString();
                string url = Path.Combine(Application.StartupPath, @"Resources\" + imagePath);
                if (File.Exists(url))
                {
                    Image image = Image.FromFile(url);
                    Bitmap b = new Bitmap(100, 150);
                    using (Graphics g = Graphics.FromImage(b))
                    {
                        g.DrawImage(image, 0, 0, 100, 150);
                    }
                    dt.Rows[i]["image"] = b;
                }
                else
                {
                    dt.Rows[i]["image"] = Properties.Resources.icons8_cart_100;
                }
            }

            // Cập nhật DataGridView với dữ liệu tìm kiếm
            dtgvMonAn.DataSource = dt;
            
            dtgvMonAn.Focus();
        }

        private void DtgvMonAn_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgvMonAn.SelectedRows.Count > 0)
            {
                txtMaMonAn.Text = dtgvMonAn.CurrentRow.Cells["ma_mon_an"].Value.ToString();
                txtTenMonAn.Text = dtgvMonAn.CurrentRow.Cells["ten_mon"].Value.ToString();
                txtHinhAnh.Text = dtgvMonAn.CurrentRow.Cells["hinh_anh"].Value.ToString();
                txtGiaMonAn.Text = dtgvMonAn.CurrentRow.Cells["gia_mon"].Value.ToString();
                txtMoTa.Text = dtgvMonAn.CurrentRow.Cells["mo_ta"].Value.ToString();
                cbTrangThai.Text = dtgvMonAn.CurrentRow.Cells["hien_thi"].Value.ToString();

                int rowIndex = dtgvMonAn.SelectedRows[0].Index;
                var imageCellValue = dtgvMonAn.Rows[rowIndex].Cells["image"].Value;

                if (imageCellValue != null && imageCellValue is Image)
                {
                    pictureBoxMonAn.Image = (Image)imageCellValue;
                }
                else
                {
                    pictureBoxMonAn.Image = null;
                }
            }
        }

        // Load form
        private void FrmMonAn_Load1(object sender, EventArgs e)
        {
            loadComboBox();
            this.dtgvMonAn.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.cbbLocLoaiMon.DataSource = bll.LayDanhSachLoaiMonAn("kfc-store-001");
            this.cbbLocLoaiMon.DisplayMember = "TenLoaiMon";
            this.cbbLocLoaiMon.ValueMember = "MaLoaiMon";
            this.cbbLocLoaiMon.SelectedIndex = 0;
            string maLoaiMon = this.cbbLocLoaiMon.SelectedValue.ToString();
            loadDataGridViewMon(maLoaiMon);
            dtgvMonAn.Columns["ma_mon_an"].HeaderText = "Mã món ăn";
            dtgvMonAn.Columns["ten_mon"].HeaderText = "Tên món ăn";
            dtgvMonAn.Columns["image"].HeaderText = "Hình ảnh";
            dtgvMonAn.Columns["gia_mon"].HeaderText = "Giá món";
            dtgvMonAn.Columns["mo_ta"].HeaderText = "Mô tả";
            dtgvMonAn.Columns["hien_thi"].HeaderText = "Hiển thị";
            dtgvMonAn.Columns["hinh_anh"].Visible = false;
            

        }

        // Loc datagridview theo loai mon
        private void CbbLocLoaiMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDataGridViewMon(cbbLocLoaiMon.SelectedValue.ToString());
            this.btnXoa.Enabled = true;
            this.btnLuuDuLieu.Enabled = true;
        }

        // Cap nhat mon an
        private void BtnLuuDuLieu_Click(object sender, EventArgs e)
        {
            if (bll != null && cbbLocLoaiMon.SelectedValue != null && layMonAn() != null)
            {
                if (bll.CapNhatThongTinMonAn("kfc-store-001", cbbLocLoaiMon.SelectedValue.ToString(), layMonAn()))
                {
                    MessageBox.Show("Cập nhật món ăn thành công!");
                    loadDataGridViewMon(cbbLocLoaiMon.SelectedValue.ToString());
                    return;
                }
                else
                {
                    MessageBox.Show("Cập nhật món ăn thất bại!");
                }
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra. Vui lòng kiểm tra lại dữ liệu.");
            }
        }

        // Xoa mon an
        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (bll.XoaMonAn("kfc-store-001", cbbLocLoaiMon.SelectedValue.ToString(), layMonAn()))
            {
                MessageBox.Show("Xoá món ăn thành công!");
                loadDataGridViewMon(cbbLocLoaiMon.SelectedValue.ToString());
                return;
            }
            else
            {
                MessageBox.Show("Xoá món ăn thất bại!");
            }
        }

        // Them mon an
        private void BtnThem_Click(object sender, EventArgs e)
        {

            if (bll.ThemMonAnVaoLoaiMon("kfc-store-001", cbbLocLoaiMon.SelectedValue.ToString(), layMonAn()))
            {
                MessageBox.Show("Thêm món ăn thành công!");
                loadDataGridViewMon(cbbLocLoaiMon.SelectedValue.ToString());
                return;
            }
            else
            {
                MessageBox.Show("Thêm món ăn thất bại!");
            }
        }

        // Load dữ liệu vào DataGridView
        private void loadDataGridViewMon(string maLoaiMon)
        {
            dtgvMonAn.RowTemplate.Height = 150;
            List<BsonDocument> dsMon = bll.GetDanhSachMonByMaLoaiMon(maLoaiMon);
            DataTable dt = new frmLoaiMon().ConvertBsonDocumentListToDataTable(dsMon);
            dt.Columns.Add("image", typeof(Image));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string imagePath = dt.Rows[i]["hinh_anh"].ToString(); 
                string url = Path.Combine(Application.StartupPath, @"Resources\" + imagePath);
                if (File.Exists(url))
                {
                    Image image = Image.FromFile(url);
                    Bitmap b = new Bitmap(100, 150);
                    using (Graphics g = Graphics.FromImage(b))
                    {
                        g.DrawImage(image, 0, 0, 100, 150);
                    }
                    dt.Rows[i]["image"] = b;
                }
                else
                {
                    dt.Rows[i]["image"] = Properties.Resources.icons8_cart_100;
                }
            }


            this.dtgvMonAn.DataSource = dt;            
            dtgvMonAn.Focus();
        }

        // Load dữ liệu vào ComboBox
        private void loadComboBox()
        {
            this.cbbLocLoaiMon.DataSource = bll.LayDanhSachLoaiMonAn("kfc-store-001");
            this.cbbLocLoaiMon.DisplayMember = "TenLoaiMon";
            this.cbbLocLoaiMon.ValueMember = "MaLoaiMon";
            this.cbbLocLoaiMon.SelectedIndex = 0;
        }

        // Lay mon an tu cac textbox va combobox
        private MonAn layMonAn()
        {
            string maMon = txtMaMonAn.Text;
            string tenMon = txtTenMonAn.Text;
            string hinhAnh = txtHinhAnh.Text;
            double giaMon = int.Parse(txtGiaMonAn.Text);
            string moTa = txtMoTa.Text;
            bool trangThai = cbTrangThai.Text == "true" ? true : false;
            return new MonAn(maMon, tenMon, hinhAnh, giaMon, moTa, trangThai);
        }
    }
}
