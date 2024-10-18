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
        }

        private void FrmLoaiMon_Load(object sender, EventArgs e)
        {
            btnHuyThem.Visible = false;
            loadDataGridViewLoaiMon();
        }

        private void loadDataGridViewLoaiMon()
        {
            // Lấy danh sách các loại món từ cơ sở dữ liệu
            List<BsonDocument> dsLoaiMonBson = bll.GetAllLoaiMon(MaCuaHang);

            // Chuyển danh sách BsonDocument thành DataTable
            DataTable dtDsLoaiMon = ConvertBsonDocumentListToDataTable(dsLoaiMonBson);

            // Gán DataTable vào DataGridView trước
            dtgvTTLH.DataSource = dtDsLoaiMon;

            // Thêm cột hình ảnh vào DataGridView
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn.HeaderText = "Hình Ảnh";
            imageColumn.Name = "hinh_anh";
            imageColumn.Width = 150;
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;  // Đặt chế độ hiển thị hình ảnh
            dtgvTTLH.Columns.Add(imageColumn);  // Thêm cột hình ảnh

            // Vòng lặp qua các hàng để thêm hình ảnh
            for (int i = 0; i < dtgvTTLH.Rows.Count - 1; i++)
            {
                // Kiểm tra giá trị trong cột chứa đường dẫn hình ảnh (giả sử cột 2 chứa đường dẫn)
                string imagePath = dtgvTTLH.Rows[i].Cells[2].Value.ToString();
                string url = Path.Combine(Application.StartupPath, @"Resources\" + imagePath);

                if (File.Exists(url))
                {
                    // Nếu tệp hình ảnh tồn tại, tải và gán hình ảnh cho cột "hinh_anh"
                    Image image = Image.FromFile(url);
                    dtgvTTLH.Rows[i].Cells[4].Value = image;
                }
                else
                {
                    // Nếu tệp hình ảnh không tồn tại, đặt hình ảnh mặc định hoặc null
                    dtgvTTLH.Rows[i].Cells["hinh_anh"].Value = null;  // Có thể thay thế bằng hình ảnh mặc định nếu muốn
                }
            }
        }

        private void loadHinhAnhDataGridView()
        {

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
