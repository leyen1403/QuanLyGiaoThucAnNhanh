using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PhanMemGiaoThucAnNhanh
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.loaiMon_subItem.Click += LoaiMon_subItem_Click;
            this.monAn_subItem.Click += MonAn_subItem_Click;
            this.donHangItem.Click += DonHangItem_Click;
            this.khachHangItem.Click += KhachHangItem_Click;
            this.thongKeItem.Click += ThongKeItem_Click;
            this.cuaHang_Item.Click += CuaHang_Item_Click;
        }

        private void CuaHang_Item_Click(object sender, EventArgs e)
        {
            loadForm(new frmCuaHang());
        }

        private void ThongKeItem_Click(object sender, EventArgs e)
        {
            loadForm(new frmThongKe());
        }

        private void KhachHangItem_Click(object sender, EventArgs e)
        {
            loadForm(new frmKhachHang());
        }

        private void DonHangItem_Click(object sender, EventArgs e)
        {
            loadForm(new frmDonHang());
        }

        private void MonAn_subItem_Click(object sender, EventArgs e)
        {
            loadForm(new frmMonAn());
        }

        private void LoaiMon_subItem_Click(object sender, EventArgs e)
        {
            loadForm(new frmLoaiMon());
        }
        void loadForm(Form form)
        {
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panel_main.Controls.Add(form);
            panel_main.Tag = form;
            form.BringToFront();
            form.Show();
        }
    }
}
