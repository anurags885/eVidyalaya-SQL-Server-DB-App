namespace eVidyalaya
{
    partial class StudentPromotionForm
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.ddlClass = new System.Windows.Forms.ComboBox();
            this.ddlSection = new System.Windows.Forms.ComboBox();
            this.lblCurrentSection = new System.Windows.Forms.Label();
            this.lblCurrentClass = new System.Windows.Forms.Label();
            this.groupBoxPromote = new System.Windows.Forms.GroupBox();
            this.gridStudent = new System.Windows.Forms.DataGridView();
            this.colSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colRegistrationNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStudentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCurrentClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSection = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHiddenClassID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHiddenSectionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHiddenStudentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStudentPromotionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.gridStudentPromotionHistory = new System.Windows.Forms.DataGridView();
            this.lblChangeAllClass = new System.Windows.Forms.Label();
            this.btnMoveLeft = new System.Windows.Forms.Button();
            this.btnMoveRight = new System.Windows.Forms.Button();
            this.ddlSelectAllClass = new System.Windows.Forms.ComboBox();
            this.ddlFromAcademicYear = new System.Windows.Forms.ComboBox();
            this.lblAcademicYear = new System.Windows.Forms.Label();
            this.groupBoxSearch = new System.Windows.Forms.GroupBox();
            this.ddlToAcademicYear = new System.Windows.Forms.ComboBox();
            this.groupBoxSave = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.colSelectT = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colHistoryRegistrationNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHistoryStudentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHistoryFromClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHistoryFromSection = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDDLClass = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colDDLSection = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colHdnFromClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHdnFromSection = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPromotionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHiddenPromotedStudenID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxPromote.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridStudent)).BeginInit();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridStudentPromotionHistory)).BeginInit();
            this.groupBoxSearch.SuspendLayout();
            this.groupBoxSave.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(573, 18);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(55, 24);
            this.btnSearch.TabIndex = 132;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // ddlClass
            // 
            this.ddlClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlClass.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.ddlClass.FormattingEnabled = true;
            this.ddlClass.ItemHeight = 13;
            this.ddlClass.Location = new System.Drawing.Point(306, 18);
            this.ddlClass.Name = "ddlClass";
            this.ddlClass.Size = new System.Drawing.Size(87, 21);
            this.ddlClass.TabIndex = 128;
            // 
            // ddlSection
            // 
            this.ddlSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlSection.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.ddlSection.FormattingEnabled = true;
            this.ddlSection.Location = new System.Drawing.Point(485, 18);
            this.ddlSection.Name = "ddlSection";
            this.ddlSection.Size = new System.Drawing.Size(71, 21);
            this.ddlSection.TabIndex = 129;
            // 
            // lblCurrentSection
            // 
            this.lblCurrentSection.AutoSize = true;
            this.lblCurrentSection.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.lblCurrentSection.Location = new System.Drawing.Point(398, 22);
            this.lblCurrentSection.Name = "lblCurrentSection";
            this.lblCurrentSection.Size = new System.Drawing.Size(80, 13);
            this.lblCurrentSection.TabIndex = 131;
            this.lblCurrentSection.Text = "From Section :";
            // 
            // lblCurrentClass
            // 
            this.lblCurrentClass.AutoSize = true;
            this.lblCurrentClass.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.lblCurrentClass.Location = new System.Drawing.Point(236, 22);
            this.lblCurrentClass.Name = "lblCurrentClass";
            this.lblCurrentClass.Size = new System.Drawing.Size(69, 13);
            this.lblCurrentClass.TabIndex = 130;
            this.lblCurrentClass.Text = "From Class :";
            // 
            // groupBoxPromote
            // 
            this.groupBoxPromote.Controls.Add(this.gridStudent);
            this.groupBoxPromote.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.groupBoxPromote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(46)))), ((int)(((byte)(75)))));
            this.groupBoxPromote.Location = new System.Drawing.Point(12, 75);
            this.groupBoxPromote.Name = "groupBoxPromote";
            this.groupBoxPromote.Size = new System.Drawing.Size(301, 522);
            this.groupBoxPromote.TabIndex = 0;
            this.groupBoxPromote.TabStop = false;
            this.groupBoxPromote.Text = "Student";
            // 
            // gridStudent
            // 
            this.gridStudent.AllowUserToAddRows = false;
            this.gridStudent.AllowUserToDeleteRows = false;
            this.gridStudent.AllowUserToResizeColumns = false;
            this.gridStudent.AllowUserToResizeRows = false;
            this.gridStudent.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridStudent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridStudent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelect,
            this.colRegistrationNo,
            this.colStudentName,
            this.colCurrentClass,
            this.colSection,
            this.colHiddenClassID,
            this.colHiddenSectionID,
            this.colHiddenStudentID,
            this.colStudentPromotionID});
            this.gridStudent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridStudent.Location = new System.Drawing.Point(3, 18);
            this.gridStudent.Name = "gridStudent";
            this.gridStudent.RowHeadersVisible = false;
            this.gridStudent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridStudent.Size = new System.Drawing.Size(295, 501);
            this.gridStudent.TabIndex = 24;
            // 
            // colSelect
            // 
            this.colSelect.HeaderText = "Select";
            this.colSelect.Name = "colSelect";
            this.colSelect.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colSelect.Width = 45;
            // 
            // colRegistrationNo
            // 
            this.colRegistrationNo.HeaderText = "Registration";
            this.colRegistrationNo.Name = "colRegistrationNo";
            this.colRegistrationNo.ReadOnly = true;
            this.colRegistrationNo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colRegistrationNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colRegistrationNo.Width = 80;
            // 
            // colStudentName
            // 
            this.colStudentName.FillWeight = 80F;
            this.colStudentName.HeaderText = "Student Name";
            this.colStudentName.Name = "colStudentName";
            this.colStudentName.ReadOnly = true;
            this.colStudentName.Width = 160;
            // 
            // colCurrentClass
            // 
            this.colCurrentClass.HeaderText = "Class";
            this.colCurrentClass.Name = "colCurrentClass";
            this.colCurrentClass.ReadOnly = true;
            this.colCurrentClass.Visible = false;
            this.colCurrentClass.Width = 60;
            // 
            // colSection
            // 
            this.colSection.HeaderText = "Section";
            this.colSection.Name = "colSection";
            this.colSection.ReadOnly = true;
            this.colSection.Visible = false;
            this.colSection.Width = 60;
            // 
            // colHiddenClassID
            // 
            this.colHiddenClassID.HeaderText = "colHiddenClassID";
            this.colHiddenClassID.Name = "colHiddenClassID";
            this.colHiddenClassID.Visible = false;
            // 
            // colHiddenSectionID
            // 
            this.colHiddenSectionID.HeaderText = "colHiddenSectionID";
            this.colHiddenSectionID.Name = "colHiddenSectionID";
            this.colHiddenSectionID.Visible = false;
            // 
            // colHiddenStudentID
            // 
            this.colHiddenStudentID.HeaderText = "colHiddenStudentID";
            this.colHiddenStudentID.Name = "colHiddenStudentID";
            this.colHiddenStudentID.Visible = false;
            // 
            // colStudentPromotionID
            // 
            this.colStudentPromotionID.HeaderText = "colStudentPromotionID";
            this.colStudentPromotionID.Name = "colStudentPromotionID";
            this.colStudentPromotionID.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(216, 18);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(44, 23);
            this.btnSave.TabIndex = 133;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.gridStudentPromotionHistory);
            this.groupBox.Controls.Add(this.lblChangeAllClass);
            this.groupBox.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.groupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(46)))), ((int)(((byte)(75)))));
            this.groupBox.Location = new System.Drawing.Point(369, 75);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(641, 525);
            this.groupBox.TabIndex = 136;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Promoted Student";
            // 
            // gridStudentPromotionHistory
            // 
            this.gridStudentPromotionHistory.AllowUserToAddRows = false;
            this.gridStudentPromotionHistory.AllowUserToDeleteRows = false;
            this.gridStudentPromotionHistory.AllowUserToResizeColumns = false;
            this.gridStudentPromotionHistory.AllowUserToResizeRows = false;
            this.gridStudentPromotionHistory.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridStudentPromotionHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridStudentPromotionHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelectT,
            this.colHistoryRegistrationNo,
            this.colHistoryStudentName,
            this.colHistoryFromClass,
            this.colHistoryFromSection,
            this.colDDLClass,
            this.colDDLSection,
            this.colDelete,
            this.colHdnFromClass,
            this.colHdnFromSection,
            this.colPromotionID,
            this.colHiddenPromotedStudenID});
            this.gridStudentPromotionHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridStudentPromotionHistory.Location = new System.Drawing.Point(3, 18);
            this.gridStudentPromotionHistory.Name = "gridStudentPromotionHistory";
            this.gridStudentPromotionHistory.RowHeadersVisible = false;
            this.gridStudentPromotionHistory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridStudentPromotionHistory.Size = new System.Drawing.Size(635, 504);
            this.gridStudentPromotionHistory.TabIndex = 24;
            this.gridStudentPromotionHistory.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridStudentPromotionHistory_CellContentClick);
            // 
            // lblChangeAllClass
            // 
            this.lblChangeAllClass.AutoSize = true;
            this.lblChangeAllClass.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.lblChangeAllClass.Location = new System.Drawing.Point(331, 0);
            this.lblChangeAllClass.Name = "lblChangeAllClass";
            this.lblChangeAllClass.Size = new System.Drawing.Size(96, 13);
            this.lblChangeAllClass.TabIndex = 161;
            this.lblChangeAllClass.Text = "Change All Class :";
            // 
            // btnMoveLeft
            // 
            this.btnMoveLeft.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveLeft.Location = new System.Drawing.Point(320, 292);
            this.btnMoveLeft.Name = "btnMoveLeft";
            this.btnMoveLeft.Size = new System.Drawing.Size(43, 26);
            this.btnMoveLeft.TabIndex = 156;
            this.btnMoveLeft.Text = "<<";
            this.btnMoveLeft.UseVisualStyleBackColor = true;
            this.btnMoveLeft.Click += new System.EventHandler(this.btnMoveLeft_Click);
            // 
            // btnMoveRight
            // 
            this.btnMoveRight.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveRight.Location = new System.Drawing.Point(320, 258);
            this.btnMoveRight.Name = "btnMoveRight";
            this.btnMoveRight.Size = new System.Drawing.Size(43, 26);
            this.btnMoveRight.TabIndex = 155;
            this.btnMoveRight.Text = ">>";
            this.btnMoveRight.UseVisualStyleBackColor = true;
            this.btnMoveRight.Click += new System.EventHandler(this.btnMoveRight_Click);
            // 
            // ddlSelectAllClass
            // 
            this.ddlSelectAllClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlSelectAllClass.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.ddlSelectAllClass.FormattingEnabled = true;
            this.ddlSelectAllClass.ItemHeight = 13;
            this.ddlSelectAllClass.Location = new System.Drawing.Point(798, 72);
            this.ddlSelectAllClass.Name = "ddlSelectAllClass";
            this.ddlSelectAllClass.Size = new System.Drawing.Size(66, 21);
            this.ddlSelectAllClass.TabIndex = 160;
            this.ddlSelectAllClass.SelectedIndexChanged += new System.EventHandler(this.ddlSelectAllClass_SelectedIndexChanged);
            // 
            // ddlFromAcademicYear
            // 
            this.ddlFromAcademicYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlFromAcademicYear.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.ddlFromAcademicYear.FormattingEnabled = true;
            this.ddlFromAcademicYear.Location = new System.Drawing.Point(126, 18);
            this.ddlFromAcademicYear.Name = "ddlFromAcademicYear";
            this.ddlFromAcademicYear.Size = new System.Drawing.Size(102, 21);
            this.ddlFromAcademicYear.TabIndex = 163;
            // 
            // lblAcademicYear
            // 
            this.lblAcademicYear.AutoSize = true;
            this.lblAcademicYear.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.lblAcademicYear.Location = new System.Drawing.Point(4, 23);
            this.lblAcademicYear.Name = "lblAcademicYear";
            this.lblAcademicYear.Size = new System.Drawing.Size(116, 13);
            this.lblAcademicYear.TabIndex = 162;
            this.lblAcademicYear.Text = "From Academic Year :";
            // 
            // groupBoxSearch
            // 
            this.groupBoxSearch.Controls.Add(this.lblAcademicYear);
            this.groupBoxSearch.Controls.Add(this.ddlClass);
            this.groupBoxSearch.Controls.Add(this.btnSearch);
            this.groupBoxSearch.Controls.Add(this.lblCurrentClass);
            this.groupBoxSearch.Controls.Add(this.ddlFromAcademicYear);
            this.groupBoxSearch.Controls.Add(this.lblCurrentSection);
            this.groupBoxSearch.Controls.Add(this.ddlSection);
            this.groupBoxSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.groupBoxSearch.Location = new System.Drawing.Point(12, 7);
            this.groupBoxSearch.Name = "groupBoxSearch";
            this.groupBoxSearch.Size = new System.Drawing.Size(637, 52);
            this.groupBoxSearch.TabIndex = 164;
            this.groupBoxSearch.TabStop = false;
            // 
            // ddlToAcademicYear
            // 
            this.ddlToAcademicYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlToAcademicYear.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.ddlToAcademicYear.FormattingEnabled = true;
            this.ddlToAcademicYear.Location = new System.Drawing.Point(108, 19);
            this.ddlToAcademicYear.Name = "ddlToAcademicYear";
            this.ddlToAcademicYear.Size = new System.Drawing.Size(102, 21);
            this.ddlToAcademicYear.TabIndex = 165;
            // 
            // groupBoxSave
            // 
            this.groupBoxSave.Controls.Add(this.label1);
            this.groupBoxSave.Controls.Add(this.ddlToAcademicYear);
            this.groupBoxSave.Controls.Add(this.btnSave);
            this.groupBoxSave.Location = new System.Drawing.Point(742, 7);
            this.groupBoxSave.Name = "groupBoxSave";
            this.groupBoxSave.Size = new System.Drawing.Size(268, 52);
            this.groupBoxSave.TabIndex = 166;
            this.groupBoxSave.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(5, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 163;
            this.label1.Text = "To Academic Year :";
            // 
            // colSelectT
            // 
            this.colSelectT.HeaderText = "Select";
            this.colSelectT.Name = "colSelectT";
            this.colSelectT.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colSelectT.Width = 45;
            // 
            // colHistoryRegistrationNo
            // 
            this.colHistoryRegistrationNo.HeaderText = "Registration";
            this.colHistoryRegistrationNo.Name = "colHistoryRegistrationNo";
            this.colHistoryRegistrationNo.ReadOnly = true;
            this.colHistoryRegistrationNo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colHistoryRegistrationNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colHistoryRegistrationNo.Width = 80;
            // 
            // colHistoryStudentName
            // 
            this.colHistoryStudentName.HeaderText = "Student Name";
            this.colHistoryStudentName.Name = "colHistoryStudentName";
            this.colHistoryStudentName.ReadOnly = true;
            this.colHistoryStudentName.Width = 160;
            // 
            // colHistoryFromClass
            // 
            this.colHistoryFromClass.HeaderText = "From Class";
            this.colHistoryFromClass.Name = "colHistoryFromClass";
            this.colHistoryFromClass.ReadOnly = true;
            this.colHistoryFromClass.Width = 70;
            // 
            // colHistoryFromSection
            // 
            this.colHistoryFromSection.HeaderText = "From SEC";
            this.colHistoryFromSection.Name = "colHistoryFromSection";
            this.colHistoryFromSection.ReadOnly = true;
            this.colHistoryFromSection.ToolTipText = "From Section";
            this.colHistoryFromSection.Width = 70;
            // 
            // colDDLClass
            // 
            this.colDDLClass.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colDDLClass.HeaderText = "To Class";
            this.colDDLClass.Name = "colDDLClass";
            this.colDDLClass.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDDLClass.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colDDLClass.Width = 65;
            // 
            // colDDLSection
            // 
            this.colDDLSection.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colDDLSection.HeaderText = "To Section";
            this.colDDLSection.Name = "colDDLSection";
            this.colDDLSection.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDDLSection.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colDDLSection.ToolTipText = "To Section";
            this.colDDLSection.Width = 70;
            // 
            // colDelete
            // 
            this.colDelete.HeaderText = "Delete";
            this.colDelete.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.colDelete.Name = "colDelete";
            this.colDelete.Text = "Delete";
            this.colDelete.ToolTipText = "Delete";
            this.colDelete.Width = 50;
            // 
            // colHdnFromClass
            // 
            this.colHdnFromClass.HeaderText = "colHdnFromClass";
            this.colHdnFromClass.Name = "colHdnFromClass";
            this.colHdnFromClass.Visible = false;
            // 
            // colHdnFromSection
            // 
            this.colHdnFromSection.HeaderText = "colHdnFromSection";
            this.colHdnFromSection.Name = "colHdnFromSection";
            this.colHdnFromSection.Visible = false;
            // 
            // colPromotionID
            // 
            this.colPromotionID.HeaderText = "colPromotionID";
            this.colPromotionID.Name = "colPromotionID";
            this.colPromotionID.Visible = false;
            // 
            // colHiddenPromotedStudenID
            // 
            this.colHiddenPromotedStudenID.HeaderText = "colHiddenPromotedStudenID";
            this.colHiddenPromotedStudenID.Name = "colHiddenPromotedStudenID";
            this.colHiddenPromotedStudenID.Visible = false;
            // 
            // StudentPromotionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1191, 612);
            this.Controls.Add(this.groupBoxSave);
            this.Controls.Add(this.ddlSelectAllClass);
            this.Controls.Add(this.groupBoxSearch);
            this.Controls.Add(this.btnMoveLeft);
            this.Controls.Add(this.btnMoveRight);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.groupBoxPromote);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(46)))), ((int)(((byte)(75)))));
            this.Name = "StudentPromotionForm";
            this.Text = "Promote Student";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StudentPromotionForm_FormClosing);
            this.groupBoxPromote.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridStudent)).EndInit();
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridStudentPromotionHistory)).EndInit();
            this.groupBoxSearch.ResumeLayout(false);
            this.groupBoxSearch.PerformLayout();
            this.groupBoxSave.ResumeLayout(false);
            this.groupBoxSave.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox ddlClass;
        private System.Windows.Forms.ComboBox ddlSection;
        private System.Windows.Forms.Label lblCurrentSection;
        private System.Windows.Forms.Label lblCurrentClass;
        private System.Windows.Forms.GroupBox groupBoxPromote;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView gridStudent;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.DataGridView gridStudentPromotionHistory;
        private System.Windows.Forms.Button btnMoveLeft;
        private System.Windows.Forms.Button btnMoveRight;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRegistrationNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStudentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCurrentClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSection;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHiddenClassID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHiddenSectionID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHiddenStudentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStudentPromotionID;
        private System.Windows.Forms.ComboBox ddlSelectAllClass;
        private System.Windows.Forms.Label lblChangeAllClass;
        private System.Windows.Forms.ComboBox ddlFromAcademicYear;
        private System.Windows.Forms.Label lblAcademicYear;
        private System.Windows.Forms.GroupBox groupBoxSearch;
        private System.Windows.Forms.ComboBox ddlToAcademicYear;
        private System.Windows.Forms.GroupBox groupBoxSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelectT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHistoryRegistrationNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHistoryStudentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHistoryFromClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHistoryFromSection;
        private System.Windows.Forms.DataGridViewComboBoxColumn colDDLClass;
        private System.Windows.Forms.DataGridViewComboBoxColumn colDDLSection;
        private System.Windows.Forms.DataGridViewLinkColumn colDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHdnFromClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHdnFromSection;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPromotionID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHiddenPromotedStudenID;
    }
}