using DTO;
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
    public partial class frmLichSuDonHangKH : Form
    {
        List<DonHang> dsDonHang = new List<DonHang>();
        public frmLichSuDonHangKH(List<DonHang> dsDonHang, string maKH)
        {
            InitializeComponent();
            this.dsDonHang = dsDonHang;
            this.dtgvLichSu.ReadOnly = true;
            dtgvLichSu.DataSource = dsDonHang;
            dtgvLichSu.Columns["MaDonHang"].HeaderText = "Mã đơn hàng";
            dtgvLichSu.Columns["ThoiGianDat"].HeaderText = "Thời gian đặt";
            dtgvLichSu.Columns["ThoiGianGiao"].HeaderText = "Thời gian giao";
            dtgvLichSu.Columns["TongTien"].HeaderText = "Tông tiền";
            dtgvLichSu.Columns["SoTienThanhToan"].HeaderText = "Số tiền thanh toán";
            dtgvLichSu.Columns["TrangThai"].HeaderText = "Trạng thái";
            dtgvLichSu.Columns["ThoiGianGiao"].Visible = false;
            dtgvLichSu.Columns["DiemTichLuySuDung"].Visible = false;
            dtgvLichSu.Columns["GiamGia"].Visible = false;

        }
    }
}
