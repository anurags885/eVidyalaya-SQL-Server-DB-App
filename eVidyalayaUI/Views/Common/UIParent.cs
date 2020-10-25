using eVidyalaya.Views.Fee;
using eVidyalaya.Views.School;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace eVidyalaya
{
    public partial class UIParent : Form
    {
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);
        private readonly ToolStripRenderer _toolStripProfessionalRenderer = new ToolStripProfessionalRenderer();
        private DeserializeDockContent m_deserializeDockContent;
        public static UIParent MDIForm { get; set; }
        //   private bool m_bSaveLayout = true;
        private LeftNavForm m_toolbox;
        public UIParent()
        {
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.Dpi;
            MDIForm = this;

            CreateStandardControls();
            m_deserializeDockContent = new DeserializeDockContent(GetContentFromPersistString);
            vsToolStripExtender1.DefaultRenderer = _toolStripProfessionalRenderer;
            this.dockPanel.Theme = this.vS2015LightTheme1;
            this.EnableVSRenderer(VisualStudioToolStripExtender.VsVersion.Vs2015, vS2015LightTheme1);
            this.dockPanel.AllowEndUserDocking = !dockPanel.AllowEndUserDocking;
            SetSchema("VS2015Blue");
            m_toolbox.Show(dockPanel);
            m_toolbox.CloseButtonVisible = false;
            m_toolbox.Dock = DockStyle.None;
            toolStripStatusDate.Text = DateTime.Today.ToString("dddd dd MMM yyyy");
            //  CreateStatusBar();
        }

        #region Methods
        public static bool IsConnectedToInternet()
        {
            int Desc;
            return InternetGetConnectedState(out Desc, 0);
        }
        private IDockContent FindDocument(string text)
        {
            foreach (IDockContent content in dockPanel.Documents)
                if (content.DockHandler.TabText == text)
                    return content;
            return null;
        }
        private void CloseAllDocuments()
        {
            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                foreach (Form form in MdiChildren)
                    form.Close();
            }
            else
            {
                foreach (IDockContent document in dockPanel.DocumentsToArray())
                {
                    // IMPORANT: dispose all panes.
                    document.DockHandler.DockPanel = null;
                    document.DockHandler.Close();
                }
            }
        }
        private IDockContent GetContentFromPersistString(string persistString)
        {
            dynamic returnValue = null;
            if (persistString == typeof(LeftNavForm).ToString())
                returnValue = m_toolbox;
            return returnValue;
        }
        private void CloseAllContents()
        {
            m_toolbox.DockPanel = null;
            CloseAllDocuments();
            // IMPORTANT: dispose all float windows.
            foreach (var window in dockPanel.FloatWindows.ToList())
                window.Dispose();

            System.Diagnostics.Debug.Assert(dockPanel.Panes.Count == 0);
            System.Diagnostics.Debug.Assert(dockPanel.Contents.Count == 0);
            System.Diagnostics.Debug.Assert(dockPanel.FloatWindows.Count == 0);
        }
        private void SetSchema(string sender)
        {
            CloseAllContents();

            switch (sender)
            {
                case "VS2005":
                    this.dockPanel.Theme = this.vS2005Theme1;
                    this.EnableVSRenderer(VisualStudioToolStripExtender.VsVersion.Vs2005, vS2005Theme1);
                    break;

                case "VS2012Light":
                    this.dockPanel.Theme = this.vS2012LightTheme1;
                    this.EnableVSRenderer(VisualStudioToolStripExtender.VsVersion.Vs2012, vS2012LightTheme1);
                    break;

                case "VS2015Blue":
                    this.dockPanel.Theme = this.vS2015BlueTheme1;
                    this.EnableVSRenderer(VisualStudioToolStripExtender.VsVersion.Vs2015, vS2015BlueTheme1);
                    break;

                case "VS2015Light":
                    this.dockPanel.Theme = this.vS2015LightTheme1;
                    this.EnableVSRenderer(VisualStudioToolStripExtender.VsVersion.Vs2015, vS2015LightTheme1);
                    break;

                case "VS2015Dark":
                    this.dockPanel.Theme = this.vS2015DarkTheme1;
                    this.EnableVSRenderer(VisualStudioToolStripExtender.VsVersion.Vs2015, vS2015DarkTheme1);
                    break;
            }
            if (dockPanel.Theme.ColorPalette != null)
            {
                statusBar.BackColor = dockPanel.Theme.ColorPalette.MainWindowStatusBarDefault.Background;
            }
        }
        private void EnableVSRenderer(VisualStudioToolStripExtender.VsVersion version, ThemeBase theme)
        {
            vsToolStripExtender1.SetStyle(mainMenu, version, theme);
            vsToolStripExtender1.SetStyle(statusBar, version, theme);
        }
        public void OpenForm(string nodeName)
        {
            switch (nodeName)
            {
                #region StudentNavigation
                case "NodeNewRegistration":
                    if (StudentAdmissionForm.instanceFrmStudentRegistration == null)
                    {
                        StudentAdmissionForm.instanceFrmStudentRegistration = new StudentAdmissionForm();
                        StudentAdmissionForm.instanceFrmStudentRegistration.Show(dockPanel);
                    }
                    else
                        StudentAdmissionForm.instanceFrmStudentRegistration.Focus();
                    break;

                case "NodeStudentFine":
                    if (StudentFineForm.instanceFrm == null)
                    {
                        StudentFineForm.instanceFrm = new StudentFineForm();
                        StudentFineForm.instanceFrm.Show(dockPanel);
                    }
                    else
                        StudentFineForm.instanceFrm.Focus();
                    break;

                case "NodePromoteStudent":
                    if (StudentPromotionForm.instanceFrm == null)
                    {
                        StudentPromotionForm.instanceFrm = new StudentPromotionForm();
                        StudentPromotionForm.instanceFrm.Show(dockPanel);
                    }
                    else
                        StudentPromotionForm.instanceFrm.Focus();
                    break;
                case "NodeTC":
                    if (Student_TC_Form.instanceFrm == null)
                    {
                        Student_TC_Form.instanceFrm = new Student_TC_Form();
                        Student_TC_Form.instanceFrm.Show(dockPanel);
                    }
                    else
                        Student_TC_Form.instanceFrm.Focus();
                    break;
                #endregion

                #region FeeNavigation
                case "NodeFeeDeposit":
                    if (FeeDepositForm.instanceFrm == null)
                    {
                        FeeDepositForm.instanceFrm = new FeeDepositForm();
                        FeeDepositForm.instanceFrm.Show(dockPanel);
                    }
                    else
                        FeeDepositForm.instanceFrm.Focus();
                    break;

                case "NodeClassFeeSetting":
                    if (ClassFeeSettingForm.instanceFrm == null)
                    {
                        ClassFeeSettingForm.instanceFrm = new ClassFeeSettingForm();
                        ClassFeeSettingForm.instanceFrm.Show(dockPanel);
                    }
                    else
                        ClassFeeSettingForm.instanceFrm.Focus();
                    break;

                case "NodeFeeSetting":
                    if (FeeSettingForm.instanceFrm == null)
                    {
                        FeeSettingForm.instanceFrm = new FeeSettingForm();
                        FeeSettingForm.instanceFrm.Show(dockPanel);
                    }
                    else
                        FeeSettingForm.instanceFrm.Focus();
                    break;

                case "NodeGenerateFee":
                    GenerateMonthlyFeeForm connectionManagerForm = new GenerateMonthlyFeeForm();
                    connectionManagerForm.StartPosition = FormStartPosition.CenterParent;
                    connectionManagerForm.ShowDialog(this);
                    break;

                case "NodeFeeType":
                    if (FeeTypeForm.instanceFrm == null)
                    {
                        FeeTypeForm.instanceFrm = new FeeTypeForm();
                        FeeTypeForm.instanceFrm.Show(dockPanel);
                    }
                    else
                        FeeTypeForm.instanceFrm.Focus();
                    break;

                case "NodeTransportFee":
                    if (TransportChargesForm.instanceFrm == null)
                    {
                        TransportChargesForm.instanceFrm = new TransportChargesForm();
                        TransportChargesForm.instanceFrm.Show(dockPanel);
                    }
                    else
                        TransportChargesForm.instanceFrm.Focus();
                    break;

                case "NodePurchasesItem":
                    if (FeePurchasesItem.instanceFrm == null)
                    {
                        FeePurchasesItem.instanceFrm = new FeePurchasesItem();
                        FeePurchasesItem.instanceFrm.Show(dockPanel);
                    }
                    else
                        FeePurchasesItem.instanceFrm.Focus();
                    break;

                case "NodeAdvancePay":
                    if (Advance_Fee_Paid_Form.instanceFrm == null)
                    {
                        Advance_Fee_Paid_Form.instanceFrm = new Advance_Fee_Paid_Form();
                        Advance_Fee_Paid_Form.instanceFrm.Show(dockPanel);
                    }
                    else
                        Advance_Fee_Paid_Form.instanceFrm.Focus();
                    break;
                #endregion

                #region ExpensesNavigation
                case "NodeExpenses":
                    if (DailyExpensesForm.instanceFrm == null)
                    {
                        DailyExpensesForm.instanceFrm = new DailyExpensesForm();
                        DailyExpensesForm.instanceFrm.Show(dockPanel);
                    }
                    else
                        DailyExpensesForm.instanceFrm.Focus();
                    break;

                case "NodeSchoolDetails":
                    if (SchoolDetailsForm.instanceFrm == null)
                    {
                        SchoolDetailsForm.instanceFrm = new SchoolDetailsForm();
                        SchoolDetailsForm.instanceFrm.Show(dockPanel);
                    }
                    else
                        SchoolDetailsForm.instanceFrm.Focus();
                    break;
                #endregion

                #region SchoolNavigation

                case "NodeExpensesReport":
                    if (ExpensesReportForm.instanceFrm == null)
                    {
                        ExpensesReportForm.instanceFrm = new ExpensesReportForm();
                        ExpensesReportForm.instanceFrm.Show(dockPanel);
                    }
                    else
                        ExpensesReportForm.instanceFrm.Focus();
                    break;

                case "NodeStudentClassWiseReport":
                    if (ReportClassWiseStudentForm.instanceFrm == null)
                    {
                        ReportClassWiseStudentForm.instanceFrm = new ReportClassWiseStudentForm();
                        ReportClassWiseStudentForm.instanceFrm.Show(dockPanel);
                    }
                    else
                        ReportClassWiseStudentForm.instanceFrm.Focus();
                    break;

                case "node_SMS_all_class":
                    if (Send_SMS_All_Class_Form.instanceFrm == null)
                    {
                        Send_SMS_All_Class_Form.instanceFrm = new Send_SMS_All_Class_Form();
                        Send_SMS_All_Class_Form.instanceFrm.Show(dockPanel);
                    }
                    else
                        Send_SMS_All_Class_Form.instanceFrm.Focus();
                    break;

                case "node_Send_SMS":
                    if (Send_SMS_To_Number_Form.instanceFrm == null)
                    {
                        Send_SMS_To_Number_Form.instanceFrm = new Send_SMS_To_Number_Form();
                        Send_SMS_To_Number_Form.instanceFrm.Show(dockPanel);
                    }
                    else
                        Send_SMS_To_Number_Form.instanceFrm.Focus();
                    break;

                case "node_backup":
                    DatabaseBackUpForm backupDB = new DatabaseBackUpForm();
                    backupDB.StartPosition = FormStartPosition.CenterParent;
                    backupDB.ShowDialog(this);
                    break;
                #endregion

                #region ReportNavigation

                case "NodeMonthlyFeeReceipt":
                    if (MonthlyFeeReceiptForm.instanceFrm == null)
                    {
                        MonthlyFeeReceiptForm.instanceFrm = new MonthlyFeeReceiptForm();
                        MonthlyFeeReceiptForm.instanceFrm.Show(dockPanel);
                    }
                    else
                        MonthlyFeeReceiptForm.instanceFrm.Focus();
                    break;

                case "NodeStudentFeeInfoReceipt":
                    if (Student_Fee_info_Report_Form.instanceFrm == null)
                    {
                        Student_Fee_info_Report_Form.instanceFrm = new Student_Fee_info_Report_Form();
                        Student_Fee_info_Report_Form.instanceFrm.Show(dockPanel);
                    }
                    else
                        Student_Fee_info_Report_Form.instanceFrm.Focus();
                    break;

                case "NodeDailyCollection":
                    if (ReportDailyFeeCollectionFeeForm.instanceFrm == null)
                    {
                        ReportDailyFeeCollectionFeeForm.instanceFrm = new ReportDailyFeeCollectionFeeForm();
                        ReportDailyFeeCollectionFeeForm.instanceFrm.Show(dockPanel);
                    }
                    else
                        ReportDailyFeeCollectionFeeForm.instanceFrm.Focus();
                    break;

                case "NodeClassWiseDues":
                    if (ReportClassWiseDuesForm.instanceFrm == null)
                    {
                        ReportClassWiseDuesForm.instanceFrm = new ReportClassWiseDuesForm();
                        ReportClassWiseDuesForm.instanceFrm.Show(dockPanel);
                    }
                    else
                        ReportClassWiseDuesForm.instanceFrm.Focus();
                    break;

                case "NodeTCReport":


                    break;

                case "NodePromotedStudent":
                    if (ReportStudentPromotion.instanceFrm == null)
                    {
                        ReportStudentPromotion.instanceFrm = new ReportStudentPromotion();
                        ReportStudentPromotion.instanceFrm.Show(dockPanel);
                    }
                    else
                        ReportStudentPromotion.instanceFrm.Focus();
                    break;

                case "Node_Fee_Deposit_List":
                    if (Fee_Deposite_By_Date_Form.instanceFrm == null)
                    {
                        Fee_Deposite_By_Date_Form.instanceFrm = new Fee_Deposite_By_Date_Form();
                        Fee_Deposite_By_Date_Form.instanceFrm.Show(dockPanel);
                    }
                    else
                        Fee_Deposite_By_Date_Form.instanceFrm.Focus();
                    break;

                    #endregion
            }
        }
        private void CreateStatusBar()
        {
            StatusBar mainStatusBar = new StatusBar();
            StatusBarPanel statusPanel = new StatusBarPanel();
            StatusBarPanel datetimePanel = new StatusBarPanel();
            mainStatusBar.Dock = DockStyle.Bottom;
            // Set first panel properties and add to StatusBar
            statusPanel.BorderStyle = StatusBarPanelBorderStyle.Sunken;
            statusPanel.Text = "Application started. No action yet.";
            statusPanel.ToolTipText = "Last Activity";
            statusPanel.AutoSize = StatusBarPanelAutoSize.Spring;
            mainStatusBar.Panels.Add(statusPanel);

            // Set second panel properties and add to StatusBar
            datetimePanel.BorderStyle = StatusBarPanelBorderStyle.Raised;
            datetimePanel.ToolTipText = "DateTime: " + System.DateTime.Today.ToString();
            datetimePanel.Text = System.DateTime.Today.ToLongDateString();
            datetimePanel.AutoSize = StatusBarPanelAutoSize.Contents;
            mainStatusBar.Panels.Add(datetimePanel);
            mainStatusBar.ShowPanels = true;
            // Add StatusBar to Form controls

            if (dockPanel.Theme.ColorPalette != null)
            {
                mainStatusBar.BackColor = System.Drawing.Color.AliceBlue;
            }
            this.Controls.Add(mainStatusBar);
        }
        #endregion

        #region Event Handlers
        private void menuItemExit_Click(object sender, System.EventArgs e)
        {
            Close();
        }
        private void menuItemToolbox_Click(object sender, System.EventArgs e)
        {
            m_toolbox.Show(dockPanel);
        }
        private void menuItemAbout_Click(object sender, System.EventArgs e)
        {
            AboutPoductForm aboutPoductForm = new AboutPoductForm();
            aboutPoductForm.StartPosition = FormStartPosition.CenterParent;
            aboutPoductForm.ShowDialog(this);
        }
        private void menuItemFile_Popup(object sender, System.EventArgs e)
        {
            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                menuItemClose.Enabled =
                    menuItemCloseAll.Enabled =
                    menuItemCloseAllButThisOne.Enabled = (ActiveMdiChild != null);
            }
            else
            {
                menuItemClose.Enabled = (dockPanel.ActiveDocument != null);
                menuItemCloseAll.Enabled =
                    menuItemCloseAllButThisOne.Enabled = (dockPanel.DocumentsCount > 0);
            }
        }
        private void menuItemClose_Click(object sender, System.EventArgs e)
        {
            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
                ActiveMdiChild.Close();
            else if (dockPanel.ActiveDocument != null)
                dockPanel.ActiveDocument.DockHandler.Close();
        }
        private void menuItemCloseAll_Click(object sender, System.EventArgs e)
        {
            CloseAllDocuments();
        }
        private void UIParent_Load(object sender, System.EventArgs e)
        {
            //TO DO::::
            timer.Start();
            timer_Tick(null, null);
        }
        private void UIParent_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Exit();
        }
        private void menuItemStatusBar_Click(object sender, System.EventArgs e)
        {
            statusBar.Visible = menuItemStatusBar.Checked = !menuItemStatusBar.Checked;
        }
        private void CreateStandardControls()
        {
            m_toolbox = new LeftNavForm();
            m_toolbox.MDIForm = this;
        }
        private void menuItemCloseAllButThisOne_Click(object sender, System.EventArgs e)
        {
            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                Form activeMdi = ActiveMdiChild;
                foreach (Form form in MdiChildren)
                {
                    if (form != activeMdi)
                        form.Close();
                }
            }
            else
            {
                foreach (IDockContent document in dockPanel.DocumentsToArray())
                {
                    if (!document.DockHandler.IsActivated)
                        document.DockHandler.Close();
                }
            }
        }
        private void exitWithoutSavingLayout_Click(object sender, EventArgs e)
        {
            //   m_bSaveLayout = false;
            Close();
            //  m_bSaveLayout = true;
        }
        private void UIParent_FormClosing(object sender, FormClosingEventArgs e)
        {
            // CloseAllDocuments();
            // Close();
        }
        private void expandAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LeftNavForm.LeftNavBar.treeLeftMenuItem.ExpandAll();
        }
        private void collapseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LeftNavForm.LeftNavBar.treeLeftMenuItem.CollapseAll();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            //if (!IsConnectedToInternet())
            //{
            //    toolStripStatusConnet.Text = "Not Connected";
            //    if (CustomMessageBox.instanceFrm == null)
            //    {
            //        CustomMessageBox.instanceFrm = new CustomMessageBox("Looks like there is no internet connection.\nPlease check the network.");
            //        CustomMessageBox.instanceFrm.ShowDialog(this);
            //    }
            //    else
            //    {
            //        CustomMessageBox.instanceFrm.Focus();
            //    }
            //}
            //else
            //    toolStripStatusConnet.Text = "Connected";
        }
        private void timerClock_Tick(object sender, EventArgs e)
        {
            toolStripStatusTime.Text = DateTime.Now.ToString("hh:mm tt");
        }
        #endregion
    }
}
