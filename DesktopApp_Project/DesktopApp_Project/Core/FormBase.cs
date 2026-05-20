using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp_Project
{
    public partial class FormBase : Form
    {
        public FormBase()
        {
            InitializeComponent();

            //cấu hình các form kế thừa từ FormBase
            this.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            this.BackColor = Color.FromArgb(31, 30, 68);
            this.FormBorderStyle = FormBorderStyle.None;
            this.ForeColor = Color.Gainsboro;
        }
    }
}
