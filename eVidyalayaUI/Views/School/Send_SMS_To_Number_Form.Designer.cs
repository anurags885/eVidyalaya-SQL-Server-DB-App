namespace eVidyalaya.Views.School
{
    partial class Send_SMS_To_Number_Form
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
            this.lblBalancedSMSValue = new System.Windows.Forms.Label();
            this.lblBalancedSms = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_message_text = new System.Windows.Forms.TextBox();
            this.btnSentMessage = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtNumbers = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gridSMS = new System.Windows.Forms.DataGridView();
            this.colMobileNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTotalLength = new System.Windows.Forms.Label();
            this.linkDownload = new System.Windows.Forms.LinkLabel();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSMS)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBalancedSMSValue
            // 
            this.lblBalancedSMSValue.AutoSize = true;
            this.lblBalancedSMSValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBalancedSMSValue.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblBalancedSMSValue.Location = new System.Drawing.Point(111, 467);
            this.lblBalancedSMSValue.Name = "lblBalancedSMSValue";
            this.lblBalancedSMSValue.Size = new System.Drawing.Size(2, 21);
            this.lblBalancedSMSValue.TabIndex = 12;
            // 
            // lblBalancedSms
            // 
            this.lblBalancedSms.AutoSize = true;
            this.lblBalancedSms.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBalancedSms.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblBalancedSms.Location = new System.Drawing.Point(12, 467);
            this.lblBalancedSms.Name = "lblBalancedSms";
            this.lblBalancedSms.Size = new System.Drawing.Size(100, 21);
            this.lblBalancedSms.TabIndex = 11;
            this.lblBalancedSms.Text = "Balanced SMS";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_message_text);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(321, 141);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SMS Text";
            // 
            // txt_message_text
            // 
            this.txt_message_text.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txt_message_text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_message_text.Location = new System.Drawing.Point(3, 19);
            this.txt_message_text.MaxLength = 1000;
            this.txt_message_text.Multiline = true;
            this.txt_message_text.Name = "txt_message_text";
            this.txt_message_text.Size = new System.Drawing.Size(315, 119);
            this.txt_message_text.TabIndex = 2;
            this.txt_message_text.TextChanged += new System.EventHandler(this.txt_message_text_TextChanged);
            // 
            // btnSentMessage
            // 
            this.btnSentMessage.Location = new System.Drawing.Point(243, 465);
            this.btnSentMessage.Name = "btnSentMessage";
            this.btnSentMessage.Size = new System.Drawing.Size(91, 25);
            this.btnSentMessage.TabIndex = 1;
            this.btnSentMessage.Text = "Send Message";
            this.btnSentMessage.UseVisualStyleBackColor = true;
            this.btnSentMessage.Click += new System.EventHandler(this.btnSentMessage_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtNumbers);
            this.groupBox2.Location = new System.Drawing.Point(12, 162);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(321, 277);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Enter Mobile Number";
            // 
            // txtNumbers
            // 
            this.txtNumbers.BackColor = System.Drawing.SystemColors.Window;
            this.txtNumbers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNumbers.Location = new System.Drawing.Point(3, 19);
            this.txtNumbers.Multiline = true;
            this.txtNumbers.Name = "txtNumbers";
            this.txtNumbers.Size = new System.Drawing.Size(315, 255);
            this.txtNumbers.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 442);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(318, 19);
            this.label1.TabIndex = 13;
            this.label1.Text = "Format: XXXXXXXXXX,XXXXXXXXXX,XXXXXXXXXX";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.gridSMS);
            this.groupBox3.Location = new System.Drawing.Point(346, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(249, 475);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "SMS Send Status";
            // 
            // gridSMS
            // 
            this.gridSMS.AllowUserToAddRows = false;
            this.gridSMS.AllowUserToDeleteRows = false;
            this.gridSMS.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridSMS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridSMS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMobileNumber,
            this.colStatus});
            this.gridSMS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSMS.Location = new System.Drawing.Point(3, 19);
            this.gridSMS.Name = "gridSMS";
            this.gridSMS.ReadOnly = true;
            this.gridSMS.RowHeadersVisible = false;
            this.gridSMS.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridSMS.Size = new System.Drawing.Size(243, 453);
            this.gridSMS.TabIndex = 7;
            // 
            // colMobileNumber
            // 
            this.colMobileNumber.DataPropertyName = "Mobile_Number";
            this.colMobileNumber.HeaderText = "Mobile Number";
            this.colMobileNumber.Name = "colMobileNumber";
            this.colMobileNumber.ReadOnly = true;
            this.colMobileNumber.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colMobileNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colMobileNumber.Width = 120;
            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "Send_Status";
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // lblTotalLength
            // 
            this.lblTotalLength.Location = new System.Drawing.Point(243, 153);
            this.lblTotalLength.Name = "lblTotalLength";
            this.lblTotalLength.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTotalLength.Size = new System.Drawing.Size(87, 13);
            this.lblTotalLength.TabIndex = 3;
            this.lblTotalLength.Text = "0";
            this.lblTotalLength.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // linkDownload
            // 
            this.linkDownload.AutoSize = true;
            this.linkDownload.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkDownload.Location = new System.Drawing.Point(608, 67);
            this.linkDownload.Name = "linkDownload";
            this.linkDownload.Size = new System.Drawing.Size(161, 15);
            this.linkDownload.TabIndex = 78;
            this.linkDownload.TabStop = true;
            this.linkDownload.Text = "SMS Report - Export To Excel";
            this.linkDownload.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkDownload_LinkClicked);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(608, 23);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(38, 15);
            this.lblDate.TabIndex = 132;
            this.lblDate.Text = "Date :";
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(611, 41);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(125, 23);
            this.dtpDate.TabIndex = 131;
            // 
            // Send_SMS_To_Number_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 519);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.linkDownload);
            this.Controls.Add(this.lblTotalLength);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnSentMessage);
            this.Controls.Add(this.lblBalancedSMSValue);
            this.Controls.Add(this.lblBalancedSms);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(46)))), ((int)(((byte)(75)))));
            this.Name = "Send_SMS_To_Number_Form";
            this.Text = "Send SMS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Send_SMS_To_Number_Form_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSMS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBalancedSMSValue;
        private System.Windows.Forms.Label lblBalancedSms;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSentMessage;
        private System.Windows.Forms.TextBox txt_message_text;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtNumbers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblTotalLength;
        private System.Windows.Forms.DataGridView gridSMS;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMobileNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.LinkLabel linkDownload;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
    }
}