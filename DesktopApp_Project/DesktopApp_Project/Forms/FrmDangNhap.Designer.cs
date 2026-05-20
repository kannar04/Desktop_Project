namespace DesktopApp_Project.Forms
{
    partial class FrmDangNhap
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
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.btnLogin = new FontAwesome.Sharp.IconButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.icoShowPass = new FontAwesome.Sharp.IconPictureBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.pnlUnder2 = new System.Windows.Forms.Panel();
            this.icoPassword = new FontAwesome.Sharp.IconPictureBox();
            this.pnlUsername = new System.Windows.Forms.Panel();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.pnlUnder1 = new System.Windows.Forms.Panel();
            this.icoUsername = new FontAwesome.Sharp.IconPictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlLogin.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icoShowPass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icoPassword)).BeginInit();
            this.pnlUsername.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icoUsername)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLogin
            // 
            this.pnlLogin.Controls.Add(this.btnLogin);
            this.pnlLogin.Controls.Add(this.panel1);
            this.pnlLogin.Controls.Add(this.pnlUsername);
            this.pnlLogin.Controls.Add(this.label3);
            this.pnlLogin.Location = new System.Drawing.Point(375, 25);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Size = new System.Drawing.Size(400, 500);
            this.pnlLogin.TabIndex = 0;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(77)))), ((int)(((byte)(221)))));
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.IconChar = FontAwesome.Sharp.IconChar.SignIn;
            this.btnLogin.IconColor = System.Drawing.Color.Gainsboro;
            this.btnLogin.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLogin.Location = new System.Drawing.Point(152, 340);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(97, 46);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.icoShowPass);
            this.panel1.Controls.Add(this.lblPassword);
            this.panel1.Controls.Add(this.txtPassword);
            this.panel1.Controls.Add(this.pnlUnder2);
            this.panel1.Controls.Add(this.icoPassword);
            this.panel1.Location = new System.Drawing.Point(26, 231);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 70);
            this.panel1.TabIndex = 0;
            // 
            // icoShowPass
            // 
            this.icoShowPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.icoShowPass.ForeColor = System.Drawing.Color.Gainsboro;
            this.icoShowPass.IconChar = FontAwesome.Sharp.IconChar.Eye;
            this.icoShowPass.IconColor = System.Drawing.Color.Gainsboro;
            this.icoShowPass.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icoShowPass.IconSize = 25;
            this.icoShowPass.Location = new System.Drawing.Point(312, 28);
            this.icoShowPass.Name = "icoShowPass";
            this.icoShowPass.Size = new System.Drawing.Size(25, 25);
            this.icoShowPass.TabIndex = 4;
            this.icoShowPass.TabStop = false;
            this.icoShowPass.Click += new System.EventHandler(this.icoShowPass_Click);
            // 
            // lblPassword
            // 
            this.lblPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblPassword.Location = new System.Drawing.Point(67, 28);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(81, 27);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Password";
            this.lblPassword.Click += new System.EventHandler(this.lblPassword_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtPassword.Location = new System.Drawing.Point(67, 28);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(270, 22);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.Enter += new System.EventHandler(this.txtPassword_Enter);
            this.txtPassword.Leave += new System.EventHandler(this.txtPassword_Leave);
            // 
            // pnlUnder2
            // 
            this.pnlUnder2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnlUnder2.Location = new System.Drawing.Point(67, 56);
            this.pnlUnder2.Name = "pnlUnder2";
            this.pnlUnder2.Size = new System.Drawing.Size(270, 4);
            this.pnlUnder2.TabIndex = 0;
            // 
            // icoPassword
            // 
            this.icoPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.icoPassword.ForeColor = System.Drawing.Color.Gainsboro;
            this.icoPassword.IconChar = FontAwesome.Sharp.IconChar.Key;
            this.icoPassword.IconColor = System.Drawing.Color.Gainsboro;
            this.icoPassword.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icoPassword.IconSize = 48;
            this.icoPassword.Location = new System.Drawing.Point(13, 11);
            this.icoPassword.Name = "icoPassword";
            this.icoPassword.Size = new System.Drawing.Size(48, 48);
            this.icoPassword.TabIndex = 0;
            this.icoPassword.TabStop = false;
            // 
            // pnlUsername
            // 
            this.pnlUsername.Controls.Add(this.lblUsername);
            this.pnlUsername.Controls.Add(this.txtUsername);
            this.pnlUsername.Controls.Add(this.pnlUnder1);
            this.pnlUsername.Controls.Add(this.icoUsername);
            this.pnlUsername.Location = new System.Drawing.Point(26, 142);
            this.pnlUsername.Name = "pnlUsername";
            this.pnlUsername.Size = new System.Drawing.Size(350, 70);
            this.pnlUsername.TabIndex = 0;
            // 
            // lblUsername
            // 
            this.lblUsername.BackColor = System.Drawing.Color.Transparent;
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblUsername.Location = new System.Drawing.Point(67, 28);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(81, 27);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Username";
            this.lblUsername.Click += new System.EventHandler(this.lblUsername_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsername.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtUsername.Location = new System.Drawing.Point(67, 28);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(270, 22);
            this.txtUsername.TabIndex = 1;
            this.txtUsername.Enter += new System.EventHandler(this.txtUsername_Enter);
            this.txtUsername.Leave += new System.EventHandler(this.txtUsername_Leave);
            // 
            // pnlUnder1
            // 
            this.pnlUnder1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnlUnder1.Location = new System.Drawing.Point(67, 56);
            this.pnlUnder1.Name = "pnlUnder1";
            this.pnlUnder1.Size = new System.Drawing.Size(270, 4);
            this.pnlUnder1.TabIndex = 0;
            // 
            // icoUsername
            // 
            this.icoUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.icoUsername.ForeColor = System.Drawing.Color.Gainsboro;
            this.icoUsername.IconChar = FontAwesome.Sharp.IconChar.User;
            this.icoUsername.IconColor = System.Drawing.Color.Gainsboro;
            this.icoUsername.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icoUsername.IconSize = 48;
            this.icoUsername.Location = new System.Drawing.Point(13, 11);
            this.icoUsername.Name = "icoUsername";
            this.icoUsername.Size = new System.Drawing.Size(48, 48);
            this.icoUsername.TabIndex = 0;
            this.icoUsername.TabStop = false;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(394, 60);
            this.label3.TabIndex = 0;
            this.label3.Text = "Đăng nhập";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 60);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chào mừng";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 252);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(220, 74);
            this.label2.TabIndex = 0;
            this.label2.Text = "Đây là hệ thống quản lý lớp IELTS";
            // 
            // FrmDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 550);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlLogin);
            this.Name = "FrmDangNhap";
            this.Text = "FrmDangNhap";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmDangNhap_Paint);
            this.pnlLogin.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icoShowPass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icoPassword)).EndInit();
            this.pnlUsername.ResumeLayout(false);
            this.pnlUsername.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icoUsername)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlUsername;
        private FontAwesome.Sharp.IconPictureBox icoUsername;
        private System.Windows.Forms.Panel pnlUnder1;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Panel pnlUnder2;
        private FontAwesome.Sharp.IconPictureBox icoPassword;
        private FontAwesome.Sharp.IconPictureBox icoShowPass;
        private FontAwesome.Sharp.IconButton btnLogin;
    }
}