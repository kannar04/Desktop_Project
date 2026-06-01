namespace DesktopApp_Project.GUI
{
    partial class FrmFlashcard
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TableLayoutPanel root;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TableLayoutPanel filters;
        private System.Windows.Forms.Label lblLop;
        private System.Windows.Forms.ComboBox _cboLop;
        private System.Windows.Forms.Label lblCapDo;
        private System.Windows.Forms.ComboBox _cboCapDo;
        private System.Windows.Forms.Label lblChuDe;
        private System.Windows.Forms.ComboBox _cboChuDe;
        private System.Windows.Forms.Panel cardPanel;
        private System.Windows.Forms.Label lblSide;
        private System.Windows.Forms.Label lblCardTitle;
        private System.Windows.Forms.Label lblCardValue;
        private System.Windows.Forms.Label lblCardMeta;
        private System.Windows.Forms.FlowLayoutPanel buttons;
        private System.Windows.Forms.Button btnTruoc;
        private System.Windows.Forms.Button btnLatThe;
        private System.Windows.Forms.Button btnTiepTheo;
        private System.Windows.Forms.Button btnXaoTron;
        private System.Windows.Forms.Label lblCounter;

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
            this.filters = new System.Windows.Forms.TableLayoutPanel();
            this.lblLop = new System.Windows.Forms.Label();
            this._cboLop = new System.Windows.Forms.ComboBox();
            this.lblCapDo = new System.Windows.Forms.Label();
            this._cboCapDo = new System.Windows.Forms.ComboBox();
            this.lblChuDe = new System.Windows.Forms.Label();
            this._cboChuDe = new System.Windows.Forms.ComboBox();
            this.cardPanel = new System.Windows.Forms.Panel();
            this.lblCardMeta = new System.Windows.Forms.Label();
            this.lblCardValue = new System.Windows.Forms.Label();
            this.lblCardTitle = new System.Windows.Forms.Label();
            this.lblSide = new System.Windows.Forms.Label();
            this.buttons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTruoc = new System.Windows.Forms.Button();
            this.btnLatThe = new System.Windows.Forms.Button();
            this.btnTiepTheo = new System.Windows.Forms.Button();
            this.btnXaoTron = new System.Windows.Forms.Button();
            this.lblCounter = new System.Windows.Forms.Label();
            this.root.SuspendLayout();
            this.filters.SuspendLayout();
            this.cardPanel.SuspendLayout();
            this.buttons.SuspendLayout();
            this.SuspendLayout();
            // 
            // root
            // 
            this.root.ColumnCount = 1;
            this.root.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.root.Controls.Add(this.lblTitle, 0, 0);
            this.root.Controls.Add(this.filters, 0, 1);
            this.root.Controls.Add(this.cardPanel, 0, 2);
            this.root.Controls.Add(this.buttons, 0, 3);
            this.root.Dock = System.Windows.Forms.DockStyle.Fill;
            this.root.Location = new System.Drawing.Point(0, 0);
            this.root.Name = "root";
            this.root.RowCount = 4;
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.root.Size = new System.Drawing.Size(1100, 720);
            this.root.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.lblTitle.Size = new System.Drawing.Size(1100, 52);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Flashcard";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // filters
            // 
            this.filters.ColumnCount = 6;
            this.filters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.filters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.filters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.filters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.filters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.filters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.filters.Controls.Add(this.lblLop, 0, 0);
            this.filters.Controls.Add(this._cboLop, 1, 0);
            this.filters.Controls.Add(this.lblCapDo, 2, 0);
            this.filters.Controls.Add(this._cboCapDo, 3, 0);
            this.filters.Controls.Add(this.lblChuDe, 4, 0);
            this.filters.Controls.Add(this._cboChuDe, 5, 0);
            this.filters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filters.Location = new System.Drawing.Point(0, 52);
            this.filters.Margin = new System.Windows.Forms.Padding(0);
            this.filters.Name = "filters";
            this.filters.Padding = new System.Windows.Forms.Padding(12, 16, 12, 10);
            this.filters.RowCount = 1;
            this.filters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.filters.Size = new System.Drawing.Size(1100, 70);
            this.filters.TabIndex = 1;
            // 
            // lblLop
            // 
            this.lblLop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLop.Location = new System.Drawing.Point(16, 20);
            this.lblLop.Margin = new System.Windows.Forms.Padding(4);
            this.lblLop.Name = "lblLop";
            this.lblLop.Size = new System.Drawing.Size(72, 36);
            this.lblLop.TabIndex = 0;
            this.lblLop.Text = "Lớp";
            this.lblLop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _cboLop
            // 
            this._cboLop.Dock = System.Windows.Forms.DockStyle.Fill;
            this._cboLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboLop.Location = new System.Drawing.Point(96, 20);
            this._cboLop.Margin = new System.Windows.Forms.Padding(4);
            this._cboLop.Name = "_cboLop";
            this._cboLop.Size = new System.Drawing.Size(370, 21);
            this._cboLop.TabIndex = 1;
            // 
            // lblCapDo
            // 
            this.lblCapDo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCapDo.Location = new System.Drawing.Point(474, 20);
            this.lblCapDo.Margin = new System.Windows.Forms.Padding(4);
            this.lblCapDo.Name = "lblCapDo";
            this.lblCapDo.Size = new System.Drawing.Size(72, 36);
            this.lblCapDo.TabIndex = 2;
            this.lblCapDo.Text = "CEFR";
            this.lblCapDo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _cboCapDo
            // 
            this._cboCapDo.Dock = System.Windows.Forms.DockStyle.Fill;
            this._cboCapDo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboCapDo.Location = new System.Drawing.Point(554, 20);
            this._cboCapDo.Margin = new System.Windows.Forms.Padding(4);
            this._cboCapDo.Name = "_cboCapDo";
            this._cboCapDo.Size = new System.Drawing.Size(162, 21);
            this._cboCapDo.TabIndex = 3;
            // 
            // lblChuDe
            // 
            this.lblChuDe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblChuDe.Location = new System.Drawing.Point(724, 20);
            this.lblChuDe.Margin = new System.Windows.Forms.Padding(4);
            this.lblChuDe.Name = "lblChuDe";
            this.lblChuDe.Size = new System.Drawing.Size(72, 36);
            this.lblChuDe.TabIndex = 4;
            this.lblChuDe.Text = "Chủ đề";
            this.lblChuDe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _cboChuDe
            // 
            this._cboChuDe.Dock = System.Windows.Forms.DockStyle.Fill;
            this._cboChuDe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboChuDe.Location = new System.Drawing.Point(804, 20);
            this._cboChuDe.Margin = new System.Windows.Forms.Padding(4);
            this._cboChuDe.Name = "_cboChuDe";
            this._cboChuDe.Size = new System.Drawing.Size(280, 21);
            this._cboChuDe.TabIndex = 5;
            // 
            // cardPanel
            // 
            this.cardPanel.Controls.Add(this.lblCardMeta);
            this.cardPanel.Controls.Add(this.lblCardValue);
            this.cardPanel.Controls.Add(this.lblCardTitle);
            this.cardPanel.Controls.Add(this.lblSide);
            this.cardPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardPanel.Location = new System.Drawing.Point(12, 134);
            this.cardPanel.Margin = new System.Windows.Forms.Padding(12);
            this.cardPanel.Name = "cardPanel";
            this.cardPanel.Padding = new System.Windows.Forms.Padding(28);
            this.cardPanel.Size = new System.Drawing.Size(1076, 510);
            this.cardPanel.TabIndex = 2;
            // 
            // lblCardMeta
            // 
            this.lblCardMeta.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblCardMeta.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCardMeta.Location = new System.Drawing.Point(28, 442);
            this.lblCardMeta.Name = "lblCardMeta";
            this.lblCardMeta.Size = new System.Drawing.Size(1020, 40);
            this.lblCardMeta.TabIndex = 3;
            this.lblCardMeta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCardValue
            // 
            this.lblCardValue.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCardValue.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.lblCardValue.Location = new System.Drawing.Point(28, 228);
            this.lblCardValue.Name = "lblCardValue";
            this.lblCardValue.Size = new System.Drawing.Size(1020, 108);
            this.lblCardValue.TabIndex = 2;
            this.lblCardValue.Text = "-";
            this.lblCardValue.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblCardTitle
            // 
            this.lblCardTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCardTitle.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Bold);
            this.lblCardTitle.Location = new System.Drawing.Point(28, 72);
            this.lblCardTitle.Name = "lblCardTitle";
            this.lblCardTitle.Size = new System.Drawing.Size(1020, 156);
            this.lblCardTitle.TabIndex = 1;
            this.lblCardTitle.Text = "Flashcard";
            this.lblCardTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSide
            // 
            this.lblSide.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSide.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSide.Location = new System.Drawing.Point(28, 28);
            this.lblSide.Name = "lblSide";
            this.lblSide.Size = new System.Drawing.Size(1020, 44);
            this.lblSide.TabIndex = 0;
            this.lblSide.Text = "Từ vựng";
            this.lblSide.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttons
            // 
            this.buttons.Controls.Add(this.btnTruoc);
            this.buttons.Controls.Add(this.btnLatThe);
            this.buttons.Controls.Add(this.btnTiepTheo);
            this.buttons.Controls.Add(this.btnXaoTron);
            this.buttons.Controls.Add(this.lblCounter);
            this.buttons.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttons.Location = new System.Drawing.Point(570, 660);
            this.buttons.Margin = new System.Windows.Forms.Padding(4);
            this.buttons.Name = "buttons";
            this.buttons.Size = new System.Drawing.Size(526, 56);
            this.buttons.TabIndex = 3;
            // 
            // btnTruoc
            // 
            this.btnTruoc.Location = new System.Drawing.Point(4, 4);
            this.btnTruoc.Margin = new System.Windows.Forms.Padding(4);
            this.btnTruoc.Name = "btnTruoc";
            this.btnTruoc.Size = new System.Drawing.Size(100, 34);
            this.btnTruoc.TabIndex = 0;
            this.btnTruoc.Text = "Trước";
            this.btnTruoc.UseVisualStyleBackColor = true;
            // 
            // btnLatThe
            // 
            this.btnLatThe.Location = new System.Drawing.Point(112, 4);
            this.btnLatThe.Margin = new System.Windows.Forms.Padding(4);
            this.btnLatThe.Name = "btnLatThe";
            this.btnLatThe.Size = new System.Drawing.Size(100, 34);
            this.btnLatThe.TabIndex = 1;
            this.btnLatThe.Text = "Lật thẻ";
            this.btnLatThe.UseVisualStyleBackColor = true;
            // 
            // btnTiepTheo
            // 
            this.btnTiepTheo.Location = new System.Drawing.Point(220, 4);
            this.btnTiepTheo.Margin = new System.Windows.Forms.Padding(4);
            this.btnTiepTheo.Name = "btnTiepTheo";
            this.btnTiepTheo.Size = new System.Drawing.Size(100, 34);
            this.btnTiepTheo.TabIndex = 2;
            this.btnTiepTheo.Text = "Tiếp theo";
            this.btnTiepTheo.UseVisualStyleBackColor = true;
            // 
            // btnXaoTron
            // 
            this.btnXaoTron.Location = new System.Drawing.Point(328, 4);
            this.btnXaoTron.Margin = new System.Windows.Forms.Padding(4);
            this.btnXaoTron.Name = "btnXaoTron";
            this.btnXaoTron.Size = new System.Drawing.Size(100, 34);
            this.btnXaoTron.TabIndex = 3;
            this.btnXaoTron.Text = "Xáo trộn";
            this.btnXaoTron.UseVisualStyleBackColor = true;
            // 
            // lblCounter
            // 
            this.lblCounter.Location = new System.Drawing.Point(436, 8);
            this.lblCounter.Margin = new System.Windows.Forms.Padding(4, 8, 4, 4);
            this.lblCounter.Name = "lblCounter";
            this.lblCounter.Size = new System.Drawing.Size(80, 26);
            this.lblCounter.TabIndex = 4;
            this.lblCounter.Text = "0 / 0";
            this.lblCounter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmFlashcard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 720);
            this.Controls.Add(this.root);
            this.Name = "FrmFlashcard";
            this.Text = "Flashcard";
            this.root.ResumeLayout(false);
            this.filters.ResumeLayout(false);
            this.cardPanel.ResumeLayout(false);
            this.buttons.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
