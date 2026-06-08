namespace DesktopApp_Project.GUI
{
    partial class FrmHoaDonHocPhi
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TableLayoutPanel root;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.WebBrowser browser;
        private System.Windows.Forms.TextBox txtFallback;
        private System.Windows.Forms.FlowLayoutPanel buttons;
        private System.Windows.Forms.Button btnXuatHtml;
        private System.Windows.Forms.Button btnIn;
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
            this.browser = new System.Windows.Forms.WebBrowser();
            this.txtFallback = new System.Windows.Forms.TextBox();
            this.buttons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnXuatHtml = new System.Windows.Forms.Button();
            this.btnIn = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.root.SuspendLayout();
            this.buttons.SuspendLayout();
            this.SuspendLayout();
            // 
            // root
            // 
            this.root.ColumnCount = 1;
            this.root.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.root.Controls.Add(this.lblTitle, 0, 0);
            this.root.Controls.Add(this.browser, 0, 1);
            this.root.Controls.Add(this.txtFallback, 0, 1);
            this.root.Controls.Add(this.buttons, 0, 2);
            this.root.Dock = System.Windows.Forms.DockStyle.Fill;
            this.root.Location = new System.Drawing.Point(0, 0);
            this.root.Name = "root";
            this.root.RowCount = 3;
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.root.Size = new System.Drawing.Size(900, 650);
            this.root.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.lblTitle.Size = new System.Drawing.Size(894, 52);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Hóa đơn học phí";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // browser
            // 
            this.browser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browser.Location = new System.Drawing.Point(3, 585);
            this.browser.Name = "browser";
            this.browser.Size = new System.Drawing.Size(894, 42);
            this.browser.TabIndex = 1;
            // 
            // txtFallback
            // 
            this.txtFallback.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFallback.Location = new System.Drawing.Point(3, 55);
            this.txtFallback.Multiline = true;
            this.txtFallback.Name = "txtFallback";
            this.txtFallback.ReadOnly = true;
            this.txtFallback.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtFallback.Size = new System.Drawing.Size(894, 524);
            this.txtFallback.TabIndex = 2;
            this.txtFallback.Visible = false;
            // 
            // buttons
            // 
            this.buttons.AutoSize = true;
            this.buttons.Controls.Add(this.btnXuatHtml);
            this.buttons.Controls.Add(this.btnIn);
            this.buttons.Controls.Add(this.btnDong);
            this.buttons.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttons.Location = new System.Drawing.Point(589, 633);
            this.buttons.Name = "buttons";
            this.buttons.Size = new System.Drawing.Size(308, 14);
            this.buttons.TabIndex = 3;
            // 
            // btnXuatHtml
            // 
            this.btnXuatHtml.Location = new System.Drawing.Point(3, 3);
            this.btnXuatHtml.Name = "btnXuatHtml";
            this.btnXuatHtml.Size = new System.Drawing.Size(110, 34);
            this.btnXuatHtml.TabIndex = 0;
            this.btnXuatHtml.Text = "Xuat HTML";
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(119, 3);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(90, 34);
            this.btnIn.TabIndex = 1;
            this.btnIn.Text = "In";
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(215, 3);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(90, 34);
            this.btnDong.TabIndex = 2;
            this.btnDong.Text = "Dong";
            // 
            // FrmHoaDonHocPhi
            // 
            this.ClientSize = new System.Drawing.Size(900, 650);
            this.Controls.Add(this.root);
            this.Name = "FrmHoaDonHocPhi";
            this.Text = "Hóa đơn học phí";
            this.root.ResumeLayout(false);
            this.root.PerformLayout();
            this.buttons.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
