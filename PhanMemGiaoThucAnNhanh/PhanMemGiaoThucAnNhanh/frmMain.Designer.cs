namespace PhanMemGiaoThucAnNhanh
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loaiMon_subItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monAn_subItem = new System.Windows.Forms.ToolStripMenuItem();
            this.donHangItem = new System.Windows.Forms.ToolStripMenuItem();
            this.khachHangItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thongKeItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cuaHang_Item = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_main = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem,
            this.donHangItem,
            this.khachHangItem,
            this.thongKeItem,
            this.cuaHang_Item});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1180, 29);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuItem
            // 
            this.menuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loaiMon_subItem,
            this.monAn_subItem});
            this.menuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.menuItem.Name = "menuItem";
            this.menuItem.Size = new System.Drawing.Size(62, 25);
            this.menuItem.Text = "Menu";
            // 
            // loaiMon_subItem
            // 
            this.loaiMon_subItem.Name = "loaiMon_subItem";
            this.loaiMon_subItem.Size = new System.Drawing.Size(199, 26);
            this.loaiMon_subItem.Text = "Quản lý loại món";
            // 
            // monAn_subItem
            // 
            this.monAn_subItem.Name = "monAn_subItem";
            this.monAn_subItem.Size = new System.Drawing.Size(199, 26);
            this.monAn_subItem.Text = "Quản lý món ăn";
            // 
            // donHangItem
            // 
            this.donHangItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.donHangItem.Name = "donHangItem";
            this.donHangItem.Size = new System.Drawing.Size(91, 25);
            this.donHangItem.Text = "Đơn hàng";
            // 
            // khachHangItem
            // 
            this.khachHangItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.khachHangItem.Name = "khachHangItem";
            this.khachHangItem.Size = new System.Drawing.Size(103, 25);
            this.khachHangItem.Text = "Khách hàng";
            // 
            // thongKeItem
            // 
            this.thongKeItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.thongKeItem.Name = "thongKeItem";
            this.thongKeItem.Size = new System.Drawing.Size(86, 25);
            this.thongKeItem.Text = "Thống kê";
            // 
            // cuaHang_Item
            // 
            this.cuaHang_Item.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cuaHang_Item.Name = "cuaHang_Item";
            this.cuaHang_Item.Size = new System.Drawing.Size(88, 25);
            this.cuaHang_Item.Text = "Cửa hàng";
            // 
            // panel_main
            // 
            this.panel_main.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel_main.Location = new System.Drawing.Point(0, 29);
            this.panel_main.Name = "panel_main";
            this.panel_main.Size = new System.Drawing.Size(1180, 611);
            this.panel_main.TabIndex = 1;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 640);
            this.Controls.Add(this.panel_main);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuItem;
        private System.Windows.Forms.ToolStripMenuItem donHangItem;
        private System.Windows.Forms.ToolStripMenuItem khachHangItem;
        private System.Windows.Forms.ToolStripMenuItem thongKeItem;
        private System.Windows.Forms.Panel panel_main;
        private System.Windows.Forms.ToolStripMenuItem loaiMon_subItem;
        private System.Windows.Forms.ToolStripMenuItem monAn_subItem;
        private System.Windows.Forms.ToolStripMenuItem cuaHang_Item;
    }
}