namespace eVidyalaya
{
    partial class Search_Previous_Dues_Form
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
            this.groupPreviousDues = new System.Windows.Forms.GroupBox();
            this.gridPreviousDues = new System.Windows.Forms.DataGridView();
            this.colGridDuesBillNo = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colGridDuesDuesAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGridDuesFeeDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.groupPreviousDues.Size = new System.Drawing.Size(318, 223);
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
            this.colGridDuesFeeDate});
            this.gridPreviousDues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPreviousDues.Location = new System.Drawing.Point(3, 19);
            this.gridPreviousDues.Name = "gridPreviousDues";
            this.gridPreviousDues.ReadOnly = true;
            this.gridPreviousDues.RowHeadersVisible = false;
            this.gridPreviousDues.Size = new System.Drawing.Size(312, 201);
            this.gridPreviousDues.TabIndex = 1;
            this.gridPreviousDues.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridPreviousDues_CellContentClick);
            // 
            // colGridDuesBillNo
            // 
            this.colGridDuesBillNo.Frozen = true;
            this.colGridDuesBillNo.HeaderText = "Bill No";
            this.colGridDuesBillNo.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.colGridDuesBillNo.Name = "colGridDuesBillNo";
            this.colGridDuesBillNo.ReadOnly = true;
            this.colGridDuesBillNo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colGridDuesBillNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
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
            this.colGridDuesFeeDate.HeaderText = "Date";
            this.colGridDuesFeeDate.Name = "colGridDuesFeeDate";
            this.colGridDuesFeeDate.ReadOnly = true;
            // 
            // Search_Previous_Dues_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 233);
            this.Controls.Add(this.groupPreviousDues);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(54)))), ((int)(((byte)(92)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Search_Previous_Dues_Form";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Previous Dues List";
            this.Load += new System.EventHandler(this.Search_Previous_Dues_Form_Load);
            this.groupPreviousDues.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPreviousDues)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupPreviousDues;
        private System.Windows.Forms.DataGridView gridPreviousDues;
        private System.Windows.Forms.DataGridViewLinkColumn colGridDuesBillNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGridDuesDuesAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGridDuesFeeDate;
    }
}