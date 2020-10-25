namespace eVidyalaya
{
    partial class Deposit_Fee_Multiple_Receipt
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupPreviousDues = new System.Windows.Forms.GroupBox();
            this.gridPreviousDues = new System.Windows.Forms.DataGridView();
            this.lblAmount = new System.Windows.Forms.Label();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtDepositAmount = new System.Windows.Forms.TextBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblDepositeDate = new System.Windows.Forms.Label();
            this.lblTotalDues = new System.Windows.Forms.Label();
            this.colGridDuesBillNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGridDuesDuesAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGridDuesFeeDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Paid_Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Dues = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Student_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupPreviousDues.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPreviousDues)).BeginInit();
            this.SuspendLayout();
            // 
            // groupPreviousDues
            // 
            this.groupPreviousDues.Controls.Add(this.gridPreviousDues);
            this.groupPreviousDues.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.groupPreviousDues.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.groupPreviousDues.Location = new System.Drawing.Point(6, 7);
            this.groupPreviousDues.Name = "groupPreviousDues";
            this.groupPreviousDues.Size = new System.Drawing.Size(512, 336);
            this.groupPreviousDues.TabIndex = 40;
            this.groupPreviousDues.TabStop = false;
            this.groupPreviousDues.Text = "Dues List :";
            // 
            // gridPreviousDues
            // 
            this.gridPreviousDues.AllowUserToAddRows = false;
            this.gridPreviousDues.AllowUserToDeleteRows = false;
            this.gridPreviousDues.AllowUserToResizeColumns = false;
            this.gridPreviousDues.AllowUserToResizeRows = false;
            this.gridPreviousDues.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.gridPreviousDues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPreviousDues.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colGridDuesBillNo,
            this.colGridDuesDuesAmount,
            this.colGridDuesFeeDate,
            this.col_Paid_Amount,
            this.col_Dues,
            this.col_Student_ID});
            this.gridPreviousDues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPreviousDues.Location = new System.Drawing.Point(3, 19);
            this.gridPreviousDues.Name = "gridPreviousDues";
            this.gridPreviousDues.ReadOnly = true;
            this.gridPreviousDues.RowHeadersVisible = false;
            this.gridPreviousDues.Size = new System.Drawing.Size(506, 314);
            this.gridPreviousDues.TabIndex = 1;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(324, 353);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(87, 15);
            this.lblAmount.TabIndex = 41;
            this.lblAmount.Text = "Enter Amount :";
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(394, 380);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(65, 23);
            this.btnCalculate.TabIndex = 42;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(465, 380);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(50, 23);
            this.btnSave.TabIndex = 43;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtDepositAmount
            // 
            this.txtDepositAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDepositAmount.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.txtDepositAmount.Location = new System.Drawing.Point(417, 349);
            this.txtDepositAmount.MaxLength = 8;
            this.txtDepositAmount.Name = "txtDepositAmount";
            this.txtDepositAmount.Size = new System.Drawing.Size(98, 23);
            this.txtDepositAmount.TabIndex = 44;
            // 
            // dtpDate
            // 
            this.dtpDate.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(81, 349);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(98, 23);
            this.dtpDate.TabIndex = 63;
            // 
            // lblDepositeDate
            // 
            this.lblDepositeDate.AutoSize = true;
            this.lblDepositeDate.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblDepositeDate.Location = new System.Drawing.Point(7, 353);
            this.lblDepositeDate.Name = "lblDepositeDate";
            this.lblDepositeDate.Size = new System.Drawing.Size(68, 15);
            this.lblDepositeDate.TabIndex = 64;
            this.lblDepositeDate.Text = "Enter Date :";
            // 
            // lblTotalDues
            // 
            this.lblTotalDues.AutoSize = true;
            this.lblTotalDues.Location = new System.Drawing.Point(7, 382);
            this.lblTotalDues.Name = "lblTotalDues";
            this.lblTotalDues.Size = new System.Drawing.Size(69, 15);
            this.lblTotalDues.TabIndex = 65;
            this.lblTotalDues.Text = "Total Dues :";
            // 
            // colGridDuesBillNo
            // 
            this.colGridDuesBillNo.Frozen = true;
            this.colGridDuesBillNo.HeaderText = "Bill No";
            this.colGridDuesBillNo.Name = "colGridDuesBillNo";
            this.colGridDuesBillNo.ReadOnly = true;
            this.colGridDuesBillNo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colGridDuesDuesAmount
            // 
            this.colGridDuesDuesAmount.Frozen = true;
            this.colGridDuesDuesAmount.HeaderText = "Due Amount";
            this.colGridDuesDuesAmount.Name = "colGridDuesDuesAmount";
            this.colGridDuesDuesAmount.ReadOnly = true;
            // 
            // colGridDuesFeeDate
            // 
            this.colGridDuesFeeDate.Frozen = true;
            this.colGridDuesFeeDate.HeaderText = "Fee Date";
            this.colGridDuesFeeDate.Name = "colGridDuesFeeDate";
            this.colGridDuesFeeDate.ReadOnly = true;
            // 
            // col_Paid_Amount
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(239)))), ((int)(((byte)(206)))));
            this.col_Paid_Amount.DefaultCellStyle = dataGridViewCellStyle5;
            this.col_Paid_Amount.Frozen = true;
            this.col_Paid_Amount.HeaderText = "Paid Amount";
            this.col_Paid_Amount.Name = "col_Paid_Amount";
            this.col_Paid_Amount.ReadOnly = true;
            // 
            // col_Dues
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.col_Dues.DefaultCellStyle = dataGridViewCellStyle6;
            this.col_Dues.HeaderText = "Dues Left";
            this.col_Dues.Name = "col_Dues";
            this.col_Dues.ReadOnly = true;
            this.col_Dues.Width = 90;
            // 
            // col_Student_ID
            // 
            this.col_Student_ID.HeaderText = "col_Student_ID";
            this.col_Student_ID.Name = "col_Student_ID";
            this.col_Student_ID.ReadOnly = true;
            this.col_Student_ID.Visible = false;
            // 
            // Deposit_Fee_Multiple_Receipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 407);
            this.Controls.Add(this.lblTotalDues);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblDepositeDate);
            this.Controls.Add(this.txtDepositAmount);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.groupPreviousDues);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Deposit_Fee_Multiple_Receipt";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Deposit Fee";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Deposit_Fee_Multiple_Receipt_FormClosing);
            this.Load += new System.EventHandler(this.Search_Previous_Dues_Form_Load);
            this.groupPreviousDues.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPreviousDues)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupPreviousDues;
        private System.Windows.Forms.DataGridView gridPreviousDues;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtDepositAmount;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblDepositeDate;
        private System.Windows.Forms.Label lblTotalDues;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGridDuesBillNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGridDuesDuesAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGridDuesFeeDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Paid_Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Dues;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Student_ID;
    }
}