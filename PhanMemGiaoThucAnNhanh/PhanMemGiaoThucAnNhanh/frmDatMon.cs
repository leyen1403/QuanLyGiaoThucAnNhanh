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
using UC;

namespace PhanMemGiaoThucAnNhanh
{
    public partial class frmDatMon : Form
    {
        private int scrollPosition;
        private MongoDB_BLL bll = new MongoDB_BLL();

        public frmDatMon()
        {
            InitializeComponent();
            this.Load += FrmDatMon_Load;
            
        }

        private void FrmDatMon_Load(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ cơ sở dữ liệu
            List<MonAn> dsMonAn = new List<MonAn>();
            CuaHang cuaHang = new CuaHang();
            cuaHang.MaCuaHang = "kfc-store-001";
            dsMonAn = bll.GetDanhSachMonAn(cuaHang.MaCuaHang);

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

    }
}
