namespace eVidyalaya
{
    partial class AboutPoductForm
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
            this.lblName = new System.Windows.Forms.Label();
            this.lblhelp = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI Semibold", 11.5F);
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(12, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(309, 42);
            this.lblName.TabIndex = 11;
            this.lblName.Text = "E-Vidyalaya\r\nSchool Information Management System";
            // 
            // lblhelp
            // 
            this.lblhelp.AutoSize = true;
            this.lblhelp.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            this.lblhelp.ForeColor = System.Drawing.Color.White;
            this.lblhelp.Location = new System.Drawing.Point(12, 103);
            this.lblhelp.Name = "lblhelp";
            this.lblhelp.Size = new System.Drawing.Size(294, 51);
            this.lblhelp.TabIndex = 13;
            this.lblhelp.Text = "For assistance please contact on below details :\r\nEmail : sandeep.codehub@gmail.c" +
    "om\r\nContact No : +91 901-377-7120";
            // 
            // AboutPoductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(95)))), ((int)(((byte)(140)))));
            this.ClientSize = new System.Drawing.Size(341, 187);
            this.Controls.Add(this.lblhelp);
            this.Controls.Add(this.lblName);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(57)))), ((int)(((byte)(85)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutPoductForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblhelp;
    }
}