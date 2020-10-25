using System;
using System.Windows.Forms;
using System.Xml;
using School.App.Repository;
namespace eVidyalaya
{
    public partial class DatabaseBackUpForm : Form
    {
        DabaseBackUp dabaseBackUp;
        public DatabaseBackUpForm()
        {
            InitializeComponent();
            GetDatabaseName();
        }

        private void btnBackUp_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog.FileName = lblDatabaseNameValue.Text + "_" + DateTime.Now.ToString("dd_MMM_yyyy_hh_mm_ss_fff_tt");
                SaveFileDialog.ShowDialog();
                string fileName = null;
                fileName = SaveFileDialog.FileName;
                dabaseBackUp = new DabaseBackUp();
                short result = dabaseBackUp.TakeBackUp(fileName.ToLower(), lblDatabaseNameValue.Text);
                switch (result)
                {
                    case 1:
                        MessageBox.Show("BackUp Completed.", "BackUp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }
            }
            catch (Exception ex)
            {
                ErrorMessage();
            }
        }

        private void GetDatabaseName()
        {
            try
            {
                lblDatabaseNameValue.Text = string.Empty;
                XmlDocument XmlDoc = new XmlDocument();
                XmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
                string connectionString = XmlDoc.SelectSingleNode("//connectionStrings/add").Attributes["connectionString"].Value;
                lblDatabaseNameValue.Text = connectionString.Split(';')[1].Split('=')[1];

            }
            catch (Exception ex)
            {
                lblDatabaseNameValue.Text = string.Empty;
                btnBackUp.Enabled = false;
                ErrorMessage();
            }
        }
        private void ErrorMessage()
        {
            MessageBox.Show("Error: please contact to admin.", "BackUp", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
