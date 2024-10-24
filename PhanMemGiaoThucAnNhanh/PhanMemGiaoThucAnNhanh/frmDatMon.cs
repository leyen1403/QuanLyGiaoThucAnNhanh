using BLL;
using DTO;
using MongoDB.Bson.IO;
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
using UC;

namespace PhanMemGiaoThucAnNhanh
{
    public partial class frmDatMon : Form
    {
        private int scrollPosition;
        private MongoDB_BLL bll = new MongoDB_BLL();
        List<MonAn> dsMonAn = new List<MonAn>();
        List<DonHang> dsDonHang = new List<DonHang>();
        string maKH;
        public frmDatMon(string maKH)
        {
            InitializeComponent();
            
            this.maKH = maKH;            
            this.Load += FrmDatMon_Load;
            this.btnTim.Click += BtnTim_Click;     
            this.pictureBox1.Click += PictureBox1_Click;
            this.FormClosed += FrmDatMon_FormClosed;
            this.ptbLichSu.Click += PtbLichSu_Click;
        }

        private void PtbLichSu_Click(object sender, EventArgs e)
        {
            this.dsDonHang = bll.LayDanhSachDonHangCuaKhachHang(maKH);
            frmLichSuDonHangKH f = new frmLichSuDonHangKH(dsDonHang,maKH);
            f.ShowDialog();
        }

        private void FrmDatMon_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            double tongTien = double.Parse(lblTongTien.Text);
            List<MonAn> dsMonAnNew = new List<MonAn>();

            // Duyệt qua các UC_MonAn trong pnDanhSachMonAn
            foreach (UC_MonAn item in pnDanhSachMonAn.Controls.OfType<UC_MonAn>())
            {
                if (item.SoLuong > 0)
                {
                    // Tạo đối tượng MonAn và gán giá trị từ UC_MonAn
                    MonAn monAn = new MonAn();
                    monAn.MaMon = item.MaMon;
                    monAn.TenMon = item.TenMonAn;
                    monAn.GiaMon = item.Gia;
                    monAn.MoTa = item.MoTa;
                    monAn.SoLuong = item.SoLuong;
                    // Lấy đường dẫn hoặc tên tệp hình ảnh nếu cần
                    monAn.HinhAnh = item.HinhAnh != null ? item.HinhAnh.ToString() : "default_image_path";

                    dsMonAnNew.Add(monAn);
                }
            }

            // Khởi tạo và truyền dữ liệu sang frmDonDatHang
            frmDonDatHang form = new frmDonDatHang(dsMonAnNew, tongTien, maKH);
            form.DonHangThanhToan += Form_DonHangThanhToan;
            form.Show(); // Hiển thị form mới
        }

        private void Form_DonHangThanhToan()
        {
            hienThiDanhSachMonAn(dsMonAn);
            lblSoMon.Text = "0";
            lblTongTien.Text = "0";
        }

        private void BtnTim_Click(object sender, EventArgs e)
        {
            string tenMonAn = txtTim.Text;
            List<MonAn> dsMonAn = new List<MonAn>();
            CuaHang cuaHang = new CuaHang();
            cuaHang.MaCuaHang = "kfc-store-001";
            dsMonAn = bll.GetDanhSachMonAnTheoTen(cuaHang.MaCuaHang, tenMonAn);
            hienThiDanhSachMonAn(dsMonAn);
        }

        private void FrmDatMon_Load(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ cơ sở dữ liệu
            
            CuaHang cuaHang = new CuaHang();
            cuaHang.MaCuaHang = "kfc-store-001";
            dsMonAn = bll.GetDanhSachMonAn(cuaHang.MaCuaHang);
            hienThiDanhSachMonAn(dsMonAn);            
            pnDanhSachMonAn.AutoScroll = true;
        }

        private void UC_MonAn_TangSoLuong(object sender, EventArgs e)
        {
            int soMon = int.Parse(lblSoMon.Text);
            soMon++;
            lblSoMon.Text = soMon.ToString();
            TinhTongTien();
        }

        private void UC_MonAn_GiamSoLuong(object sender, EventArgs e)
        {
            int soMon = int.Parse(lblSoMon.Text);
            if (soMon > 0)
            {
                soMon--;
                lblSoMon.Text = soMon.ToString();
                TinhTongTien();
            }
        }
        private void TinhTongTien()
        {
            double tongTien = 0;

            // Lặp qua tất cả các UC_MonAn trong pnDanhSachMonAn
            foreach (UC_MonAn uCMonAn in pnDanhSachMonAn.Controls.OfType<UC_MonAn>())
            {
                tongTien +=(double) uCMonAn.Gia * uCMonAn.SoLuong; // Tính tổng tiền (Giá * Số lượng)
            }

            // Cập nhật lblTongTien với tổng tiền tính được
            lblTongTien.Text = tongTien.ToString("N0"); // Định dạng số với phân cách hàng nghìn
        }
        // Hiển thị danh sách món ăn lên giao diện
        private void hienThiDanhSachMonAn(List<MonAn> dsMonAn)
        {
            // Xoa tat ca controls trong pnDanhSachMonAn
            pnDanhSachMonAn.Controls.Clear();
            // Hiển thị dữ liệu lên giao diện
            for (int i = 0; i < dsMonAn.Count; i++)
            {
                UC_MonAn item = new UC_MonAn();
                item.Name = "UC_MonAn" + i;
                item.Top = i * item.Height;
                item.Left = 0;
                item.SoLuong = 0;

                item.MaMon = dsMonAn[i].MaMon;
                item.TenMonAn = dsMonAn[i].TenMon;
                item.Gia = dsMonAn[i].GiaMon;
                item.MoTa = dsMonAn[i].MoTa;

                // Xử lý hình ảnh
                string imagePath = dsMonAn[i].HinhAnh;
                string url = Path.Combine(Application.StartupPath, @"Resources\" + imagePath);
                if (File.Exists(url))
                {
                    // Nếu tệp hình ảnh tồn tại, tải và gán hình ảnh cho item
                    Image image = Image.FromFile(url);
                    Bitmap resizedImage = new Bitmap(100, 150); // Thay đổi kích thước hình ảnh
                    using (Graphics g = Graphics.FromImage(resizedImage))
                    {
                        g.DrawImage(image, 0, 0, 100, 150);
                    }
                    item.HinhAnh = resizedImage; // Gán hình ảnh đã được thay đổi kích thước
                }
                else
                {
                    // Nếu không, đặt hình ảnh mặc định
                    item.HinhAnh = Properties.Resources.icons8_folder_35; // Hình ảnh mặc định
                }

                // Gắn sự kiện tăng và giảm số lượng
                item.TangSoLuong += UC_MonAn_TangSoLuong;
                item.GiamSoLuong += UC_MonAn_GiamSoLuong;

                pnDanhSachMonAn.Controls.Add(item);
            }
        }

    }
}
