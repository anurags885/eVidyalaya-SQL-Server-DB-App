﻿namespace eVidyalaya
{
    partial class ReportClassWiseStudentForm
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
            this.ddlSection = new System.Windows.Forms.ComboBox();
            this.lblSection = new System.Windows.Forms.Label();
            this.lblPleaseWait = new System.Windows.Forms.Label();
            this.crystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btnViewReport = new System.Windows.Forms.Button();
            this.ddlClass = new System.Windows.Forms.ComboBox();
            this.lblClass = new System.Windows.Forms.Label();
            this.groupReport.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupReport
            // 
            this.groupReport.Controls.Add(this.ddlSection);
            this.groupReport.Controls.Add(this.lblSection);
            this.groupReport.Controls.Add(this.lblPleaseWait);
            this.groupReport.Controls.Add(this.crystalReportViewer);
            this.groupReport.Controls.Add(this.btnViewReport);
            this.groupReport.Controls.Add(this.ddlClass);
            this.groupReport.Controls.Add(this.lblClass);
            this.groupReport.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupReport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(54)))), ((int)(((byte)(92)))));
            this.groupReport.Location = new System.Drawing.Point(12, 12);
            this.groupReport.Name = "groupReport";
            this.groupReport.Size = new System.Drawing.Size(945, 557);
            this.groupReport.TabIndex = 1;
            this.groupReport.TabStop = false;
            // 
            // ddlSection
            // 
            this.ddlSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlSection.FormattingEnabled = true;
            this.ddlSection.Location = new System.Drawing.Point(203, 15);
            this.ddlSection.Name = "ddlSection";
            this.ddlSection.Size = new System.Drawing.Size(54, 23);
            this.ddlSection.TabIndex = 134;
            // 
            // lblSection
            // 
            this.lblSection.AutoSize = true;
            this.lblSection.Location = new System.Drawing.Point(148, 23);
            this.lblSection.Name = "lblSection";
            this.lblSection.Size = new System.Drawing.Size(53, 15);
            this.lblSection.TabIndex = 135;
            this.lblSection.Text = "Section :";
            // 
            // lblPleaseWait
            // 
            this.lblPleaseWait.AutoSize = true;
            this.lblPleaseWait.Location = new System.Drawing.Point(333, 23);
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
            this.crystalReportViewer.Location = new System.Drawing.Point(6, 55);
            this.crystalReportViewer.Name = "crystalReportViewer";
            this.crystalReportViewer.ShowCloseButton = false;
            this.crystalReportViewer.ShowCopyButton = false;
            this.crystalReportViewer.ShowGroupTreeButton = false;
            this.crystalReportViewer.ShowLogo = false;
            this.crystalReportViewer.ShowParameterPanelButton = false;
            this.crystalReportViewer.Size = new System.Drawing.Size(933, 496);
            this.crystalReportViewer.TabIndex = 132;
            this.crystalReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.crystalReportViewer.Visible = false;
            // 
            // btnViewReport
            // 
            this.btnViewReport.Location = new System.Drawing.Point(279, 15);
            this.btnViewReport.Name = "btnViewReport";
            this.btnViewReport.Size = new System.Drawing.Size(48, 23);
            this.btnViewReport.TabIndex = 131;
            this.btnViewReport.Text = "View";
            this.btnViewReport.UseVisualStyleBackColor = true;
            this.btnViewReport.Click += new System.EventHandler(this.btnViewReport_Click);
            // 
            // ddlClass
            // 
            this.ddlClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlClass.FormattingEnabled = true;
            this.ddlClass.Location = new System.Drawing.Point(53, 15);
            this.ddlClass.Name = "ddlClass";
            this.ddlClass.Size = new System.Drawing.Size(89, 23);
            this.ddlClass.TabIndex = 127;
            // 
            // lblClass
            // 
            this.lblClass.AutoSize = true;
            this.lblClass.Location = new System.Drawing.Point(12, 23);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(39, 15);
            this.lblClass.TabIndex = 128;
            this.lblClass.Text = "Class :";
            // 
            // ReportClassWiseStudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(963, 581);
            this.Controls.Add(this.groupReport);
            this.Name = "ReportClassWiseStudentForm";
            this.Text = "Class Wise Student Report";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReportClassWiseStudentForm_FormClosing);
            this.groupReport.ResumeLayout(false);
            this.groupReport.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupReport;
        private System.Windows.Forms.Label lblPleaseWait;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer;
        private System.Windows.Forms.Button btnViewReport;
        private System.Windows.Forms.ComboBox ddlClass;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.ComboBox ddlSection;
        private System.Windows.Forms.Label lblSection;
    }
}