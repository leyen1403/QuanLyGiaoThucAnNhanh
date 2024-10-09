using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UC
{
    public partial class UC_MonAn: UserControl
    {
        public string DuongDanHinhAnhMonAn
        {
            get { return ""; }
            set { pictureBoxAnhMonAn.Image = Image.FromFile(value);}
        }
        public string TenMonAn
        {
            get { return lbl_TenMonAn.Text; }
            set { lbl_TenMonAn.Text = value;}
        }public string MoTaMon
        {
            get { return lbl_MoTaMonAn.Text; }
            set { lbl_MoTaMonAn.Text = value;}
        }
        public string GiaMon
        {
            get { return lbl_GiaMonAn.Text; }
            set { lbl_GiaMonAn.Text = value;}
        }
        public string SoLuongMonDaChon
        {
            get { return lbl_SoLuongDaChon.Text; }
            set { lbl_SoLuongDaChon.Text = value; }
        }
        public UC_MonAn()
        {
            InitializeComponent();
            btnTang.Click += BtnTang_Click;
            btnGiam.Click += BtnGiam_Click;
        }

        private void BtnGiam_Click(object sender, EventArgs e)
        {

        }

        private void BtnTang_Click(object sender, EventArgs e)
        {

        }

        private void UC_MonAn_Load(object sender, EventArgs e)
        {
            btnGiam.BackColor = Color.Transparent;
            btnTang.BackColor = Color.Transparent;
           
        }
    }
}
