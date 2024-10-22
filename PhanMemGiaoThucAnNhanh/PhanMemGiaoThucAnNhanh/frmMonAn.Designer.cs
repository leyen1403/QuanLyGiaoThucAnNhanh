
namespace PhanMemGiaoThucAnNhanh
{
    partial class frmMonAn
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbbLoaiMon = new System.Windows.Forms.ComboBox();
            this.cbTrangThai = new System.Windows.Forms.ComboBox();
            this.pictureBoxMonAn = new System.Windows.Forms.PictureBox();
            this.btnLuuDuLieu = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.txtGiaMonAn = new System.Windows.Forms.TextBox();
            this.txtHinhAnh = new System.Windows.Forms.TextBox();
            this.txtTenMonAn = new System.Windows.Forms.TextBox();
            this.txtMaMonAn = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dtgvMonAn = new System.Windows.Forms.DataGridView();
            this.cbbLocLoaiMon = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMonAn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvMonAn)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbbLoaiMon);
            this.groupBox1.Controls.Add(this.cbTrangThai);
            this.groupBox1.Controls.Add(this.pictureBoxMonAn);
            this.groupBox1.Controls.Add(this.btnLuuDuLieu);
            this.groupBox1.Controls.Add(this.btnXoa);
            this.groupBox1.Controls.Add(this.btnThem);
            this.groupBox1.Controls.Add(this.txtMoTa);
            this.groupBox1.Controls.Add(this.txtGiaMonAn);
            this.groupBox1.Controls.Add(this.txtHinhAnh);
            this.groupBox1.Controls.Add(this.txtTenMonAn);
            this.groupBox1.Controls.Add(this.txtMaMonAn);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Size = new System.Drawing.Size(1164, 198);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "THÔNG TIN";
            // 
            // cbbLoaiMon
            // 
            this.cbbLoaiMon.FormattingEnabled = true;
            this.cbbLoaiMon.Items.AddRange(new object[] {
            "True",
            "False"});
            this.cbbLoaiMon.Location = new System.Drawing.Point(807, 23);
            this.cbbLoaiMon.Name = "cbbLoaiMon";
            this.cbbLoaiMon.Size = new System.Drawing.Size(139, 21);
            this.cbbLoaiMon.TabIndex = 7;
            this.cbbLoaiMon.SelectedIndexChanged += new System.EventHandler(this.cbTrangThai_SelectedIndexChanged);
            // 
            // cbTrangThai
            // 
            this.cbTrangThai.FormattingEnabled = true;
            this.cbTrangThai.Items.AddRange(new object[] {
            "True",
            "False"});
            this.cbTrangThai.Location = new System.Drawing.Point(551, 82);
            this.cbTrangThai.Name = "cbTrangThai";
            this.cbTrangThai.Size = new System.Drawing.Size(139, 21);
            this.cbTrangThai.TabIndex = 5;
            this.cbTrangThai.SelectedIndexChanged += new System.EventHandler(this.cbTrangThai_SelectedIndexChanged);
            // 
            // pictureBoxMonAn
            // 
            this.pictureBoxMonAn.Location = new System.Drawing.Point(961, 31);
            this.pictureBoxMonAn.Name = "pictureBoxMonAn";
            this.pictureBoxMonAn.Size = new System.Drawing.Size(191, 144);
            this.pictureBoxMonAn.TabIndex = 30;
            this.pictureBoxMonAn.TabStop = false;
            // 
            // btnLuuDuLieu
            // 
            this.btnLuuDuLieu.BackColor = System.Drawing.Color.Red;
            this.btnLuuDuLieu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLuuDuLieu.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuuDuLieu.ForeColor = System.Drawing.Color.White;
            this.btnLuuDuLieu.Image = global::PhanMemGiaoThucAnNhanh.Properties.Resources.icons8_save_35;
            this.btnLuuDuLieu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuuDuLieu.Location = new System.Drawing.Point(12, 153);
            this.btnLuuDuLieu.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnLuuDuLieu.Name = "btnLuuDuLieu";
            this.btnLuuDuLieu.Size = new System.Drawing.Size(117, 32);
            this.btnLuuDuLieu.TabIndex = 16;
            this.btnLuuDuLieu.Text = "Lưu dữ liệu";
            this.btnLuuDuLieu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLuuDuLieu.UseVisualStyleBackColor = false;
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.Red;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnXoa.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Image = global::PhanMemGiaoThucAnNhanh.Properties.Resources.icons8_delete_35;
            this.btnXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoa.Location = new System.Drawing.Point(12, 90);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Padding = new System.Windows.Forms.Padding(27, 0, 27, 0);
            this.btnXoa.Size = new System.Drawing.Size(117, 32);
            this.btnXoa.TabIndex = 15;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoa.UseVisualStyleBackColor = false;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.Red;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnThem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Image = global::PhanMemGiaoThucAnNhanh.Properties.Resources.icons8_add_35;
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem.Location = new System.Drawing.Point(12, 27);
            this.btnThem.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnThem.Name = "btnThem";
            this.btnThem.Padding = new System.Windows.Forms.Padding(27, 0, 17, 0);
            this.btnThem.Size = new System.Drawing.Size(117, 32);
            this.btnThem.TabIndex = 0;
            this.btnThem.Tag = "Chưa Click";
            this.btnThem.Text = "Thêm";
            this.btnThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThem.UseVisualStyleBackColor = false;
            // 
            // txtMoTa
            // 
            this.txtMoTa.Location = new System.Drawing.Point(551, 111);
            this.txtMoTa.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtMoTa.Multiline = true;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(139, 82);
            this.txtMoTa.TabIndex = 6;
            // 
            // txtGiaMonAn
            // 
            this.txtGiaMonAn.Location = new System.Drawing.Point(551, 24);
            this.txtGiaMonAn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtGiaMonAn.Name = "txtGiaMonAn";
            this.txtGiaMonAn.Size = new System.Drawing.Size(139, 20);
            this.txtGiaMonAn.TabIndex = 4;
            // 
            // txtHinhAnh
            // 
            this.txtHinhAnh.Location = new System.Drawing.Point(278, 129);
            this.txtHinhAnh.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtHinhAnh.Multiline = true;
            this.txtHinhAnh.Name = "txtHinhAnh";
            this.txtHinhAnh.Size = new System.Drawing.Size(139, 63);
            this.txtHinhAnh.TabIndex = 3;
            // 
            // txtTenMonAn
            // 
            this.txtTenMonAn.Location = new System.Drawing.Point(278, 83);
            this.txtTenMonAn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtTenMonAn.Name = "txtTenMonAn";
            this.txtTenMonAn.Size = new System.Drawing.Size(139, 20);
            this.txtTenMonAn.TabIndex = 2;
            // 
            // txtMaMonAn
            // 
            this.txtMaMonAn.Location = new System.Drawing.Point(278, 28);
            this.txtMaMonAn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtMaMonAn.Name = "txtMaMonAn";
            this.txtMaMonAn.Size = new System.Drawing.Size(139, 20);
            this.txtMaMonAn.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(446, 115);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Mô tả:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(702, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Loại món";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(446, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Giá món ăn";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(446, 86);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Trạng thái:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(173, 141);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "Tên hình ảnh:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(173, 86);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(92, 17);
            this.label14.TabIndex = 14;
            this.label14.Text = "Tên món ăn :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(891, 90);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 17);
            this.label13.TabIndex = 8;
            this.label13.Text = "Hình ảnh";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(173, 31);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(86, 17);
            this.label12.TabIndex = 17;
            this.label12.Text = "Mã món ăn :";
            // 
            // dtgvMonAn
            // 
            this.dtgvMonAn.AllowUserToAddRows = false;
            this.dtgvMonAn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dtgvMonAn.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvMonAn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvMonAn.Location = new System.Drawing.Point(0, 245);
            this.dtgvMonAn.Name = "dtgvMonAn";
            this.dtgvMonAn.Size = new System.Drawing.Size(1164, 327);
            this.dtgvMonAn.TabIndex = 2;
            // 
            // cbbLocLoaiMon
            // 
            this.cbbLocLoaiMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbLocLoaiMon.FormattingEnabled = true;
            this.cbbLocLoaiMon.Location = new System.Drawing.Point(0, 203);
            this.cbbLocLoaiMon.Name = "cbbLocLoaiMon";
            this.cbbLocLoaiMon.Size = new System.Drawing.Size(139, 28);
            this.cbbLocLoaiMon.TabIndex = 4;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(148, 204);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(307, 26);
            this.txtSearch.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Red;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Image = global::PhanMemGiaoThucAnNhanh.Properties.Resources.icons8_search_35;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(464, 205);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(52, 25);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // frmMonAn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1164, 572);
            this.Controls.Add(this.dtgvMonAn);
            this.Controls.Add(this.cbbLocLoaiMon);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtSearch);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "frmMonAn";
            this.Text = "Quản lý loại món ăn";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMonAn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvMonAn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTenMonAn;
        private System.Windows.Forms.TextBox txtMaMonAn;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnLuuDuLieu;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridView dtgvMonAn;
        private System.Windows.Forms.PictureBox pictureBoxMonAn;
        private System.Windows.Forms.TextBox txtGiaMonAn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbTrangThai;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHinhAnh;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbbLocLoaiMon;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cbbLoaiMon;
        private System.Windows.Forms.Label label1;
    }
}