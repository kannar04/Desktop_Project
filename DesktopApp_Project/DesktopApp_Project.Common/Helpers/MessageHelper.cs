using System.Windows.Forms;

namespace DesktopApp_Project.Common
{
    public static class MessageHelper
    {
        public static void ShowInfo(string message)
        {
            MessageBox.Show(message, "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowError(string message)
        {
            MessageBox.Show(message, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static bool Confirm(string message)
        {
            return MessageBox.Show(message, "Xac nhan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }
    }
}
