namespace eVidyalaya
{
    partial class ReportStudentPromotion
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
            this.groupReport = new System.Windows.Forms.GroupBox();
            this.crystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.groupBoxSearch = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.maskedFromAcademicYear = new System.Windows.Forms.MaskedTextBox();
            this.lblAcademicYear = new System.Windows.Forms.Label();
            this.ddlClass = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblCurrentClass = new System.Windows.Forms.Label();
            this.lblCurrentSection = new System.Windows.Forms.Label();
            this.ddlSection = new System.Windows.Forms.ComboBox();
            this.groupReport.SuspendLayout();
            this.groupBoxSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupReport
            // 
            this.groupReport.Controls.Add(this.crystalReportViewer);
            this.groupReport.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupReport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(54)))), ((int)(((byte)(92)))));
            this.groupReport.Location = new System.Drawing.Point(6, 49);
            this.groupReport.Name = "groupReport";
            this.groupReport.Size = new System.Drawing.Size(1133, 551);
            this.groupReport.TabIndex = 2;
            this.groupReport.TabStop = false;
            // 
            // crystalReportViewer
            // 
            this.crystalReportViewer.ActiveViewIndex = -1;
            this.crystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer.DisplayBackgroundEdge = false;
            this.crystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer.EnableDrillDown = false;
            this.crystalReportViewer.Location = new System.Drawing.Point(3, 19);
            this.crystalReportViewer.Name = "crystalReportViewer";
            this.crystalReportViewer.ShowCloseButton = false;
            this.crystalReportViewer.ShowCopyButton = false;
            this.crystalReportViewer.ShowGroupTreeButton = false;
            this.crystalReportViewer.ShowLogo = false;
            this.crystalReportViewer.ShowParameterPanelButton = false;
            this.crystalReportViewer.Size = new System.Drawing.Size(1127, 529);
            this.crystalReportViewer.TabIndex = 132;
            this.crystalReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.crystalReportViewer.Visible = false;
            // 
            // groupBoxSearch
            // 
            this.groupBoxSearch.Controls.Add(this.label1);
            this.groupBoxSearch.Controls.Add(this.maskedFromAcademicYear);
            this.groupBoxSearch.Controls.Add(this.lblAcademicYear);
            this.groupBoxSearch.Controls.Add(this.ddlClass);
            this.groupBoxSearch.Controls.Add(this.btnSearch);
            this.groupBoxSearch.Controls.Add(this.lblCurrentClass);
            this.groupBoxSearch.Controls.Add(this.lblCurrentSection);
            this.groupBoxSearch.Controls.Add(this.ddlSection);
            this.groupBoxSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.groupBoxSearch.Location = new System.Drawing.Point(6, -2);
            this.groupBoxSearch.Name = "groupBoxSearch";
            this.groupBoxSearch.Size = new System.Drawing.Size(592, 55);
            this.groupBoxSearch.TabIndex = 165;
            this.groupBoxSearch.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 7F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(125, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 12);
            this.label1.TabIndex = 166;
            this.label1.Text = "YYYY-YYYY";
            // 
            // maskedFromAcademicYear
            // 
            this.maskedFromAcademicYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.maskedFromAcademicYear.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.maskedFromAcademicYear.ForeColor = System.Drawing.SystemColors.WindowText;
            this.maskedFromAcademicYear.Location = new System.Drawing.Point(125, 18);
            this.maskedFromAcademicYear.Mask = "0000-0000";
            this.maskedFromAcademicYear.Name = "maskedFromAcademicYear";
            this.maskedFromAcademicYear.Size = new System.Drawing.Size(61, 22);
            this.maskedFromAcademicYear.TabIndex = 1;
            // 
            // lblAcademicYear
            // 
            this.lblAcademicYear.AutoSize = true;
            this.lblAcademicYear.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.lblAcademicYear.Location = new System.Drawing.Point(7, 23);
            this.lblAcademicYear.Name = "lblAcademicYear";
            this.lblAcademicYear.Size = new System.Drawing.Size(116, 13);
            this.lblAcademicYear.TabIndex = 0;
            this.lblAcademicYear.Text = "From Academic Year :";
            // 
            // ddlClass
            // 
            this.ddlClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlClass.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.ddlClass.FormattingEnabled = true;
            this.ddlClass.ItemHeight = 13;
            this.ddlClass.Location = new System.Drawing.Point(261, 18);
            this.ddlClass.Name = "ddlClass";
            this.ddlClass.Size = new System.Drawing.Size(87, 21);
            this.ddlClass.TabIndex = 128;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(529, 16);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(55, 24);
            this.btnSearch.TabIndex = 132;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblCurrentClass
            // 
            this.lblCurrentClass.AutoSize = true;
            this.lblCurrentClass.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.lblCurrentClass.Location = new System.Drawing.Point(191, 22);
            this.lblCurrentClass.Name = "lblCurrentClass";
            this.lblCurrentClass.Size = new System.Drawing.Size(69, 13);
            this.lblCurrentClass.TabIndex = 130;
            this.lblCurrentClass.Text = "From Class :";
            // 
            // lblCurrentSection
            // 
            this.lblCurrentSection.AutoSize = true;
            this.lblCurrentSection.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.lblCurrentSection.Location = new System.Drawing.Point(353, 22);
            this.lblCurrentSection.Name = "lblCurrentSection";
            this.lblCurrentSection.Size = new System.Drawing.Size(80, 13);
            this.lblCurrentSection.TabIndex = 131;
            this.lblCurrentSection.Text = "From Section :";
            // 
            // ddlSection
            // 
            this.ddlSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlSection.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.ddlSection.FormattingEnabled = true;
            this.ddlSection.Location = new System.Drawing.Point(440, 18);
            this.ddlSection.Name = "ddlSection";
            this.ddlSection.Size = new System.Drawing.Size(71, 21);
            this.ddlSection.TabIndex = 129;
            // 
            // ReportStudentPromotion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 644);
            this.Controls.Add(this.groupBoxSearch);
            this.Controls.Add(this.groupReport);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(54)))), ((int)(((byte)(92)))));
            this.Name = "ReportStudentPromotion";
            this.Text = "Report Student Promotion";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReportStudentPromotion_FormClosing);
            this.groupReport.ResumeLayout(false);
            this.groupBoxSearch.ResumeLayout(false);
            this.groupBoxSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupReport;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer;
        private System.Windows.Forms.GroupBox groupBoxSearch;
        private System.Windows.Forms.Label lblAcademicYear;
        private System.Windows.Forms.ComboBox ddlClass;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblCurrentClass;
        private System.Windows.Forms.Label lblCurrentSection;
        private System.Windows.Forms.ComboBox ddlSection;
        private System.Windows.Forms.MaskedTextBox maskedFromAcademicYear;
        private System.Windows.Forms.Label label1;
    }
}