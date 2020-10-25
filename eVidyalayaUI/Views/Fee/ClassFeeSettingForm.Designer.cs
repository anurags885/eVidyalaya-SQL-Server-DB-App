namespace eVidyalaya
{
    partial class ClassFeeSettingForm
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
            this.groupFee = new System.Windows.Forms.GroupBox();
            this.txtAmountForStaffChild = new System.Windows.Forms.TextBox();
            this.linkSearchByFeeType = new System.Windows.Forms.LinkLabel();
            this.chkIsApplicapleOnStaffChild = new System.Windows.Forms.CheckBox();
            this.ddlClass = new System.Windows.Forms.ComboBox();
            this.lblAmountForStaffChild = new System.Windows.Forms.Label();
            this.ddlFeeType = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblFeeType = new System.Windows.Forms.Label();
            this.lblClass = new System.Windows.Forms.Label();
            this.txtFeeAmount = new System.Windows.Forms.TextBox();
            this.chkApplicable = new System.Windows.Forms.CheckBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.groupFeeList = new System.Windows.Forms.GroupBox();
            this.gridFeeSetting = new System.Windows.Forms.DataGridView();
            this.colEdit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colFeeSettingID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFeeTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClassID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFeeType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colIsApplicableOnStaffChild = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colAmountForStaffChild = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblNoRecordFound = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.hdnClassFeeID = new System.Windows.Forms.Label();
            this.lblShortCutKeys = new System.Windows.Forms.Label();
            this.ddlAcademicYear = new System.Windows.Forms.ComboBox();
            this.lblAcademicYear = new System.Windows.Forms.Label();
            this.groupFee.SuspendLayout();
            this.groupFeeList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFeeSetting)).BeginInit();
            this.SuspendLayout();
            // 
            // groupFee
            // 
            this.groupFee.Controls.Add(this.txtAmountForStaffChild);
            this.groupFee.Controls.Add(this.linkSearchByFeeType);
            this.groupFee.Controls.Add(this.chkIsApplicapleOnStaffChild);
            this.groupFee.Controls.Add(this.ddlClass);
            this.groupFee.Controls.Add(this.lblAmountForStaffChild);
            this.groupFee.Controls.Add(this.ddlFeeType);
            this.groupFee.Controls.Add(this.btnSave);
            this.groupFee.Controls.Add(this.lblFeeType);
            this.groupFee.Controls.Add(this.lblClass);
            this.groupFee.Controls.Add(this.txtFeeAmount);
            this.groupFee.Controls.Add(this.chkApplicable);
            this.groupFee.Controls.Add(this.lblAmount);
            this.groupFee.Enabled = false;
            this.groupFee.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.groupFee.Location = new System.Drawing.Point(10, 34);
            this.groupFee.Name = "groupFee";
            this.groupFee.Size = new System.Drawing.Size(654, 84);
            this.groupFee.TabIndex = 0;
            this.groupFee.TabStop = false;
            // 
            // txtAmountForStaffChild
            // 
            this.txtAmountForStaffChild.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmountForStaffChild.Enabled = false;
            this.txtAmountForStaffChild.Location = new System.Drawing.Point(467, 55);
            this.txtAmountForStaffChild.MaxLength = 5;
            this.txtAmountForStaffChild.Name = "txtAmountForStaffChild";
            this.txtAmountForStaffChild.Size = new System.Drawing.Size(84, 22);
            this.txtAmountForStaffChild.TabIndex = 9;
            // 
            // linkSearchByFeeType
            // 
            this.linkSearchByFeeType.AutoSize = true;
            this.linkSearchByFeeType.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkSearchByFeeType.Location = new System.Drawing.Point(255, 10);
            this.linkSearchByFeeType.Name = "linkSearchByFeeType";
            this.linkSearchByFeeType.Size = new System.Drawing.Size(104, 13);
            this.linkSearchByFeeType.TabIndex = 6;
            this.linkSearchByFeeType.TabStop = true;
            this.linkSearchByFeeType.Text = "Search By Fee Type";
            this.linkSearchByFeeType.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSearchByFeeType_LinkClicked);
            // 
            // chkIsApplicapleOnStaffChild
            // 
            this.chkIsApplicapleOnStaffChild.AutoSize = true;
            this.chkIsApplicapleOnStaffChild.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkIsApplicapleOnStaffChild.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsApplicapleOnStaffChild.ForeColor = System.Drawing.Color.Red;
            this.chkIsApplicapleOnStaffChild.Location = new System.Drawing.Point(5, 57);
            this.chkIsApplicapleOnStaffChild.Name = "chkIsApplicapleOnStaffChild";
            this.chkIsApplicapleOnStaffChild.Size = new System.Drawing.Size(171, 19);
            this.chkIsApplicapleOnStaffChild.TabIndex = 7;
            this.chkIsApplicapleOnStaffChild.Text = "Is Applicaple On Staff Child";
            this.chkIsApplicapleOnStaffChild.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkIsApplicapleOnStaffChild.UseVisualStyleBackColor = true;
            this.chkIsApplicapleOnStaffChild.CheckedChanged += new System.EventHandler(this.chkIaApplicapleOnStaffChild_CheckedChanged);
            // 
            // ddlClass
            // 
            this.ddlClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlClass.FormattingEnabled = true;
            this.ddlClass.Location = new System.Drawing.Point(49, 25);
            this.ddlClass.Name = "ddlClass";
            this.ddlClass.Size = new System.Drawing.Size(118, 21);
            this.ddlClass.TabIndex = 1;
            this.ddlClass.SelectedIndexChanged += new System.EventHandler(this.ddlClass_SelectedIndexChanged);
            // 
            // lblAmountForStaffChild
            // 
            this.lblAmountForStaffChild.AutoSize = true;
            this.lblAmountForStaffChild.Enabled = false;
            this.lblAmountForStaffChild.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountForStaffChild.Location = new System.Drawing.Point(331, 58);
            this.lblAmountForStaffChild.Name = "lblAmountForStaffChild";
            this.lblAmountForStaffChild.Size = new System.Drawing.Size(135, 15);
            this.lblAmountForStaffChild.TabIndex = 8;
            this.lblAmountForStaffChild.Text = "Amount For Staff Child :";
            // 
            // ddlFeeType
            // 
            this.ddlFeeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlFeeType.FormattingEnabled = true;
            this.ddlFeeType.Location = new System.Drawing.Point(233, 26);
            this.ddlFeeType.Name = "ddlFeeType";
            this.ddlFeeType.Size = new System.Drawing.Size(152, 21);
            this.ddlFeeType.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(604, 55);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(43, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblFeeType
            // 
            this.lblFeeType.AutoSize = true;
            this.lblFeeType.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFeeType.Location = new System.Drawing.Point(173, 29);
            this.lblFeeType.Name = "lblFeeType";
            this.lblFeeType.Size = new System.Drawing.Size(59, 15);
            this.lblFeeType.TabIndex = 0;
            this.lblFeeType.Text = "Fee Type :";
            // 
            // lblClass
            // 
            this.lblClass.AutoSize = true;
            this.lblClass.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClass.Location = new System.Drawing.Point(8, 28);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(39, 15);
            this.lblClass.TabIndex = 1;
            this.lblClass.Text = "Class :";
            // 
            // txtFeeAmount
            // 
            this.txtFeeAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFeeAmount.Location = new System.Drawing.Point(467, 24);
            this.txtFeeAmount.MaxLength = 5;
            this.txtFeeAmount.Name = "txtFeeAmount";
            this.txtFeeAmount.Size = new System.Drawing.Size(84, 22);
            this.txtFeeAmount.TabIndex = 3;
            // 
            // chkApplicable
            // 
            this.chkApplicable.AutoSize = true;
            this.chkApplicable.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkApplicable.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkApplicable.Location = new System.Drawing.Point(565, 27);
            this.chkApplicable.Name = "chkApplicable";
            this.chkApplicable.Size = new System.Drawing.Size(82, 19);
            this.chkApplicable.TabIndex = 4;
            this.chkApplicable.Text = "Applicable";
            this.chkApplicable.UseVisualStyleBackColor = true;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.Location = new System.Drawing.Point(409, 28);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(57, 15);
            this.lblAmount.TabIndex = 2;
            this.lblAmount.Text = "Amount :";
            // 
            // groupFeeList
            // 
            this.groupFeeList.Controls.Add(this.gridFeeSetting);
            this.groupFeeList.Controls.Add(this.lblNoRecordFound);
            this.groupFeeList.Enabled = false;
            this.groupFeeList.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.groupFeeList.Location = new System.Drawing.Point(10, 125);
            this.groupFeeList.Name = "groupFeeList";
            this.groupFeeList.Size = new System.Drawing.Size(654, 491);
            this.groupFeeList.TabIndex = 8;
            this.groupFeeList.TabStop = false;
            // 
            // gridFeeSetting
            // 
            this.gridFeeSetting.AllowUserToAddRows = false;
            this.gridFeeSetting.AllowUserToDeleteRows = false;
            this.gridFeeSetting.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridFeeSetting.ColumnHeadersHeight = 35;
            this.gridFeeSetting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridFeeSetting.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colEdit,
            this.colFeeSettingID,
            this.colFeeTypeID,
            this.colClassID,
            this.colClass,
            this.colFeeType,
            this.colAmount,
            this.colActive,
            this.colIsApplicableOnStaffChild,
            this.colAmountForStaffChild});
            this.gridFeeSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridFeeSetting.Location = new System.Drawing.Point(3, 18);
            this.gridFeeSetting.Name = "gridFeeSetting";
            this.gridFeeSetting.RowHeadersVisible = false;
            this.gridFeeSetting.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridFeeSetting.Size = new System.Drawing.Size(648, 470);
            this.gridFeeSetting.TabIndex = 136;
            this.gridFeeSetting.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridFeeSetting_CellContentClick);
            // 
            // colEdit
            // 
            this.colEdit.HeaderText = "Edit";
            this.colEdit.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.colEdit.Name = "colEdit";
            this.colEdit.ReadOnly = true;
            this.colEdit.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colEdit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colEdit.Width = 40;
            // 
            // colFeeSettingID
            // 
            this.colFeeSettingID.HeaderText = "FeeSettingID";
            this.colFeeSettingID.Name = "colFeeSettingID";
            this.colFeeSettingID.ReadOnly = true;
            this.colFeeSettingID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colFeeSettingID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colFeeSettingID.Visible = false;
            this.colFeeSettingID.Width = 40;
            // 
            // colFeeTypeID
            // 
            this.colFeeTypeID.HeaderText = "colFeeTypeID";
            this.colFeeTypeID.Name = "colFeeTypeID";
            this.colFeeTypeID.ReadOnly = true;
            this.colFeeTypeID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colFeeTypeID.Visible = false;
            // 
            // colClassID
            // 
            this.colClassID.HeaderText = "colClassID";
            this.colClassID.Name = "colClassID";
            this.colClassID.ReadOnly = true;
            this.colClassID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colClassID.Visible = false;
            // 
            // colClass
            // 
            this.colClass.HeaderText = "Class";
            this.colClass.Name = "colClass";
            this.colClass.ReadOnly = true;
            this.colClass.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colClass.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colClass.Width = 60;
            // 
            // colFeeType
            // 
            this.colFeeType.HeaderText = "Fee Type";
            this.colFeeType.Name = "colFeeType";
            this.colFeeType.ReadOnly = true;
            this.colFeeType.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colFeeType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colFeeType.Width = 210;
            // 
            // colAmount
            // 
            this.colAmount.HeaderText = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            this.colAmount.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colAmount.Width = 80;
            // 
            // colActive
            // 
            this.colActive.HeaderText = "Active";
            this.colActive.Name = "colActive";
            this.colActive.ReadOnly = true;
            this.colActive.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colActive.Width = 55;
            // 
            // colIsApplicableOnStaffChild
            // 
            this.colIsApplicableOnStaffChild.HeaderText = "Applicable On Staff Child";
            this.colIsApplicableOnStaffChild.Name = "colIsApplicableOnStaffChild";
            this.colIsApplicableOnStaffChild.ReadOnly = true;
            this.colIsApplicableOnStaffChild.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colAmountForStaffChild
            // 
            this.colAmountForStaffChild.HeaderText = "Amount For Staff Child";
            this.colAmountForStaffChild.Name = "colAmountForStaffChild";
            this.colAmountForStaffChild.ReadOnly = true;
            this.colAmountForStaffChild.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colAmountForStaffChild.Width = 80;
            // 
            // lblNoRecordFound
            // 
            this.lblNoRecordFound.AutoSize = true;
            this.lblNoRecordFound.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoRecordFound.ForeColor = System.Drawing.Color.Red;
            this.lblNoRecordFound.Location = new System.Drawing.Point(8, 1);
            this.lblNoRecordFound.Name = "lblNoRecordFound";
            this.lblNoRecordFound.Size = new System.Drawing.Size(103, 15);
            this.lblNoRecordFound.TabIndex = 9;
            this.lblNoRecordFound.Text = "No Record Found.";
            this.lblNoRecordFound.Visible = false;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(670, 15);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(45, 15);
            this.lblError.TabIndex = 139;
            this.lblError.Text = "lblError";
            this.lblError.Visible = false;
            // 
            // hdnClassFeeID
            // 
            this.hdnClassFeeID.AutoSize = true;
            this.hdnClassFeeID.Location = new System.Drawing.Point(670, 153);
            this.hdnClassFeeID.Name = "hdnClassFeeID";
            this.hdnClassFeeID.Size = new System.Drawing.Size(85, 15);
            this.hdnClassFeeID.TabIndex = 140;
            this.hdnClassFeeID.Text = "hdnClassFeeID";
            this.hdnClassFeeID.Visible = false;
            // 
            // lblShortCutKeys
            // 
            this.lblShortCutKeys.AutoSize = true;
            this.lblShortCutKeys.Location = new System.Drawing.Point(670, 138);
            this.lblShortCutKeys.Name = "lblShortCutKeys";
            this.lblShortCutKeys.Size = new System.Drawing.Size(91, 15);
            this.lblShortCutKeys.TabIndex = 142;
            this.lblShortCutKeys.Text = "lblShortCutKeys";
            // 
            // ddlAcademicYear
            // 
            this.ddlAcademicYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlAcademicYear.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.ddlAcademicYear.FormattingEnabled = true;
            this.ddlAcademicYear.Location = new System.Drawing.Point(111, 11);
            this.ddlAcademicYear.Name = "ddlAcademicYear";
            this.ddlAcademicYear.Size = new System.Drawing.Size(110, 21);
            this.ddlAcademicYear.TabIndex = 151;
            this.ddlAcademicYear.SelectedIndexChanged += new System.EventHandler(this.ddlAcademicYear_SelectedIndexChanged);
            // 
            // lblAcademicYear
            // 
            this.lblAcademicYear.AutoSize = true;
            this.lblAcademicYear.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblAcademicYear.Location = new System.Drawing.Point(15, 16);
            this.lblAcademicYear.Name = "lblAcademicYear";
            this.lblAcademicYear.Size = new System.Drawing.Size(91, 15);
            this.lblAcademicYear.TabIndex = 150;
            this.lblAcademicYear.Text = "Academic Year :";
            // 
            // ClassFeeSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(973, 624);
            this.Controls.Add(this.ddlAcademicYear);
            this.Controls.Add(this.lblAcademicYear);
            this.Controls.Add(this.lblShortCutKeys);
            this.Controls.Add(this.hdnClassFeeID);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.groupFeeList);
            this.Controls.Add(this.groupFee);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(54)))), ((int)(((byte)(92)))));
            this.Name = "ClassFeeSettingForm";
            this.Text = "Class Wise Fee Setting";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClassFeeSettingForm_FormClosing);
            this.Load += new System.EventHandler(this.ClassFeeSettingForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ClassFeeSettingForm_KeyDown);
            this.groupFee.ResumeLayout(false);
            this.groupFee.PerformLayout();
            this.groupFeeList.ResumeLayout(false);
            this.groupFeeList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFeeSetting)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupFee;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.Label lblFeeType;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.ComboBox ddlFeeType;
        private System.Windows.Forms.ComboBox ddlClass;
        private System.Windows.Forms.TextBox txtFeeAmount;
        private System.Windows.Forms.CheckBox chkApplicable;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupFeeList;
        private System.Windows.Forms.DataGridView gridFeeSetting;
        private System.Windows.Forms.Label lblNoRecordFound;
        private System.Windows.Forms.LinkLabel linkSearchByFeeType;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label hdnClassFeeID;
        private System.Windows.Forms.Label lblShortCutKeys;
        private System.Windows.Forms.CheckBox chkIsApplicapleOnStaffChild;
        private System.Windows.Forms.TextBox txtAmountForStaffChild;
        private System.Windows.Forms.Label lblAmountForStaffChild;
        private System.Windows.Forms.ComboBox ddlAcademicYear;
        private System.Windows.Forms.Label lblAcademicYear;
        private System.Windows.Forms.DataGridViewLinkColumn colEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFeeSettingID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFeeTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClassID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFeeType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colActive;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsApplicableOnStaffChild;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmountForStaffChild;
    }
}