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
        List<MonAnCuaHang> dsMonAn = new List<MonAnCuaHang>();
        public frmDonHang()
        {
            InitializeComponent();
            dsDonHang = bll.LayToanBoDanhSachDonHang();
            //dtgvDsDonHang.ReadOnly = true;
            this.Load += FrmDonHang_Load;
         
            this.dtgvDsDonHang.SelectionChanged += DtgvDsDonHang_SelectionChanged; ;
            this.btnLoc.Click += BtnLoc_Click;
            this.btnTim.Click += BtnTim_Click;
            this.btnReset.Click += BtnReset_Click;
            this.btnCapNhat.Click += BtnCapNhat_Click;
        }

        private void BtnCapNhat_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có khách hàng nào được chọn không
            if (cbbKhachHang.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng!");
                return;
            }
            string maKH = cbbKhachHang.SelectedValue.ToString(); // Lấy mã khách hàng

            // Kiểm tra mã đơn hàng
            if (string.IsNullOrWhiteSpace(txtDonHang.Text))
            {
                MessageBox.Show("Vui lòng nhập mã đơn hàng!");
                return;
            }
            string maDH = txtDonHang.Text;

            // Kiểm tra trạng thái
            if (cbbTinhTrang.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn trạng thái!");
                return;
            }
            string trangThai = cbbTinhTrang.SelectedItem.ToString();

            // Gọi phương thức cập nhật
            if (bll.CapNhatTrangThaiDonHang(maCuaHang, maKH, maDH, trangThai))
            {
                MessageBox.Show("Lưu thành công!");
                dsDonHang = bll.LayToanBoDanhSachDonHang();
                loadDataGridView();
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

               
                string maDH = dtgvDsDonHang.CurrentRow.Cells["MaDonHang"].Value.ToString();
                cbbKhachHang.Text = bll.TimMaKhachHangTheoMaDonHang(maCuaHang, maDH);
                txtDonHang.Text = dtgvDsDonHang.CurrentRow.Cells[0].Value.ToString();
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
            txtDonHang.Text = string.Empty;
            
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
        }

        private void loadComboBox()
        {
            //cbbKhachHang.DataSource = dsKhachHang;
            //cbbKhachHang.DisplayMember = "TenKhachHang";
            //cbbKhachHang.ValueMember = "MaKhachHang";
           
            cbbKhachHang.DataSource = bll.LayDanhSachKhachHang();
            cbbKhachHang.DisplayMember = "TenKhachHang";
            cbbKhachHang.ValueMember = "MaKhachHang";
        }
        private void loadDataGridView()
        {
            dtgvDsDonHang.Columns.Clear();
            // Tạo cột hình ảnh

            dtgvDsDonHang.Columns.Add("MaDonHang", "Mã đơn hàng");
            dtgvDsDonHang.Columns.Add("ThoiGianGiao", "Thoi gian giao");
            dtgvDsDonHang.Columns.Add("GiamGia", "Giảm giá");
            dtgvDsDonHang.Columns.Add("DiemTichLuySuDung", "Điểm tích lũy sử dụng");
            dtgvDsDonHang.Columns.Add("ThoiGianDat", "Thời gian đặt");
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
            dtgvDsDonHang.Columns.Add("ThoiGianGiao", "Thoi gian giao");
            dtgvDsDonHang.Columns.Add("GiamGia", "Giảm giá");
            dtgvDsDonHang.Columns.Add("DiemTichLuySuDung", "Điểm tích lũy sử dụng");
            dtgvDsDonHang.Columns.Add("ThoiGianDat", "Thời gian đặt");
            dtgvDsDonHang.Columns.Add("TongTien", "Tổng tiền");
            dtgvDsDonHang.Columns.Add("SoTienThanhToan", "Số tiền thanh toán");
            dtgvDsDonHang.Columns.Add("TrangThai", "Trạng thái");
            var dsDonHang = bll.LayToanBoDanhSachDonHang();

            foreach (var item in dsDonHang)
            {
                dtgvDsDonHang.Rows.Add(item.MaDonHang, item.ThoiGianDat, item.ThoiGianGiao, item.GiamGia, item.DiemTichLuySuDung, item.TongTien, item.SoTienThanhToan, item.TrangThai);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
