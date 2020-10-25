using School.App.Models.Fee;
using School.App.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace eVidyalaya
{
    public partial class GenerateMonthlyFeeForm : DockContent
    {
        FeeGenerate feeGenerate;
        List<Month_Model> generatedMonthList;
        Dictionary<int, CheckBox> dicCheckBox;

        public GenerateMonthlyFeeForm()
        {
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.Dpi;
            IsMonthlyFeeGenerated();
        }
        private void btnGenerateFee_Click(object sender, EventArgs e)
        {
            #region Count_of_Enable_Checked_Check_Box
            int EnableCheckBoxCount = 0;

            foreach (Control control in this.panelMonths.Controls)
            {
                if (control.GetType() == typeof(CheckBox))
                {
                    CheckBox ckBox = (CheckBox)control;
                    if (ckBox.Enabled == true && ckBox.Checked == true)
                        EnableCheckBoxCount++;
                }
            }

            if (EnableCheckBoxCount > 3)
            {
                MessageBox.Show("You can only generate fee of maximum 3 months.", "Generate Fee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            #endregion

            #region Validation
            int countMonths = dicCheckBox.Where(x => x.Value.Checked == false).Count();
            string month_Value = GetCommaSepratedMonthValue();
            if (countMonths > 0)
            {
                MessageBox.Show("Please select month to generate fee.", "Generate Fee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            #endregion

            try
            {
                btnGenerateFee.Enabled = false;
                feeGenerate = new FeeGenerate();
                lblPleaseWait.Visible = true;
                short returnValue = feeGenerate.GenerateMonthlyFee(month_Value, Common.Get_Current_Academic_Year());
                switch (returnValue)
                {
                    case 1:
                        MessageBox.Show("Fee Generated Successfully.", "Generate Fee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        IsMonthlyFeeGenerated();
                        break;
                    case 0:
                        MessageBox.Show("Fee Already Generated For This Month.", "Generate Fee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case -1:
                        MessageBox.Show("Error: Please Contact To Admin.", "Generate Fee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Please Contact To Admin.", "Generate Fee", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                lblPleaseWait.Visible = false;
            }
        }
        private void IsMonthlyFeeGenerated()
        {
            int LastMonthNo = 0;
            Int32 currentAcademicYear = Common.Get_Current_Academic_Year();

            feeGenerate = new FeeGenerate();
            string returnValue = feeGenerate.IsMonthlyFeeGenerated(currentAcademicYear, out LastMonthNo);
            generatedMonthList = feeGenerate.GetPurchasesFeeList(currentAcademicYear);
            generatedMonthList = generatedMonthList ?? new List<Month_Model>();

            DisableMonthCheckBox(generatedMonthList);

            if (!string.IsNullOrWhiteSpace(returnValue))
            {
                bool isGenerated = returnValue.ToLower() == "true" ? true : false;
                if (isGenerated)
                    lblMessage.Text = "Fee for the month is already generated.";
                else
                    lblMessage.Text = "Fee for the month is not generated. Please select month to generate\nmonthly fee.";
            }
            /* Here 15 is eqivalent to MARCH 
             *IF Month Value from DB IS 15(March)
             */
            //if (LastMonthNo == 15)
            //    btnGenerateFee.Enabled = false;
            //else
            //    btnGenerateFee.Enabled = true;
        }
        private void DisableMonthCheckBox(List<Month_Model> generatedMonthList)
        {
            dicCheckBox = GetCheckBoxDictionary();

            foreach (var item in generatedMonthList)
            {
                dicCheckBox.ToList().Where(x => x.Key == item.Month_Value).
                    Select(s => { s.Value.Checked = true; s.Value.Enabled = false; return s; }).ToList();
            }

            if (dicCheckBox.Where(x => x.Value.Checked == false).Count() > 0)
            {
                btnGenerateFee.Enabled = true;
            }
            else
            {
                btnGenerateFee.Enabled = false;
            }
        }
        private Dictionary<int, CheckBox> GetCheckBoxDictionary()
        {
            Dictionary<int, CheckBox> dicCheckBox = new Dictionary<int, CheckBox>();
            dicCheckBox.Add(4, chkApril);
            dicCheckBox.Add(5, chkMay);
            dicCheckBox.Add(6, chkJune);
            dicCheckBox.Add(7, chkJuly);
            dicCheckBox.Add(8, chkAugust);
            dicCheckBox.Add(9, chkSeptember);
            dicCheckBox.Add(10, chkOctober);
            dicCheckBox.Add(11, chkNovember);
            dicCheckBox.Add(12, chkDecember);
            dicCheckBox.Add(13, chkJanuary);
            dicCheckBox.Add(14, chkFebruary);
            dicCheckBox.Add(15, chkMarch);
            return dicCheckBox;
        }
        private string GetCommaSepratedMonthValue()
        {
            string monthsValues = string.Empty;
            foreach (Control control in this.panelMonths.Controls)
            {
                if (control.GetType() == typeof(CheckBox))
                {
                    CheckBox ckBox = (CheckBox)control;
                    if (ckBox.Enabled == true && ckBox.Checked == true)
                    {
                        switch (ckBox.Name)
                        {
                            case "chkApril":
                                monthsValues += "4,";
                                break;
                            case "chkMay":
                                monthsValues += "5,";
                                break;
                            case "chkJune":
                                monthsValues += "6,";
                                break;
                            case "chkJuly":
                                monthsValues += "7,";
                                break;
                            case "chkAugust":
                                monthsValues += "8,";
                                break;
                            case "chkSeptember":
                                monthsValues += "9,";
                                break;
                            case "chkOctober":
                                monthsValues += "10,";
                                break;
                            case "chkNovember":
                                monthsValues += "11,";
                                break;
                            case "chkDecember":
                                monthsValues += "12,";
                                break;
                            case "chkJanuary":
                                monthsValues += "13,";
                                break;
                            case "chkFebruary":
                                monthsValues += "14,";
                                break;
                            case "chkMarch":
                                monthsValues += "15,";
                                break;
                        }
                    }
                }
            }
            if (!string.IsNullOrEmpty(monthsValues))
                return monthsValues.Remove(monthsValues.LastIndexOf(','));
            else
                return string.Empty;
        }
    }
}
