using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace eVidyalaya.Views.Fee
{
    public partial class Fee_Generate_Form :DockContent
    {
        public static Fee_Generate_Form instanceFrm;
        public Fee_Generate_Form()
        {
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.Dpi;
        }
        private void Fee_Generate_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Fee_Generate_Form.instanceFrm = null;
        }
    }
}
