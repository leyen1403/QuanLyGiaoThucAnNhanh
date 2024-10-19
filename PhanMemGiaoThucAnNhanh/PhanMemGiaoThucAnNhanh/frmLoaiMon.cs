using BLL;
using MongoDB.Bson;
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

namespace PhanMemGiaoThucAnNhanh
{
    public partial class frmLoaiMon : Form
    {
        public string MaCuaHang = new frmMain().MaCuaHang;
        MongoDB_BLL bll = new MongoDB_BLL();
        public frmLoaiMon()
        {
            InitializeComponent();
            this.Load += FrmLoaiMon_Load;
            btnThem.Click += BtnThem_Click;
            btnXoa.Click += BtnXoa_Click;
            btnLuuDuLieu.Click += BtnLuuDuLieu_Click;
            btnHuyThem.Click += BtnHuyThem_Click;
            dtgvTTLH.SelectionChanged += DtgvTTLH_SelectionChanged;
            btnTaiAnh.Click += BtnTaiAnh_Click;
        }

        private void BtnTaiAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif"; // Bộ lọc tệp hình ảnh
                openFileDialog.Title = "Hãy chọn ảnh";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    pictureBoxLoaiMon.Image = Image.FromFile(filePath); // Tải ảnh vào PictureBox
                }
            }
        }

        private void DtgvTTLH_SelectionChanged(object sender, EventArgs e)
        {
            txtMALH.Text = dtgvTTLH.CurrentRow.Cells["ma_loai_mon"].Value.ToString();
            txtTENLH.Text = dtgvTTLH.CurrentRow.Cells["ten_loai_mon"].Value.ToString();
            pictureBoxLoaiMon.Image = (Image)dtgvTTLH.CurrentRow.Cells["hinh_anh"].Value;
        }

        private void BtnHuyThem_Click(object sender, EventArgs e)
        {

        }

        private void BtnLuuDuLieu_Click(object sender, EventArgs e)
        {

        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {

        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text == "Thêm")
            {
                btnThem.Text = "Xác nhận thêm";
                btnHuyThem.Visible = true;
                txtMALH.Text = String.Empty;
                txtTENLH.Text = String.Empty;
                pictureBoxLoaiMon.Image = null;
            }
            else
            {
                btnThem.Text = "Thêm";
                btnHuyThem.Visible = false;
            }
        }

        private void FrmLoaiMon_Load(object sender, EventArgs e)
        {
            btnHuyThem.Visible = false;
            loadDataGridViewLoaiMon();
        }

        public void loadDataGridViewLoaiMon()
        {
            // Lấy danh sách các loại món từ cơ sở dữ liệu
            List<BsonDocument> dsLoaiMonBson = bll.GetAllLoaiMon(MaCuaHang);

            // Chuyển danh sách BsonDocument thành DataTable
            DataTable dtDsLoaiMon = ConvertBsonDocumentListToDataTable(dsLoaiMonBson);

            // Thêm cột hình ảnh vào DataTable
            dtDsLoaiMon.Columns.Add("hinh_anh", typeof(Image));

            // Vòng lặp qua các hàng để thêm hình ảnh
            for (int i = 0; i < dtDsLoaiMon.Rows.Count; i++)
            {
                string imagePath = dtDsLoaiMon.Rows[i]["anh_loai_mon"].ToString(); // Giả sử cột chứa đường dẫn là "DuongDanHinh"
                string url = Path.Combine(Application.StartupPath, @"Resources\" + imagePath);

                if (File.Exists(url))
                {
                    // Nếu tệp hình ảnh tồn tại, tải và gán hình ảnh cho cột "hinh_anh"
                    Image image = Image.FromFile(url);
                    Bitmap b = new Bitmap(100, 150);
                    using (Graphics g = Graphics.FromImage(b))
                    {
                        g.DrawImage(image, 0, 0, 100, 150);
                    }
                    dtDsLoaiMon.Rows[i]["hinh_anh"] = b;
                }
                else
                {
                    // Nếu không, đặt hình ảnh mặc định
                    dtDsLoaiMon.Rows[i]["hinh_anh"] = Properties.Resources.icons8_cart_100; // Hình ảnh mặc định
                }
            }

            // Gán DataTable vào DataGridView
            dtgvTTLH.DataSource = dtDsLoaiMon;
            dtgvTTLH.Columns["anh_loai_mon"].Visible = false;
            dtgvTTLH.Columns["mon_an"].Visible = false;
            dtgvTTLH.Columns[0].HeaderText = "Mã loại món";
            dtgvTTLH.Columns[1].HeaderText = "Tên loại món";
            dtgvTTLH.Columns["hinh_anh"].HeaderText = "Hình ảnh";
            // Đặt chiều cao dòng
            dtgvTTLH.RowTemplate.Height = 150;

            // Cập nhật giao diện
            dtgvTTLH.Invalidate();
            dtgvTTLH.Refresh();
        }
        
        public DataTable ConvertBsonDocumentListToDataTable(List<BsonDocument> bsonDocuments)
        {
            DataTable dataTable = new DataTable();

            if (bsonDocuments.Count > 0)
            {
                // Thêm các cột vào DataTable
                foreach (var key in bsonDocuments[0].Names)
                {
                    dataTable.Columns.Add(key);
                }

                // Thêm các hàng vào DataTable
                foreach (var doc in bsonDocuments)
                {
                    DataRow row = dataTable.NewRow();

                    foreach (var key in doc.Names)
                    {
                        // Kiểm tra kiểu dữ liệu và gán giá trị tương ứng
                        row[key] = doc[key].ToString(); // Hoặc có thể chuyển đổi kiểu dữ liệu phù hợp
                    }

                    dataTable.Rows.Add(row);
                }
            }

            return dataTable;
        }
    }
}
