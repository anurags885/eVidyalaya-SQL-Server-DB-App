namespace eVidyalaya
{
    partial class FeeSettingForm
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
            System.Windows.Forms.GroupBox groupBox;
            this.btnAddRows = new System.Windows.Forms.Button();
            this.ddlAcademicYear = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblAcademicYear = new System.Windows.Forms.Label();
            this.gridFeeSetting = new System.Windows.Forms.DataGridView();
            this.colFeeSettingID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFeeType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colApr = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colMay = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colJun = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colJul = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colAug = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colSep = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colOct = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colNov = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDec = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colJan = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colFeb = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colMar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colOneTime = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.lblShortCutKeys = new System.Windows.Forms.Label();
            groupBox = new System.Windows.Forms.GroupBox();
            groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFeeSetting)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            groupBox.Controls.Add(this.btnAddRows);
            groupBox.Controls.Add(this.ddlAcademicYear);
            groupBox.Controls.Add(this.btnSave);
            groupBox.Controls.Add(this.lblAcademicYear);
            groupBox.Location = new System.Drawing.Point(8, 8);
            groupBox.Name = "groupBox";
            groupBox.Size = new System.Drawing.Size(810, 47);
            groupBox.TabIndex = 148;
            groupBox.TabStop = false;
            // 
            // btnAddRows
            // 
            this.btnAddRows.Location = new System.Drawing.Point(666, 16);
            this.btnAddRows.Name = "btnAddRows";
            this.btnAddRows.Size = new System.Drawing.Size(69, 25);
            this.btnAddRows.TabIndex = 142;
            this.btnAddRows.Text = "Add Row\r\n";
            this.btnAddRows.UseVisualStyleBackColor = true;
            this.btnAddRows.Click += new System.EventHandler(this.btnAddRows_Click);
            // 
            // ddlAcademicYear
            // 
            this.ddlAcademicYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlAcademicYear.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.ddlAcademicYear.FormattingEnabled = true;
            this.ddlAcademicYear.Location = new System.Drawing.Point(101, 16);
            this.ddlAcademicYear.Name = "ddlAcademicYear";
            this.ddlAcademicYear.Size = new System.Drawing.Size(101, 21);
            this.ddlAcademicYear.TabIndex = 147;
            this.ddlAcademicYear.SelectedIndexChanged += new System.EventHandler(this.ddlAcademicYear_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(741, 16);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(65, 25);
            this.btnSave.TabIndex = 143;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblAcademicYear
            // 
            this.lblAcademicYear.AutoSize = true;
            this.lblAcademicYear.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAcademicYear.Location = new System.Drawing.Point(4, 20);
            this.lblAcademicYear.Name = "lblAcademicYear";
            this.lblAcademicYear.Size = new System.Drawing.Size(91, 15);
            this.lblAcademicYear.TabIndex = 146;
            this.lblAcademicYear.Text = "Academic Year :";
            // 
            // gridFeeSetting
            // 
            this.gridFeeSetting.AllowUserToAddRows = false;
            this.gridFeeSetting.AllowUserToDeleteRows = false;
            this.gridFeeSetting.AllowUserToResizeRows = false;
            this.gridFeeSetting.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridFeeSetting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridFeeSetting.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFeeSettingID,
            this.colFeeType,
            this.colApr,
            this.colMay,
            this.colJun,
            this.colJul,
            this.colAug,
            this.colSep,
            this.colOct,
            this.colNov,
            this.colDec,
            this.colJan,
            this.colFeb,
            this.colMar,
            this.colOneTime,
            this.colDelete});
            this.gridFeeSetting.Location = new System.Drawing.Point(8, 65);
            this.gridFeeSetting.Name = "gridFeeSetting";
            this.gridFeeSetting.RowHeadersVisible = false;
            this.gridFeeSetting.RowTemplate.Height = 27;
            this.gridFeeSetting.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridFeeSetting.Size = new System.Drawing.Size(810, 543);
            this.gridFeeSetting.TabIndex = 135;
            this.gridFeeSetting.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridFeeSetting_CellContentClick);
            // 
            // colFeeSettingID
            // 
            this.colFeeSettingID.HeaderText = "FeeSettingID";
            this.colFeeSettingID.Name = "colFeeSettingID";
            this.colFeeSettingID.Visible = false;
            // 
            // colFeeType
            // 
            this.colFeeType.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colFeeType.FillWeight = 363.1648F;
            this.colFeeType.HeaderText = "Fee Type";
            this.colFeeType.Name = "colFeeType";
            this.colFeeType.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colFeeType.Width = 200;
            // 
            // colApr
            // 
            this.colApr.FillWeight = 66.49117F;
            this.colApr.HeaderText = "Apr";
            this.colApr.Name = "colApr";
            this.colApr.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colApr.Width = 37;
            // 
            // colMay
            // 
            this.colMay.FillWeight = 68.62225F;
            this.colMay.HeaderText = "May";
            this.colMay.Name = "colMay";
            this.colMay.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colMay.Width = 38;
            // 
            // colJun
            // 
            this.colJun.FillWeight = 70.64277F;
            this.colJun.HeaderText = "Jun";
            this.colJun.Name = "colJun";
            this.colJun.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colJun.Width = 38;
            // 
            // colJul
            // 
            this.colJul.FillWeight = 72.55846F;
            this.colJul.HeaderText = "Jul";
            this.colJul.Name = "colJul";
            this.colJul.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colJul.Width = 40;
            // 
            // colAug
            // 
            this.colAug.FillWeight = 74.37476F;
            this.colAug.HeaderText = "Aug";
            this.colAug.Name = "colAug";
            this.colAug.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colAug.Width = 41;
            // 
            // colSep
            // 
            this.colSep.FillWeight = 76.09682F;
            this.colSep.HeaderText = "Sep";
            this.colSep.Name = "colSep";
            this.colSep.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colSep.Width = 42;
            // 
            // colOct
            // 
            this.colOct.FillWeight = 77.72956F;
            this.colOct.HeaderText = "Oct";
            this.colOct.Name = "colOct";
            this.colOct.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colOct.Width = 43;
            // 
            // colNov
            // 
            this.colNov.FillWeight = 79.27758F;
            this.colNov.HeaderText = "Nov";
            this.colNov.Name = "colNov";
            this.colNov.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colNov.Width = 44;
            // 
            // colDec
            // 
            this.colDec.FillWeight = 80.74528F;
            this.colDec.HeaderText = "Dec";
            this.colDec.Name = "colDec";
            this.colDec.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colDec.Width = 44;
            // 
            // colJan
            // 
            this.colJan.FillWeight = 59.37239F;
            this.colJan.HeaderText = "Jan";
            this.colJan.Name = "colJan";
            this.colJan.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colJan.Width = 33;
            // 
            // colFeb
            // 
            this.colFeb.FillWeight = 61.8728F;
            this.colFeb.HeaderText = "Feb";
            this.colFeb.Name = "colFeb";
            this.colFeb.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colFeb.Width = 34;
            // 
            // colMar
            // 
            this.colMar.FillWeight = 64.24348F;
            this.colMar.HeaderText = "Mar";
            this.colMar.Name = "colMar";
            this.colMar.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colMar.Width = 35;
            // 
            // colOneTime
            // 
            this.colOneTime.FillWeight = 184.8079F;
            this.colOneTime.HeaderText = "Admission Time";
            this.colOneTime.Name = "colOneTime";
            this.colOneTime.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colOneTime.Width = 102;
            // 
            // colDelete
            // 
            this.colDelete.HeaderText = "x";
            this.colDelete.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.colDelete.Name = "colDelete";
            this.colDelete.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colDelete.ToolTipText = "Remove Blank Rows";
            this.colDelete.Width = 30;
            // 
            // lblShortCutKeys
            // 
            this.lblShortCutKeys.AutoSize = true;
            this.lblShortCutKeys.Location = new System.Drawing.Point(828, 46);
            this.lblShortCutKeys.Name = "lblShortCutKeys";
            this.lblShortCutKeys.Size = new System.Drawing.Size(91, 15);
            this.lblShortCutKeys.TabIndex = 145;
            this.lblShortCutKeys.Text = "lblShortCutKeys";
            // 
            // FeeSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1015, 613);
            this.Controls.Add(groupBox);
            this.Controls.Add(this.lblShortCutKeys);
            this.Controls.Add(this.gridFeeSetting);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(54)))), ((int)(((byte)(92)))));
            this.Name = "FeeSettingForm";
            this.Text = "Fee Setting";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FeeSettingForm_FormClosing);
            this.Load += new System.EventHandler(this.FeeSetting_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FeeSettingForm_KeyDown);
            groupBox.ResumeLayout(false);
            groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFeeSetting)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridFeeSetting;
        private System.Windows.Forms.Label lblShortCutKeys;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAddRows;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFeeSettingID;
        private System.Windows.Forms.DataGridViewComboBoxColumn colFeeType;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colApr;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colMay;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colJun;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colJul;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colAug;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSep;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colOct;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colNov;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colDec;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colJan;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colFeb;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colMar;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colOneTime;
        private System.Windows.Forms.DataGridViewLinkColumn colDelete;
        private System.Windows.Forms.ComboBox ddlAcademicYear;
        private System.Windows.Forms.Label lblAcademicYear;
    }
}