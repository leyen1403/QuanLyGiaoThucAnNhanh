
namespace UC
{
    partial class UC_MonAn
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTenMonAn = new System.Windows.Forms.Label();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.lblGiaMonAn = new System.Windows.Forms.Label();
            this.lblSelected = new System.Windows.Forms.Label();
            this.btnGiam = new System.Windows.Forms.Button();
            this.btnTang = new System.Windows.Forms.Button();
            this.ptbHinhAnh = new System.Windows.Forms.PictureBox();
            this.lbl_SoLuongDaChon = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ptbHinhAnh)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTenMonAn
            // 
            this.lblTenMonAn.AutoSize = true;
            this.lblTenMonAn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenMonAn.ForeColor = System.Drawing.Color.Black;
            this.lblTenMonAn.Location = new System.Drawing.Point(3, 150);
            this.lblTenMonAn.Name = "lblTenMonAn";
            this.lblTenMonAn.Size = new System.Drawing.Size(81, 16);
            this.lblTenMonAn.TabIndex = 1;
            this.lblTenMonAn.Text = "Tên món ăn";
            // 
            // lblMoTa
            // 
            this.lblMoTa.AutoSize = true;
            this.lblMoTa.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoTa.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblMoTa.Location = new System.Drawing.Point(3, 174);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(38, 14);
            this.lblMoTa.TabIndex = 2;
            this.lblMoTa.Text = "Mô tả";
            // 
            // lblGiaMonAn
            // 
            this.lblGiaMonAn.AutoSize = true;
            this.lblGiaMonAn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGiaMonAn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblGiaMonAn.Location = new System.Drawing.Point(4, 238);
            this.lblGiaMonAn.Name = "lblGiaMonAn";
            this.lblGiaMonAn.Size = new System.Drawing.Size(59, 16);
            this.lblGiaMonAn.TabIndex = 3;
            this.lblGiaMonAn.Text = "₫15,000";
            // 
            // lblSelected
            // 
            this.lblSelected.BackColor = System.Drawing.Color.Gray;
            this.lblSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelected.ForeColor = System.Drawing.Color.White;
            this.lblSelected.Location = new System.Drawing.Point(156, 10);
            this.lblSelected.Name = "lblSelected";
            this.lblSelected.Size = new System.Drawing.Size(32, 23);
            this.lblSelected.TabIndex = 4;
            this.lblSelected.Text = "0";
            this.lblSelected.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnGiam
            // 
            this.btnGiam.Image = global::UC.Properties.Resources.icons8_minus_35;
            this.btnGiam.Location = new System.Drawing.Point(92, 230);
            this.btnGiam.Name = "btnGiam";
            this.btnGiam.Size = new System.Drawing.Size(38, 32);
            this.btnGiam.TabIndex = 5;
            this.btnGiam.UseVisualStyleBackColor = true;
            // 
            // btnTang
            // 
            this.btnTang.Image = global::UC.Properties.Resources.icons8_add_35;
            this.btnTang.Location = new System.Drawing.Point(169, 230);
            this.btnTang.Name = "btnTang";
            this.btnTang.Size = new System.Drawing.Size(38, 32);
            this.btnTang.TabIndex = 5;
            this.btnTang.UseVisualStyleBackColor = true;
            // 
            // ptbHinhAnh
            // 
            this.ptbHinhAnh.Location = new System.Drawing.Point(0, 0);
            this.ptbHinhAnh.Name = "ptbHinhAnh";
            this.ptbHinhAnh.Size = new System.Drawing.Size(210, 147);
            this.ptbHinhAnh.TabIndex = 4;
            this.ptbHinhAnh.TabStop = false;
            // 
            // lbl_SoLuongDaChon
            // 
            this.lbl_SoLuongDaChon.AutoSize = true;
            this.lbl_SoLuongDaChon.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_SoLuongDaChon.ForeColor = System.Drawing.Color.Blue;
            this.lbl_SoLuongDaChon.Location = new System.Drawing.Point(136, 234);
            this.lbl_SoLuongDaChon.Name = "lbl_SoLuongDaChon";
            this.lbl_SoLuongDaChon.Size = new System.Drawing.Size(32, 24);
            this.lbl_SoLuongDaChon.TabIndex = 6;
            this.lbl_SoLuongDaChon.Text = "15";
            // 
            // UC_MonAn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.lbl_SoLuongDaChon);
            this.Controls.Add(this.btnGiam);
            this.Controls.Add(this.btnTang);
            this.Controls.Add(this.ptbHinhAnh);
            this.Controls.Add(this.lblGiaMonAn);
            this.Controls.Add(this.lblMoTa);
            this.Controls.Add(this.lblTenMonAn);
            this.Name = "UC_MonAn";
            this.Size = new System.Drawing.Size(210, 288);
            ((System.ComponentModel.ISupportInitialize)(this.ptbHinhAnh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGiaMonAn;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.Label lblTenMonAn;
        private System.Windows.Forms.Label lblSelected;
        private System.Windows.Forms.PictureBox ptbHinhAnh;
        private System.Windows.Forms.Button btnTang;
        private System.Windows.Forms.Button btnGiam;
        private System.Windows.Forms.Label lbl_SoLuongDaChon;
    }
}
