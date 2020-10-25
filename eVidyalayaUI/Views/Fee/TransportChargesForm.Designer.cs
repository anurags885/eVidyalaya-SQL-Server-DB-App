namespace eVidyalaya
{
    partial class TransportChargesForm
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
            this.lblAreaName = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.txtRouteName = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupTransport = new System.Windows.Forms.GroupBox();
            this.gridTransport = new System.Windows.Forms.DataGridView();
            this.hdnRouteID = new System.Windows.Forms.Label();
            this.lblShortCutKeys = new System.Windows.Forms.Label();
            this.colRouteID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRouteName = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupTransport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTransport)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAreaName
            // 
            this.lblAreaName.AutoSize = true;
            this.lblAreaName.Location = new System.Drawing.Point(10, 20);
            this.lblAreaName.Name = "lblAreaName";
            this.lblAreaName.Size = new System.Drawing.Size(79, 15);
            this.lblAreaName.TabIndex = 0;
            this.lblAreaName.Text = "Route Name :";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(351, 20);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(57, 15);
            this.lblAmount.TabIndex = 1;
            this.lblAmount.Text = "Amount :";
            // 
            // txtRouteName
            // 
            this.txtRouteName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRouteName.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.txtRouteName.Location = new System.Drawing.Point(91, 12);
            this.txtRouteName.MaxLength = 100;
            this.txtRouteName.Name = "txtRouteName";
            this.txtRouteName.Size = new System.Drawing.Size(257, 22);
            this.txtRouteName.TabIndex = 3;
            // 
            // txtAmount
            // 
            this.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmount.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.txtAmount.Location = new System.Drawing.Point(412, 12);
            this.txtAmount.MaxLength = 5;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(60, 22);
            this.txtAmount.TabIndex = 4;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(482, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(46, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupTransport
            // 
            this.groupTransport.Controls.Add(this.gridTransport);
            this.groupTransport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(60)))), ((int)(((byte)(98)))));
            this.groupTransport.Location = new System.Drawing.Point(12, 41);
            this.groupTransport.Name = "groupTransport";
            this.groupTransport.Size = new System.Drawing.Size(396, 559);
            this.groupTransport.TabIndex = 144;
            this.groupTransport.TabStop = false;
            // 
            // gridTransport
            // 
            this.gridTransport.AllowDrop = true;
            this.gridTransport.AllowUserToAddRows = false;
            this.gridTransport.AllowUserToDeleteRows = false;
            this.gridTransport.AllowUserToResizeColumns = false;
            this.gridTransport.AllowUserToResizeRows = false;
            this.gridTransport.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridTransport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTransport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRouteID,
            this.colRouteName,
            this.colAmount});
            this.gridTransport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTransport.Location = new System.Drawing.Point(3, 19);
            this.gridTransport.Name = "gridTransport";
            this.gridTransport.ReadOnly = true;
            this.gridTransport.RowHeadersVisible = false;
            this.gridTransport.Size = new System.Drawing.Size(390, 537);
            this.gridTransport.TabIndex = 0;
            this.gridTransport.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridTransport_CellContentClick);
            // 
            // hdnRouteID
            // 
            this.hdnRouteID.AutoSize = true;
            this.hdnRouteID.Location = new System.Drawing.Point(457, 438);
            this.hdnRouteID.Name = "hdnRouteID";
            this.hdnRouteID.Size = new System.Drawing.Size(72, 15);
            this.hdnRouteID.TabIndex = 145;
            this.hdnRouteID.Text = "hdnRouteID";
            this.hdnRouteID.Visible = false;
            // 
            // lblShortCutKeys
            // 
            this.lblShortCutKeys.AutoSize = true;
            this.lblShortCutKeys.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblShortCutKeys.Location = new System.Drawing.Point(414, 60);
            this.lblShortCutKeys.Name = "lblShortCutKeys";
            this.lblShortCutKeys.Size = new System.Drawing.Size(26, 15);
            this.lblShortCutKeys.TabIndex = 146;
            this.lblShortCutKeys.Text = "Key";
            // 
            // colRouteID
            // 
            this.colRouteID.HeaderText = "Route ID";
            this.colRouteID.Name = "colRouteID";
            this.colRouteID.ReadOnly = true;
            this.colRouteID.Visible = false;
            // 
            // colRouteName
            // 
            this.colRouteName.HeaderText = "Route Name";
            this.colRouteName.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.colRouteName.Name = "colRouteName";
            this.colRouteName.ReadOnly = true;
            this.colRouteName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colRouteName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colRouteName.Width = 300;
            // 
            // colAmount
            // 
            this.colAmount.HeaderText = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            this.colAmount.Width = 65;
            // 
            // TransportChargesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 612);
            this.Controls.Add(this.lblShortCutKeys);
            this.Controls.Add(this.hdnRouteID);
            this.Controls.Add(this.groupTransport);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.txtRouteName);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lblAreaName);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(54)))), ((int)(((byte)(92)))));
            this.Name = "TransportChargesForm";
            this.Text = "Transport Fee Setting";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TransportChargesForm_FormClosing);
            this.Load += new System.EventHandler(this.TransportChargesForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TransportChargesForm_KeyDown);
            this.groupTransport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTransport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAreaName;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.TextBox txtRouteName;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupTransport;
        private System.Windows.Forms.DataGridView gridTransport;
        private System.Windows.Forms.Label hdnRouteID;
        private System.Windows.Forms.Label lblShortCutKeys;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRouteID;
        private System.Windows.Forms.DataGridViewLinkColumn colRouteName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
    }
}