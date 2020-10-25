namespace eVidyalaya
{
    partial class ConnectionManagerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblServer = new System.Windows.Forms.Label();
            this.ddlDatabse = new System.Windows.Forms.ComboBox();
            this.btnSaveSetting = new System.Windows.Forms.Button();
            this.ddlServerName = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.groupLogin = new System.Windows.Forms.GroupBox();
            this.lblAuthentication = new System.Windows.Forms.Label();
            this.ddlAuthentication = new System.Windows.Forms.ComboBox();
            this.groupDatabase = new System.Windows.Forms.GroupBox();
            this.lblDatabaseName = new System.Windows.Forms.Label();
            this.groupLogin.SuspendLayout();
            this.groupDatabase.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(7, 90);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(63, 15);
            this.lblPassword.TabIndex = 19;
            this.lblPassword.Text = "Password :";
            // 
            // txtpassword
            // 
            this.txtpassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtpassword.Location = new System.Drawing.Point(102, 82);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.Size = new System.Drawing.Size(260, 23);
            this.txtpassword.TabIndex = 18;
            this.txtpassword.Leave += new System.EventHandler(this.txtpassword_Leave);
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(7, 61);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(71, 15);
            this.lblUserName.TabIndex = 17;
            this.lblUserName.Text = "User Name :";
            // 
            // txtUserName
            // 
            this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserName.Location = new System.Drawing.Point(102, 53);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(260, 23);
            this.txtUserName.TabIndex = 16;
            this.txtUserName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtUserName_KeyUp);
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(7, 17);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(81, 15);
            this.lblServer.TabIndex = 10;
            this.lblServer.Text = "Server Name :";
            // 
            // ddlDatabse
            // 
            this.ddlDatabse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlDatabse.Enabled = false;
            this.ddlDatabse.FormattingEnabled = true;
            this.ddlDatabse.Location = new System.Drawing.Point(10, 46);
            this.ddlDatabse.Name = "ddlDatabse";
            this.ddlDatabse.Size = new System.Drawing.Size(352, 23);
            this.ddlDatabse.TabIndex = 135;
            // 
            // btnSaveSetting
            // 
            this.btnSaveSetting.Location = new System.Drawing.Point(233, 255);
            this.btnSaveSetting.Name = "btnSaveSetting";
            this.btnSaveSetting.Size = new System.Drawing.Size(145, 27);
            this.btnSaveSetting.TabIndex = 136;
            this.btnSaveSetting.Text = "Save Database Settings";
            this.btnSaveSetting.UseVisualStyleBackColor = true;
            this.btnSaveSetting.Click += new System.EventHandler(this.btnSaveSetting_Click);
            // 
            // ddlServerName
            // 
            this.ddlServerName.FormattingEnabled = true;
            this.ddlServerName.Location = new System.Drawing.Point(94, 9);
            this.ddlServerName.Name = "ddlServerName";
            this.ddlServerName.Size = new System.Drawing.Size(218, 23);
            this.ddlServerName.TabIndex = 137;
            this.ddlServerName.DropDown += new System.EventHandler(this.ddlServerName_DropDown);
            this.ddlServerName.SelectedIndexChanged += new System.EventHandler(this.ddlServerName_SelectedIndexChanged);
            this.ddlServerName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ddlServerName_KeyPress);
            this.ddlServerName.Leave += new System.EventHandler(this.ddlServerName_Leave);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(318, 9);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(60, 23);
            this.btnRefresh.TabIndex = 138;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // groupLogin
            // 
            this.groupLogin.Controls.Add(this.lblAuthentication);
            this.groupLogin.Controls.Add(this.ddlAuthentication);
            this.groupLogin.Controls.Add(this.txtUserName);
            this.groupLogin.Controls.Add(this.lblUserName);
            this.groupLogin.Controls.Add(this.txtpassword);
            this.groupLogin.Controls.Add(this.lblPassword);
            this.groupLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(82)))), ((int)(((byte)(137)))));
            this.groupLogin.Location = new System.Drawing.Point(10, 43);
            this.groupLogin.Name = "groupLogin";
            this.groupLogin.Size = new System.Drawing.Size(368, 118);
            this.groupLogin.TabIndex = 139;
            this.groupLogin.TabStop = false;
            this.groupLogin.Text = "Login on to the server";
            // 
            // lblAuthentication
            // 
            this.lblAuthentication.AutoSize = true;
            this.lblAuthentication.Location = new System.Drawing.Point(6, 32);
            this.lblAuthentication.Name = "lblAuthentication";
            this.lblAuthentication.Size = new System.Drawing.Size(89, 15);
            this.lblAuthentication.TabIndex = 141;
            this.lblAuthentication.Text = "Authentication:";
            // 
            // ddlAuthentication
            // 
            this.ddlAuthentication.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlAuthentication.FormattingEnabled = true;
            this.ddlAuthentication.Location = new System.Drawing.Point(102, 24);
            this.ddlAuthentication.Name = "ddlAuthentication";
            this.ddlAuthentication.Size = new System.Drawing.Size(260, 23);
            this.ddlAuthentication.TabIndex = 140;
            this.ddlAuthentication.SelectedIndexChanged += new System.EventHandler(this.ddlAuthentication_SelectedIndexChanged);
            // 
            // groupDatabase
            // 
            this.groupDatabase.Controls.Add(this.lblDatabaseName);
            this.groupDatabase.Controls.Add(this.ddlDatabse);
            this.groupDatabase.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(82)))), ((int)(((byte)(137)))));
            this.groupDatabase.Location = new System.Drawing.Point(10, 167);
            this.groupDatabase.Name = "groupDatabase";
            this.groupDatabase.Size = new System.Drawing.Size(368, 82);
            this.groupDatabase.TabIndex = 140;
            this.groupDatabase.TabStop = false;
            this.groupDatabase.Text = "Connect to a database";
            // 
            // lblDatabaseName
            // 
            this.lblDatabaseName.AutoSize = true;
            this.lblDatabaseName.Location = new System.Drawing.Point(7, 27);
            this.lblDatabaseName.Name = "lblDatabaseName";
            this.lblDatabaseName.Size = new System.Drawing.Size(166, 15);
            this.lblDatabaseName.TabIndex = 141;
            this.lblDatabaseName.Text = "Select or enter database name";
            // 
            // ConnectionManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 288);
            this.Controls.Add(this.groupDatabase);
            this.Controls.Add(this.groupLogin);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.ddlServerName);
            this.Controls.Add(this.btnSaveSetting);
            this.Controls.Add(this.lblServer);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(82)))), ((int)(((byte)(137)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConnectionManagerForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connection Manager";
            this.groupLogin.ResumeLayout(false);
            this.groupLogin.PerformLayout();
            this.groupDatabase.ResumeLayout(false);
            this.groupDatabase.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.ComboBox ddlDatabse;
        private System.Windows.Forms.Button btnSaveSetting;
        private System.Windows.Forms.ComboBox ddlServerName;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.GroupBox groupLogin;
        private System.Windows.Forms.Label lblAuthentication;
        private System.Windows.Forms.ComboBox ddlAuthentication;
        private System.Windows.Forms.GroupBox groupDatabase;
        private System.Windows.Forms.Label lblDatabaseName;
    }
}