namespace eVidyalaya.Views.School
{
    partial class Send_SMS_All_Class_Form
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTotalLength = new System.Windows.Forms.Label();
            this.btnGenerateNumber = new System.Windows.Forms.Button();
            this.txt_message_text = new System.Windows.Forms.TextBox();
            this.lbl_Heading = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gridSMS = new System.Windows.Forms.DataGridView();
            this.colMobileNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSentDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSMSID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSendSMS = new System.Windows.Forms.Button();
            this.lblBalancedSms = new System.Windows.Forms.Label();
            this.lblBalancedSMSValue = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.linkDownload = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSMS)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTotalLength);
            this.groupBox1.Controls.Add(this.btnGenerateNumber);
            this.groupBox1.Controls.Add(this.txt_message_text);
            this.groupBox1.Location = new System.Drawing.Point(13, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(321, 217);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SMS Text";
            // 
            // lblTotalLength
            // 
            this.lblTotalLength.AutoSize = true;
            this.lblTotalLength.Location = new System.Drawing.Point(3, 185);
            this.lblTotalLength.Name = "lblTotalLength";
            this.lblTotalLength.Size = new System.Drawing.Size(14, 15);
            this.lblTotalLength.TabIndex = 9;
            this.lblTotalLength.Text = "0";
            // 
            // btnGenerateNumber
            // 
            this.btnGenerateNumber.Location = new System.Drawing.Point(192, 188);
            this.btnGenerateNumber.Name = "btnGenerateNumber";
            this.btnGenerateNumber.Size = new System.Drawing.Size(120, 23);
            this.btnGenerateNumber.TabIndex = 1;
            this.btnGenerateNumber.Text = "Construct Message";
            this.btnGenerateNumber.UseVisualStyleBackColor = true;
            this.btnGenerateNumber.Click += new System.EventHandler(this.btnGenerateNumber_Click);
            // 
            // txt_message_text
            // 
            this.txt_message_text.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txt_message_text.Location = new System.Drawing.Point(6, 22);
            this.txt_message_text.MaxLength = 1000;
            this.txt_message_text.Multiline = true;
            this.txt_message_text.Name = "txt_message_text";
            this.txt_message_text.Size = new System.Drawing.Size(306, 160);
            this.txt_message_text.TabIndex = 2;
            this.txt_message_text.TextChanged += new System.EventHandler(this.txt_message_text_TextChanged);
            // 
            // lbl_Heading
            // 
            this.lbl_Heading.AutoSize = true;
            this.lbl_Heading.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lbl_Heading.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Heading.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_Heading.Location = new System.Drawing.Point(13, 9);
            this.lbl_Heading.Name = "lbl_Heading";
            this.lbl_Heading.Size = new System.Drawing.Size(213, 21);
            this.lbl_Heading.TabIndex = 4;
            this.lbl_Heading.Text = "Send SMS To All Active Number";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gridSMS);
            this.groupBox2.Location = new System.Drawing.Point(340, 46);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(394, 563);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Active Numbers";
            // 
            // gridSMS
            // 
            this.gridSMS.AllowUserToAddRows = false;
            this.gridSMS.AllowUserToDeleteRows = false;
            this.gridSMS.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridSMS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridSMS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMobileNumber,
            this.colStatus,
            this.colSentDate,
            this.colSMSID});
            this.gridSMS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSMS.Location = new System.Drawing.Point(3, 19);
            this.gridSMS.Name = "gridSMS";
            this.gridSMS.ReadOnly = true;
            this.gridSMS.RowHeadersVisible = false;
            this.gridSMS.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridSMS.Size = new System.Drawing.Size(388, 541);
            this.gridSMS.TabIndex = 6;
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
            // colSentDate
            // 
            this.colSentDate.DataPropertyName = "Send_Date_Time";
            this.colSentDate.HeaderText = "Sent Date";
            this.colSentDate.Name = "colSentDate";
            this.colSentDate.ReadOnly = true;
            this.colSentDate.Width = 150;
            // 
            // colSMSID
            // 
            this.colSMSID.DataPropertyName = "SMS_ID";
            this.colSMSID.HeaderText = "colSMSID";
            this.colSMSID.Name = "colSMSID";
            this.colSMSID.ReadOnly = true;
            this.colSMSID.Visible = false;
            // 
            // btnSendSMS
            // 
            this.btnSendSMS.Enabled = false;
            this.btnSendSMS.Location = new System.Drawing.Point(757, 65);
            this.btnSendSMS.Name = "btnSendSMS";
            this.btnSendSMS.Size = new System.Drawing.Size(96, 23);
            this.btnSendSMS.TabIndex = 6;
            this.btnSendSMS.Text = "Send Message";
            this.btnSendSMS.UseVisualStyleBackColor = true;
            this.btnSendSMS.Click += new System.EventHandler(this.btnSendSMS_Click);
            // 
            // lblBalancedSms
            // 
            this.lblBalancedSms.AutoSize = true;
            this.lblBalancedSms.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBalancedSms.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblBalancedSms.Location = new System.Drawing.Point(19, 279);
            this.lblBalancedSms.Name = "lblBalancedSms";
            this.lblBalancedSms.Size = new System.Drawing.Size(100, 21);
            this.lblBalancedSms.TabIndex = 7;
            this.lblBalancedSms.Text = "Balanced SMS";
            // 
            // lblBalancedSMSValue
            // 
            this.lblBalancedSMSValue.AutoSize = true;
            this.lblBalancedSMSValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBalancedSMSValue.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblBalancedSMSValue.Location = new System.Drawing.Point(118, 279);
            this.lblBalancedSMSValue.Name = "lblBalancedSMSValue";
            this.lblBalancedSMSValue.Size = new System.Drawing.Size(2, 21);
            this.lblBalancedSMSValue.TabIndex = 8;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(16, 316);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(38, 15);
            this.lblDate.TabIndex = 135;
            this.lblDate.Text = "Date :";
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(19, 334);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(125, 23);
            this.dtpDate.TabIndex = 134;
            // 
            // linkDownload
            // 
            this.linkDownload.AutoSize = true;
            this.linkDownload.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkDownload.Location = new System.Drawing.Point(16, 360);
            this.linkDownload.Name = "linkDownload";
            this.linkDownload.Size = new System.Drawing.Size(161, 15);
            this.linkDownload.TabIndex = 133;
            this.linkDownload.TabStop = true;
            this.linkDownload.Text = "SMS Report - Export To Excel";
            this.linkDownload.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkDownload_LinkClicked);
            // 
            // Send_SMS_All_Class_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 621);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.linkDownload);
            this.Controls.Add(this.lblBalancedSMSValue);
            this.Controls.Add(this.lblBalancedSms);
            this.Controls.Add(this.btnSendSMS);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lbl_Heading);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(46)))), ((int)(((byte)(75)))));
            this.Name = "Send_SMS_All_Class_Form";
            this.Text = "Send SMS (All Active Number)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Send_SMS_All_Class_Form_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSMS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnGenerateNumber;
        private System.Windows.Forms.TextBox txt_message_text;
        private System.Windows.Forms.Label lbl_Heading;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSendSMS;
        private System.Windows.Forms.Label lblBalancedSms;
        private System.Windows.Forms.Label lblBalancedSMSValue;
        private System.Windows.Forms.DataGridView gridSMS;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMobileNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSentDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSMSID;
        private System.Windows.Forms.Label lblTotalLength;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.LinkLabel linkDownload;
    }
}