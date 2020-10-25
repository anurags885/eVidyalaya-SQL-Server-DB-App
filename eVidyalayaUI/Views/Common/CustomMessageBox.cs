using System;
using System.Windows.Forms;

namespace eVidyalaya
{
    public partial class CustomMessageBox : Form
    {
        internal static CustomMessageBox instanceFrm;
        public CustomMessageBox(string MessageText)
        {
            InitializeComponent();
            lblMessage.Text = MessageText;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            CustomMessageBox.instanceFrm = null;
            this.Close();
        }

        private void CustomMessageBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            CustomMessageBox.instanceFrm = null;
        }
    }
}
