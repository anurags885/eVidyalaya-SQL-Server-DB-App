namespace eVidyalaya
{
    partial class UserLogin
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
            this.components = new System.ComponentModel.Container();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUserID = new System.Windows.Forms.Label();
            this.lnlSchool_Name = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblConnected = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.picture_Help = new System.Windows.Forms.PictureBox();
            this.panelLogin = new System.Windows.Forms.Panel();
            this.picture_Logo = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture_Help)).BeginInit();
            this.panelLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture_Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.btnLogin.ForeColor = System.Drawing.Color.Black;
            this.btnLogin.Location = new System.Drawing.Point(484, 160);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(47, 26);
            this.btnLogin.TabIndex = 13;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtUserID
            // 
            this.txtUserID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtUserID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserID.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.txtUserID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(49)))), ((int)(((byte)(64)))));
            this.txtUserID.Location = new System.Drawing.Point(321, 83);
            this.txtUserID.MaxLength = 20;
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(210, 23);
            this.txtUserID.TabIndex = 10;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.txtPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(49)))), ((int)(((byte)(64)))));
            this.txtPassword.Location = new System.Drawing.Point(321, 131);
            this.txtPassword.MaxLength = 20;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(210, 23);
            this.txtPassword.TabIndex = 12;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(49)))), ((int)(((byte)(64)))));
            this.lblPassword.Location = new System.Drawing.Point(318, 113);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(65, 15);
            this.lblPassword.TabIndex = 11;
            this.lblPassword.Text = "Password :";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(49)))), ((int)(((byte)(64)))));
            this.lblUserID.Location = new System.Drawing.Point(318, 65);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(55, 15);
            this.lblUserID.TabIndex = 9;
            this.lblUserID.Text = "User ID :";
            this.lblUserID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lnlSchool_Name
            // 
            this.lnlSchool_Name.AutoSize = true;
            this.lnlSchool_Name.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.lnlSchool_Name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(49)))), ((int)(((byte)(64)))));
            this.lnlSchool_Name.Location = new System.Drawing.Point(305, 11);
            this.lnlSchool_Name.Name = "lnlSchool_Name";
            this.lnlSchool_Name.Size = new System.Drawing.Size(226, 20);
            this.lnlSchool_Name.TabIndex = 6;
            this.lnlSchool_Name.Text = "Central English School, Sasaram";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(107)))), ((int)(((byte)(170)))));
            this.panel1.Controls.Add(this.lblConnected);
            this.panel1.Location = new System.Drawing.Point(-2, 258);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(576, 25);
            this.panel1.TabIndex = 15;
            // 
            // lblConnected
            // 
            this.lblConnected.AutoSize = true;
            this.lblConnected.ForeColor = System.Drawing.Color.White;
            this.lblConnected.Location = new System.Drawing.Point(6, 4);
            this.lblConnected.Name = "lblConnected";
            this.lblConnected.Size = new System.Drawing.Size(10, 15);
            this.lblConnected.TabIndex = 0;
            this.lblConnected.Text = ".";
            // 
            // timer
            // 
            this.timer.Interval = 3000;
            // 
            // picture_Help
            // 
            this.picture_Help.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picture_Help.Location = new System.Drawing.Point(534, 7);
            this.picture_Help.Name = "picture_Help";
            this.picture_Help.Size = new System.Drawing.Size(34, 28);
            this.picture_Help.TabIndex = 16;
            this.picture_Help.TabStop = false;
            // 
            // panelLogin
            // 
            this.panelLogin.BackColor = System.Drawing.SystemColors.Control;
            this.panelLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLogin.Controls.Add(this.picture_Logo);
            this.panelLogin.Controls.Add(this.label1);
            this.panelLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(51)))), ((int)(((byte)(75)))));
            this.panelLogin.Location = new System.Drawing.Point(-2, -3);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(291, 263);
            this.panelLogin.TabIndex = 17;
            // 
            // picture_Logo
            // 
            this.picture_Logo.Cursor = System.Windows.Forms.Cursors.Default;
            this.picture_Logo.Location = new System.Drawing.Point(8, 9);
            this.picture_Logo.Name = "picture_Logo";
            this.picture_Logo.Size = new System.Drawing.Size(274, 224);
            this.picture_Logo.TabIndex = 11;
            this.picture_Logo.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(49)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(8, 237);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "School Information Management System";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UserLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 283);
            this.Controls.Add(this.lnlSchool_Name);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUserID);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.picture_Help);
            this.Controls.Add(this.panelLogin);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(34)))), ((int)(((byte)(53)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Login";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture_Help)).EndInit();
            this.panelLogin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picture_Logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.Label lnlSchool_Name;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblConnected;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.PictureBox picture_Help;
        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.PictureBox picture_Logo;
        private System.Windows.Forms.Label label1;
    }
}