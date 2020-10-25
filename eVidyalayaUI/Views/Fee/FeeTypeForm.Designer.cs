namespace eVidyalaya
{
    partial class FeeTypeForm
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
            this.groupContols = new System.Windows.Forms.GroupBox();
            this.chkIsPurchasable = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.txtFeeType = new System.Windows.Forms.TextBox();
            this.lblFeetype = new System.Windows.Forms.Label();
            this.lblShortCutKeys = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.groupFeeTypeList = new System.Windows.Forms.GroupBox();
            this.gridFeeType = new System.Windows.Forms.DataGridView();
            this.colEdit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colFeeTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFeeType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFixedFeeType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsActiveHidden = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colIsLostableHidden = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colIsPurchasable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hdnFeeTypeID = new System.Windows.Forms.Label();
            this.linkResetControls = new System.Windows.Forms.LinkLabel();
            this.groupContols.SuspendLayout();
            this.groupFeeTypeList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFeeType)).BeginInit();
            this.SuspendLayout();
            // 
            // groupContols
            // 
            this.groupContols.Controls.Add(this.chkIsPurchasable);
            this.groupContols.Controls.Add(this.btnSave);
            this.groupContols.Controls.Add(this.chkActive);
            this.groupContols.Controls.Add(this.txtFeeType);
            this.groupContols.Controls.Add(this.lblFeetype);
            this.groupContols.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(54)))), ((int)(((byte)(92)))));
            this.groupContols.Location = new System.Drawing.Point(10, 6);
            this.groupContols.Name = "groupContols";
            this.groupContols.Size = new System.Drawing.Size(591, 57);
            this.groupContols.TabIndex = 0;
            this.groupContols.TabStop = false;
            // 
            // chkIsPurchasable
            // 
            this.chkIsPurchasable.AutoSize = true;
            this.chkIsPurchasable.Location = new System.Drawing.Point(423, 24);
            this.chkIsPurchasable.Name = "chkIsPurchasable";
            this.chkIsPurchasable.Size = new System.Drawing.Size(102, 19);
            this.chkIsPurchasable.TabIndex = 152;
            this.chkIsPurchasable.Text = "Is Purchasable";
            this.chkIsPurchasable.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(54)))), ((int)(((byte)(92)))));
            this.btnSave.Location = new System.Drawing.Point(532, 20);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(48, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Location = new System.Drawing.Point(329, 24);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(71, 19);
            this.chkActive.TabIndex = 2;
            this.chkActive.Text = "Is Active";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // txtFeeType
            // 
            this.txtFeeType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFeeType.Location = new System.Drawing.Point(62, 19);
            this.txtFeeType.MaxLength = 30;
            this.txtFeeType.Name = "txtFeeType";
            this.txtFeeType.Size = new System.Drawing.Size(244, 23);
            this.txtFeeType.TabIndex = 1;
            // 
            // lblFeetype
            // 
            this.lblFeetype.AutoSize = true;
            this.lblFeetype.Location = new System.Drawing.Point(6, 25);
            this.lblFeetype.Name = "lblFeetype";
            this.lblFeetype.Size = new System.Drawing.Size(53, 15);
            this.lblFeetype.TabIndex = 27;
            this.lblFeetype.Text = "Fee Type";
            // 
            // lblShortCutKeys
            // 
            this.lblShortCutKeys.AutoSize = true;
            this.lblShortCutKeys.Location = new System.Drawing.Point(607, 79);
            this.lblShortCutKeys.Name = "lblShortCutKeys";
            this.lblShortCutKeys.Size = new System.Drawing.Size(91, 15);
            this.lblShortCutKeys.TabIndex = 147;
            this.lblShortCutKeys.Text = "lblShortCutKeys";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(604, 21);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(45, 15);
            this.lblError.TabIndex = 145;
            this.lblError.Text = "lblError";
            this.lblError.Visible = false;
            // 
            // groupFeeTypeList
            // 
            this.groupFeeTypeList.Controls.Add(this.gridFeeType);
            this.groupFeeTypeList.Location = new System.Drawing.Point(10, 62);
            this.groupFeeTypeList.Name = "groupFeeTypeList";
            this.groupFeeTypeList.Size = new System.Drawing.Size(591, 553);
            this.groupFeeTypeList.TabIndex = 143;
            this.groupFeeTypeList.TabStop = false;
            // 
            // gridFeeType
            // 
            this.gridFeeType.AllowUserToAddRows = false;
            this.gridFeeType.AllowUserToDeleteRows = false;
            this.gridFeeType.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridFeeType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridFeeType.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colEdit,
            this.colFeeTypeID,
            this.colFeeType,
            this.colFixedFeeType,
            this.colActive,
            this.colIsActiveHidden,
            this.colIsLostableHidden,
            this.colIsPurchasable});
            this.gridFeeType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridFeeType.Location = new System.Drawing.Point(3, 19);
            this.gridFeeType.Name = "gridFeeType";
            this.gridFeeType.RowHeadersVisible = false;
            this.gridFeeType.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridFeeType.Size = new System.Drawing.Size(585, 531);
            this.gridFeeType.TabIndex = 5;
            this.gridFeeType.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridFeeType_CellContentClick);
            // 
            // colEdit
            // 
            this.colEdit.HeaderText = "Edit";
            this.colEdit.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.colEdit.Name = "colEdit";
            this.colEdit.ReadOnly = true;
            this.colEdit.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colEdit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colEdit.Width = 40;
            // 
            // colFeeTypeID
            // 
            this.colFeeTypeID.HeaderText = "FeeTypeID";
            this.colFeeTypeID.Name = "colFeeTypeID";
            this.colFeeTypeID.ReadOnly = true;
            this.colFeeTypeID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colFeeTypeID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colFeeTypeID.Visible = false;
            this.colFeeTypeID.Width = 40;
            // 
            // colFeeType
            // 
            this.colFeeType.HeaderText = "Fee Type (Display Name)";
            this.colFeeType.Name = "colFeeType";
            this.colFeeType.ReadOnly = true;
            this.colFeeType.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colFeeType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colFeeType.Width = 180;
            // 
            // colFixedFeeType
            // 
            this.colFixedFeeType.HeaderText = "Fee Type (Fixed Name)";
            this.colFixedFeeType.Name = "colFixedFeeType";
            this.colFixedFeeType.Width = 180;
            // 
            // colActive
            // 
            this.colActive.HeaderText = "Is Active";
            this.colActive.Name = "colActive";
            this.colActive.ReadOnly = true;
            this.colActive.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colActive.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colActive.Width = 70;
            // 
            // colIsActiveHidden
            // 
            this.colIsActiveHidden.HeaderText = "Active";
            this.colIsActiveHidden.Name = "colIsActiveHidden";
            this.colIsActiveHidden.Visible = false;
            // 
            // colIsLostableHidden
            // 
            this.colIsLostableHidden.HeaderText = "Is lostable";
            this.colIsLostableHidden.Name = "colIsLostableHidden";
            this.colIsLostableHidden.Visible = false;
            // 
            // colIsPurchasable
            // 
            this.colIsPurchasable.HeaderText = "Is Purchasable";
            this.colIsPurchasable.Name = "colIsPurchasable";
            // 
            // hdnFeeTypeID
            // 
            this.hdnFeeTypeID.AutoSize = true;
            this.hdnFeeTypeID.Location = new System.Drawing.Point(846, 48);
            this.hdnFeeTypeID.Name = "hdnFeeTypeID";
            this.hdnFeeTypeID.Size = new System.Drawing.Size(84, 15);
            this.hdnFeeTypeID.TabIndex = 150;
            this.hdnFeeTypeID.Text = "hdnFeeTypeID";
            this.hdnFeeTypeID.Visible = false;
            // 
            // linkResetControls
            // 
            this.linkResetControls.AutoSize = true;
            this.linkResetControls.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkResetControls.Location = new System.Drawing.Point(605, 44);
            this.linkResetControls.Name = "linkResetControls";
            this.linkResetControls.Size = new System.Drawing.Size(35, 15);
            this.linkResetControls.TabIndex = 151;
            this.linkResetControls.TabStop = true;
            this.linkResetControls.Text = "Reset";
            this.linkResetControls.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkResetControls_LinkClicked);
            // 
            // FeeTypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(942, 628);
            this.Controls.Add(this.linkResetControls);
            this.Controls.Add(this.hdnFeeTypeID);
            this.Controls.Add(this.lblShortCutKeys);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.groupFeeTypeList);
            this.Controls.Add(this.groupContols);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(54)))), ((int)(((byte)(92)))));
            this.Name = "FeeTypeForm";
            this.Text = "Fee Type";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FeeTypeForm_FormClosing);
            this.Load += new System.EventHandler(this.FeeTypeForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FeeTypeForm_KeyDown);
            this.groupContols.ResumeLayout(false);
            this.groupContols.PerformLayout();
            this.groupFeeTypeList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridFeeType)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupContols;
        private System.Windows.Forms.TextBox txtFeeType;
        private System.Windows.Forms.Label lblFeetype;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblShortCutKeys;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.GroupBox groupFeeTypeList;
        private System.Windows.Forms.DataGridView gridFeeType;
        private System.Windows.Forms.Label hdnFeeTypeID;
        private System.Windows.Forms.LinkLabel linkResetControls;
        private System.Windows.Forms.CheckBox chkIsPurchasable;
        private System.Windows.Forms.DataGridViewLinkColumn colEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFeeTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFeeType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFixedFeeType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActive;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsActiveHidden;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsLostableHidden;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIsPurchasable;
    }
}