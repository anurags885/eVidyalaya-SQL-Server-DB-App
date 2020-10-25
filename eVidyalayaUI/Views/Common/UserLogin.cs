using System;
using System.Text;
using System.Windows.Forms;
using School.App.Repository;
using SchoolModels;
using System.Runtime.InteropServices;

namespace eVidyalaya
{
    public partial class UserLogin : Form
    {
        #region Variables
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);
        private readonly ToolStripRenderer _toolStripProfessionalRenderer = new ToolStripProfessionalRenderer();
        string _appPath = Application.StartupPath + "\\";
		#endregion
		public UserLogin()
		{
			string url = this._appPath + "AppImage\\help.png";
			string logoPath = _appPath + "AppImage\\eVidyalaya.png";
			this.InitializeComponent();

			this.picture_Help.Anchor = AnchorStyles.None;
			this.picture_Help.Load(url);
			this.picture_Help.SizeMode = PictureBoxSizeMode.Zoom;

			picture_Logo.Anchor = AnchorStyles.None;
			picture_Logo.Load(logoPath);
			picture_Logo.SizeMode = PictureBoxSizeMode.Zoom;

			this.timer.Start();
			this.timer_Tick(null, null);
		}
		private void btnLogin_Click(object sender, EventArgs e)
		{
			bool flag = this.ControlValidation();
			if (flag)
			{
				bool flag2 = !string.IsNullOrWhiteSpace(this.txtUserID.Text.Trim()) && !string.IsNullOrWhiteSpace(this.txtPassword.Text.Trim());
				if (flag2)
				{
					bool flag3 = this.ValidateUser();
					if (flag3)
					{
						base.Hide();
						UIParent uIParent = new UIParent();
						uIParent.Show();
					}
					else
					{
						MessageBox.Show("Wrong User Id or Password, Please try again.", "User Login", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						this.txtUserID.Select();
					}
				}
			}
		}
		private bool ValidateUser()
		{
			bool result = false;
			try
			{
				User user = new User();
				User_Model user_Model = user.Get_User_Login_Details(this.txtUserID.Text.Trim().ToLower(), this.txtPassword.Text.Trim().ToLower());
				bool flag = user_Model != null && user_Model.User_ID != null;
				result = flag;
			}
			catch
			{
				MessageBox.Show("Error: Please contact to support team.", "User Login", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			return result;
		}
		private bool ControlValidation()
		{
			StringBuilder stringBuilder = new StringBuilder();
			bool flag = string.IsNullOrWhiteSpace(this.txtUserID.Text);
			if (flag)
			{
				stringBuilder.Append("• User ID is required.\n");
			}
			bool flag2 = string.IsNullOrWhiteSpace(this.txtPassword.Text);
			if (flag2)
			{
				stringBuilder.Append("• Password is required.\n");
			}
			bool flag3 = !string.IsNullOrWhiteSpace(Convert.ToString(stringBuilder));
			bool result;
			if (flag3)
			{
				MessageBox.Show(Convert.ToString(stringBuilder), "User Login", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				result = false;
			}
			else
			{
				result = true;
			}
			return result;
		}
		public static bool IsConnectedToInternet()
		{
			int num;
			return UserLogin.InternetGetConnectedState(out num, 0);
		}
		private void timer_Tick(object sender, EventArgs e)
		{
			//bool flag = !UserLogin.IsConnectedToInternet();
			//if (flag)
			//{
			//	this.lblConnected.Text = "Not Connected";
			//	bool flag2 = CustomMessageBox.instanceFrm == null;
			//	if (flag2)
			//	{
			//		CustomMessageBox.instanceFrm = new CustomMessageBox("Looks like there is no internet connection.\nPlease check the network.");
			//		CustomMessageBox.instanceFrm.ShowDialog(this);
			//	}
			//	else
			//	{
			//		CustomMessageBox.instanceFrm.Focus();
			//	}
			//}
			//else
			//{
			//	this.lblConnected.Text = "Connected To Server";
			//}
		}
		private void picture_Help_Click(object sender, EventArgs e)
		{
			new AboutPoductForm
			{
				StartPosition = FormStartPosition.CenterParent
			}.ShowDialog();
		}

	}
}

//http://edumarshal.com/index.html
