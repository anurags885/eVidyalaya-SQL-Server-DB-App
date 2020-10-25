namespace eVidyalaya
{
    partial class FeePurchasesItem
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
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.dtpPurchasesDate = new System.Windows.Forms.DateTimePicker();
            this.lblPurchasesDate = new System.Windows.Forms.Label();
            this.lblParticulars = new System.Windows.Forms.Label();
            this.ddlFeeType = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblStudentName = new System.Windows.Forms.Label();
            this.txtRegistrationNo = new System.Windows.Forms.TextBox();
            this.lblClassValue = new System.Windows.Forms.Label();
            this.lblRegistrationNo = new System.Windows.Forms.Label();
            this.lblStudentNameValue = new System.Windows.Forms.Label();
            this.lblClass = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gridFeeType = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gridPurchasesItem = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dateReport = new System.Windows.Forms.DateTimePicker();
            this.linkView = new System.Windows.Forms.LinkLabel();
            this.lblDate = new System.Windows.Forms.Label();
            this.colReceiptNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRegistrationNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrint = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colFeeTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFeeType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.groupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFeeType)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPurchasesItem)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.dtpPurchasesDate);
            this.groupBox.Controls.Add(this.lblPurchasesDate);
            this.groupBox.Controls.Add(this.lblParticulars);
            this.groupBox.Controls.Add(this.ddlFeeType);
            this.groupBox.Controls.Add(this.btnAdd);
            this.groupBox.Controls.Add(this.lblStudentName);
            this.groupBox.Controls.Add(this.txtRegistrationNo);
            this.groupBox.Controls.Add(this.lblClassValue);
            this.groupBox.Controls.Add(this.lblRegistrationNo);
            this.groupBox.Controls.Add(this.lblStudentNameValue);
            this.groupBox.Controls.Add(this.lblClass);
            this.groupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(54)))), ((int)(((byte)(92)))));
            this.groupBox.Location = new System.Drawing.Point(12, 2);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(582, 122);
            this.groupBox.TabIndex = 0;
            this.groupBox.TabStop = false;
            // 
            // dtpPurchasesDate
            // 
            this.dtpPurchasesDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPurchasesDate.Location = new System.Drawing.Point(107, 14);
            this.dtpPurchasesDate.Name = "dtpPurchasesDate";
            this.dtpPurchasesDate.Size = new System.Drawing.Size(122, 23);
            this.dtpPurchasesDate.TabIndex = 132;
            // 
            // lblPurchasesDate
            // 
            this.lblPurchasesDate.AutoSize = true;
            this.lblPurchasesDate.Location = new System.Drawing.Point(6, 19);
            this.lblPurchasesDate.Name = "lblPurchasesDate";
            this.lblPurchasesDate.Size = new System.Drawing.Size(94, 15);
            this.lblPurchasesDate.TabIndex = 131;
            this.lblPurchasesDate.Text = "Purchases Date :";
            // 
            // lblParticulars
            // 
            this.lblParticulars.AutoSize = true;
            this.lblParticulars.Location = new System.Drawing.Point(297, 45);
            this.lblParticulars.Name = "lblParticulars";
            this.lblParticulars.Size = new System.Drawing.Size(68, 15);
            this.lblParticulars.TabIndex = 11;
            this.lblParticulars.Text = "Particulars :";
            // 
            // ddlFeeType
            // 
            this.ddlFeeType.FormattingEnabled = true;
            this.ddlFeeType.Location = new System.Drawing.Point(368, 42);
            this.ddlFeeType.Name = "ddlFeeType";
            this.ddlFeeType.Size = new System.Drawing.Size(134, 23);
            this.ddlFeeType.TabIndex = 2;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(513, 42);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(56, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblStudentName
            // 
            this.lblStudentName.AutoSize = true;
            this.lblStudentName.Location = new System.Drawing.Point(6, 74);
            this.lblStudentName.Name = "lblStudentName";
            this.lblStudentName.Size = new System.Drawing.Size(90, 15);
            this.lblStudentName.TabIndex = 7;
            this.lblStudentName.Text = "Student Name :";
            // 
            // txtRegistrationNo
            // 
            this.txtRegistrationNo.CausesValidation = false;
            this.txtRegistrationNo.Location = new System.Drawing.Point(107, 41);
            this.txtRegistrationNo.Name = "txtRegistrationNo";
            this.txtRegistrationNo.Size = new System.Drawing.Size(122, 23);
            this.txtRegistrationNo.TabIndex = 0;
            this.txtRegistrationNo.Leave += new System.EventHandler(this.txtRegistrationNo_Leave);
            // 
            // lblClassValue
            // 
            this.lblClassValue.AutoSize = true;
            this.lblClassValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblClassValue.Location = new System.Drawing.Point(104, 99);
            this.lblClassValue.Name = "lblClassValue";
            this.lblClassValue.Size = new System.Drawing.Size(76, 15);
            this.lblClassValue.TabIndex = 10;
            this.lblClassValue.Text = "lblClassValue";
            this.lblClassValue.Visible = false;
            // 
            // lblRegistrationNo
            // 
            this.lblRegistrationNo.AutoSize = true;
            this.lblRegistrationNo.Location = new System.Drawing.Point(6, 45);
            this.lblRegistrationNo.Name = "lblRegistrationNo";
            this.lblRegistrationNo.Size = new System.Drawing.Size(95, 15);
            this.lblRegistrationNo.TabIndex = 1;
            this.lblRegistrationNo.Text = "Registration No :";
            // 
            // lblStudentNameValue
            // 
            this.lblStudentNameValue.AutoSize = true;
            this.lblStudentNameValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudentNameValue.Location = new System.Drawing.Point(104, 74);
            this.lblStudentNameValue.Name = "lblStudentNameValue";
            this.lblStudentNameValue.Size = new System.Drawing.Size(128, 15);
            this.lblStudentNameValue.TabIndex = 8;
            this.lblStudentNameValue.Text = "lblStudentNameValue";
            this.lblStudentNameValue.Visible = false;
            // 
            // lblClass
            // 
            this.lblClass.AutoSize = true;
            this.lblClass.Location = new System.Drawing.Point(6, 99);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(39, 15);
            this.lblClass.TabIndex = 9;
            this.lblClass.Text = "Class :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gridFeeType);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(54)))), ((int)(((byte)(92)))));
            this.groupBox1.Location = new System.Drawing.Point(12, 124);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(582, 255);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // gridFeeType
            // 
            this.gridFeeType.AllowUserToAddRows = false;
            this.gridFeeType.AllowUserToDeleteRows = false;
            this.gridFeeType.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridFeeType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridFeeType.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFeeTypeID,
            this.colFeeType,
            this.colAmount,
            this.colDelete});
            this.gridFeeType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridFeeType.Location = new System.Drawing.Point(3, 19);
            this.gridFeeType.Name = "gridFeeType";
            this.gridFeeType.RowHeadersVisible = false;
            this.gridFeeType.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridFeeType.Size = new System.Drawing.Size(576, 233);
            this.gridFeeType.TabIndex = 6;
            this.gridFeeType.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridFeeType_CellContentClick);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(538, 383);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(56, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gridPurchasesItem);
            this.groupBox2.Location = new System.Drawing.Point(616, 46);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(324, 475);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // gridPurchasesItem
            // 
            this.gridPurchasesItem.AllowUserToAddRows = false;
            this.gridPurchasesItem.AllowUserToDeleteRows = false;
            this.gridPurchasesItem.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridPurchasesItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridPurchasesItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colReceiptNo,
            this.colRegistrationNo,
            this.colPrint});
            this.gridPurchasesItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPurchasesItem.Location = new System.Drawing.Point(3, 19);
            this.gridPurchasesItem.Name = "gridPurchasesItem";
            this.gridPurchasesItem.RowHeadersVisible = false;
            this.gridPurchasesItem.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridPurchasesItem.Size = new System.Drawing.Size(318, 453);
            this.gridPurchasesItem.TabIndex = 7;
            this.gridPurchasesItem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridPurchasesItem_CellContentClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dateReport);
            this.groupBox3.Controls.Add(this.linkView);
            this.groupBox3.Controls.Add(this.lblDate);
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(54)))), ((int)(((byte)(92)))));
            this.groupBox3.Location = new System.Drawing.Point(616, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(324, 49);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            // 
            // dateReport
            // 
            this.dateReport.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateReport.Location = new System.Drawing.Point(50, 16);
            this.dateReport.Name = "dateReport";
            this.dateReport.Size = new System.Drawing.Size(125, 23);
            this.dateReport.TabIndex = 130;
            // 
            // linkView
            // 
            this.linkView.AutoSize = true;
            this.linkView.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.linkView.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkView.Location = new System.Drawing.Point(181, 20);
            this.linkView.Name = "linkView";
            this.linkView.Size = new System.Drawing.Size(43, 15);
            this.linkView.TabIndex = 1;
            this.linkView.TabStop = true;
            this.linkView.Text = "Search";
            this.linkView.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkView_LinkClicked);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(6, 20);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(38, 15);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "Date :";
            // 
            // colReceiptNo
            // 
            this.colReceiptNo.HeaderText = "Receipt No";
            this.colReceiptNo.Name = "colReceiptNo";
            this.colReceiptNo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colReceiptNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colRegistrationNo
            // 
            this.colRegistrationNo.HeaderText = "Registration No";
            this.colRegistrationNo.Name = "colRegistrationNo";
            // 
            // colPrint
            // 
            this.colPrint.HeaderText = "Print";
            this.colPrint.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.colPrint.Name = "colPrint";
            this.colPrint.Width = 50;
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
            this.colFeeType.Width = 180;
            // 
            // colAmount
            // 
            this.colAmount.HeaderText = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            this.colAmount.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colAmount.Width = 70;
            // 
            // colDelete
            // 
            this.colDelete.HeaderText = "Delete";
            this.colDelete.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.colDelete.Name = "colDelete";
            this.colDelete.Width = 50;
            // 
            // FeePurchasesItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 533);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(54)))), ((int)(((byte)(92)))));
            this.Name = "FeePurchasesItem";
            this.Text = "Purchases Item";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FeeForLostableFeeTypeForm_FormClosing);
            this.Load += new System.EventHandler(this.FeePurchasesItem_Load);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridFeeType)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPurchasesItem)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Label lblRegistrationNo;
        private System.Windows.Forms.Label lblClassValue;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.Label lblStudentNameValue;
        private System.Windows.Forms.TextBox txtRegistrationNo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblStudentName;
        private System.Windows.Forms.Label lblParticulars;
        private System.Windows.Forms.ComboBox ddlFeeType;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView gridFeeType;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.LinkLabel linkView;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dateReport;
        private System.Windows.Forms.DataGridView gridPurchasesItem;
        private System.Windows.Forms.DateTimePicker dtpPurchasesDate;
        private System.Windows.Forms.Label lblPurchasesDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFeeTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFeeType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewLinkColumn colDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReceiptNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRegistrationNo;
        private System.Windows.Forms.DataGridViewLinkColumn colPrint;
    }
}