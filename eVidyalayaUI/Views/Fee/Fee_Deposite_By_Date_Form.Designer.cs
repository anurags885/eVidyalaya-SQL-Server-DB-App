namespace eVidyalaya.Views.Fee
{
    partial class Fee_Deposite_By_Date_Form
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupData = new System.Windows.Forms.GroupBox();
            this.grid_Fee_List = new System.Windows.Forms.DataGridView();
            this.panelFeeC = new System.Windows.Forms.GroupBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.linkDownload = new System.Windows.Forms.LinkLabel();
            this.col_FeeReceiptNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Full_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Registration_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Class_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_AmountDeposit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Fee_Deposit_Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_FeeDepositDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Print = new System.Windows.Forms.DataGridViewLinkColumn();
            this.col_Fee_Deposit_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Student_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_Fee_List)).BeginInit();
            this.panelFeeC.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupData
            // 
            this.groupData.Controls.Add(this.grid_Fee_List);
            this.groupData.Location = new System.Drawing.Point(12, 52);
            this.groupData.Name = "groupData";
            this.groupData.Size = new System.Drawing.Size(943, 551);
            this.groupData.TabIndex = 0;
            this.groupData.TabStop = false;
            // 
            // grid_Fee_List
            // 
            this.grid_Fee_List.AllowDrop = true;
            this.grid_Fee_List.AllowUserToAddRows = false;
            this.grid_Fee_List.AllowUserToDeleteRows = false;
            this.grid_Fee_List.AllowUserToOrderColumns = true;
            this.grid_Fee_List.AllowUserToResizeColumns = false;
            this.grid_Fee_List.AllowUserToResizeRows = false;
            this.grid_Fee_List.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grid_Fee_List.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_Fee_List.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_FeeReceiptNo,
            this.col_Full_Name,
            this.col_Registration_No,
            this.col_Class_Name,
            this.col_AmountDeposit,
            this.col_Fee_Deposit_Type,
            this.col_FeeDepositDate,
            this.col_Print,
            this.col_Fee_Deposit_Code,
            this.col_Student_ID});
            this.grid_Fee_List.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_Fee_List.Location = new System.Drawing.Point(3, 19);
            this.grid_Fee_List.Name = "grid_Fee_List";
            this.grid_Fee_List.ReadOnly = true;
            this.grid_Fee_List.RowHeadersVisible = false;
            this.grid_Fee_List.Size = new System.Drawing.Size(937, 529);
            this.grid_Fee_List.TabIndex = 1;
            this.grid_Fee_List.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_Fee_List_CellContentClick);
            // 
            // panelFeeC
            // 
            this.panelFeeC.Controls.Add(this.dtpDate);
            this.panelFeeC.Controls.Add(this.lblDate);
            this.panelFeeC.Location = new System.Drawing.Point(12, 1);
            this.panelFeeC.Name = "panelFeeC";
            this.panelFeeC.Size = new System.Drawing.Size(192, 50);
            this.panelFeeC.TabIndex = 76;
            this.panelFeeC.TabStop = false;
            // 
            // dtpDate
            // 
            this.dtpDate.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(75, 18);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(98, 23);
            this.dtpDate.TabIndex = 5;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblDate.Location = new System.Drawing.Point(6, 22);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(67, 15);
            this.lblDate.TabIndex = 62;
            this.lblDate.Text = "Select Date";
            // 
            // linkDownload
            // 
            this.linkDownload.AutoSize = true;
            this.linkDownload.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkDownload.Location = new System.Drawing.Point(230, 23);
            this.linkDownload.Name = "linkDownload";
            this.linkDownload.Size = new System.Drawing.Size(87, 15);
            this.linkDownload.TabIndex = 77;
            this.linkDownload.TabStop = true;
            this.linkDownload.Text = "Export To Excel";
            this.linkDownload.Visible = false;
            this.linkDownload.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkDownload_LinkClicked);
            // 
            // col_FeeReceiptNo
            // 
            this.col_FeeReceiptNo.HeaderText = "Receipt No";
            this.col_FeeReceiptNo.Name = "col_FeeReceiptNo";
            this.col_FeeReceiptNo.ReadOnly = true;
            this.col_FeeReceiptNo.Width = 120;
            // 
            // col_Full_Name
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.col_Full_Name.DefaultCellStyle = dataGridViewCellStyle1;
            this.col_Full_Name.HeaderText = "Student Name";
            this.col_Full_Name.Name = "col_Full_Name";
            this.col_Full_Name.ReadOnly = true;
            this.col_Full_Name.Width = 200;
            // 
            // col_Registration_No
            // 
            this.col_Registration_No.HeaderText = "Registration No";
            this.col_Registration_No.Name = "col_Registration_No";
            this.col_Registration_No.ReadOnly = true;
            this.col_Registration_No.Width = 115;
            // 
            // col_Class_Name
            // 
            this.col_Class_Name.HeaderText = "Class";
            this.col_Class_Name.Name = "col_Class_Name";
            this.col_Class_Name.ReadOnly = true;
            // 
            // col_AmountDeposit
            // 
            this.col_AmountDeposit.HeaderText = "Deposit Amount";
            this.col_AmountDeposit.Name = "col_AmountDeposit";
            this.col_AmountDeposit.ReadOnly = true;
            this.col_AmountDeposit.Width = 80;
            // 
            // col_Fee_Deposit_Type
            // 
            this.col_Fee_Deposit_Type.HeaderText = "Fee Deposit Type";
            this.col_Fee_Deposit_Type.Name = "col_Fee_Deposit_Type";
            this.col_Fee_Deposit_Type.ReadOnly = true;
            this.col_Fee_Deposit_Type.Width = 150;
            // 
            // col_FeeDepositDate
            // 
            this.col_FeeDepositDate.HeaderText = "Deposit Date";
            this.col_FeeDepositDate.Name = "col_FeeDepositDate";
            this.col_FeeDepositDate.ReadOnly = true;
            // 
            // col_Print
            // 
            this.col_Print.HeaderText = "Print";
            this.col_Print.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.col_Print.Name = "col_Print";
            this.col_Print.ReadOnly = true;
            this.col_Print.Width = 60;
            // 
            // col_Fee_Deposit_Code
            // 
            this.col_Fee_Deposit_Code.HeaderText = "col_Fee_Deposit_Code";
            this.col_Fee_Deposit_Code.Name = "col_Fee_Deposit_Code";
            this.col_Fee_Deposit_Code.ReadOnly = true;
            this.col_Fee_Deposit_Code.Visible = false;
            // 
            // col_Student_ID
            // 
            this.col_Student_ID.HeaderText = "col_Student_ID";
            this.col_Student_ID.Name = "col_Student_ID";
            this.col_Student_ID.ReadOnly = true;
            this.col_Student_ID.Visible = false;
            // 
            // Fee_Deposite_By_Date_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1192, 649);
            this.Controls.Add(this.linkDownload);
            this.Controls.Add(this.panelFeeC);
            this.Controls.Add(this.groupData);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "Fee_Deposite_By_Date_Form";
            this.Text = "Fee Deposite By Date";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Fee_Deposite_By_Date_Form_FormClosing);
            this.Load += new System.EventHandler(this.Fee_Deposite_By_Date_Form_Load);
            this.groupData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_Fee_List)).EndInit();
            this.panelFeeC.ResumeLayout(false);
            this.panelFeeC.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupData;
        private System.Windows.Forms.GroupBox panelFeeC;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DataGridView grid_Fee_List;
        private System.Windows.Forms.LinkLabel linkDownload;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_FeeReceiptNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Full_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Registration_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Class_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_AmountDeposit;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Fee_Deposit_Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_FeeDepositDate;
        private System.Windows.Forms.DataGridViewLinkColumn col_Print;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Fee_Deposit_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Student_ID;
    }
}