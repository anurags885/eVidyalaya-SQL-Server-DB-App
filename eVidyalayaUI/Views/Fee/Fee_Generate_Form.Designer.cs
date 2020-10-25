namespace eVidyalaya.Views.Fee
{
    partial class Fee_Generate_Form
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
            this.ddlMonths = new System.Windows.Forms.ComboBox();
            this.lblMonth = new System.Windows.Forms.Label();
            this.grp_Student_List = new System.Windows.Forms.GroupBox();
            this.grid_Student_List = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grp_Student_Details = new System.Windows.Forms.GroupBox();
            this.lblStudentName = new System.Windows.Forms.Label();
            this.lblClass = new System.Windows.Forms.Label();
            this.lblClassValue = new System.Windows.Forms.Label();
            this.btn_Generate = new System.Windows.Forms.Button();
            this.lblStudentNameValue = new System.Windows.Forms.Label();
            this.btn_Search = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblRegistrationNumber = new System.Windows.Forms.Label();
            this.grp_Student_List.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_Student_List)).BeginInit();
            this.grp_Student_Details.SuspendLayout();
            this.SuspendLayout();
            // 
            // ddlMonths
            // 
            this.ddlMonths.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlMonths.FormattingEnabled = true;
            this.ddlMonths.Location = new System.Drawing.Point(181, 12);
            this.ddlMonths.Name = "ddlMonths";
            this.ddlMonths.Size = new System.Drawing.Size(132, 21);
            this.ddlMonths.TabIndex = 15;
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Location = new System.Drawing.Point(12, 15);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(163, 15);
            this.lblMonth.TabIndex = 0;
            this.lblMonth.Text = "Select month to generate fee:";
            // 
            // grp_Student_List
            // 
            this.grp_Student_List.Controls.Add(this.grid_Student_List);
            this.grp_Student_List.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.grp_Student_List.Location = new System.Drawing.Point(12, 45);
            this.grp_Student_List.Name = "grp_Student_List";
            this.grp_Student_List.Size = new System.Drawing.Size(458, 466);
            this.grp_Student_List.TabIndex = 8;
            this.grp_Student_List.TabStop = false;
            this.grp_Student_List.Text = "List of students whose fee is not generate in the month of :";
            // 
            // grid_Student_List
            // 
            this.grid_Student_List.AllowUserToAddRows = false;
            this.grid_Student_List.AllowUserToDeleteRows = false;
            this.grid_Student_List.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grid_Student_List.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grid_Student_List.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.grid_Student_List.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_Student_List.Location = new System.Drawing.Point(3, 19);
            this.grid_Student_List.Name = "grid_Student_List";
            this.grid_Student_List.RowHeadersVisible = false;
            this.grid_Student_List.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grid_Student_List.Size = new System.Drawing.Size(452, 444);
            this.grid_Student_List.TabIndex = 9;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Registration No";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn1.Width = 120;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Student Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 190;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Class";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 130;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "col_Student_ID";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "col_Class_ID";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "col_Month_Value";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // grp_Student_Details
            // 
            this.grp_Student_Details.Controls.Add(this.lblStudentName);
            this.grp_Student_Details.Controls.Add(this.lblClass);
            this.grp_Student_Details.Controls.Add(this.lblClassValue);
            this.grp_Student_Details.Controls.Add(this.btn_Generate);
            this.grp_Student_Details.Controls.Add(this.lblStudentNameValue);
            this.grp_Student_Details.Controls.Add(this.btn_Search);
            this.grp_Student_Details.Controls.Add(this.textBox1);
            this.grp_Student_Details.Controls.Add(this.lblRegistrationNumber);
            this.grp_Student_Details.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.grp_Student_Details.ForeColor = System.Drawing.Color.Black;
            this.grp_Student_Details.Location = new System.Drawing.Point(476, 45);
            this.grp_Student_Details.Name = "grp_Student_Details";
            this.grp_Student_Details.Size = new System.Drawing.Size(366, 466);
            this.grp_Student_Details.TabIndex = 23;
            this.grp_Student_Details.TabStop = false;
            // 
            // lblStudentName
            // 
            this.lblStudentName.AutoSize = true;
            this.lblStudentName.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblStudentName.Location = new System.Drawing.Point(8, 49);
            this.lblStudentName.Name = "lblStudentName";
            this.lblStudentName.Size = new System.Drawing.Size(90, 15);
            this.lblStudentName.TabIndex = 40;
            this.lblStudentName.Text = "Student Name :";
            // 
            // lblClass
            // 
            this.lblClass.AutoSize = true;
            this.lblClass.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblClass.Location = new System.Drawing.Point(59, 77);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(39, 15);
            this.lblClass.TabIndex = 41;
            this.lblClass.Text = "Class :";
            // 
            // lblClassValue
            // 
            this.lblClassValue.AutoSize = true;
            this.lblClassValue.BackColor = System.Drawing.SystemColors.Control;
            this.lblClassValue.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblClassValue.Location = new System.Drawing.Point(104, 77);
            this.lblClassValue.Name = "lblClassValue";
            this.lblClassValue.Size = new System.Drawing.Size(36, 15);
            this.lblClassValue.TabIndex = 42;
            this.lblClassValue.Text = "fgfdg";
            this.lblClassValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_Generate
            // 
            this.btn_Generate.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.btn_Generate.ForeColor = System.Drawing.Color.Black;
            this.btn_Generate.Location = new System.Drawing.Point(277, 110);
            this.btn_Generate.Name = "btn_Generate";
            this.btn_Generate.Size = new System.Drawing.Size(84, 24);
            this.btn_Generate.TabIndex = 39;
            this.btn_Generate.Text = "Generate Fee";
            this.btn_Generate.UseVisualStyleBackColor = true;
            // 
            // lblStudentNameValue
            // 
            this.lblStudentNameValue.AutoSize = true;
            this.lblStudentNameValue.BackColor = System.Drawing.SystemColors.Control;
            this.lblStudentNameValue.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblStudentNameValue.Location = new System.Drawing.Point(104, 49);
            this.lblStudentNameValue.Name = "lblStudentNameValue";
            this.lblStudentNameValue.Size = new System.Drawing.Size(20, 15);
            this.lblStudentNameValue.TabIndex = 43;
            this.lblStudentNameValue.Text = "gj ";
            this.lblStudentNameValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_Search
            // 
            this.btn_Search.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btn_Search.ForeColor = System.Drawing.Color.Black;
            this.btn_Search.Location = new System.Drawing.Point(310, 18);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(51, 24);
            this.btn_Search.TabIndex = 2;
            this.btn_Search.Text = "Search";
            this.btn_Search.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.textBox1.Location = new System.Drawing.Point(103, 18);
            this.textBox1.MaxLength = 19;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(163, 23);
            this.textBox1.TabIndex = 1;
            // 
            // lblRegistrationNumber
            // 
            this.lblRegistrationNumber.AutoSize = true;
            this.lblRegistrationNumber.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblRegistrationNumber.Location = new System.Drawing.Point(3, 22);
            this.lblRegistrationNumber.Name = "lblRegistrationNumber";
            this.lblRegistrationNumber.Size = new System.Drawing.Size(95, 15);
            this.lblRegistrationNumber.TabIndex = 27;
            this.lblRegistrationNumber.Text = "Registration No :";
            // 
            // Fee_Generate_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 534);
            this.Controls.Add(this.ddlMonths);
            this.Controls.Add(this.grp_Student_Details);
            this.Controls.Add(this.lblMonth);
            this.Controls.Add(this.grp_Student_List);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.Name = "Fee_Generate_Form";
            this.Text = "Generate Fee";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Fee_Generate_Form_FormClosing);
            this.grp_Student_List.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_Student_List)).EndInit();
            this.grp_Student_Details.ResumeLayout(false);
            this.grp_Student_Details.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.ComboBox ddlMonths;
        private System.Windows.Forms.GroupBox grp_Student_List;
        private System.Windows.Forms.DataGridView grid_Student_List;
        private System.Windows.Forms.DataGridViewLinkColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.GroupBox grp_Student_Details;
        private System.Windows.Forms.Label lblStudentName;
        private System.Windows.Forms.Button btn_Generate;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.Label lblClassValue;
        private System.Windows.Forms.Label lblStudentNameValue;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblRegistrationNumber;
    }
}