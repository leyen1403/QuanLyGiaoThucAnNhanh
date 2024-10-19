using BLL;
using MongoDB.Bson;
using MongoDB.Driver;
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
        }

        private void BtnLuuDuLieu_Click(object sender, EventArgs e)
        {
            if (bll.LuuLoaiMon((DataTable)dtgvTTLH.DataSource, "kfc-store-001"))
            {
                MessageBox.Show("Lưu dữ liệu thành công");
            }
            else
            {
                MessageBox.Show("Fail !!!");
            }
            
        }
        void DatabingdingLH(DataTable dt)
        {
            // Xóa DataBindings trước khi liên kết mới
            txtMALH.DataBindings.Clear();
            txtTENLH.DataBindings.Clear();
            txtAnhLoaiMon.DataBindings.Clear();
            //pictureBoxLoaiMon.DataBindings.Clear();


            //Liên kết dữ liệu với text box
            txtMALH.DataBindings.Add("Text", dt, "ma_loai_mon");
            txtTENLH.DataBindings.Add("Text", dt, "ten_loai_mon");
            txtAnhLoaiMon.DataBindings.Add("Text", dt, "anh_loai_mon");
            //pictureBoxLoaiMon.DataBindings.Add("Image", dt, "anh_loai_mon");

        }

        private void DtgvTTLH_SelectionChanged(object sender, EventArgs e)
        {
            //txtMALH.Text = dtgvTTLH.CurrentRow.Cells["ma_loai_mon"].Value.ToString();
            //txtTENLH.Text = dtgvTTLH.CurrentRow.Cells["ten_loai_mon"].Value.ToString();
            pictureBoxLoaiMon.Image = (Image)dtgvTTLH.CurrentRow.Cells["hinh_anh"].Value;
            //txtAnhLoaiMon.Text = dtgvTTLH.CurrentRow.Cells["anh_loai_mon"].Value.ToString();
        }

        private void BtnHuyThem_Click(object sender, EventArgs e)
        {
            DatabingdingLH((DataTable)dtgvTTLH.DataSource);
            btnThem.Text = "Thêm";
            btnHuyThem.Visible = false;
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (dtgvTTLH.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa dòng này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Lấy dòng đang chọn
                    DataGridViewRow selectedRow = dtgvTTLH.SelectedRows[0];

                    // Lấy DataTable từ DataSource của DataGridView (giả sử DataSource là DataTable)
                    DataTable dataTable = (DataTable)dtgvTTLH.DataSource;

                    // Xác định index của dòng đang chọn trong DataTable
                    int rowIndex = dtgvTTLH.SelectedRows[0].Index;


                    // Kiểm tra index có hợp lệ không
                    if (rowIndex >= 0 && rowIndex < dtgvTTLH.Rows.Count)
                    {
                        // Xóa dòng từ DataSource
                        dtgvTTLH.Rows.RemoveAt(rowIndex);

                        // Gán lại DataSource mới cho DataGridView
                        dtgvTTLH.DataSource = dataTable;
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa!");
            }
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnThem.Text == "Hoàn tất thêm")
                {
                    if (string.IsNullOrEmpty(txtTENLH.Text) || string.IsNullOrEmpty(txtMALH.Text) ) //Kiểm tra trùng mã loại món
                    {
                        throw new Exception("Vui lòng nhập đầy đủ dữ liệu");
                        txtMALH.Focus();
                    }

                    // Tạo một DataRow mới và thêm dữ liệu vào
                    DataTable dt = (DataTable)dtgvTTLH.DataSource;
                    DataRow newRow = dt.NewRow();
                    newRow["ma_loai_mon"] = txtMALH.Text;
                    newRow["ten_loai_mon"] = txtTENLH.Text;
                    newRow["anh_loai_mon"] = txtAnhLoaiMon.Text;
                    //Bốc hình ảnh
                    string imagePath = txtAnhLoaiMon.Text; // Giả sử cột chứa đường dẫn là "DuongDanHinh"
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
                        newRow["hinh_anh"] = b;
                    }
                    else
                    {
                        // Nếu không, đặt hình ảnh mặc định
                        newRow["hinh_anh"] = Properties.Resources.icons8_folder_35; // Hình ảnh mặc định
                    }
                    // Thêm DataRow vào DataTable
                    dt.Rows.Add(newRow);

                    // Gán DataTable làm DataSource cho DataGridView
                    dtgvTTLH.DataSource = dt;
                    btnThem.Text = "Thêm";
                    //btnThem.Tag = "Chưa Click";
                    btnHuyThem.Visible = false;
                    dtgvTTLH.Invalidate();
                    dtgvTTLH.Refresh();
                }
                else if (btnThem.Text == "Thêm")
                {
                    // Xóa DataBindings trước khi liên kết mới
                    txtMALH.DataBindings.Clear();
                    txtTENLH.DataBindings.Clear();
                    txtAnhLoaiMon.DataBindings.Clear();
                    pictureBoxLoaiMon.Image = null;
                    txtMALH.Focus();
                    //Xóa text
                    txtAnhLoaiMon.Clear();
                    txtMALH.Clear();
                    txtTENLH.Clear();


                    btnThem.Text = "Hoàn tất thêm";
                    btnHuyThem.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmLoaiMon_Load(object sender, EventArgs e)
        {
            btnHuyThem.Visible = false;
            dtgvTTLH.MultiSelect = false;
            dtgvTTLH.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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
            dtDsLoaiMon.Columns.Remove("mon_an");
            dtgvTTLH.DataSource = dtDsLoaiMon;
            dtgvTTLH.Columns["anh_loai_mon"].Visible = false;
            //dtgvTTLH.Columns["mon_an"].Visible = false;
            dtgvTTLH.Columns[0].HeaderText = "Mã loại món";
            dtgvTTLH.Columns[1].HeaderText = "Tên loại món";
            dtgvTTLH.Columns["hinh_anh"].HeaderText = "Hình ảnh";
            // Đặt chiều cao dòng
            dtgvTTLH.RowTemplate.Height = 150;

            // Cập nhật giao diện
            dtgvTTLH.Invalidate();
            dtgvTTLH.Refresh();
            DatabingdingLH((DataTable) dtgvTTLH.DataSource);
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
