namespace eVidyalaya
{
    partial class Student_TC_Form
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
            this.lblRegistrationNumber = new System.Windows.Forms.Label();
            this.txtRegistrationNo = new System.Windows.Forms.TextBox();
            this.lblStudentName = new System.Windows.Forms.Label();
            this.lblClass = new System.Windows.Forms.Label();
            this.lblReason = new System.Windows.Forms.Label();
            this.lblTCDate = new System.Windows.Forms.Label();
            this.lblAcademicYear = new System.Windows.Forms.Label();
            this.ddlTCReason = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtMaskedAcademicYear = new System.Windows.Forms.MaskedTextBox();
            this.lblStudentNameValue = new System.Windows.Forms.Label();
            this.lblClassValue = new System.Windows.Forms.Label();
            this.txtMaskedDate = new System.Windows.Forms.MaskedTextBox();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.txtTCNumber = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTCNumber = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTCAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPrintTCReceipt = new System.Windows.Forms.Button();
            this.btnPrintTCForm = new System.Windows.Forms.Button();
            this.groupBox.SuspendLayout();
            this.panelInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblRegistrationNumber
            // 
            this.lblRegistrationNumber.AutoSize = true;
            this.lblRegistrationNumber.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblRegistrationNumber.Location = new System.Drawing.Point(2, 21);
            this.lblRegistrationNumber.Name = "lblRegistrationNumber";
            this.lblRegistrationNumber.Size = new System.Drawing.Size(95, 15);
            this.lblRegistrationNumber.TabIndex = 27;
            this.lblRegistrationNumber.Text = "Registration No :";
            // 
            // txtRegistrationNo
            // 
            this.txtRegistrationNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRegistrationNo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.txtRegistrationNo.Location = new System.Drawing.Point(102, 14);
            this.txtRegistrationNo.MaxLength = 19;
            this.txtRegistrationNo.Name = "txtRegistrationNo";
            this.txtRegistrationNo.Size = new System.Drawing.Size(132, 23);
            this.txtRegistrationNo.TabIndex = 1;
            // 
            // lblStudentName
            // 
            this.lblStudentName.AutoSize = true;
            this.lblStudentName.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblStudentName.Location = new System.Drawing.Point(3, 8);
            this.lblStudentName.Name = "lblStudentName";
            this.lblStudentName.Size = new System.Drawing.Size(90, 15);
            this.lblStudentName.TabIndex = 28;
            this.lblStudentName.Text = "Student Name :";
            // 
            // lblClass
            // 
            this.lblClass.AutoSize = true;
            this.lblClass.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblClass.Location = new System.Drawing.Point(11, 36);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(81, 15);
            this.lblClass.TabIndex = 29;
            this.lblClass.Text = "Current Class :";
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblReason.Location = new System.Drawing.Point(41, 123);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(51, 15);
            this.lblReason.TabIndex = 32;
            this.lblReason.Text = "Reason :";
            // 
            // lblTCDate
            // 
            this.lblTCDate.AutoSize = true;
            this.lblTCDate.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblTCDate.Location = new System.Drawing.Point(37, 97);
            this.lblTCDate.Name = "lblTCDate";
            this.lblTCDate.Size = new System.Drawing.Size(55, 15);
            this.lblTCDate.TabIndex = 33;
            this.lblTCDate.Text = "TC Date :";
            // 
            // lblAcademicYear
            // 
            this.lblAcademicYear.AutoSize = true;
            this.lblAcademicYear.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblAcademicYear.Location = new System.Drawing.Point(3, 64);
            this.lblAcademicYear.Name = "lblAcademicYear";
            this.lblAcademicYear.Size = new System.Drawing.Size(91, 15);
            this.lblAcademicYear.TabIndex = 34;
            this.lblAcademicYear.Text = "Academic Year :";
            // 
            // ddlTCReason
            // 
            this.ddlTCReason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlTCReason.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.ddlTCReason.FormattingEnabled = true;
            this.ddlTCReason.Location = new System.Drawing.Point(98, 120);
            this.ddlTCReason.Name = "ddlTCReason";
            this.ddlTCReason.Size = new System.Drawing.Size(331, 23);
            this.ddlTCReason.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(54)))), ((int)(((byte)(92)))));
            this.btnSave.Location = new System.Drawing.Point(382, 213);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(47, 24);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtMaskedAcademicYear
            // 
            this.txtMaskedAcademicYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaskedAcademicYear.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.txtMaskedAcademicYear.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtMaskedAcademicYear.Location = new System.Drawing.Point(98, 60);
            this.txtMaskedAcademicYear.Mask = "0000-0000";
            this.txtMaskedAcademicYear.Name = "txtMaskedAcademicYear";
            this.txtMaskedAcademicYear.Size = new System.Drawing.Size(97, 23);
            this.txtMaskedAcademicYear.TabIndex = 3;
            // 
            // lblStudentNameValue
            // 
            this.lblStudentNameValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(231)))));
            this.lblStudentNameValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStudentNameValue.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblStudentNameValue.Location = new System.Drawing.Point(98, 4);
            this.lblStudentNameValue.Name = "lblStudentNameValue";
            this.lblStudentNameValue.Size = new System.Drawing.Size(331, 23);
            this.lblStudentNameValue.TabIndex = 38;
            this.lblStudentNameValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblClassValue
            // 
            this.lblClassValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(231)))));
            this.lblClassValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblClassValue.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblClassValue.Location = new System.Drawing.Point(98, 32);
            this.lblClassValue.Name = "lblClassValue";
            this.lblClassValue.Size = new System.Drawing.Size(97, 23);
            this.lblClassValue.TabIndex = 37;
            this.lblClassValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMaskedDate
            // 
            this.txtMaskedDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaskedDate.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.txtMaskedDate.Location = new System.Drawing.Point(98, 89);
            this.txtMaskedDate.Mask = "00.00.0000";
            this.txtMaskedDate.Name = "txtMaskedDate";
            this.txtMaskedDate.Size = new System.Drawing.Size(97, 23);
            this.txtMaskedDate.TabIndex = 4;
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.btnSearch);
            this.groupBox.Controls.Add(this.panelInfo);
            this.groupBox.Controls.Add(this.txtRegistrationNo);
            this.groupBox.Controls.Add(this.lblRegistrationNumber);
            this.groupBox.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox.Location = new System.Drawing.Point(8, 6);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(446, 287);
            this.groupBox.TabIndex = 0;
            this.groupBox.TabStop = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(54)))), ((int)(((byte)(92)))));
            this.btnSearch.Location = new System.Drawing.Point(242, 14);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(51, 24);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panelInfo
            // 
            this.panelInfo.Controls.Add(this.btnPrintTCForm);
            this.panelInfo.Controls.Add(this.btnPrintTCReceipt);
            this.panelInfo.Controls.Add(this.txtTCAmount);
            this.panelInfo.Controls.Add(this.label1);
            this.panelInfo.Controls.Add(this.txtTCNumber);
            this.panelInfo.Controls.Add(this.btnDelete);
            this.panelInfo.Controls.Add(this.btnSave);
            this.panelInfo.Controls.Add(this.label3);
            this.panelInfo.Controls.Add(this.lblStudentName);
            this.panelInfo.Controls.Add(this.lblTCNumber);
            this.panelInfo.Controls.Add(this.label2);
            this.panelInfo.Controls.Add(this.lblClass);
            this.panelInfo.Controls.Add(this.txtMaskedDate);
            this.panelInfo.Controls.Add(this.lblReason);
            this.panelInfo.Controls.Add(this.lblTCDate);
            this.panelInfo.Controls.Add(this.lblClassValue);
            this.panelInfo.Controls.Add(this.lblAcademicYear);
            this.panelInfo.Controls.Add(this.lblStudentNameValue);
            this.panelInfo.Controls.Add(this.ddlTCReason);
            this.panelInfo.Controls.Add(this.txtMaskedAcademicYear);
            this.panelInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.panelInfo.Location = new System.Drawing.Point(4, 39);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(436, 242);
            this.panelInfo.TabIndex = 0;
            this.panelInfo.Visible = false;
            // 
            // txtTCNumber
            // 
            this.txtTCNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTCNumber.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.txtTCNumber.Location = new System.Drawing.Point(98, 150);
            this.txtTCNumber.MaxLength = 19;
            this.txtTCNumber.Name = "txtTCNumber";
            this.txtTCNumber.ShortcutsEnabled = false;
            this.txtTCNumber.Size = new System.Drawing.Size(97, 23);
            this.txtTCNumber.TabIndex = 5;
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(54)))), ((int)(((byte)(92)))));
            this.btnDelete.Location = new System.Drawing.Point(328, 213);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(51, 24);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(200, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 169;
            this.label3.Text = "DD.MM.YYYY";
            // 
            // lblTCNumber
            // 
            this.lblTCNumber.AutoSize = true;
            this.lblTCNumber.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblTCNumber.Location = new System.Drawing.Point(18, 155);
            this.lblTCNumber.Name = "lblTCNumber";
            this.lblTCNumber.Size = new System.Drawing.Size(74, 15);
            this.lblTCNumber.TabIndex = 29;
            this.lblTCNumber.Text = "TC Number :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(200, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 168;
            this.label2.Text = "YYYY-YYYY";
            // 
            // txtTCAmount
            // 
            this.txtTCAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTCAmount.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.txtTCAmount.Location = new System.Drawing.Point(98, 179);
            this.txtTCAmount.MaxLength = 10;
            this.txtTCAmount.Name = "txtTCAmount";
            this.txtTCAmount.ShortcutsEnabled = false;
            this.txtTCAmount.Size = new System.Drawing.Size(97, 23);
            this.txtTCAmount.TabIndex = 170;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(20, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 15);
            this.label1.TabIndex = 171;
            this.label1.Text = "TC Amount :";
            // 
            // btnPrintTCReceipt
            // 
            this.btnPrintTCReceipt.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnPrintTCReceipt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(54)))), ((int)(((byte)(92)))));
            this.btnPrintTCReceipt.Location = new System.Drawing.Point(218, 213);
            this.btnPrintTCReceipt.Name = "btnPrintTCReceipt";
            this.btnPrintTCReceipt.Size = new System.Drawing.Size(107, 24);
            this.btnPrintTCReceipt.TabIndex = 4;
            this.btnPrintTCReceipt.Text = "Print TC Receipt";
            this.btnPrintTCReceipt.UseVisualStyleBackColor = true;
            this.btnPrintTCReceipt.Visible = false;
            this.btnPrintTCReceipt.Click += new System.EventHandler(this.btnPrintTCReceipt_Click);
            // 
            // btnPrintTCForm
            // 
            this.btnPrintTCForm.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnPrintTCForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(54)))), ((int)(((byte)(92)))));
            this.btnPrintTCForm.Location = new System.Drawing.Point(126, 213);
            this.btnPrintTCForm.Name = "btnPrintTCForm";
            this.btnPrintTCForm.Size = new System.Drawing.Size(89, 24);
            this.btnPrintTCForm.TabIndex = 4;
            this.btnPrintTCForm.Text = "Print TC Form";
            this.btnPrintTCForm.UseVisualStyleBackColor = true;
            this.btnPrintTCForm.Visible = false;
            // 
            // Student_TC_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 500);
            this.Controls.Add(this.groupBox);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(54)))), ((int)(((byte)(92)))));
            this.Name = "Student_TC_Form";
            this.Text = "Student TC Entry";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Student_TC_Form_FormClosing);
            this.Load += new System.EventHandler(this.Student_TC_Form_Load);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblRegistrationNumber;
        private System.Windows.Forms.TextBox txtRegistrationNo;
        private System.Windows.Forms.Label lblStudentName;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.Label lblTCDate;
        private System.Windows.Forms.Label lblAcademicYear;
        private System.Windows.Forms.ComboBox ddlTCReason;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.MaskedTextBox txtMaskedAcademicYear;
        private System.Windows.Forms.Label lblStudentNameValue;
        private System.Windows.Forms.Label lblClassValue;
        private System.Windows.Forms.MaskedTextBox txtMaskedDate;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtTCNumber;
        private System.Windows.Forms.Label lblTCNumber;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtTCAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPrintTCForm;
        private System.Windows.Forms.Button btnPrintTCReceipt;
    }
}