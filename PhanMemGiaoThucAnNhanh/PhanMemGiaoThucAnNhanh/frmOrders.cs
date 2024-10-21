using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UC;

namespace PhanMemGiaoThucAnNhanh
{
    public partial class frmOrders : Form
    {
        public frmOrders()
        {
            InitializeComponent();
            this.Load += FrmOrders_Load;
        }

        private void FrmOrders_Load(object sender, EventArgs e)
        {
            loadSuKien();
            UC_MonAn ucMonAn = new UC_MonAn();
            ucMonAn.Name = "UC_MonAn";

            ucMonAn.Top = 0;
            ucMonAn.Left = 0;

            pnDanhSachMonAn.Controls.Add(ucMonAn);
        }

        private void loadSuKien()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            //this.MaximizeBox = false;
        }
    }
}
