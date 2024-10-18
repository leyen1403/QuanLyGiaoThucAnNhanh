using BLL;
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
           List<BsonDocument> dsLoaiMonBSon = bll.GetAllLoaiMon(MaCuaHang);
            DataTable dtDsLoaiMon = new DataTable();
            dtDsLoaiMon = ConvertBsonDocumentListToDataTable(dsLoaiMonBSon);
            //dtgvTTLH.AllowUserToAddRows = false;
            dtgvTTLH.DataSource = dtDsLoaiMon;
            dtgvTTLH.Columns[3].Visible = false;
            // Giả sử bạn đã tạo DataGridView tên là dataGridView1

            // Thêm cột cho hình ảnh
            DataGridViewImageColumn imgColumn = new DataGridViewImageColumn();
            imgColumn.HeaderText = "Ảnh Loại Món";
            imgColumn.Name = "anh_loai_mon";
            dtgvTTLH.Columns.Add(imgColumn);

            // Thêm dữ liệu vào DataGridView
            dtgvTTLH.Rows.Add(); // Thêm hàng mới

            // Đặt hình ảnh từ Resources
            dtgvTTLH.Rows[0].Cells["anh_loai_mon"].Value = Properties.Resources.icons8_delete_35; // Thay thế "tên_hình_ảnh" bằng tên bạn đã đặt trong Resources

            // Lặp lại nếu cần thêm nhiều hàng
            dtgvTTLH.Rows.Add();
            dtgvTTLH.Rows[1].Cells["anh_loai_mon"].Value = Properties.Resources.icons8_delete_35; // Hình ảnh khác

            //loadHinhAnhDataGridView();
        }
        private void loadHinhAnhDataGridView()
        {
            // Duyệt qua từng dòng trong DataGridView
            for (int i = 0; i < dtgvTTLH.Rows.Count; i++)
            {
                // Lấy giá trị tên hình ảnh từ cột "anh_loai_mon"
                string tenHinhAnh = dtgvTTLH.Rows[i].Cells["anh_loai_mon"].Value.ToString();

                // Tạo đường dẫn hình ảnh từ Resources
                // Giả sử hình ảnh được lưu trong Resources với tên tương ứng
                Image img = Properties.Resources.ResourceManager.GetObject(tenHinhAnh) as Image;

                // Nếu hình ảnh không null, gán vào ô của cột hình ảnh
                if (img != null)
                {
                    dtgvTTLH.Rows[i].Cells["anh_loai_mon"].Value = img; // Gán hình ảnh vào cột DataGridViewImageColumn
                }
                else
                {
                    // Xử lý trường hợp không tìm thấy hình ảnh
                    dtgvTTLH.Rows[i].Cells["anh_loai_mon"].Value = null; // Hoặc một hình ảnh mặc định
                }
            }

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
