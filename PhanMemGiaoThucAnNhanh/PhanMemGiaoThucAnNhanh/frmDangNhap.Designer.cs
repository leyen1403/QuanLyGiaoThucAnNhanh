namespace PhanMemGiaoThucAnNhanh
{
    partial class frmDangNhap
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
            this.lbl_TaoTaiKhoan = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_Xoa = new System.Windows.Forms.Button();
            this.btn_DangNhap = new System.Windows.Forms.Button();
            this.cb_HienMatKhau = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.txt_MatKhau = new System.Windows.Forms.TextBox();
            this.lbl_MatKhau = new System.Windows.Forms.Label();
            this.txt_TenDangNhap = new System.Windows.Forms.TextBox();
            this.lbl_TenDangNhap = new System.Windows.Forms.Label();
            this.lbl_DangNhap = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_TaoTaiKhoan
            // 
            this.lbl_TaoTaiKhoan.AutoSize = true;
            this.lbl_TaoTaiKhoan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_TaoTaiKhoan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(78)))), ((int)(((byte)(165)))));
            this.lbl_TaoTaiKhoan.Location = new System.Drawing.Point(89, 435);
            this.lbl_TaoTaiKhoan.Name = "lbl_TaoTaiKhoan";
            this.lbl_TaoTaiKhoan.Size = new System.Drawing.Size(73, 13);
            this.lbl_TaoTaiKhoan.TabIndex = 30;
            this.lbl_TaoTaiKhoan.Text = "Tạo tài khoản";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(57, 409);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Bạn chưa có tài khoản?";
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.BackColor = System.Drawing.Color.White;
            this.btn_Xoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Xoa.FlatAppearance.BorderSize = 2;
            this.btn_Xoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Xoa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.btn_Xoa.Location = new System.Drawing.Point(28, 369);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(218, 28);
            this.btn_Xoa.TabIndex = 25;
            this.btn_Xoa.Text = "XOÁ";
            this.btn_Xoa.UseVisualStyleBackColor = false;
            // 
            // btn_DangNhap
            // 
            this.btn_DangNhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.btn_DangNhap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_DangNhap.FlatAppearance.BorderSize = 0;
            this.btn_DangNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DangNhap.ForeColor = System.Drawing.Color.White;
            this.btn_DangNhap.Location = new System.Drawing.Point(28, 322);
            this.btn_DangNhap.Name = "btn_DangNhap";
            this.btn_DangNhap.Size = new System.Drawing.Size(218, 28);
            this.btn_DangNhap.TabIndex = 24;
            this.btn_DangNhap.Text = "ĐĂNG NHẬP";
            this.btn_DangNhap.UseVisualStyleBackColor = false;
            // 
            // cb_HienMatKhau
            // 
            this.cb_HienMatKhau.AutoSize = true;
            this.cb_HienMatKhau.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_HienMatKhau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_HienMatKhau.Location = new System.Drawing.Point(124, 267);
            this.cb_HienMatKhau.Name = "cb_HienMatKhau";
            this.cb_HienMatKhau.Size = new System.Drawing.Size(92, 17);
            this.cb_HienMatKhau.TabIndex = 23;
            this.cb_HienMatKhau.Text = "Hiện mật khẩu";
            this.cb_HienMatKhau.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(124, 322);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(102, 17);
            this.checkBox1.TabIndex = 29;
            this.checkBox1.Text = "Show Password";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // txt_MatKhau
            // 
            this.txt_MatKhau.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.txt_MatKhau.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_MatKhau.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_MatKhau.Location = new System.Drawing.Point(28, 214);
            this.txt_MatKhau.Multiline = true;
            this.txt_MatKhau.Name = "txt_MatKhau";
            this.txt_MatKhau.PasswordChar = '*';
            this.txt_MatKhau.Size = new System.Drawing.Size(218, 28);
            this.txt_MatKhau.TabIndex = 22;
            // 
            // lbl_MatKhau
            // 
            this.lbl_MatKhau.AutoSize = true;
            this.lbl_MatKhau.Location = new System.Drawing.Point(25, 185);
            this.lbl_MatKhau.Name = "lbl_MatKhau";
            this.lbl_MatKhau.Size = new System.Drawing.Size(55, 13);
            this.lbl_MatKhau.TabIndex = 27;
            this.lbl_MatKhau.Text = "Mật khẩu:";
            // 
            // txt_TenDangNhap
            // 
            this.txt_TenDangNhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.txt_TenDangNhap.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_TenDangNhap.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TenDangNhap.Location = new System.Drawing.Point(28, 139);
            this.txt_TenDangNhap.Multiline = true;
            this.txt_TenDangNhap.Name = "txt_TenDangNhap";
            this.txt_TenDangNhap.Size = new System.Drawing.Size(218, 28);
            this.txt_TenDangNhap.TabIndex = 21;
            // 
            // lbl_TenDangNhap
            // 
            this.lbl_TenDangNhap.AutoSize = true;
            this.lbl_TenDangNhap.Location = new System.Drawing.Point(25, 109);
            this.lbl_TenDangNhap.Name = "lbl_TenDangNhap";
            this.lbl_TenDangNhap.Size = new System.Drawing.Size(84, 13);
            this.lbl_TenDangNhap.TabIndex = 28;
            this.lbl_TenDangNhap.Text = "Tên đăng nhập:";
            // 
            // lbl_DangNhap
            // 
            this.lbl_DangNhap.AutoSize = true;
            this.lbl_DangNhap.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_DangNhap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.lbl_DangNhap.Location = new System.Drawing.Point(23, 56);
            this.lbl_DangNhap.Name = "lbl_DangNhap";
            this.lbl_DangNhap.Size = new System.Drawing.Size(165, 27);
            this.lbl_DangNhap.TabIndex = 26;
            this.lbl_DangNhap.Text = "ĐĂNG NHẬP";
            // 
            // frmDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 505);
            this.Controls.Add(this.lbl_TaoTaiKhoan);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_Xoa);
            this.Controls.Add(this.btn_DangNhap);
            this.Controls.Add(this.cb_HienMatKhau);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.txt_MatKhau);
            this.Controls.Add(this.lbl_MatKhau);
            this.Controls.Add(this.txt_TenDangNhap);
            this.Controls.Add(this.lbl_TenDangNhap);
            this.Controls.Add(this.lbl_DangNhap);
            this.Name = "frmDangNhap";
            this.Text = "frmDangNhap";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_TaoTaiKhoan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_Xoa;
        private System.Windows.Forms.Button btn_DangNhap;
        private System.Windows.Forms.CheckBox cb_HienMatKhau;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox txt_MatKhau;
        private System.Windows.Forms.Label lbl_MatKhau;
        private System.Windows.Forms.TextBox txt_TenDangNhap;
        private System.Windows.Forms.Label lbl_TenDangNhap;
        private System.Windows.Forms.Label lbl_DangNhap;
    }
}