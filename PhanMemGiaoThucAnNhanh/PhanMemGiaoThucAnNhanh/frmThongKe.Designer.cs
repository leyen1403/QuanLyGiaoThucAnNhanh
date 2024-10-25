namespace PhanMemGiaoThucAnNhanh
{
    partial class frmThongKe
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThongKe));
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpNgayKT = new System.Windows.Forms.DateTimePicker();
            this.dtpNgayBD = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grbThongKe = new System.Windows.Forms.GroupBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dtgvThongKe = new System.Windows.Forms.DataGridView();
            this.btnXemDuoiDangDoThi = new System.Windows.Forms.Button();
            this.btnTKSPBanNhieu = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnXemTKDoanhThu = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.grbThongKe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvThongKe)).BeginInit();
            this.panel11.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(563, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thống kê";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(34, 36);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(136, 17);
            this.label11.TabIndex = 0;
            this.label11.Text = "Chọn ngày bắt đầu :";
            // 
            // dtpNgayKT
            // 
            this.dtpNgayKT.CustomFormat = "yyyy-MM-dd";
            this.dtpNgayKT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayKT.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayKT.Location = new System.Drawing.Point(164, 65);
            this.dtpNgayKT.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dtpNgayKT.Name = "dtpNgayKT";
            this.dtpNgayKT.Size = new System.Drawing.Size(151, 23);
            this.dtpNgayKT.TabIndex = 43;
            // 
            // dtpNgayBD
            // 
            this.dtpNgayBD.CustomFormat = "yyyy-MM-dd";
            this.dtpNgayBD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayBD.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayBD.Location = new System.Drawing.Point(164, 32);
            this.dtpNgayBD.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dtpNgayBD.Name = "dtpNgayBD";
            this.dtpNgayBD.Size = new System.Drawing.Size(151, 23);
            this.dtpNgayBD.TabIndex = 42;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grbThongKe);
            this.groupBox1.Controls.Add(this.dtpNgayKT);
            this.groupBox1.Controls.Add(this.dtpNgayBD);
            this.groupBox1.Controls.Add(this.btnXemDuoiDangDoThi);
            this.groupBox1.Controls.Add(this.btnTKSPBanNhieu);
            this.groupBox1.Controls.Add(this.btnReport);
            this.groupBox1.Controls.Add(this.btnXemTKDoanhThu);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Size = new System.Drawing.Size(1164, 572);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thống kê dịch vụ doanh thu";
            // 
            // grbThongKe
            // 
            this.grbThongKe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbThongKe.Controls.Add(this.chart1);
            this.grbThongKe.Controls.Add(this.dtgvThongKe);
            this.grbThongKe.Location = new System.Drawing.Point(37, 165);
            this.grbThongKe.Name = "grbThongKe";
            this.grbThongKe.Size = new System.Drawing.Size(1092, 370);
            this.grbThongKe.TabIndex = 44;
            this.grbThongKe.TabStop = false;
            this.grbThongKe.Text = "Thống kê";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(3, 16);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1086, 351);
            this.chart1.TabIndex = 45;
            this.chart1.Text = "chart1";
            this.chart1.Visible = false;
            // 
            // dtgvThongKe
            // 
            this.dtgvThongKe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvThongKe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvThongKe.Location = new System.Drawing.Point(3, 16);
            this.dtgvThongKe.Name = "dtgvThongKe";
            this.dtgvThongKe.Size = new System.Drawing.Size(1086, 351);
            this.dtgvThongKe.TabIndex = 0;
            // 
            // btnXemDuoiDangDoThi
            // 
            this.btnXemDuoiDangDoThi.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnXemDuoiDangDoThi.BackColor = System.Drawing.Color.Red;
            this.btnXemDuoiDangDoThi.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnXemDuoiDangDoThi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXemDuoiDangDoThi.ForeColor = System.Drawing.Color.White;
            this.btnXemDuoiDangDoThi.Image = ((System.Drawing.Image)(resources.GetObject("btnXemDuoiDangDoThi.Image")));
            this.btnXemDuoiDangDoThi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXemDuoiDangDoThi.Location = new System.Drawing.Point(586, 101);
            this.btnXemDuoiDangDoThi.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnXemDuoiDangDoThi.Name = "btnXemDuoiDangDoThi";
            this.btnXemDuoiDangDoThi.Size = new System.Drawing.Size(263, 36);
            this.btnXemDuoiDangDoThi.TabIndex = 6;
            this.btnXemDuoiDangDoThi.Text = "Xem dưới dạng đồ thị";
            this.btnXemDuoiDangDoThi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXemDuoiDangDoThi.UseVisualStyleBackColor = false;
            // 
            // btnTKSPBanNhieu
            // 
            this.btnTKSPBanNhieu.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnTKSPBanNhieu.BackColor = System.Drawing.Color.Red;
            this.btnTKSPBanNhieu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTKSPBanNhieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTKSPBanNhieu.ForeColor = System.Drawing.Color.White;
            this.btnTKSPBanNhieu.Image = ((System.Drawing.Image)(resources.GetObject("btnTKSPBanNhieu.Image")));
            this.btnTKSPBanNhieu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTKSPBanNhieu.Location = new System.Drawing.Point(309, 101);
            this.btnTKSPBanNhieu.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnTKSPBanNhieu.Name = "btnTKSPBanNhieu";
            this.btnTKSPBanNhieu.Size = new System.Drawing.Size(263, 36);
            this.btnTKSPBanNhieu.TabIndex = 6;
            this.btnTKSPBanNhieu.Text = "Xem sản phẩm bán nhiều nhất";
            this.btnTKSPBanNhieu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTKSPBanNhieu.UseVisualStyleBackColor = false;
            // 
            // btnReport
            // 
            this.btnReport.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnReport.BackColor = System.Drawing.Color.Red;
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.ForeColor = System.Drawing.Color.White;
            this.btnReport.Image = global::PhanMemGiaoThucAnNhanh.Properties.Resources.icons8_report_35;
            this.btnReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReport.Location = new System.Drawing.Point(863, 101);
            this.btnReport.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(263, 36);
            this.btnReport.TabIndex = 5;
            this.btnReport.Text = "Xuất doanh thu (Report)";
            this.btnReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReport.UseVisualStyleBackColor = false;
            // 
            // btnXemTKDoanhThu
            // 
            this.btnXemTKDoanhThu.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnXemTKDoanhThu.BackColor = System.Drawing.Color.Red;
            this.btnXemTKDoanhThu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnXemTKDoanhThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXemTKDoanhThu.ForeColor = System.Drawing.Color.White;
            this.btnXemTKDoanhThu.Image = ((System.Drawing.Image)(resources.GetObject("btnXemTKDoanhThu.Image")));
            this.btnXemTKDoanhThu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXemTKDoanhThu.Location = new System.Drawing.Point(37, 101);
            this.btnXemTKDoanhThu.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnXemTKDoanhThu.Name = "btnXemTKDoanhThu";
            this.btnXemTKDoanhThu.Padding = new System.Windows.Forms.Padding(40, 0, 40, 0);
            this.btnXemTKDoanhThu.Size = new System.Drawing.Size(263, 36);
            this.btnXemTKDoanhThu.TabIndex = 5;
            this.btnXemTKDoanhThu.Text = "Xem doanh thu";
            this.btnXemTKDoanhThu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXemTKDoanhThu.UseVisualStyleBackColor = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(34, 69);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(138, 17);
            this.label12.TabIndex = 1;
            this.label12.Text = "Chọn ngày kết thúc :";
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.groupBox1);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel11.Location = new System.Drawing.Point(0, 0);
            this.panel11.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(1164, 572);
            this.panel11.TabIndex = 41;
            // 
            // frmThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 572);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.label1);
            this.Name = "frmThongKe";
            this.Text = "frmThongKe";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grbThongKe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvThongKe)).EndInit();
            this.panel11.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTKSPBanNhieu;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnXemTKDoanhThu;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtpNgayKT;
        private System.Windows.Forms.DateTimePicker dtpNgayBD;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.GroupBox grbThongKe;
        private System.Windows.Forms.DataGridView dtgvThongKe;
        private System.Windows.Forms.Button btnXemDuoiDangDoThi;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}