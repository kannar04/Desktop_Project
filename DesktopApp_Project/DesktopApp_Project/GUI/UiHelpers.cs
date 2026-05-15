using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DesktopApp_Project.BUS;
using DesktopApp_Project.Common;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.GUI
{
    public static class UiHelpers
    {
        public static readonly Font DefaultFont = new Font("Segoe UI", 9F, FontStyle.Regular);
        public static readonly Font TitleFont = new Font("Segoe UI", 13F, FontStyle.Bold);

        public static Button Button(string text)
        {
            return new Button
            {
                Text = text,
                AutoSize = false,
                Height = 34,
                Width = 110,
                Font = DefaultFont,
                BackColor = Color.FromArgb(235, 242, 252),
                FlatStyle = FlatStyle.Flat,
                Margin = new Padding(4)
            };
        }

        public static Label Label(string text)
        {
            return new Label
            {
                Text = text,
                AutoSize = true,
                Font = DefaultFont,
                Margin = new Padding(4, 8, 4, 2)
            };
        }

        public static TextBox TextBox()
        {
            return new TextBox { Width = 220, Font = DefaultFont, Margin = new Padding(4) };
        }

        public static ComboBox ComboBox()
        {
            return new ComboBox
            {
                Width = 220,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = DefaultFont,
                Margin = new Padding(4)
            };
        }

        public static DataGridView Grid()
        {
            return new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoGenerateColumns = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                BackgroundColor = Color.White,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                Font = DefaultFont
            };
        }

        public static int SelectedId(ComboBox combo)
        {
            if (combo.SelectedValue == null)
            {
                return 0;
            }

            int id;
            return int.TryParse(combo.SelectedValue.ToString(), out id) ? id : 0;
        }

        public static T SelectedItem<T>(DataGridView grid) where T : class
        {
            if (grid.CurrentRow == null)
            {
                return null;
            }

            return grid.CurrentRow.DataBoundItem as T;
        }

        public static void ShowResult(ServiceResult result)
        {
            MessageBox.Show(result.Message, result.Success ? "Thông báo" : "Lỗi",
                MessageBoxButtons.OK,
                result.Success ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
        }

        public static void BindLopHoc(ComboBox combo, ServiceFactory services)
        {
            combo.DataSource = null;
            combo.DataSource = services.LopHoc.LayDanhSach();
            combo.DisplayMember = "TenLop";
            combo.ValueMember = "MaLopHoc";
        }

        public static void BindKyNang(ComboBox combo)
        {
            combo.DataSource = AppConstants.SkillLabels.ToList();
        }

        public static TableLayoutPanel FormGrid()
        {
            var panel = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                ColumnCount = 4,
                Padding = new Padding(8)
            };
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            return panel;
        }
    }

    public abstract class ModuleFormBase : Form
    {
        protected readonly ServiceFactory Services;
        protected readonly NguoiDungDTO CurrentUser;
        private readonly Label _title;

        protected ModuleFormBase(ServiceFactory services, NguoiDungDTO currentUser, string title)
        {
            Services = services;
            CurrentUser = currentUser;
            Font = UiHelpers.DefaultFont;
            Text = title;
            Dock = DockStyle.Fill;
            TopLevel = false;
            FormBorderStyle = FormBorderStyle.None;
            BackColor = Color.White;

            _title = new Label
            {
                Text = title,
                Dock = DockStyle.Top,
                Height = 42,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = UiHelpers.TitleFont,
                Padding = new Padding(12, 0, 0, 0),
                BackColor = Color.FromArgb(245, 247, 250)
            };
            Controls.Add(_title);
        }

        protected void AddContent(Control control)
        {
            control.Dock = DockStyle.Fill;
            Controls.Add(control);
            control.BringToFront();
            _title.BringToFront();
        }

        protected void Info(string message)
        {
            MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
