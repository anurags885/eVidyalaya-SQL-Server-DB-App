namespace eVidyalaya
{
    partial class StudentFineForm
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
            this.ddlCurrentClass = new System.Windows.Forms.ComboBox();
            this.ddlCurrentSection = new System.Windows.Forms.ComboBox();
            this.lblCurrentSection = new System.Windows.Forms.Label();
            this.lblCurrentClass = new System.Windows.Forms.Label();
            this.groupStudent = new System.Windows.Forms.GroupBox();
            this.gridStudent = new System.Windows.Forms.DataGridView();
            this.colSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colRegistrationNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStudentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStudentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.ddlFeeType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFineDate = new System.Windows.Forms.Label();
            this.datePickerReport = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gridFine = new System.Windows.Forms.DataGridView();
            this.colSelectF = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colRegistrationNoF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStudentNameF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmountF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStudentIDF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFineTransactionIDF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnMoveRight = new System.Windows.Forms.Button();
            this.btnMoveLeft = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.groupSearch = new System.Windows.Forms.GroupBox();
            this.groupStudent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridStudent)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFine)).BeginInit();
            this.groupSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // ddlCurrentClass
            // 
            this.ddlCurrentClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlCurrentClass.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.ddlCurrentClass.FormattingEnabled = true;
            this.ddlCurrentClass.ItemHeight = 15;
            this.ddlCurrentClass.Location = new System.Drawing.Point(55, 15);
            this.ddlCurrentClass.Name = "ddlCurrentClass";
            this.ddlCurrentClass.Size = new System.Drawing.Size(74, 23);
            this.ddlCurrentClass.TabIndex = 139;
            // 
            // ddlCurrentSection
            // 
            this.ddlCurrentSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlCurrentSection.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.ddlCurrentSection.FormattingEnabled = true;
            this.ddlCurrentSection.Location = new System.Drawing.Point(192, 15);
            this.ddlCurrentSection.Name = "ddlCurrentSection";
            this.ddlCurrentSection.Size = new System.Drawing.Size(57, 23);
            this.ddlCurrentSection.TabIndex = 140;
            // 
            // lblCurrentSection
            // 
            this.lblCurrentSection.AutoSize = true;
            this.lblCurrentSection.Location = new System.Drawing.Point(135, 19);
            this.lblCurrentSection.Name = "lblCurrentSection";
            this.lblCurrentSection.Size = new System.Drawing.Size(53, 15);
            this.lblCurrentSection.TabIndex = 142;
            this.lblCurrentSection.Text = "Section :";
            // 
            // lblCurrentClass
            // 
            this.lblCurrentClass.AutoSize = true;
            this.lblCurrentClass.Location = new System.Drawing.Point(9, 19);
            this.lblCurrentClass.Name = "lblCurrentClass";
            this.lblCurrentClass.Size = new System.Drawing.Size(39, 15);
            this.lblCurrentClass.TabIndex = 141;
            this.lblCurrentClass.Text = "Class :";
            // 
            // groupStudent
            // 
            this.groupStudent.Controls.Add(this.gridStudent);
            this.groupStudent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(60)))), ((int)(((byte)(98)))));
            this.groupStudent.Location = new System.Drawing.Point(8, 84);
            this.groupStudent.Name = "groupStudent";
            this.groupStudent.Size = new System.Drawing.Size(395, 555);
            this.groupStudent.TabIndex = 143;
            this.groupStudent.TabStop = false;
            this.groupStudent.Text = "Student List";
            // 
            // gridStudent
            // 
            this.gridStudent.AllowDrop = true;
            this.gridStudent.AllowUserToAddRows = false;
            this.gridStudent.AllowUserToDeleteRows = false;
            this.gridStudent.AllowUserToResizeColumns = false;
            this.gridStudent.AllowUserToResizeRows = false;
            this.gridStudent.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridStudent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridStudent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelect,
            this.colRegistrationNo,
            this.colStudentName,
            this.colStudentID});
            this.gridStudent.Location = new System.Drawing.Point(7, 19);
            this.gridStudent.Name = "gridStudent";
            this.gridStudent.RowHeadersVisible = false;
            this.gridStudent.Size = new System.Drawing.Size(382, 528);
            this.gridStudent.TabIndex = 0;
            // 
            // colSelect
            // 
            this.colSelect.HeaderText = "Select";
            this.colSelect.Name = "colSelect";
            this.colSelect.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colSelect.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colSelect.Width = 50;
            // 
            // colRegistrationNo
            // 
            this.colRegistrationNo.HeaderText = "Registration No";
            this.colRegistrationNo.Name = "colRegistrationNo";
            this.colRegistrationNo.ReadOnly = true;
            this.colRegistrationNo.Width = 112;
            // 
            // colStudentName
            // 
            this.colStudentName.HeaderText = "Student Name";
            this.colStudentName.Name = "colStudentName";
            this.colStudentName.ReadOnly = true;
            this.colStudentName.Width = 200;
            // 
            // colStudentID
            // 
            this.colStudentID.HeaderText = "colStudentID";
            this.colStudentID.Name = "colStudentID";
            this.colStudentID.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(733, 15);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(52, 23);
            this.btnSave.TabIndex = 145;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ddlFeeType
            // 
            this.ddlFeeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlFeeType.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.ddlFeeType.FormattingEnabled = true;
            this.ddlFeeType.Location = new System.Drawing.Point(480, 15);
            this.ddlFeeType.Name = "ddlFeeType";
            this.ddlFeeType.Size = new System.Drawing.Size(183, 23);
            this.ddlFeeType.TabIndex = 146;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(412, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 147;
            this.label1.Text = "Fine Type :";
            // 
            // lblFineDate
            // 
            this.lblFineDate.AutoSize = true;
            this.lblFineDate.Location = new System.Drawing.Point(255, 18);
            this.lblFineDate.Name = "lblFineDate";
            this.lblFineDate.Size = new System.Drawing.Size(63, 15);
            this.lblFineDate.TabIndex = 148;
            this.lblFineDate.Text = "Fine Date :";
            // 
            // datePickerReport
            // 
            this.datePickerReport.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.datePickerReport.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePickerReport.Location = new System.Drawing.Point(317, 15);
            this.datePickerReport.Name = "datePickerReport";
            this.datePickerReport.Size = new System.Drawing.Size(90, 23);
            this.datePickerReport.TabIndex = 149;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(669, 15);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(57, 23);
            this.btnSearch.TabIndex = 151;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gridFine);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(60)))), ((int)(((byte)(98)))));
            this.groupBox1.Location = new System.Drawing.Point(464, 84);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(442, 555);
            this.groupBox1.TabIndex = 152;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Student\'s Fine List";
            // 
            // gridFine
            // 
            this.gridFine.AllowDrop = true;
            this.gridFine.AllowUserToAddRows = false;
            this.gridFine.AllowUserToDeleteRows = false;
            this.gridFine.AllowUserToResizeColumns = false;
            this.gridFine.AllowUserToResizeRows = false;
            this.gridFine.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridFine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridFine.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelectF,
            this.colRegistrationNoF,
            this.colStudentNameF,
            this.colAmountF,
            this.colStudentIDF,
            this.colFineTransactionIDF});
            this.gridFine.Location = new System.Drawing.Point(6, 19);
            this.gridFine.Name = "gridFine";
            this.gridFine.RowHeadersVisible = false;
            this.gridFine.Size = new System.Drawing.Size(430, 528);
            this.gridFine.TabIndex = 0;
            this.gridFine.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridFine_CellEnter);
            this.gridFine.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.gridFine_EditingControlShowing);
            // 
            // colSelectF
            // 
            this.colSelectF.HeaderText = "Select";
            this.colSelectF.Name = "colSelectF";
            this.colSelectF.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colSelectF.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colSelectF.Width = 50;
            // 
            // colRegistrationNoF
            // 
            this.colRegistrationNoF.HeaderText = "Registration No";
            this.colRegistrationNoF.Name = "colRegistrationNoF";
            this.colRegistrationNoF.ReadOnly = true;
            this.colRegistrationNoF.Width = 112;
            // 
            // colStudentNameF
            // 
            this.colStudentNameF.HeaderText = "Student Name";
            this.colStudentNameF.Name = "colStudentNameF";
            this.colStudentNameF.ReadOnly = true;
            this.colStudentNameF.Width = 170;
            // 
            // colAmountF
            // 
            this.colAmountF.HeaderText = "Amount";
            this.colAmountF.Name = "colAmountF";
            this.colAmountF.Width = 80;
            // 
            // colStudentIDF
            // 
            this.colStudentIDF.HeaderText = "colStudentIDF";
            this.colStudentIDF.Name = "colStudentIDF";
            this.colStudentIDF.Visible = false;
            // 
            // colFineTransactionIDF
            // 
            this.colFineTransactionIDF.HeaderText = "colFineTransactionIDF";
            this.colFineTransactionIDF.Name = "colFineTransactionIDF";
            this.colFineTransactionIDF.Visible = false;
            // 
            // btnMoveRight
            // 
            this.btnMoveRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnMoveRight.Location = new System.Drawing.Point(415, 301);
            this.btnMoveRight.Name = "btnMoveRight";
            this.btnMoveRight.Size = new System.Drawing.Size(43, 26);
            this.btnMoveRight.TabIndex = 153;
            this.btnMoveRight.Text = ">>";
            this.btnMoveRight.UseVisualStyleBackColor = true;
            this.btnMoveRight.Click += new System.EventHandler(this.btnMoveRight_Click);
            // 
            // btnMoveLeft
            // 
            this.btnMoveLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnMoveLeft.Location = new System.Drawing.Point(415, 344);
            this.btnMoveLeft.Name = "btnMoveLeft";
            this.btnMoveLeft.Size = new System.Drawing.Size(43, 26);
            this.btnMoveLeft.TabIndex = 154;
            this.btnMoveLeft.Text = "<<";
            this.btnMoveLeft.UseVisualStyleBackColor = true;
            this.btnMoveLeft.Click += new System.EventHandler(this.btnMoveLeft_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(791, 22);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(184, 13);
            this.lblError.TabIndex = 155;
            this.lblError.Text = "Cannot Be Applied For This Month.";
            this.lblError.Visible = false;
            // 
            // groupSearch
            // 
            this.groupSearch.Controls.Add(this.lblCurrentClass);
            this.groupSearch.Controls.Add(this.lblError);
            this.groupSearch.Controls.Add(this.lblCurrentSection);
            this.groupSearch.Controls.Add(this.ddlCurrentSection);
            this.groupSearch.Controls.Add(this.ddlCurrentClass);
            this.groupSearch.Controls.Add(this.btnSave);
            this.groupSearch.Controls.Add(this.btnSearch);
            this.groupSearch.Controls.Add(this.ddlFeeType);
            this.groupSearch.Controls.Add(this.datePickerReport);
            this.groupSearch.Controls.Add(this.label1);
            this.groupSearch.Controls.Add(this.lblFineDate);
            this.groupSearch.Location = new System.Drawing.Point(8, 15);
            this.groupSearch.Name = "groupSearch";
            this.groupSearch.Size = new System.Drawing.Size(980, 49);
            this.groupSearch.TabIndex = 156;
            this.groupSearch.TabStop = false;
            // 
            // StudentFineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1113, 618);
            this.Controls.Add(this.groupSearch);
            this.Controls.Add(this.btnMoveLeft);
            this.Controls.Add(this.btnMoveRight);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupStudent);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(46)))), ((int)(((byte)(75)))));
            this.Name = "StudentFineForm";
            this.Text = "Set Student Fine";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StudentFineForm_FormClosing);
            this.Load += new System.EventHandler(this.StudentFineForm_Load);
            this.groupStudent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridStudent)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridFine)).EndInit();
            this.groupSearch.ResumeLayout(false);
            this.groupSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox ddlCurrentClass;
        private System.Windows.Forms.ComboBox ddlCurrentSection;
        private System.Windows.Forms.Label lblCurrentSection;
        private System.Windows.Forms.Label lblCurrentClass;
        private System.Windows.Forms.GroupBox groupStudent;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView gridStudent;
        private System.Windows.Forms.ComboBox ddlFeeType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFineDate;
        private System.Windows.Forms.DateTimePicker datePickerReport;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView gridFine;
        private System.Windows.Forms.Button btnMoveRight;
        private System.Windows.Forms.Button btnMoveLeft;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRegistrationNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStudentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStudentID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelectF;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRegistrationNoF;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStudentNameF;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmountF;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStudentIDF;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFineTransactionIDF;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.GroupBox groupSearch;
    }
}