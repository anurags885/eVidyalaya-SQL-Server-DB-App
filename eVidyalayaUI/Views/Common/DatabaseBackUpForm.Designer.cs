namespace eVidyalaya
{
    partial class DatabaseBackUpForm
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
            this.btnBackUp = new System.Windows.Forms.Button();
            this.lblDatabaseName = new System.Windows.Forms.Label();
            this.lblDatabaseNameValue = new System.Windows.Forms.Label();
            this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // btnBackUp
            // 
            this.btnBackUp.Location = new System.Drawing.Point(353, 37);
            this.btnBackUp.Name = "btnBackUp";
            this.btnBackUp.Size = new System.Drawing.Size(73, 23);
            this.btnBackUp.TabIndex = 0;
            this.btnBackUp.Text = "BackUp";
            this.btnBackUp.UseVisualStyleBackColor = true;
            this.btnBackUp.Click += new System.EventHandler(this.btnBackUp_Click);
            // 
            // lblDatabaseName
            // 
            this.lblDatabaseName.AutoSize = true;
            this.lblDatabaseName.Location = new System.Drawing.Point(12, 13);
            this.lblDatabaseName.Name = "lblDatabaseName";
            this.lblDatabaseName.Size = new System.Drawing.Size(66, 15);
            this.lblDatabaseName.TabIndex = 1;
            this.lblDatabaseName.Text = "File Name :";
            // 
            // lblDatabaseNameValue
            // 
            this.lblDatabaseNameValue.AutoSize = true;
            this.lblDatabaseNameValue.Location = new System.Drawing.Point(84, 13);
            this.lblDatabaseNameValue.Name = "lblDatabaseNameValue";
            this.lblDatabaseNameValue.Size = new System.Drawing.Size(91, 15);
            this.lblDatabaseNameValue.TabIndex = 2;
            this.lblDatabaseNameValue.Text = "Database Name";
            // 
            // SaveFileDialog
            // 
            this.SaveFileDialog.Filter = "Bakup files (*.bak)|*.bak";
            // 
            // DatabaseBackUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 70);
            this.Controls.Add(this.lblDatabaseNameValue);
            this.Controls.Add(this.lblDatabaseName);
            this.Controls.Add(this.btnBackUp);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(54)))), ((int)(((byte)(92)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DatabaseBackUpForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "BackUp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBackUp;
        private System.Windows.Forms.Label lblDatabaseName;
        private System.Windows.Forms.Label lblDatabaseNameValue;
        internal System.Windows.Forms.SaveFileDialog SaveFileDialog;
    }
}