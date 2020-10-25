namespace eVidyalaya
{
    partial class Student_Fee_info_Report_Form
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
            this.crystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.ddlAcademicYear = new System.Windows.Forms.ComboBox();
            this.ddlSettingType = new System.Windows.Forms.ComboBox();
            this.lblSettingType = new System.Windows.Forms.Label();
            this.lblAcademicYear = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // crystalReportViewer
            // 
            this.crystalReportViewer.ActiveViewIndex = -1;
            this.crystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer.DisplayBackgroundEdge = false;
            this.crystalReportViewer.EnableDrillDown = false;
            this.crystalReportViewer.Location = new System.Drawing.Point(9, 40);
            this.crystalReportViewer.Name = "crystalReportViewer";
            this.crystalReportViewer.ShowCloseButton = false;
            this.crystalReportViewer.ShowCopyButton = false;
            this.crystalReportViewer.ShowGroupTreeButton = false;
            this.crystalReportViewer.ShowLogo = false;
            this.crystalReportViewer.ShowParameterPanelButton = false;
            this.crystalReportViewer.Size = new System.Drawing.Size(1135, 580);
            this.crystalReportViewer.TabIndex = 133;
            this.crystalReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.crystalReportViewer.Visible = false;
            // 
            // ddlAcademicYear
            // 
            this.ddlAcademicYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlAcademicYear.FormattingEnabled = true;
            this.ddlAcademicYear.Location = new System.Drawing.Point(98, 11);
            this.ddlAcademicYear.Name = "ddlAcademicYear";
            this.ddlAcademicYear.Size = new System.Drawing.Size(86, 21);
            this.ddlAcademicYear.TabIndex = 137;
            // 
            // ddlSettingType
            // 
            this.ddlSettingType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlSettingType.FormattingEnabled = true;
            this.ddlSettingType.Location = new System.Drawing.Point(302, 11);
            this.ddlSettingType.Name = "ddlSettingType";
            this.ddlSettingType.Size = new System.Drawing.Size(215, 21);
            this.ddlSettingType.TabIndex = 135;
            // 
            // lblSettingType
            // 
            this.lblSettingType.AutoSize = true;
            this.lblSettingType.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSettingType.Location = new System.Drawing.Point(196, 14);
            this.lblSettingType.Name = "lblSettingType";
            this.lblSettingType.Size = new System.Drawing.Size(100, 15);
            this.lblSettingType.TabIndex = 134;
            this.lblSettingType.Text = "Fee Setting Type :";
            // 
            // lblAcademicYear
            // 
            this.lblAcademicYear.AutoSize = true;
            this.lblAcademicYear.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAcademicYear.Location = new System.Drawing.Point(6, 14);
            this.lblAcademicYear.Name = "lblAcademicYear";
            this.lblAcademicYear.Size = new System.Drawing.Size(91, 15);
            this.lblAcademicYear.TabIndex = 136;
            this.lblAcademicYear.Text = "Academic Year :";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(523, 9);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(54, 23);
            this.btnSearch.TabIndex = 138;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // Student_Fee_info_Report_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1223, 610);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.ddlAcademicYear);
            this.Controls.Add(this.ddlSettingType);
            this.Controls.Add(this.lblSettingType);
            this.Controls.Add(this.lblAcademicYear);
            this.Controls.Add(this.crystalReportViewer);
            this.Name = "Student_Fee_info_Report_Form";
            this.Text = "Student Fee Setting Report";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PartialFeeReportForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer;
        private System.Windows.Forms.ComboBox ddlAcademicYear;
        private System.Windows.Forms.ComboBox ddlSettingType;
        private System.Windows.Forms.Label lblSettingType;
        private System.Windows.Forms.Label lblAcademicYear;
        private System.Windows.Forms.Button btnSearch;
    }
}