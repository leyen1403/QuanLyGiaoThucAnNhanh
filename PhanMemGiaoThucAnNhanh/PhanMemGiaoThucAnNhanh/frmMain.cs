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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            this.menuItem.Click += MenuItem_Click;
        }

        private void MenuItem_Click(object sender, EventArgs e)
        {
            // Tạo một instance của form menu
            Form formMenu = new frmMenu();

            // Đặt parent của form menu là panel_main của form chính
            formMenu.TopLevel = false;
            formMenu.FormBorderStyle = FormBorderStyle.None;
            formMenu.Dock = DockStyle.Fill;
            panel_main.Controls.Add(formMenu);
            panel_main.Tag = formMenu;
            formMenu.BringToFront();

            // Hiển thị form menu
            formMenu.Show();
        }
    }
}
