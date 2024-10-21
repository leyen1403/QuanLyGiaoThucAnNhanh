using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BLL;
namespace PhanMemGiaoThucAnNhanh
{
    public partial class frmThongKe : Form
    {
        private bool isClickedBtnSPBanChay = false;
        MongoDB_BLL bll = new   MongoDB_BLL();
        public frmThongKe()
        {
            InitializeComponent();
            loadSuKien();
            this.Load += FrmThongKe_Load;
        }

        private void FrmThongKe_Load(object sender, EventArgs e)
        {
            DataTable dt = bll.GetTongTienTheoNgayHoanThanhDataTable();
            // Thiết lập DataGridView
            dtgvThongKe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Thiết lập cỡ chữ cho toàn bộ DataGridView
            dtgvThongKe.DefaultCellStyle.Font = new Font("Arial", 12);
            dtgvThongKe.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12);
            dtgvThongKe.MultiSelect = false;
            dtgvThongKe.AllowUserToAddRows = false;
            dtgvThongKe.DataSource = dt;
            dtgvThongKe.Refresh();
        }

        private void loadSuKien()
        {
            btnXemTKDoanhThu.Click += BtnXemTKDoanhThu_Click;
            btnTKSPBanNhieu.Click += BtnTKSPBanNhieu_Click;
            btnReport.Click += BtnReport_Click;
            btnXemDuoiDangDoThi.Click += BtnXemDuoiDangDoThi_Click;
        }

        private void BtnXemDuoiDangDoThi_Click(object sender, EventArgs e)
        {
            // Khởi tạo Chart
            chart1.Visible = true;
            LoadDataAndChart();
        }
        private void LoadDataAndChart()
        {
            // Lấy DataTable từ DataGridView
            DataTable dataTable = (DataTable)dtgvThongKe.DataSource;

            // Gọi phương thức để vẽ biểu đồ từ DataTable
            DrawChart(dataTable);
        }

        private void DrawChart(DataTable dataTable)
        {
            //Nếu là đang xem doanh thu thì xử lí đồ thị cho doanh thu
            if (isClickedBtnSPBanChay == false)
            {
                // Xóa các series cũ (nếu có)
                chart1.Series.Clear();

                // Tạo một series mới
                Series series = new Series
                {
                    Name = "Tổng tiền",
                    Color = System.Drawing.Color.ForestGreen,
                    ChartType = SeriesChartType.Column // Thay đổi loại biểu đồ nếu cần
                };

                // Thêm dữ liệu từ DataTable vào series
                foreach (DataRow row in dataTable.Rows)
                {
                    series.Points.AddXY(row["Ngày"], row["Tổng Tiền"]);
                }

                // Thêm series vào chart
                chart1.Series.Add(series);

                // Tùy chỉnh nhãn trục (nếu cần)
                chart1.ChartAreas[0].AxisX.Title = "Ngày";
                chart1.ChartAreas[0].AxisY.Title = "Tổng tiền";

                // Thêm tiêu đề cho biểu đồ (nếu cần)
                chart1.Titles.Clear();
                chart1.Titles.Add("Biểu Đồ Dữ Liệu Thu Nhập");
            }
            else
            {
                // Xóa các series cũ (nếu có)
                chart1.Series.Clear();

                // Tạo một series mới
                Series series = new Series
                {
                    Name = "Số lượng món ăn",
                    Color = System.Drawing.Color.ForestGreen,
                    ChartType = SeriesChartType.Column // Thay đổi loại biểu đồ nếu cần
                };

                // Thêm dữ liệu từ DataTable vào series
                foreach (DataRow row in dataTable.Rows)
                {
                    series.Points.AddXY(row["Tên món ăn"], row["Tổng số lượng"]);
                }

                // Thêm series vào chart
                chart1.Series.Add(series);

                // Tùy chỉnh nhãn trục (nếu cần)
                chart1.ChartAreas[0].AxisX.Title = "Món ăn";
                chart1.ChartAreas[0].AxisY.Title = "Tổng số lượng bán ra";

                // Thêm tiêu đề cho biểu đồ (nếu cần)
                chart1.Titles.Clear();
                chart1.Titles.Add("Biểu Đồ Số Lượng Món Ăn Bán Ra");
            }
            
        }


        private void BtnReport_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnTKSPBanNhieu_Click(object sender, EventArgs e)
        {
            try
            {
                isClickedBtnSPBanChay = true;
                chart1.Visible = false;
                DataTable dt = bll.GetMonAnBanChayDataTable();
                dtgvThongKe.DataSource = dt;
                dtgvThongKe.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnXemTKDoanhThu_Click(object sender, EventArgs e)
        {
            try
            {
                isClickedBtnSPBanChay = false;
                chart1.Visible = false;
                DataTable dt = bll.GetTongTienTheoNgayHoanThanhDataTable(dtpNgayBD.Text, dtpNgayKT.Text);
                dtgvThongKe.DataSource = dt;
                dtgvThongKe.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
