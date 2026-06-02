namespace DesktopApp_Project.GUI
{
    partial class FrmThanhToan
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TableLayoutPanel root;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TableLayoutPanel form;
        private System.Windows.Forms.Label lblHocVienValue;
        private System.Windows.Forms.Label lblLopValue;
        private System.Windows.Forms.Label lblSoTienValue;
        private System.Windows.Forms.Label lblTrangThaiValue;
        private System.Windows.Forms.Label lblHanValue;
        private System.Windows.Forms.ComboBox cboPhuongThuc;
        private System.Windows.Forms.TextBox txtReceiverEmail;
        private System.Windows.Forms.TextBox txtPaymentUrl;
        private System.Windows.Forms.TextBox txtQrContent;
        private System.Windows.Forms.FlowLayoutPanel buttons;
        private System.Windows.Forms.Button btnTaoThanhToan;
        private System.Windows.Forms.Button btnFakeComplete;
        private System.Windows.Forms.Button btnFakeExpired;
        private System.Windows.Forms.Button btnFakeFailed;
        private System.Windows.Forms.Button btnDong;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.root = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.form = new System.Windows.Forms.TableLayoutPanel();
            this.lblHocVien = new System.Windows.Forms.Label();
            this.lblHocVienValue = new System.Windows.Forms.Label();
            this.lblLop = new System.Windows.Forms.Label();
            this.lblLopValue = new System.Windows.Forms.Label();
            this.lblSoTien = new System.Windows.Forms.Label();
            this.lblSoTienValue = new System.Windows.Forms.Label();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.lblTrangThaiValue = new System.Windows.Forms.Label();
            this.lblHan = new System.Windows.Forms.Label();
            this.lblHanValue = new System.Windows.Forms.Label();
            this.lblPhuongThuc = new System.Windows.Forms.Label();
            this.cboPhuongThuc = new System.Windows.Forms.ComboBox();
            this.lblReceiverEmail = new System.Windows.Forms.Label();
            this.txtReceiverEmail = new System.Windows.Forms.TextBox();
            this.lblPaymentUrl = new System.Windows.Forms.Label();
            this.txtPaymentUrl = new System.Windows.Forms.TextBox();
            this.lblQrContent = new System.Windows.Forms.Label();
            this.txtQrContent = new System.Windows.Forms.TextBox();
            this.buttons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTaoThanhToan = new System.Windows.Forms.Button();
            this.btnFakeComplete = new System.Windows.Forms.Button();
            this.btnFakeExpired = new System.Windows.Forms.Button();
            this.btnFakeFailed = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.root.SuspendLayout();
            this.form.SuspendLayout();
            this.buttons.SuspendLayout();
            this.SuspendLayout();
            // 
            // root
            // 
            this.root.ColumnCount = 1;
            this.root.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.root.Controls.Add(this.lblTitle, 0, 0);
            this.root.Controls.Add(this.form, 0, 1);
            this.root.Controls.Add(this.buttons, 0, 2);
            this.root.Dock = System.Windows.Forms.DockStyle.Fill;
            this.root.Location = new System.Drawing.Point(0, 0);
            this.root.Name = "root";
            this.root.RowCount = 3;
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.root.Size = new System.Drawing.Size(760, 540);
            this.root.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.lblTitle.Size = new System.Drawing.Size(754, 52);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Thanh toán học phí";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // form
            // 
            this.form.ColumnCount = 2;
            this.form.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.form.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.form.Controls.Add(this.lblHocVien, 0, 0);
            this.form.Controls.Add(this.lblHocVienValue, 1, 0);
            this.form.Controls.Add(this.lblLop, 0, 1);
            this.form.Controls.Add(this.lblLopValue, 1, 1);
            this.form.Controls.Add(this.lblSoTien, 0, 2);
            this.form.Controls.Add(this.lblSoTienValue, 1, 2);
            this.form.Controls.Add(this.lblTrangThai, 0, 3);
            this.form.Controls.Add(this.lblTrangThaiValue, 1, 3);
            this.form.Controls.Add(this.lblHan, 0, 4);
            this.form.Controls.Add(this.lblHanValue, 1, 4);
            this.form.Controls.Add(this.lblPhuongThuc, 0, 5);
            this.form.Controls.Add(this.cboPhuongThuc, 1, 5);
            this.form.Controls.Add(this.lblReceiverEmail, 0, 6);
            this.form.Controls.Add(this.txtReceiverEmail, 1, 6);
            this.form.Controls.Add(this.lblPaymentUrl, 0, 7);
            this.form.Controls.Add(this.txtPaymentUrl, 1, 7);
            this.form.Controls.Add(this.lblQrContent, 0, 8);
            this.form.Controls.Add(this.txtQrContent, 1, 8);
            this.form.Dock = System.Windows.Forms.DockStyle.Fill;
            this.form.Location = new System.Drawing.Point(3, 55);
            this.form.Name = "form";
            this.form.Padding = new System.Windows.Forms.Padding(16);
            this.form.RowCount = 9;
            this.form.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.form.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.form.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.form.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.form.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.form.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.form.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.form.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.form.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.form.Size = new System.Drawing.Size(754, 428);
            this.form.TabIndex = 1;
            // 
            // lblHocVien
            // 
            this.lblHocVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHocVien.Location = new System.Drawing.Point(19, 16);
            this.lblHocVien.Name = "lblHocVien";
            this.lblHocVien.Size = new System.Drawing.Size(144, 36);
            this.lblHocVien.TabIndex = 0;
            this.lblHocVien.Text = "Hoc vien";
            this.lblHocVien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHocVienValue
            // 
            this.lblHocVienValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHocVienValue.Location = new System.Drawing.Point(169, 16);
            this.lblHocVienValue.Name = "lblHocVienValue";
            this.lblHocVienValue.Size = new System.Drawing.Size(566, 36);
            this.lblHocVienValue.TabIndex = 1;
            // 
            // lblLop
            // 
            this.lblLop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLop.Location = new System.Drawing.Point(19, 52);
            this.lblLop.Name = "lblLop";
            this.lblLop.Size = new System.Drawing.Size(144, 36);
            this.lblLop.TabIndex = 2;
            this.lblLop.Text = "Lop";
            this.lblLop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLopValue
            // 
            this.lblLopValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLopValue.Location = new System.Drawing.Point(169, 52);
            this.lblLopValue.Name = "lblLopValue";
            this.lblLopValue.Size = new System.Drawing.Size(566, 36);
            this.lblLopValue.TabIndex = 3;
            // 
            // lblSoTien
            // 
            this.lblSoTien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSoTien.Location = new System.Drawing.Point(19, 88);
            this.lblSoTien.Name = "lblSoTien";
            this.lblSoTien.Size = new System.Drawing.Size(144, 36);
            this.lblSoTien.TabIndex = 4;
            this.lblSoTien.Text = "So tien";
            this.lblSoTien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSoTienValue
            // 
            this.lblSoTienValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSoTienValue.Location = new System.Drawing.Point(169, 88);
            this.lblSoTienValue.Name = "lblSoTienValue";
            this.lblSoTienValue.Size = new System.Drawing.Size(566, 36);
            this.lblSoTienValue.TabIndex = 5;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTrangThai.Location = new System.Drawing.Point(19, 124);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(144, 36);
            this.lblTrangThai.TabIndex = 6;
            this.lblTrangThai.Text = "Trang thai";
            this.lblTrangThai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTrangThaiValue
            // 
            this.lblTrangThaiValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTrangThaiValue.Location = new System.Drawing.Point(169, 124);
            this.lblTrangThaiValue.Name = "lblTrangThaiValue";
            this.lblTrangThaiValue.Size = new System.Drawing.Size(566, 36);
            this.lblTrangThaiValue.TabIndex = 7;
            // 
            // lblHan
            // 
            this.lblHan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHan.Location = new System.Drawing.Point(19, 160);
            this.lblHan.Name = "lblHan";
            this.lblHan.Size = new System.Drawing.Size(144, 36);
            this.lblHan.TabIndex = 8;
            this.lblHan.Text = "Han thanh toan";
            this.lblHan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHanValue
            // 
            this.lblHanValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHanValue.Location = new System.Drawing.Point(169, 160);
            this.lblHanValue.Name = "lblHanValue";
            this.lblHanValue.Size = new System.Drawing.Size(566, 36);
            this.lblHanValue.TabIndex = 9;
            // 
            // lblPhuongThuc
            // 
            this.lblPhuongThuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPhuongThuc.Location = new System.Drawing.Point(19, 196);
            this.lblPhuongThuc.Name = "lblPhuongThuc";
            this.lblPhuongThuc.Size = new System.Drawing.Size(144, 36);
            this.lblPhuongThuc.TabIndex = 10;
            this.lblPhuongThuc.Text = "Phuong thuc";
            this.lblPhuongThuc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboPhuongThuc
            // 
            this.cboPhuongThuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboPhuongThuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhuongThuc.Location = new System.Drawing.Point(169, 199);
            this.cboPhuongThuc.Name = "cboPhuongThuc";
            this.cboPhuongThuc.Size = new System.Drawing.Size(566, 21);
            this.cboPhuongThuc.TabIndex = 11;
            // 
            // lblReceiverEmail
            // 
            this.lblReceiverEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblReceiverEmail.Location = new System.Drawing.Point(19, 232);
            this.lblReceiverEmail.Name = "lblReceiverEmail";
            this.lblReceiverEmail.Size = new System.Drawing.Size(144, 36);
            this.lblReceiverEmail.TabIndex = 12;
            this.lblReceiverEmail.Text = "Email nhan";
            this.lblReceiverEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtReceiverEmail
            // 
            this.txtReceiverEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtReceiverEmail.Location = new System.Drawing.Point(169, 235);
            this.txtReceiverEmail.Name = "txtReceiverEmail";
            this.txtReceiverEmail.Size = new System.Drawing.Size(566, 20);
            this.txtReceiverEmail.TabIndex = 13;
            // 
            // lblPaymentUrl
            // 
            this.lblPaymentUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPaymentUrl.Location = new System.Drawing.Point(19, 268);
            this.lblPaymentUrl.Name = "lblPaymentUrl";
            this.lblPaymentUrl.Size = new System.Drawing.Size(144, 70);
            this.lblPaymentUrl.TabIndex = 14;
            this.lblPaymentUrl.Text = "Payment URL";
            this.lblPaymentUrl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPaymentUrl
            // 
            this.txtPaymentUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPaymentUrl.Location = new System.Drawing.Point(169, 271);
            this.txtPaymentUrl.Multiline = true;
            this.txtPaymentUrl.Name = "txtPaymentUrl";
            this.txtPaymentUrl.ReadOnly = true;
            this.txtPaymentUrl.Size = new System.Drawing.Size(566, 64);
            this.txtPaymentUrl.TabIndex = 15;
            // 
            // lblQrContent
            // 
            this.lblQrContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblQrContent.Location = new System.Drawing.Point(19, 338);
            this.lblQrContent.Name = "lblQrContent";
            this.lblQrContent.Size = new System.Drawing.Size(144, 74);
            this.lblQrContent.TabIndex = 16;
            this.lblQrContent.Text = "QR content";
            this.lblQrContent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtQrContent
            // 
            this.txtQrContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtQrContent.Location = new System.Drawing.Point(169, 341);
            this.txtQrContent.Multiline = true;
            this.txtQrContent.Name = "txtQrContent";
            this.txtQrContent.ReadOnly = true;
            this.txtQrContent.Size = new System.Drawing.Size(566, 68);
            this.txtQrContent.TabIndex = 17;
            // 
            // buttons
            // 
            this.buttons.AutoSize = true;
            this.buttons.Controls.Add(this.btnTaoThanhToan);
            this.buttons.Controls.Add(this.btnFakeComplete);
            this.buttons.Controls.Add(this.btnFakeExpired);
            this.buttons.Controls.Add(this.btnFakeFailed);
            this.buttons.Controls.Add(this.btnDong);
            this.buttons.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttons.Location = new System.Drawing.Point(147, 489);
            this.buttons.Name = "buttons";
            this.buttons.Size = new System.Drawing.Size(610, 48);
            this.buttons.TabIndex = 2;
            // 
            // btnTaoThanhToan
            // 
            this.btnTaoThanhToan.Location = new System.Drawing.Point(3, 3);
            this.btnTaoThanhToan.Name = "btnTaoThanhToan";
            this.btnTaoThanhToan.Size = new System.Drawing.Size(120, 34);
            this.btnTaoThanhToan.TabIndex = 0;
            this.btnTaoThanhToan.Text = "Tao thanh toan";
            // 
            // btnFakeComplete
            // 
            this.btnFakeComplete.Location = new System.Drawing.Point(129, 3);
            this.btnFakeComplete.Name = "btnFakeComplete";
            this.btnFakeComplete.Size = new System.Drawing.Size(130, 34);
            this.btnFakeComplete.TabIndex = 1;
            this.btnFakeComplete.Text = "Gia lap hoan tat";
            // 
            // btnFakeExpired
            // 
            this.btnFakeExpired.Location = new System.Drawing.Point(265, 3);
            this.btnFakeExpired.Name = "btnFakeExpired";
            this.btnFakeExpired.Size = new System.Drawing.Size(120, 34);
            this.btnFakeExpired.TabIndex = 2;
            this.btnFakeExpired.Text = "Gia lap het han";
            // 
            // btnFakeFailed
            // 
            this.btnFakeFailed.Location = new System.Drawing.Point(391, 3);
            this.btnFakeFailed.Name = "btnFakeFailed";
            this.btnFakeFailed.Size = new System.Drawing.Size(120, 34);
            this.btnFakeFailed.TabIndex = 3;
            this.btnFakeFailed.Text = "Gia lap that bai";
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(517, 3);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(90, 34);
            this.btnDong.TabIndex = 4;
            this.btnDong.Text = "Dong";
            // 
            // FrmThanhToan
            // 
            this.ClientSize = new System.Drawing.Size(760, 540);
            this.Controls.Add(this.root);
            this.Name = "FrmThanhToan";
            this.Text = "Thanh toán học phí";
            this.root.ResumeLayout(false);
            this.root.PerformLayout();
            this.form.ResumeLayout(false);
            this.form.PerformLayout();
            this.buttons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label lblHocVien;
        private System.Windows.Forms.Label lblLop;
        private System.Windows.Forms.Label lblSoTien;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.Label lblHan;
        private System.Windows.Forms.Label lblPhuongThuc;
        private System.Windows.Forms.Label lblReceiverEmail;
        private System.Windows.Forms.Label lblPaymentUrl;
        private System.Windows.Forms.Label lblQrContent;
    }
}
