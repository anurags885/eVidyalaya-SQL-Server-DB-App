using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace eVidyalaya
{
    public partial class ConnectionManagerForm : Form
    {
        bool isServerDDLClick = false;
        public ConnectionManagerForm()
        {
            InitializeComponent();
            ddlServerName.SelectedIndexChanged -= new EventHandler(ddlServerName_SelectedIndexChanged);
            ddlAuthentication.SelectedIndexChanged -= new EventHandler(ddlAuthentication_SelectedIndexChanged);
            Authentication();
            txtUserName.Enabled = false;
            txtpassword.Enabled = false;
            ddlAuthentication.SelectedIndexChanged += new EventHandler(ddlAuthentication_SelectedIndexChanged);
            ddlServerName.SelectedIndexChanged += new EventHandler(ddlServerName_SelectedIndexChanged);
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ddlServerName.Visible = false;
            GetAllServerName();
            ddlServerName.Visible = true;
        }
        private void GetAllServerName()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;
                DataTable dtInstancesList = new DataTable();
                dtInstancesList = instance.GetDataSources().Select("", "ServerName ASC").CopyToDataTable();
                ddlServerName.DataSource = dtInstancesList;
                ddlServerName.DisplayMember = "ServerName";
                ddlServerName.ValueMember = "ServerName";
                ddlServerName.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Server Found. \nPlease enter your server name or please try below options.\n . or (local)", "Connection Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
        }
        private void Authentication()
        {
            Dictionary<short, string> dicAuth = new Dictionary<short, string>();
            dicAuth.Add(0, "Windows Authentication");
            dicAuth.Add(1, "SQL Server Authentication");
            ddlAuthentication.DataSource = dicAuth.ToList();
            ddlAuthentication.DisplayMember = "Value";
            ddlAuthentication.ValueMember = "Key";
        }
        private void ddlAuthentication_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt16(ddlAuthentication.SelectedValue) == 0)
            {
                txtUserName.Enabled = false;
                txtpassword.Enabled = false;
                ddlDatabse.Enabled = true;
            }
            else if (Convert.ToInt16(ddlAuthentication.SelectedValue) == 1)
            {
                txtUserName.Enabled = true;
                txtpassword.Enabled = true;
                ddlDatabse.Enabled = false;
            }
        }
        public List<string> GetDatabaseList(string connectionString)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<string> list = new List<string>();
            try
            {
                // Open connection to the database
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // Set up a command with the given query and associate
                    // this with the current connection.
                    using (SqlCommand cmd = new SqlCommand("SELECT Name from sys.databases", con))
                    {
                        using (IDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                list.Add(dr[0].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (Convert.ToInt16(ddlAuthentication.SelectedValue) == 0)
                {
                    MessageBox.Show("Please Enter Correr Server Name.", "Connection Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ddlDatabse.Enabled = false;
                }
                else if (Convert.ToInt16(ddlAuthentication.SelectedValue) == 1)
                {
                    MessageBox.Show("Login failed for user '" + txtUserName.Text.Trim() + "'", "Connection Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            Cursor.Current = Cursors.Default;
            return list;
        }
        private void ddlServerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string conString = "Data Source=" + Convert.ToString(ddlServerName.Text) + ";Initial Catalog=Master;Integrated Security=True";
            BindDatabase(conString);
        }
        private void BindDatabase(string connectionString)
        {
            Cursor.Current = Cursors.WaitCursor;
            this.BeginInvoke(new Action(() =>
            {
                if (!string.IsNullOrWhiteSpace(Convert.ToString(ddlServerName.Text)))
                {
                    ddlDatabse.Enabled = true;
                    ddlDatabse.DataSource = null;
                    ddlDatabse.DataSource = GetDatabaseList(connectionString);
                    ddlDatabse.DisplayMember = "NAME";
                }
                else
                {
                    ddlDatabse.DataSource = null;
                    ddlDatabse.Enabled = false;
                }
            }));
            Cursor.Current = Cursors.Default;
        }
        private void ddlServerName_Leave(object sender, EventArgs e)
        {
            string conString = "Data Source=" + Convert.ToString(ddlServerName.Text) + ";Initial Catalog=Master;Integrated Security=True";
            BindDatabase(conString);
        }
        private void ddlServerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            ddlDatabse.Enabled = true;
        }
        private void txtUserName_KeyUp(object sender, KeyEventArgs e)
        {
            ddlDatabse.Enabled = true;
        }
        private void txtpassword_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                string conString = "Data Source=" + Convert.ToString(ddlServerName.Text) + ";Initial Catalog=Master;User Id=" + txtUserName.Text.Trim() + ";Password=" + txtpassword.Text.Trim() + ";";
                BindDatabase(conString);
            }
        }
        private void btnSaveSetting_Click(object sender, EventArgs e)
        {
            string connectionString = string.Empty;
            Cursor.Current = Cursors.WaitCursor;
            this.BeginInvoke(new Action(() =>
            {
                if (!string.IsNullOrWhiteSpace(Convert.ToString(ddlDatabse.Text)))
                {
                    if (Convert.ToInt16(ddlAuthentication.SelectedValue) == 0)
                    {
                        connectionString = "Data Source=" + Convert.ToString(ddlServerName.Text) + ";Initial Catalog=" + ddlDatabse.Text + ";Integrated Security=True";
                    }
                    else if (Convert.ToInt16(ddlAuthentication.SelectedValue) == 1)
                    {
                        if (CredentialValidation())
                            connectionString = "Data Source=" + Convert.ToString(ddlServerName.Text) + ";Initial Catalog=" + ddlDatabse.Text + ";User Id=" + txtUserName.Text.Trim() + ";Password=" + txtpassword.Text.Trim() + ";";
                        else
                            return;
                    }

                    List<string> listDatatBaseList = GetDatabaseList(connectionString);
                    if (listDatatBaseList != null && listDatatBaseList.Count > 0)
                    {
                        SaveConnectionString(connectionString);
                    }
                }
                else
                {
                    ddlDatabse.DataSource = null;
                    ddlDatabse.Enabled = false;
                    MessageBox.Show("Database setting not saved. Plase try again", "Connection Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }));
            Cursor.Current = Cursors.Default;
        }
        private void SaveConnectionString(string connectionString)
        {
            try
            {
                //XmlDocument XmlDoc = new XmlDocument();

                //XmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

                XDocument xmlDocument = XDocument.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

                foreach (var item in xmlDocument.Descendants("configuration"))
                {
                    if (item.Element("appSettings") != null)
                    {
                        if (item.Element("appSettings").Element("add").Attribute("key").Value == "connect")
                        {
                            if (item.Element("appSettings").Element("add").Attribute("value").Value == "0")
                            {
                                item.Element("appSettings").Element("add").Attribute("value").Value = "1";
                            }
                        }
                    }

                    if (item.Element("connectionStrings") != null)
                    {
                        if (item.Element("connectionStrings").Element("add").Attribute("name").Value == "DatabaseConnect")
                        {
                            item.Element("connectionStrings").Element("add").Attribute("connectionString").Value = connectionString;
                        }
                    }
                }

                if (File.Exists(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile))
                {
                    File.Delete(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
                }
                xmlDocument.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
                MessageBox.Show("Database Settings Saved Successfully.\nPlease restart this application.", "Connection Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ErrorMessageBox();
            }
        }
        private void ErrorMessageBox()
        {
            MessageBox.Show("Error : Please Contact To Admin.", "Connection Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void ddlServerName_DropDown(object sender, EventArgs e)
        {
            if (!isServerDDLClick)
            {
                GetAllServerName();
                isServerDDLClick = true;
            }
        }
        private bool CredentialValidation()
        {
            StringBuilder message = new StringBuilder();
            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                message.Append("\u2022 User name is required.\n");
            }
            if (string.IsNullOrWhiteSpace(txtpassword.Text))
            {
                message.Append("\u2022 Password is required.\n");
            }
            if (!string.IsNullOrWhiteSpace(Convert.ToString(message)))
            {
                MessageBox.Show(Convert.ToString(message), "Connection Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}