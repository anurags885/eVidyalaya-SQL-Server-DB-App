using System.Collections.Generic;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.Linq;

namespace eVidyalaya
{
    public partial class LeftNavForm : DockContent
    {
        public UIParent MDIForm { get; set; }
        public static LeftNavForm LeftNavBar { get; set; }
        public LeftNavForm()
        {
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.Dpi;
            LeftNavBar = this;
            treeLeftMenuItem.ExpandAll();
        }
        private void treeLeftMenuItem_MouseClick(object sender, MouseEventArgs e)
        {
            TreeNode selectedNode = treeLeftMenuItem.HitTest(e.Location).Node;
            MDIForm.OpenForm(selectedNode.Name);
        }
    }
}