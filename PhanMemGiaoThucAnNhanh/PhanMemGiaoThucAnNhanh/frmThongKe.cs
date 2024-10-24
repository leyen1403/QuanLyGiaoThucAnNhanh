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
using System.Windows.Forms.DataVisualization.Charting;
using BLL;
using DTO;
using Syncfusion.XlsIO;
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
            List<PHIEUBAOCAO> dsPBC = bll.LayPhieuBaoCao("kfc-store-001",dtpNgayBD.Text,dtpNgayKT.Text);
            if (dsPBC.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ngày bắt đầu và ngày kết thúc");
                return;
            }
            //Create replacer
            Dictionary<string, string> replacer = new Dictionary<string, string>();
            string ngay = "Ngày" + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
            replacer.Add("%NgayBatDau", dtpNgayBD.Text);
            replacer.Add("%NgayKetThuc", dtpNgayKT.Text);
            replacer.Add("%NgayThangNam", ngay);
            //NHACUNGCAP ncc = qlhh.NHACUNGCAPs.Where(t => t.MANCC == pn.MANCC).FirstOrDefault();
            var cuaHang = bll.GetOneCuaHang("kfc-store-001");
            var tenCuaHang = cuaHang["cua_hang"]["ten_cua_hang"];
            var soDienThoai = cuaHang["cua_hang"]["so_dien_thoai"];
            var diaChi = cuaHang["cua_hang"]["dia_chi"];
            replacer.Add("%TenCuaHang", tenCuaHang.ToString());
            replacer.Add("%DiaChi", diaChi.ToString());
            replacer.Add("%SDT", soDienThoai.ToString());
            double tongTien = 0;
            foreach (PHIEUBAOCAO item in dsPBC)
            {
                tongTien += item.THANHTIEN;
            }
            replacer.Add("%TongTien", String.Format("{0:0,0} VNĐ", tongTien));

            MemoryStream stream = null;
            byte[] arrByte = new byte[0];
            arrByte = File.ReadAllBytes("PhieuBaoCao.xlsx").ToArray();
            //Get stream
            if (arrByte.Count() > 0)
            {
                stream = new MemoryStream(arrByte);
            }
            //Create Excel Engine
            ExcelEngine engine = new ExcelEngine();
            IWorkbook workBook = engine.Excel.Workbooks.Open(stream);
            IWorksheet workSheet = workBook.Worksheets[0];
            ITemplateMarkersProcessor markProcessor = workSheet.CreateTemplateMarkersProcessor();
            //Replace value
            if (replacer != null && replacer.Count > 0)
            {
                foreach (KeyValuePair<string, string> repl in replacer)
                {
                    Replace(workSheet, repl.Key, repl.Value);
                }
            }
            //Lấp đầy đủ thông tin cần xuất theo Excel
            //List<CHITIETPHIEUNHAP> ctpns = pn.CHITIETPHIEUNHAPs.Where(t => t.MAPHIEUNHAP == pn.MAPHIEUNHAP).ToList();
            //List<ChiTietPN> ctpnSTT = new List<ChiTietPN>();
            //int stt = 1;
            //foreach (CHITIETPHIEUNHAP ct in ctpns)
            //{
            //    ChiTietPN ctstt = new ChiTietPN(ct, stt++);
            //    ctstt.TenSP = qlhh.SANPHAMs.Where(t => t.MASANPHAM == ct.MASANPHAM).FirstOrDefault().TENSANPHAM;
            //    ctpnSTT.Add(ctstt);
            //}
            string viewName = "PhieuBaoCao";
            markProcessor.AddVariable(viewName, dsPBC);
            markProcessor.ApplyMarkers(UnknownVariableAction.ReplaceBlank);
            ////Xóa bỏ dòng đánh dấu [TMP]
            IRange range = workSheet.FindFirst("[TMP]", ExcelFindType.Text);
            if (range != null)
            {
                workSheet.DeleteRow(range.Row);
            }
            //Lưu file
            //string fileName = "";
            //string file = Path.Combine(Path.GetTempPath(), "PhieuNhapHang_" + Guid.NewGuid() + "xlsx");
            //fileName = file;
            //Output file
            string fileName = "PhieuBaoCao_HoanTat.xlsx";
            try
            {
                workBook.SaveAs(fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu tệp : ", ex.Message);
            }


            //Close
            workBook.Close();
            engine.Dispose();
            MessageBox.Show("Xuất xong");
            if (!string.IsNullOrEmpty(fileName) && MessageBox.Show("Bạn có muốn mở file không  ?", "Thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(fileName);
            }
        }
        private void Replace(IWorksheet workSheet, string p1, string p2)
        {
            workSheet.Replace(p1, p2);
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
