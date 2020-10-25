namespace eVidyalaya
{
    partial class ReportDailyFeeCollectionFeeForm
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
            this.lblPleaseWait = new System.Windows.Forms.Label();
            this.crystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btnViewReport = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.datePickerReport = new System.Windows.Forms.DateTimePicker();
            this.groupReport.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupReport
            // 
            this.groupReport.Controls.Add(this.lblPleaseWait);
            this.groupReport.Controls.Add(this.crystalReportViewer);
            this.groupReport.Controls.Add(this.btnViewReport);
            this.groupReport.Controls.Add(this.lblDate);
            this.groupReport.Controls.Add(this.datePickerReport);
            this.groupReport.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupReport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(54)))), ((int)(((byte)(92)))));
            this.groupReport.Location = new System.Drawing.Point(12, 4);
            this.groupReport.Name = "groupReport";
            this.groupReport.Size = new System.Drawing.Size(1275, 648);
            this.groupReport.TabIndex = 1;
            this.groupReport.TabStop = false;
            // 
            // lblPleaseWait
            // 
            this.lblPleaseWait.AutoSize = true;
            this.lblPleaseWait.Location = new System.Drawing.Point(231, 30);
            this.lblPleaseWait.Name = "lblPleaseWait";
            this.lblPleaseWait.Size = new System.Drawing.Size(80, 15);
            this.lblPleaseWait.TabIndex = 133;
            this.lblPleaseWait.Text = "Please Wait ...";
            this.lblPleaseWait.Visible = false;
            // 
            // crystalReportViewer
            // 
            this.crystalReportViewer.ActiveViewIndex = -1;
            this.crystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer.DisplayBackgroundEdge = false;
            this.crystalReportViewer.EnableDrillDown = false;
            this.crystalReportViewer.Location = new System.Drawing.Point(7, 57);
            this.crystalReportViewer.Name = "crystalReportViewer";
            this.crystalReportViewer.ShowCloseButton = false;
            this.crystalReportViewer.ShowCopyButton = false;
            this.crystalReportViewer.ShowGroupTreeButton = false;
            this.crystalReportViewer.ShowLogo = false;
            this.crystalReportViewer.ShowParameterPanelButton = false;
            this.crystalReportViewer.Size = new System.Drawing.Size(1262, 585);
            this.crystalReportViewer.TabIndex = 132;
            this.crystalReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.crystalReportViewer.Visible = false;
            // 
            // btnViewReport
            // 
            this.btnViewReport.Location = new System.Drawing.Point(182, 22);
            this.btnViewReport.Name = "btnViewReport";
            this.btnViewReport.Size = new System.Drawing.Size(48, 23);
            this.btnViewReport.TabIndex = 131;
            this.btnViewReport.Text = "View";
            this.btnViewReport.UseVisualStyleBackColor = true;
            this.btnViewReport.Click += new System.EventHandler(this.btnViewReport_Click);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(13, 30);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(32, 15);
            this.lblDate.TabIndex = 130;
            this.lblDate.Text = "Date";
            // 
            // datePickerReport
            // 
            this.datePickerReport.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePickerReport.Location = new System.Drawing.Point(51, 22);
            this.datePickerReport.Name = "datePickerReport";
            this.datePickerReport.Size = new System.Drawing.Size(125, 23);
            this.datePickerReport.TabIndex = 129;
            // 
            // ReportDailyFeeCollectionFeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1296, 658);
            this.Controls.Add(this.groupReport);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(54)))), ((int)(((byte)(92)))));
            this.Name = "ReportDailyFeeCollectionFeeForm";
            this.Text = "Fee Collection Report";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReportDailyFeeCollectionFeeForm_FormClosing);
            this.groupReport.ResumeLayout(false);
            this.groupReport.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupReport;
        private System.Windows.Forms.Label lblPleaseWait;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer;
        private System.Windows.Forms.Button btnViewReport;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker datePickerReport;
    }
}