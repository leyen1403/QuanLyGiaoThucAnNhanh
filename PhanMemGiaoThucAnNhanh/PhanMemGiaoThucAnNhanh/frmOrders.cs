﻿using System;
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
    public partial class frmOrders : Form
    {
        public frmOrders()
        {
            InitializeComponent();
            loadSuKien();
        }

        private void loadSuKien()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            this.MaximizeBox = false;
        }
    }
}
