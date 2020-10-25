namespace eVidyalaya
{
    partial class DailyExpensesForm
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
            this.groupExpenses = new System.Windows.Forms.GroupBox();
            this.txtMaskedDate = new System.Windows.Forms.MaskedTextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblPaymentMode = new System.Windows.Forms.Label();
            this.ddlPaymentMode = new System.Windows.Forms.ComboBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.txtBillNo = new System.Windows.Forms.TextBox();
            this.lblBillNo = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.txtShopName = new System.Windows.Forms.TextBox();
            this.txtParticulars = new System.Windows.Forms.TextBox();
            this.lblShopName = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.hdnExpensesID = new System.Windows.Forms.Label();
            this.btnViewReport = new System.Windows.Forms.Button();
            this.groupGrid = new System.Windows.Forms.GroupBox();
            this.gridExpenses = new System.Windows.Forms.DataGridView();
            this.ColSLNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBillNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColShopName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColParticulars = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPaymentMode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColEdit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ColDelete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ColExpensesID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupExpenses.SuspendLayout();
            this.groupGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridExpenses)).BeginInit();
            this.SuspendLayout();
            // 
            // groupExpenses
            // 
            this.groupExpenses.Controls.Add(this.txtMaskedDate);
            this.groupExpenses.Controls.Add(this.btnSearch);
            this.groupExpenses.Controls.Add(this.lblPaymentMode);
            this.groupExpenses.Controls.Add(this.ddlPaymentMode);
            this.groupExpenses.Controls.Add(this.txtQuantity);
            this.groupExpenses.Controls.Add(this.lblQuantity);
            this.groupExpenses.Controls.Add(this.txtBillNo);
            this.groupExpenses.Controls.Add(this.lblBillNo);
            this.groupExpenses.Controls.Add(this.btnSave);
            this.groupExpenses.Controls.Add(this.txtAmount);
            this.groupExpenses.Controls.Add(this.lblDate);
            this.groupExpenses.Controls.Add(this.txtShopName);
            this.groupExpenses.Controls.Add(this.txtParticulars);
            this.groupExpenses.Controls.Add(this.lblShopName);
            this.groupExpenses.Controls.Add(this.lblAmount);
            this.groupExpenses.Controls.Add(this.label1);
            this.groupExpenses.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.groupExpenses.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(46)))), ((int)(((byte)(75)))));
            this.groupExpenses.Location = new System.Drawing.Point(13, -1);
            this.groupExpenses.Name = "groupExpenses";
            this.groupExpenses.Size = new System.Drawing.Size(610, 136);
            this.groupExpenses.TabIndex = 0;
            this.groupExpenses.TabStop = false;
            // 
            // txtMaskedDate
            // 
            this.txtMaskedDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaskedDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(46)))), ((int)(((byte)(75)))));
            this.txtMaskedDate.Location = new System.Drawing.Point(118, 14);
            this.txtMaskedDate.Mask = "00.00.0000";
            this.txtMaskedDate.Name = "txtMaskedDate";
            this.txtMaskedDate.Size = new System.Drawing.Size(74, 23);
            this.txtMaskedDate.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(46)))), ((int)(((byte)(75)))));
            this.btnSearch.Location = new System.Drawing.Point(524, 14);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(60, 23);
            this.btnSearch.TabIndex = 15;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblPaymentMode
            // 
            this.lblPaymentMode.AutoSize = true;
            this.lblPaymentMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(46)))), ((int)(((byte)(75)))));
            this.lblPaymentMode.Location = new System.Drawing.Point(169, 106);
            this.lblPaymentMode.Name = "lblPaymentMode";
            this.lblPaymentMode.Size = new System.Drawing.Size(88, 15);
            this.lblPaymentMode.TabIndex = 13;
            this.lblPaymentMode.Text = "Payment Mode";
            // 
            // ddlPaymentMode
            // 
            this.ddlPaymentMode.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlPaymentMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(46)))), ((int)(((byte)(75)))));
            this.ddlPaymentMode.FormattingEnabled = true;
            this.ddlPaymentMode.Location = new System.Drawing.Point(262, 98);
            this.ddlPaymentMode.Name = "ddlPaymentMode";
            this.ddlPaymentMode.Size = new System.Drawing.Size(108, 23);
            this.ddlPaymentMode.TabIndex = 6;
            // 
            // txtQuantity
            // 
            this.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQuantity.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(46)))), ((int)(((byte)(75)))));
            this.txtQuantity.Location = new System.Drawing.Point(118, 98);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(48, 23);
            this.txtQuantity.TabIndex = 5;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(46)))), ((int)(((byte)(75)))));
            this.lblQuantity.Location = new System.Drawing.Point(59, 106);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(53, 15);
            this.lblQuantity.TabIndex = 10;
            this.lblQuantity.Text = "Quantity";
            // 
            // txtBillNo
            // 
            this.txtBillNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBillNo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBillNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(46)))), ((int)(((byte)(75)))));
            this.txtBillNo.Location = new System.Drawing.Point(317, 14);
            this.txtBillNo.MaxLength = 50;
            this.txtBillNo.Name = "txtBillNo";
            this.txtBillNo.Size = new System.Drawing.Size(189, 23);
            this.txtBillNo.TabIndex = 2;
            // 
            // lblBillNo
            // 
            this.lblBillNo.AutoSize = true;
            this.lblBillNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(46)))), ((int)(((byte)(75)))));
            this.lblBillNo.Location = new System.Drawing.Point(269, 22);
            this.lblBillNo.Name = "lblBillNo";
            this.lblBillNo.Size = new System.Drawing.Size(42, 15);
            this.lblBillNo.TabIndex = 10;
            this.lblBillNo.Text = "Bill No";
            // 
            // btnSave
            // 
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(46)))), ((int)(((byte)(75)))));
            this.btnSave.Location = new System.Drawing.Point(524, 98);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(60, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtAmount
            // 
            this.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmount.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(46)))), ((int)(((byte)(75)))));
            this.txtAmount.Location = new System.Drawing.Point(433, 98);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(73, 23);
            this.txtAmount.TabIndex = 7;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(46)))), ((int)(((byte)(75)))));
            this.lblDate.Location = new System.Drawing.Point(80, 22);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(32, 15);
            this.lblDate.TabIndex = 7;
            this.lblDate.Text = "Date";
            // 
            // txtShopName
            // 
            this.txtShopName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtShopName.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShopName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(46)))), ((int)(((byte)(75)))));
            this.txtShopName.Location = new System.Drawing.Point(118, 42);
            this.txtShopName.MaxLength = 80;
            this.txtShopName.Name = "txtShopName";
            this.txtShopName.Size = new System.Drawing.Size(388, 23);
            this.txtShopName.TabIndex = 3;
            // 
            // txtParticulars
            // 
            this.txtParticulars.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtParticulars.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtParticulars.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(46)))), ((int)(((byte)(75)))));
            this.txtParticulars.Location = new System.Drawing.Point(118, 69);
            this.txtParticulars.MaxLength = 80;
            this.txtParticulars.Name = "txtParticulars";
            this.txtParticulars.Size = new System.Drawing.Size(388, 23);
            this.txtParticulars.TabIndex = 4;
            // 
            // lblShopName
            // 
            this.lblShopName.AutoSize = true;
            this.lblShopName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(46)))), ((int)(((byte)(75)))));
            this.lblShopName.Location = new System.Drawing.Point(5, 50);
            this.lblShopName.Name = "lblShopName";
            this.lblShopName.Size = new System.Drawing.Size(111, 15);
            this.lblShopName.TabIndex = 0;
            this.lblShopName.Text = "Shop/Person Name";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(46)))), ((int)(((byte)(75)))));
            this.lblAmount.Location = new System.Drawing.Point(376, 106);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(51, 15);
            this.lblAmount.TabIndex = 1;
            this.lblAmount.Text = "Amount";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(46)))), ((int)(((byte)(75)))));
            this.label1.Location = new System.Drawing.Point(50, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Particulars";
            // 
            // hdnExpensesID
            // 
            this.hdnExpensesID.AutoSize = true;
            this.hdnExpensesID.Location = new System.Drawing.Point(629, 15);
            this.hdnExpensesID.Name = "hdnExpensesID";
            this.hdnExpensesID.Size = new System.Drawing.Size(89, 15);
            this.hdnExpensesID.TabIndex = 14;
            this.hdnExpensesID.Text = "hdnExpensesID";
            this.hdnExpensesID.Visible = false;
            // 
            // btnViewReport
            // 
            this.btnViewReport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewReport.Location = new System.Drawing.Point(931, 577);
            this.btnViewReport.Name = "btnViewReport";
            this.btnViewReport.Size = new System.Drawing.Size(85, 23);
            this.btnViewReport.TabIndex = 2;
            this.btnViewReport.Text = "View Report";
            this.btnViewReport.UseVisualStyleBackColor = true;
            this.btnViewReport.Click += new System.EventHandler(this.btnViewReport_Click);
            // 
            // groupGrid
            // 
            this.groupGrid.Controls.Add(this.gridExpenses);
            this.groupGrid.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupGrid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(46)))), ((int)(((byte)(75)))));
            this.groupGrid.Location = new System.Drawing.Point(13, 136);
            this.groupGrid.Name = "groupGrid";
            this.groupGrid.Size = new System.Drawing.Size(1003, 429);
            this.groupGrid.TabIndex = 3;
            this.groupGrid.TabStop = false;
            // 
            // gridExpenses
            // 
            this.gridExpenses.AllowUserToAddRows = false;
            this.gridExpenses.AllowUserToDeleteRows = false;
            this.gridExpenses.AllowUserToResizeColumns = false;
            this.gridExpenses.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridExpenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridExpenses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColSLNo,
            this.ColBillNo,
            this.ColShopName,
            this.ColParticulars,
            this.ColQuantity,
            this.ColPaymentMode,
            this.ColAmount,
            this.ColEdit,
            this.ColDelete,
            this.ColExpensesID,
            this.ColDate});
            this.gridExpenses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridExpenses.Location = new System.Drawing.Point(3, 19);
            this.gridExpenses.Name = "gridExpenses";
            this.gridExpenses.ReadOnly = true;
            this.gridExpenses.RowHeadersVisible = false;
            this.gridExpenses.Size = new System.Drawing.Size(997, 407);
            this.gridExpenses.TabIndex = 10;
            this.gridExpenses.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridExpenses_CellContentClick);
            // 
            // ColSLNo
            // 
            this.ColSLNo.HeaderText = "SL No";
            this.ColSLNo.Name = "ColSLNo";
            this.ColSLNo.ReadOnly = true;
            this.ColSLNo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColSLNo.Width = 60;
            // 
            // ColBillNo
            // 
            this.ColBillNo.HeaderText = "Bill No";
            this.ColBillNo.Name = "ColBillNo";
            this.ColBillNo.ReadOnly = true;
            this.ColBillNo.Width = 120;
            // 
            // ColShopName
            // 
            this.ColShopName.HeaderText = "Shop/Person Name";
            this.ColShopName.Name = "ColShopName";
            this.ColShopName.ReadOnly = true;
            this.ColShopName.Width = 200;
            // 
            // ColParticulars
            // 
            this.ColParticulars.HeaderText = "Particulars";
            this.ColParticulars.Name = "ColParticulars";
            this.ColParticulars.ReadOnly = true;
            this.ColParticulars.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColParticulars.Width = 220;
            // 
            // ColQuantity
            // 
            this.ColQuantity.HeaderText = "Quantity";
            this.ColQuantity.Name = "ColQuantity";
            this.ColQuantity.ReadOnly = true;
            this.ColQuantity.Width = 70;
            // 
            // ColPaymentMode
            // 
            this.ColPaymentMode.HeaderText = "PaymentMode";
            this.ColPaymentMode.Name = "ColPaymentMode";
            this.ColPaymentMode.ReadOnly = true;
            this.ColPaymentMode.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColPaymentMode.Width = 110;
            // 
            // ColAmount
            // 
            this.ColAmount.HeaderText = "Amount";
            this.ColAmount.Name = "ColAmount";
            this.ColAmount.ReadOnly = true;
            this.ColAmount.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // ColEdit
            // 
            this.ColEdit.HeaderText = "Edit";
            this.ColEdit.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ColEdit.Name = "ColEdit";
            this.ColEdit.ReadOnly = true;
            this.ColEdit.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColEdit.VisitedLinkColor = System.Drawing.Color.Teal;
            this.ColEdit.Width = 50;
            // 
            // ColDelete
            // 
            this.ColDelete.HeaderText = "Delete";
            this.ColDelete.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ColDelete.Name = "ColDelete";
            this.ColDelete.ReadOnly = true;
            this.ColDelete.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColDelete.VisitedLinkColor = System.Drawing.Color.Teal;
            this.ColDelete.Width = 50;
            // 
            // ColExpensesID
            // 
            this.ColExpensesID.HeaderText = "ExpensesID";
            this.ColExpensesID.Name = "ColExpensesID";
            this.ColExpensesID.ReadOnly = true;
            this.ColExpensesID.Visible = false;
            // 
            // ColDate
            // 
            this.ColDate.HeaderText = "Date";
            this.ColDate.Name = "ColDate";
            this.ColDate.ReadOnly = true;
            this.ColDate.Visible = false;
            // 
            // DailyExpensesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1020, 612);
            this.Controls.Add(this.groupGrid);
            this.Controls.Add(this.btnViewReport);
            this.Controls.Add(this.hdnExpensesID);
            this.Controls.Add(this.groupExpenses);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(46)))), ((int)(((byte)(75)))));
            this.Name = "DailyExpensesForm";
            this.Text = "DailyExpensesForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DailyExpensesForm_FormClosing);
            this.Load += new System.EventHandler(this.DailyExpensesForm_Load);
            this.groupExpenses.ResumeLayout(false);
            this.groupExpenses.PerformLayout();
            this.groupGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridExpenses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupExpenses;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtParticulars;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnViewReport;
        private System.Windows.Forms.TextBox txtBillNo;
        private System.Windows.Forms.Label lblBillNo;
        private System.Windows.Forms.ComboBox ddlPaymentMode;
        private System.Windows.Forms.TextBox txtShopName;
        private System.Windows.Forms.Label lblShopName;
        private System.Windows.Forms.Label lblPaymentMode;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label hdnExpensesID;
        private System.Windows.Forms.GroupBox groupGrid;
        private System.Windows.Forms.DataGridView gridExpenses;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.MaskedTextBox txtMaskedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSLNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBillNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColShopName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColParticulars;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPaymentMode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAmount;
        private System.Windows.Forms.DataGridViewLinkColumn ColEdit;
        private System.Windows.Forms.DataGridViewLinkColumn ColDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColExpensesID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDate;
    }
}