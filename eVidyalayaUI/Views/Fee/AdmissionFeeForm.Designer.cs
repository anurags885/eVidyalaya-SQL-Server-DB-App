namespace eVidyalaya
{
    partial class AdmissionFeeForm
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
            this.gridAdmissionFeeType = new System.Windows.Forms.DataGridView();
            this.colSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colFeeTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFeeType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMonthNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReceiptNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSequenceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupFee = new System.Windows.Forms.GroupBox();
            this.panelMonths = new System.Windows.Forms.Panel();
            this.chkMarch = new System.Windows.Forms.CheckBox();
            this.chkFebruary = new System.Windows.Forms.CheckBox();
            this.chkJanuary = new System.Windows.Forms.CheckBox();
            this.chkDecember = new System.Windows.Forms.CheckBox();
            this.chkNovember = new System.Windows.Forms.CheckBox();
            this.chkOctober = new System.Windows.Forms.CheckBox();
            this.chkSeptember = new System.Windows.Forms.CheckBox();
            this.chkAugust = new System.Windows.Forms.CheckBox();
            this.chkJuly = new System.Windows.Forms.CheckBox();
            this.chkJune = new System.Windows.Forms.CheckBox();
            this.chkMay = new System.Windows.Forms.CheckBox();
            this.chkApril = new System.Windows.Forms.CheckBox();
            this.btnCalculateFee = new System.Windows.Forms.Button();
            this.lblMonths = new System.Windows.Forms.Label();
            this.ddlAcademicYear = new System.Windows.Forms.ComboBox();
            this.lblAcademicYear = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.lblTotalFeeAmount = new System.Windows.Forms.Label();
            this.lblTotalFeeAmountValue = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.txtMaskedDate = new System.Windows.Forms.MaskedTextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAdmissionFeeType)).BeginInit();
            this.groupFee.SuspendLayout();
            this.panelMonths.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gridAdmissionFeeType);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(54)))), ((int)(((byte)(92)))));
            this.groupBox1.Location = new System.Drawing.Point(6, 142);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(546, 292);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // gridAdmissionFeeType
            // 
            this.gridAdmissionFeeType.AllowUserToAddRows = false;
            this.gridAdmissionFeeType.AllowUserToDeleteRows = false;
            this.gridAdmissionFeeType.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridAdmissionFeeType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridAdmissionFeeType.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelect,
            this.colFeeTypeID,
            this.colFeeType,
            this.colAmount,
            this.colMonthNo,
            this.colTotalAmount,
            this.colReceiptNo,
            this.colSequenceID});
            this.gridAdmissionFeeType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAdmissionFeeType.Location = new System.Drawing.Point(3, 18);
            this.gridAdmissionFeeType.Name = "gridAdmissionFeeType";
            this.gridAdmissionFeeType.RowHeadersVisible = false;
            this.gridAdmissionFeeType.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridAdmissionFeeType.Size = new System.Drawing.Size(540, 271);
            this.gridAdmissionFeeType.TabIndex = 6;
            this.gridAdmissionFeeType.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridAdmissionFeeType_CellContentClick);
            this.gridAdmissionFeeType.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridAdmissionFeeType_CellEnter);
            this.gridAdmissionFeeType.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridAdmissionFeeType_CellLeave);
            this.gridAdmissionFeeType.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.gridAdmissionFeeType_CellValidating);
            this.gridAdmissionFeeType.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.gridAdmissionFeeType_EditingControlShowing);
            // 
            // colSelect
            // 
            this.colSelect.HeaderText = "Select";
            this.colSelect.Name = "colSelect";
            this.colSelect.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colSelect.Width = 45;
            // 
            // colFeeTypeID
            // 
            this.colFeeTypeID.HeaderText = "FeeTypeID";
            this.colFeeTypeID.Name = "colFeeTypeID";
            this.colFeeTypeID.ReadOnly = true;
            this.colFeeTypeID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colFeeTypeID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colFeeTypeID.Visible = false;
            // 
            // colFeeType
            // 
            this.colFeeType.HeaderText = "Fee Type";
            this.colFeeType.Name = "colFeeType";
            this.colFeeType.ReadOnly = true;
            this.colFeeType.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colFeeType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colFeeType.Width = 185;
            // 
            // colAmount
            // 
            this.colAmount.HeaderText = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colAmount.Width = 70;
            // 
            // colMonthNo
            // 
            this.colMonthNo.HeaderText = "Number of Months";
            this.colMonthNo.Name = "colMonthNo";
            this.colMonthNo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colMonthNo.Width = 120;
            // 
            // colTotalAmount
            // 
            this.colTotalAmount.HeaderText = "TotalAmount";
            this.colTotalAmount.Name = "colTotalAmount";
            this.colTotalAmount.ReadOnly = true;
            this.colTotalAmount.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colReceiptNo
            // 
            this.colReceiptNo.HeaderText = "colReceiptNo";
            this.colReceiptNo.Name = "colReceiptNo";
            this.colReceiptNo.Visible = false;
            // 
            // colSequenceID
            // 
            this.colSequenceID.HeaderText = "colSequenceID";
            this.colSequenceID.Name = "colSequenceID";
            this.colSequenceID.Visible = false;
            // 
            // groupFee
            // 
            this.groupFee.Controls.Add(this.txtMaskedDate);
            this.groupFee.Controls.Add(this.lblDate);
            this.groupFee.Controls.Add(this.panelMonths);
            this.groupFee.Controls.Add(this.btnCalculateFee);
            this.groupFee.Controls.Add(this.lblMonths);
            this.groupFee.Controls.Add(this.ddlAcademicYear);
            this.groupFee.Controls.Add(this.lblAcademicYear);
            this.groupFee.Location = new System.Drawing.Point(6, 2);
            this.groupFee.Name = "groupFee";
            this.groupFee.Size = new System.Drawing.Size(546, 141);
            this.groupFee.TabIndex = 3;
            this.groupFee.TabStop = false;
            // 
            // panelMonths
            // 
            this.panelMonths.BackColor = System.Drawing.Color.White;
            this.panelMonths.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMonths.Controls.Add(this.chkMarch);
            this.panelMonths.Controls.Add(this.chkFebruary);
            this.panelMonths.Controls.Add(this.chkJanuary);
            this.panelMonths.Controls.Add(this.chkDecember);
            this.panelMonths.Controls.Add(this.chkNovember);
            this.panelMonths.Controls.Add(this.chkOctober);
            this.panelMonths.Controls.Add(this.chkSeptember);
            this.panelMonths.Controls.Add(this.chkAugust);
            this.panelMonths.Controls.Add(this.chkJuly);
            this.panelMonths.Controls.Add(this.chkJune);
            this.panelMonths.Controls.Add(this.chkMay);
            this.panelMonths.Controls.Add(this.chkApril);
            this.panelMonths.Enabled = false;
            this.panelMonths.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelMonths.Location = new System.Drawing.Point(3, 64);
            this.panelMonths.Name = "panelMonths";
            this.panelMonths.Size = new System.Drawing.Size(440, 71);
            this.panelMonths.TabIndex = 7;
            // 
            // chkMarch
            // 
            this.chkMarch.AutoSize = true;
            this.chkMarch.Location = new System.Drawing.Point(336, 49);
            this.chkMarch.Name = "chkMarch";
            this.chkMarch.Size = new System.Drawing.Size(60, 19);
            this.chkMarch.TabIndex = 8;
            this.chkMarch.Text = "March";
            this.chkMarch.UseVisualStyleBackColor = true;
            // 
            // chkFebruary
            // 
            this.chkFebruary.AutoSize = true;
            this.chkFebruary.Location = new System.Drawing.Point(229, 49);
            this.chkFebruary.Name = "chkFebruary";
            this.chkFebruary.Size = new System.Drawing.Size(72, 19);
            this.chkFebruary.TabIndex = 8;
            this.chkFebruary.Text = "February";
            this.chkFebruary.UseVisualStyleBackColor = true;
            // 
            // chkJanuary
            // 
            this.chkJanuary.AutoSize = true;
            this.chkJanuary.Location = new System.Drawing.Point(111, 49);
            this.chkJanuary.Name = "chkJanuary";
            this.chkJanuary.Size = new System.Drawing.Size(67, 19);
            this.chkJanuary.TabIndex = 8;
            this.chkJanuary.Text = "January";
            this.chkJanuary.UseVisualStyleBackColor = true;
            // 
            // chkDecember
            // 
            this.chkDecember.AutoSize = true;
            this.chkDecember.Location = new System.Drawing.Point(8, 49);
            this.chkDecember.Name = "chkDecember";
            this.chkDecember.Size = new System.Drawing.Size(81, 19);
            this.chkDecember.TabIndex = 9;
            this.chkDecember.Text = "December";
            this.chkDecember.UseVisualStyleBackColor = true;
            // 
            // chkNovember
            // 
            this.chkNovember.AutoSize = true;
            this.chkNovember.Location = new System.Drawing.Point(336, 26);
            this.chkNovember.Name = "chkNovember";
            this.chkNovember.Size = new System.Drawing.Size(82, 19);
            this.chkNovember.TabIndex = 8;
            this.chkNovember.Text = "November";
            this.chkNovember.UseVisualStyleBackColor = true;
            // 
            // chkOctober
            // 
            this.chkOctober.AutoSize = true;
            this.chkOctober.Location = new System.Drawing.Point(229, 26);
            this.chkOctober.Name = "chkOctober";
            this.chkOctober.Size = new System.Drawing.Size(69, 19);
            this.chkOctober.TabIndex = 8;
            this.chkOctober.Text = "October";
            this.chkOctober.UseVisualStyleBackColor = true;
            // 
            // chkSeptember
            // 
            this.chkSeptember.AutoSize = true;
            this.chkSeptember.Location = new System.Drawing.Point(111, 26);
            this.chkSeptember.Name = "chkSeptember";
            this.chkSeptember.Size = new System.Drawing.Size(84, 19);
            this.chkSeptember.TabIndex = 8;
            this.chkSeptember.Text = "September";
            this.chkSeptember.UseVisualStyleBackColor = true;
            // 
            // chkAugust
            // 
            this.chkAugust.AutoSize = true;
            this.chkAugust.Location = new System.Drawing.Point(8, 26);
            this.chkAugust.Name = "chkAugust";
            this.chkAugust.Size = new System.Drawing.Size(64, 19);
            this.chkAugust.TabIndex = 8;
            this.chkAugust.Text = "August";
            this.chkAugust.UseVisualStyleBackColor = true;
            // 
            // chkJuly
            // 
            this.chkJuly.AutoSize = true;
            this.chkJuly.Location = new System.Drawing.Point(336, 3);
            this.chkJuly.Name = "chkJuly";
            this.chkJuly.Size = new System.Drawing.Size(47, 19);
            this.chkJuly.TabIndex = 8;
            this.chkJuly.Text = "July";
            this.chkJuly.UseVisualStyleBackColor = true;
            // 
            // chkJune
            // 
            this.chkJune.AutoSize = true;
            this.chkJune.Location = new System.Drawing.Point(229, 3);
            this.chkJune.Name = "chkJune";
            this.chkJune.Size = new System.Drawing.Size(51, 19);
            this.chkJune.TabIndex = 8;
            this.chkJune.Text = "June";
            this.chkJune.UseVisualStyleBackColor = true;
            // 
            // chkMay
            // 
            this.chkMay.AutoSize = true;
            this.chkMay.Location = new System.Drawing.Point(111, 3);
            this.chkMay.Name = "chkMay";
            this.chkMay.Size = new System.Drawing.Size(49, 19);
            this.chkMay.TabIndex = 1;
            this.chkMay.Text = "May";
            this.chkMay.UseVisualStyleBackColor = true;
            // 
            // chkApril
            // 
            this.chkApril.AutoSize = true;
            this.chkApril.Location = new System.Drawing.Point(8, 3);
            this.chkApril.Name = "chkApril";
            this.chkApril.Size = new System.Drawing.Size(51, 19);
            this.chkApril.TabIndex = 0;
            this.chkApril.Text = "April";
            this.chkApril.UseVisualStyleBackColor = true;
            // 
            // btnCalculateFee
            // 
            this.btnCalculateFee.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.btnCalculateFee.Location = new System.Drawing.Point(452, 112);
            this.btnCalculateFee.Name = "btnCalculateFee";
            this.btnCalculateFee.Size = new System.Drawing.Size(91, 22);
            this.btnCalculateFee.TabIndex = 12;
            this.btnCalculateFee.Text = "Calculate Fee";
            this.btnCalculateFee.UseVisualStyleBackColor = true;
            this.btnCalculateFee.Click += new System.EventHandler(this.btnCalculateFee_Click);
            // 
            // lblMonths
            // 
            this.lblMonths.AutoSize = true;
            this.lblMonths.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblMonths.Location = new System.Drawing.Point(6, 46);
            this.lblMonths.Name = "lblMonths";
            this.lblMonths.Size = new System.Drawing.Size(217, 15);
            this.lblMonths.TabIndex = 14;
            this.lblMonths.Text = "Select months to calculate fee amount :";
            // 
            // ddlAcademicYear
            // 
            this.ddlAcademicYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlAcademicYear.FormattingEnabled = true;
            this.ddlAcademicYear.Location = new System.Drawing.Point(226, 17);
            this.ddlAcademicYear.Name = "ddlAcademicYear";
            this.ddlAcademicYear.Size = new System.Drawing.Size(115, 21);
            this.ddlAcademicYear.TabIndex = 14;
            this.ddlAcademicYear.SelectedIndexChanged += new System.EventHandler(this.ddlAcademicYear_SelectedIndexChanged);
            // 
            // lblAcademicYear
            // 
            this.lblAcademicYear.AutoSize = true;
            this.lblAcademicYear.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.lblAcademicYear.Location = new System.Drawing.Point(134, 22);
            this.lblAcademicYear.Name = "lblAcademicYear";
            this.lblAcademicYear.Size = new System.Drawing.Size(86, 13);
            this.lblAcademicYear.TabIndex = 13;
            this.lblAcademicYear.Text = "Academic Year :";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.Location = new System.Drawing.Point(6, 437);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(91, 24);
            this.btnGenerate.TabIndex = 6;
            this.btnGenerate.Text = "Save Details";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // lblTotalFeeAmount
            // 
            this.lblTotalFeeAmount.AutoSize = true;
            this.lblTotalFeeAmount.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalFeeAmount.Location = new System.Drawing.Point(360, 437);
            this.lblTotalFeeAmount.Name = "lblTotalFeeAmount";
            this.lblTotalFeeAmount.Size = new System.Drawing.Size(86, 15);
            this.lblTotalFeeAmount.TabIndex = 11;
            this.lblTotalFeeAmount.Text = "Total Amount :";
            this.lblTotalFeeAmount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblTotalFeeAmount.Visible = false;
            // 
            // lblTotalFeeAmountValue
            // 
            this.lblTotalFeeAmountValue.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalFeeAmountValue.Location = new System.Drawing.Point(458, 437);
            this.lblTotalFeeAmountValue.Name = "lblTotalFeeAmountValue";
            this.lblTotalFeeAmountValue.Size = new System.Drawing.Size(71, 15);
            this.lblTotalFeeAmountValue.TabIndex = 14;
            this.lblTotalFeeAmountValue.Text = "0";
            this.lblTotalFeeAmountValue.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblTotalFeeAmountValue.Visible = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Enabled = false;
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(103, 437);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(47, 24);
            this.btnPrint.TabIndex = 15;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // txtMaskedDate
            // 
            this.txtMaskedDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaskedDate.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtMaskedDate.Location = new System.Drawing.Point(52, 16);
            this.txtMaskedDate.Mask = "00.00.0000";
            this.txtMaskedDate.Name = "txtMaskedDate";
            this.txtMaskedDate.Size = new System.Drawing.Size(67, 22);
            this.txtMaskedDate.TabIndex = 48;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblDate.Location = new System.Drawing.Point(9, 22);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(37, 13);
            this.lblDate.TabIndex = 49;
            this.lblDate.Text = "Date :";
            // 
            // AdmissionFeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 466);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.lblTotalFeeAmountValue);
            this.Controls.Add(this.lblTotalFeeAmount);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupFee);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(54)))), ((int)(((byte)(92)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdmissionFeeForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admission Fee";
            this.Load += new System.EventHandler(this.AdmissionFeeForm_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAdmissionFeeType)).EndInit();
            this.groupFee.ResumeLayout(false);
            this.groupFee.PerformLayout();
            this.panelMonths.ResumeLayout(false);
            this.panelMonths.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView gridAdmissionFeeType;
        private System.Windows.Forms.GroupBox groupFee;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label lblTotalFeeAmount;
        private System.Windows.Forms.Label lblMonths;
        private System.Windows.Forms.ComboBox ddlAcademicYear;
        private System.Windows.Forms.Label lblAcademicYear;
        private System.Windows.Forms.Button btnCalculateFee;
        private System.Windows.Forms.Panel panelMonths;
        private System.Windows.Forms.CheckBox chkMarch;
        private System.Windows.Forms.CheckBox chkFebruary;
        private System.Windows.Forms.CheckBox chkJanuary;
        private System.Windows.Forms.CheckBox chkDecember;
        private System.Windows.Forms.CheckBox chkNovember;
        private System.Windows.Forms.CheckBox chkOctober;
        private System.Windows.Forms.CheckBox chkSeptember;
        private System.Windows.Forms.CheckBox chkAugust;
        private System.Windows.Forms.CheckBox chkJuly;
        private System.Windows.Forms.CheckBox chkJune;
        private System.Windows.Forms.CheckBox chkMay;
        private System.Windows.Forms.CheckBox chkApril;
        private System.Windows.Forms.Label lblTotalFeeAmountValue;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFeeTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFeeType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMonthNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReceiptNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSequenceID;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.MaskedTextBox txtMaskedDate;
        private System.Windows.Forms.Label lblDate;
    }
}