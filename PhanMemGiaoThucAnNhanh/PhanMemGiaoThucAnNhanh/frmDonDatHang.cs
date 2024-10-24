using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;

namespace PhanMemGiaoThucAnNhanh
{
    public partial class frmDonDatHang : Form
    {
        public delegate void DonHangThanhToanHandler();
        public event DonHangThanhToanHandler DonHangThanhToan;
        MongoDB_BLL bll = new MongoDB_BLL();
        List<MonAn> dsMonAn;
        double tongTien;
        string maKH;
        public frmDonDatHang(List<MonAn> dsMonAn, double tongTien, string maKH)
        {
            InitializeComponent();
            this.dtgvDonDatHang.ReadOnly = true;
            this.dsMonAn = dsMonAn;
            this.tongTien = tongTien;
            this.maKH = maKH;
            lblTongTien.Text = tongTien.ToString("N0") + " đồng";
            this.Load += FrmDonDatHang_Load;
            this.btnThanhToan.Click += BtnThanhToan_Click;
        }

        private void BtnThanhToan_Click(object sender, EventArgs e)
        {
            // Tạo ra 1 đơn hàng mới với mã là chuỗi mã khách hàng + số đơn hàng hiện có + order
            string maDonHang = maKH + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_order";
            // Tạo 1 bản ghi đơn hàng
            DonHang donHangMoi = new DonHang
            {
                MaDonHang = maDonHang,
                ThoiGianDat = DateTime.Now.AddHours(7), // Hoặc thời gian hiện tại
                ThoiGianGiao = DateTime.Now.AddHours(8),
                GiamGia = 0,
                DiemTichLuySuDung = 0,
                TongTien = tongTien,
                SoTienThanhToan = tongTien,
                TrangThai = "đang xử lý",
                MonAnDonHang = new List<MonAnDonHang>()
            };
            foreach (var monAn in dsMonAn)
            {
                donHangMoi.MonAnDonHang.Add(new MonAnDonHang
                {
                    MaMonAn = monAn.MaMon,
                    TenMon = monAn.TenMon,
                    Gia = monAn.GiaMon,
                    SoLuong = (int)monAn.SoLuong,
                    ThanhTien = monAn.GiaMon * monAn.SoLuong,
                    MoTa = monAn.MoTa,
                    HinhAnh = monAn.HinhAnh
                });
            }
            if(donHangMoi.MonAnDonHang.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn món ăn");
                return;
            }
            if (bll.ThemDonHang(maKH, donHangMoi))
            {
                DonHangThanhToan?.Invoke();
                MessageBox.Show("Đặt món thành công");
                this.Close();
            }
            else
            {
                MessageBox.Show("Đặt món thất bại");
            }
        }

        private void FrmDonDatHang_Load(object sender, EventArgs e)
        {
            dtgvDonDatHang.DataSource = dsMonAn;
            dtgvDonDatHang.Columns["MaMon"].HeaderText = "Mã món";
            dtgvDonDatHang.Columns["TenMon"].HeaderText = "Tên món";
            dtgvDonDatHang.Columns["GiaMon"].HeaderText = "Đơn giá";
            dtgvDonDatHang.Columns["SoLuong"].HeaderText = "Số lượng";
            dtgvDonDatHang.Columns["MaLoai"].Visible = false;
            dtgvDonDatHang.Columns["HinhAnh"].Visible = false;
            dtgvDonDatHang.Columns["MoTa"].Visible = false;
            dtgvDonDatHang.Columns["HienThi"].Visible = false;
            //Thêm cột thành tiền bằng đơn giá * số lượng            
            DataGridViewTextBoxColumn thanhTienColumn = new DataGridViewTextBoxColumn();
            thanhTienColumn.HeaderText = "Thành tiền";
            thanhTienColumn.Name = "ThanhTien";
            thanhTienColumn.ReadOnly = true;
            dtgvDonDatHang.Columns.Add(thanhTienColumn);

            // Tính và hiển thị giá trị cho cột "Thành tiền"
            foreach (DataGridViewRow row in dtgvDonDatHang.Rows)
            {
                double giaMon = Convert.ToDouble(row.Cells["GiaMon"].Value);
                int soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);
                double thanhTien = giaMon * soLuong;
                row.Cells["ThanhTien"].Value = thanhTien.ToString("N0"); // Định dạng phân cách hàng nghìn
            }
        }
    }
}
