
namespace PhanMemGiaoThucAnNhanh
{
    partial class frmLoaiMon
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
            this.dtgvTTLH = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnHuyThem = new System.Windows.Forms.Button();
            this.btnLuuDuLieu = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.txtTENLH = new System.Windows.Forms.TextBox();
            this.txtMALH = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvTTLH)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgvTTLH
            // 
            this.dtgvTTLH.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvTTLH.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgvTTLH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvTTLH.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dtgvTTLH.Location = new System.Drawing.Point(0, 294);
            this.dtgvTTLH.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dtgvTTLH.Name = "dtgvTTLH";
            this.dtgvTTLH.RowHeadersWidth = 51;
            this.dtgvTTLH.RowTemplate.Height = 24;
            this.dtgvTTLH.Size = new System.Drawing.Size(1164, 278);
            this.dtgvTTLH.TabIndex = 21;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnHuyThem);
            this.groupBox1.Controls.Add(this.btnLuuDuLieu);
            this.groupBox1.Controls.Add(this.btnXoa);
            this.groupBox1.Controls.Add(this.btnThem);
            this.groupBox1.Controls.Add(this.txtMoTa);
            this.groupBox1.Controls.Add(this.txtTENLH);
            this.groupBox1.Controls.Add(this.txtMALH);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Size = new System.Drawing.Size(1164, 288);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "THÔNG TIN";
            // 
            // btnHuyThem
            // 
            this.btnHuyThem.BackColor = System.Drawing.Color.Red;
            this.btnHuyThem.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnHuyThem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuyThem.ForeColor = System.Drawing.Color.White;
            this.btnHuyThem.Image = global::PhanMemGiaoThucAnNhanh.Properties.Resources.icons8_cancel_35;
            this.btnHuyThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHuyThem.Location = new System.Drawing.Point(628, 222);
            this.btnHuyThem.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnHuyThem.Name = "btnHuyThem";
            this.btnHuyThem.Size = new System.Drawing.Size(117, 32);
            this.btnHuyThem.TabIndex = 28;
            this.btnHuyThem.Text = "Hủy Thêm";
            this.btnHuyThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHuyThem.UseVisualStyleBackColor = false;
            // 
            // btnLuuDuLieu
            // 
            this.btnLuuDuLieu.BackColor = System.Drawing.Color.Red;
            this.btnLuuDuLieu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLuuDuLieu.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuuDuLieu.ForeColor = System.Drawing.Color.White;
            this.btnLuuDuLieu.Image = global::PhanMemGiaoThucAnNhanh.Properties.Resources.icons8_save_35;
            this.btnLuuDuLieu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuuDuLieu.Location = new System.Drawing.Point(421, 222);
            this.btnLuuDuLieu.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnLuuDuLieu.Name = "btnLuuDuLieu";
            this.btnLuuDuLieu.Size = new System.Drawing.Size(117, 32);
            this.btnLuuDuLieu.TabIndex = 29;
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
            this.btnXoa.Location = new System.Drawing.Point(628, 161);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Padding = new System.Windows.Forms.Padding(27, 0, 27, 0);
            this.btnXoa.Size = new System.Drawing.Size(117, 32);
            this.btnXoa.TabIndex = 27;
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
            this.btnThem.Location = new System.Drawing.Point(420, 161);
            this.btnThem.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnThem.Name = "btnThem";
            this.btnThem.Padding = new System.Windows.Forms.Padding(27, 0, 17, 0);
            this.btnThem.Size = new System.Drawing.Size(117, 32);
            this.btnThem.TabIndex = 26;
            this.btnThem.Tag = "Chưa Click";
            this.btnThem.Text = "Thêm";
            this.btnThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThem.UseVisualStyleBackColor = false;
            // 
            // txtMoTa
            // 
            this.txtMoTa.Location = new System.Drawing.Point(389, 79);
            this.txtMoTa.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtMoTa.Multiline = true;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(559, 78);
            this.txtMoTa.TabIndex = 19;
            // 
            // txtTENLH
            // 
            this.txtTENLH.Location = new System.Drawing.Point(741, 34);
            this.txtTENLH.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtTENLH.Name = "txtTENLH";
            this.txtTENLH.Size = new System.Drawing.Size(139, 20);
            this.txtTENLH.TabIndex = 18;
            // 
            // txtMALH
            // 
            this.txtMALH.Location = new System.Drawing.Point(389, 32);
            this.txtMALH.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtMALH.Name = "txtMALH";
            this.txtMALH.Size = new System.Drawing.Size(139, 20);
            this.txtMALH.TabIndex = 17;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(636, 38);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(98, 17);
            this.label14.TabIndex = 4;
            this.label14.Text = "Tên loại món :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(284, 81);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 17);
            this.label13.TabIndex = 3;
            this.label13.Text = "Mô tả :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(284, 34);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(96, 17);
            this.label12.TabIndex = 2;
            this.label12.Text = "Mã loại món  :";
            // 
            // frmLoaiMon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1164, 572);
            this.Controls.Add(this.dtgvTTLH);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "frmLoaiMon";
            this.Text = "Quản lý loại món ăn";
            ((System.ComponentModel.ISupportInitialize)(this.dtgvTTLH)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgvTTLH;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.TextBox txtTENLH;
        private System.Windows.Forms.TextBox txtMALH;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnHuyThem;
        private System.Windows.Forms.Button btnLuuDuLieu;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
    }
}