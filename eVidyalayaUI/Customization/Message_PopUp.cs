using System.Windows.Forms;

namespace eVidyalaya.Customization
{
    public static class Message_PopUp
    {
        public static void Show_Error_Message(string error_message)
        {
            MessageBox.Show(error_message, "School", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void Show_Success_Message(string message)
        {
            MessageBox.Show(message, "School", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult Show_Confirm_Box(string message)
        {
            return MessageBox.Show(message, "School", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }
}
