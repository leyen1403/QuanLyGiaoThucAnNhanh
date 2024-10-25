using BLL;
using DTO;
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
    public partial class frmDonHang : Form
    {

        string maCuaHang = "kfc-store-001";
        MongoDB_BLL bll = new MongoDB_BLL();
        List<DonHang> dsDonHang = new List<DonHang>();
        List<KhachHang> dsKhachHang = new List<KhachHang>();

        public frmDonHang()
        {
            InitializeComponent();
            dsDonHang = bll.LayToanBoDanhSachDonHang();
            //dtgvDsDonHang.ReadOnly = true;
            this.Load += FrmDonHang_Load;

            this.dtgvDsDonHang.SelectionChanged += DtgvDsDonHang_SelectionChanged;
            this.btnLoc.Click += BtnLoc_Click;
            this.btnTim.Click += BtnTim_Click;
            this.btnReset.Click += BtnReset_Click;
            this.btnCapNhat.Click += BtnCapNhat_Click;
        }

        private void BtnCapNhat_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có khách hàng nào được chọn không
            //if (cbbKhachHang.SelectedValue == null)
            //{
            //    MessageBox.Show("Vui lòng chọn khách hàng!");
            //    return;
            //}


            // Kiểm tra mã đơn hàng
            //if (string.IsNullOrWhiteSpace(txtMaDonHang.Text))
            //{
            //    MessageBox.Show("Vui lòng nhập mã đơn hàng!");
            //    return;
            //}

            // Kiểm tra trạng thái
            //if (cbbTinhTrang.SelectedItem == null)
            //{
            //    MessageBox.Show("Vui lòng chọn trạng thái!");
            //    return;
            //}
            string maDH = txtMaDonHang.Text;
            string maKH = cbbKhachHang.SelectedValue.ToString(); // Lấy mã khách hàng

            string trangThai = cbbTinhTrang.SelectedItem.ToString();

            DonHang dh = new DonHang();
            dh.MaDonHang = txtMaDonHang.Text;
            dh.ThoiGianDat = dtpThoiGianDat.Value;
            dh.ThoiGianGiao = dtpThoiGianGiao.Value;
            dh.GiamGia = int.Parse(txtGiamGia.Text);
            dh.DiemTichLuySuDung = int.Parse(txtDiemTichLuy.Text);
            dh.TongTien = Double.Parse(txtTongTien.Text);
            dh.SoTienThanhToan = Double.Parse(txtSoTienThanhToan.Text);
            dh.TrangThai = trangThai;
           // var result = bll.CapNhatDonHang(maCuaHang, maKH, maDH, dh);
            // Gọi phương thức cập nhật
            if (bll.CapNhatDonHang(maCuaHang, maKH, maDH, dh))
            {
                MessageBox.Show("Lưu thành công!");
                dsDonHang = bll.LayToanBoDanhSachDonHang();
                loadDataGridViewToanBo();
            }
            else
            {
                MessageBox.Show("Lưu không thành công!");
                return;
            }
        }

        private void DtgvDsDonHang_SelectionChanged(object sender, EventArgs e)
        {

            if (dtgvDsDonHang.CurrentRow != null)
            {
                // Lấy giá trị từ MongoDB dưới dạng DateTime trực tiếp
                DateTime thoiGianDat = (DateTime)dtgvDsDonHang.CurrentRow.Cells["ThoiGianDat"].Value;
                DateTime thoiGianGiao = (DateTime)dtgvDsDonHang.CurrentRow.Cells["ThoiGianGiao"].Value;

                // Chuyển đổi thời gian từ UTC sang thời gian cục bộ
                DateTime localThoiGianDat = thoiGianDat.ToLocalTime();
                DateTime localThoiGianGiao = thoiGianGiao.ToLocalTime();

                // Đặt giá trị cho DateTimePicker
                dtpThoiGianDat.Value = localThoiGianDat;
                dtpThoiGianGiao.Value = localThoiGianGiao;





                string maDH = dtgvDsDonHang.CurrentRow.Cells["MaDonHang"].Value.ToString();
                cbbKhachHang.Text = bll.TimMaKhachHangTheoMaDonHang(maCuaHang, maDH);
                txtDiemTichLuy.Text = dtgvDsDonHang.CurrentRow.Cells["DiemTichLuySuDung"].Value.ToString();
                txtTongTien.Text = dtgvDsDonHang.CurrentRow.Cells["TongTien"].Value.ToString();
                txtSoTienThanhToan.Text = dtgvDsDonHang.CurrentRow.Cells["SoTienThanhToan"].Value.ToString();
                txtGiamGia.Text = dtgvDsDonHang.CurrentRow.Cells["GiamGia"].Value.ToString();
                txtMaDonHang.Text = dtgvDsDonHang.CurrentRow.Cells[0].Value.ToString();
                cbbTinhTrang.Text = dtgvDsDonHang.CurrentRow.Cells["TrangThai"].Value.ToString();

            if (dtgvDsDonHang.SelectedRows.Count > 0)
            {
                // lấy giá trị dòng đầu
                DataGridViewRow selectedRow = dtgvDsDonHang.SelectedRows[0];
                // Gán giá trị của các cột tương ứng vào TextBox
                var tinhTrang = selectedRow.Cells[0].Value.ToString();
                //loadDataGridViewLichSu(txtMaPhieuNhap);
            }

        }
    
    }

        private void BtnReset_Click(object sender, EventArgs e)

        {
            loadDataGridViewToanBo();
            cbbKhachHang.Text = string.Empty;
            cbbTinhTrang.Text = string.Empty;
            txtMaDonHang.Text = string.Empty;
            txtDiemTichLuy.Text = string.Empty;
            txtGiamGia.Text= string.Empty;
            txtTongTien.Text = string.Empty;
            txtMaDonHang.Text = string.Empty ;
            txtSoTienThanhToan.Text = string.Empty ;
            dtpThoiGianDat.Value = DateTime.Now;
            dtpThoiGianGiao.Value = DateTime.Now;
        }

        private void BtnLoc_Click(object sender, EventArgs e)
        {
            string tinhTrangDuocChon = cbbTinhTrang.SelectedItem.ToString();
            dsDonHang = bll.TimDonHangTheoTinhTrang(tinhTrangDuocChon);
            loadDataGridView();
        }

      

        private void BtnTim_Click(object sender, EventArgs e)
        {
            string maKH = txtTim.Text;
            dsDonHang = bll.TimDonHangTheoMaKhachHang(maKH);
            loadDataGridView();
        }

        

        private void FrmDonHang_Load(object sender, EventArgs e)
        {
            loadComboBox();
            loadDataGridViewToanBo();
            // Trong constructor của form (hoặc ở sự kiện Form_Load):
            txtTim.GotFocus += new EventHandler(txtMaKH_GotFocus);
            txtTim.LostFocus += new EventHandler(txtMaKH_LostFocus);

            // Thiết lập ban đầu:
           
            txtTim.ForeColor = Color.Gray;

        }

        private void loadComboBox()
        {
                       
            cbbKhachHang.DataSource = bll.LayDanhSachKhachHang();
            cbbKhachHang.DisplayMember = "TenKhachHang";
            cbbKhachHang.ValueMember = "MaKhachHang";
        }
        private void loadDataGridView()
        {
            dtgvDsDonHang.Columns.Clear();
            // Tạo cột hình ảnh

            dtgvDsDonHang.Columns.Add("MaDonHang", "Mã đơn hàng");
            dtgvDsDonHang.Columns.Add("ThoiGianDat", "Thời gian đặt");
            dtgvDsDonHang.Columns.Add("ThoiGianGiao", "Thoi gian giao");
            dtgvDsDonHang.Columns.Add("GiamGia", "Giảm giá");
            dtgvDsDonHang.Columns.Add("DiemTichLuySuDung", "Điểm tích lũy sử dụng");

            dtgvDsDonHang.Columns.Add("TongTien", "Tổng tiền");
            dtgvDsDonHang.Columns.Add("SoTienThanhToan", "Số tiền thanh toán");
            dtgvDsDonHang.Columns.Add("TrangThai", "Trạng thái");


            foreach (var item in dsDonHang)
            {
                dtgvDsDonHang.Rows.Add(item.MaDonHang, item.ThoiGianDat, item.ThoiGianGiao, item.GiamGia, item.DiemTichLuySuDung, item.TongTien, item.SoTienThanhToan, item.TrangThai);
            }
        }
        private void loadDataGridViewToanBo()
        {
            dtgvDsDonHang.Columns.Clear();
            // Tạo cột hình ảnh

            dtgvDsDonHang.Columns.Add("MaDonHang", "Mã đơn hàng");
            dtgvDsDonHang.Columns.Add("ThoiGianDat", "Thời gian đặt");
            dtgvDsDonHang.Columns.Add("ThoiGianGiao", "Thoi gian giao");
            dtgvDsDonHang.Columns.Add("GiamGia", "Giảm giá");
            dtgvDsDonHang.Columns.Add("DiemTichLuySuDung", "Điểm tích lũy sử dụng");
            
            dtgvDsDonHang.Columns.Add("TongTien", "Tổng tiền");
            dtgvDsDonHang.Columns.Add("SoTienThanhToan", "Số tiền thanh toán");
            dtgvDsDonHang.Columns.Add("TrangThai", "Trạng thái");
             var dsDonHang = bll.LayToanBoDanhSachDonHang().OrderBy(m => m.TrangThai);

            foreach (var item in dsDonHang)
            {
                dtgvDsDonHang.Rows.Add(item.MaDonHang, item.ThoiGianDat, item.ThoiGianGiao, item.GiamGia, item.DiemTichLuySuDung, item.TongTien, item.SoTienThanhToan, item.TrangThai);
            }
        }

        private void txtMaKH_GotFocus(object sender, EventArgs e)
        {
            if (txtTim.Text == "Nhập mã khách hàng")
            {
                txtTim.Text = "";
                txtTim.ForeColor = Color.Black;  // Đổi màu chữ thành đen
            }
        }

        private void txtMaKH_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTim.Text))
            {
                txtTim.Text = "Nhập mã khách hàng";
                txtTim.ForeColor = Color.Gray;  // Đổi màu chữ thành xám
            }
        }

      
    }
}
