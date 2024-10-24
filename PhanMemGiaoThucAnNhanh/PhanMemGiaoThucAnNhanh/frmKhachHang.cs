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
using DTO;
using BLL;
namespace PhanMemGiaoThucAnNhanh
{
    public partial class frmKhachHang : Form
    {
        string maCuaHang = "kfc-store-001";
        MongoDB_BLL bll = new MongoDB_BLL();
        List<KhachHang> dsKhachHang = new List<KhachHang>();
        List<DonHang> dsDonHang = new List<DonHang>();

        public frmKhachHang()
        {
            InitializeComponent();
            dsKhachHang = bll.LayDanhSachKhachHang();
           // dtgvDsKhachHang.ReadOnly = true;
            this.Load += FrmKhachHang_Load;
            this.dtgvDsKhachHang.SelectionChanged += DtgvDsKhacHang_SelectionChanged;
            this.btnTim.Click += BtnTim_Click;
            this.btnThem.Click += BtnThem_Click;
            this.btnXoa.Click += BtnXoa_Click;
            this.btnLuu.Click += BtnLuu_Click;
            this.btnHuyThem.Click += BtnHuyThem_Click;           
        }

        private void BtnHuyThem_Click(object sender, EventArgs e)
        {
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtSDT.Text = "";
            txtEmail.Text = "";
            txtDiaChi.Text = "";
            txtDiemTichLuy.Text = "";
            txtMatKhau.Text = "";
            cbbHoatDong.Text = "";
            txtMaKH.Focus();
           
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {

            KhachHang kh = new KhachHang();
            kh.MaKhachHang = txtMaKH.Text;
            kh.TenKhachHang = txtTenKH.Text;
            kh.SoDienThoai = txtSDT.Text;
            kh.Email = txtEmail.Text;
            kh.DiemTichLuyHienCo = int.Parse(txtDiemTichLuy.Text);
            kh.DiaChi = txtDiaChi.Text;
            kh.MatKhau = txtMatKhau.Text;
            kh.HoatDong = Convert.ToBoolean(cbbHoatDong.SelectedValue);
            if (bll.CapNhatKhachHang(maCuaHang, kh))
            {
                MessageBox.Show("Lưu thành công!");
                dsKhachHang = bll.LayDanhSachKhachHang();
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
            string maKhacHang = txtMaKH.Text;
           
            if (bll.XoaKhachHang(maCuaHang, maKhacHang))
            {
                MessageBox.Show("Xóa thành công!");
                dsKhachHang = bll.LayDanhSachKhachHang();
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
            KhachHang kh = new KhachHang();
            kh.MaKhachHang = txtMaKH.Text;
            kh.TenKhachHang = txtTenKH.Text;
            kh.SoDienThoai = txtSDT.Text;
            kh.Email = txtEmail.Text;
            kh.DiemTichLuyHienCo = int.Parse(txtDiemTichLuy.Text);
            kh.DiaChi = txtDiaChi.Text;
            kh.MatKhau = txtMatKhau.Text;
            kh.HoatDong = Convert.ToBoolean(cbbHoatDong.SelectedValue);
            if (bll.TaoTaiKhoanKhachHang(maCuaHang, kh))
            {
                MessageBox.Show("Thêm thành công!");
                dsKhachHang = bll.LayDanhSachKhachHang();
                loadDataGridView();
            }
            else
            {
                MessageBox.Show("Thêm không thành công!");
                return;
            }
        }

        private void BtnTim_Click(object sender, EventArgs e)
        {
            string tenHoacMa = txtTim.Text;
            dsKhachHang = bll.LayKhachHangTheoTenHoacMa(tenHoacMa);
            loadDataGridView();
        }

        private void DtgvDsKhacHang_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgvDsKhachHang.CurrentRow != null)
            {
                txtMaKH.Text = dtgvDsKhachHang.CurrentRow.Cells["MaKhachHang"].Value.ToString();
                txtTenKH.Text = dtgvDsKhachHang.CurrentRow.Cells["TenKhachHang"].Value.ToString();
                txtSDT.Text = dtgvDsKhachHang.CurrentRow.Cells["SoDienThoai"].Value.ToString();
                txtEmail.Text = dtgvDsKhachHang.CurrentRow.Cells["Email"].Value.ToString();
                txtDiaChi.Text = dtgvDsKhachHang.CurrentRow.Cells["DiaChi"].Value.ToString();
                txtDiemTichLuy.Text = dtgvDsKhachHang.CurrentRow.Cells["DiemTichLuyHienCo"].Value.ToString();
                //bool hoatDong = Convert.ToBoolean(dtgvDsKhachHang.CurrentRow.Cells["HoatDong"].Value);
                //cbbHoatDong.SelectedValue = hoatDong;
                cbbHoatDong.Text = dtgvDsKhachHang.CurrentRow.Cells["HoatDong"].Value.ToString();
                txtMatKhau.Text = dtgvDsKhachHang.CurrentRow.Cells["MatKhau"].Value.ToString();

                if(dtgvDsKhachHang.SelectedRows.Count > 0)
                {
                    // lấy giá trị dòng đầu
                    DataGridViewRow selectedRow = dtgvDsKhachHang.SelectedRows[0];
                    // Gán giá trị của các cột tương ứng vào TextBox
                    var txtMaPhieuNhap = selectedRow.Cells[0].Value.ToString();
                    loadDataGridViewLichSu(txtMaPhieuNhap);
                }
               
            }
        }

        private void FrmKhachHang_Load(object sender, EventArgs e)
        {
            loadDataGridView();
        }

        private void loadDataGridView()
        {
            dtgvDsKhachHang.Columns.Clear();
            // Tạo cột hình ảnh

            dtgvDsKhachHang.Columns.Add("MaKhachHang", "Mã khách hàng");
            dtgvDsKhachHang.Columns.Add("TenKhachHang", "Tên khách hàng");
            dtgvDsKhachHang.Columns.Add("SoDienThoai", "Số điện thoại");
            dtgvDsKhachHang.Columns.Add("DiaChi", "Địa chỉ");
            dtgvDsKhachHang.Columns.Add("Email", "Email");
            dtgvDsKhachHang.Columns.Add("DiemTichLuyHienCo", "Điểm tích lũy hiện có");
            dtgvDsKhachHang.Columns.Add("HoatDong", "Hoạt động");
            dtgvDsKhachHang.Columns.Add("MatKhau", "Mật khẩu");

            foreach (var item in dsKhachHang)
            { 
                dtgvDsKhachHang.Rows.Add(item.MaKhachHang, item.TenKhachHang, item.SoDienThoai, item.DiaChi, item.Email, item.DiemTichLuyHienCo, item.HoatDong, item.MatKhau);
            }
        }


        private void loadDataGridViewLichSu(string maKhachHang)
        {
            dtgvLichSuGiaoDich.Columns.Clear();

            // Tạo cột cho DataGridView
            dtgvLichSuGiaoDich.Columns.Add("MaDonHang", "Mã đơn hàng");
            dtgvLichSuGiaoDich.Columns.Add("ThoiGianDat", "Thời gian đặt");
            dtgvLichSuGiaoDich.Columns.Add("ThoiGianGiao", "Thời gian giao");
            dtgvLichSuGiaoDich.Columns.Add("TongTien", "Tổng tiền");
            dtgvLichSuGiaoDich.Columns.Add("SoTienThanhToan", "Số tiền thanh toán");
            dtgvLichSuGiaoDich.Columns.Add("TrangThai", "Trạng thái");

            // Giả định rằng bạn đã có một phương thức để lấy danh sách đơn hàng của khách hàng theo mã khách hàng
            var dsDonHang = bll.LayDanhSachDonHangCuaKhachHang(maKhachHang);

            // Nạp dữ liệu vào DataGridView
            foreach (var donHang in dsDonHang)
            {
                dtgvLichSuGiaoDich.Rows.Add(donHang.MaDonHang, donHang.ThoiGianDat, donHang.ThoiGianGiao, donHang.TongTien, donHang.SoTienThanhToan, donHang.TrangThai);
            }

            // Định dạng các cột không cần thiế
        } 

    }
}
