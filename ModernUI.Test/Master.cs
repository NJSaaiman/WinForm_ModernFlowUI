using System.Drawing;
using ModernUI.Structures.Core.Forms.MessageBoxes;

namespace ModernUI.Test
{
    public partial class Master : ModernUI.Structures.Core.Forms.MUIMdiParent
    {
        public Master()
        {
            InitializeComponent();

           
            this.Load += Master_Load;
            
        }

        void Master_Load(object sender, System.EventArgs e)
        {
            Form1 frm = new Form1();
            frm.MdiParent = this;
            //frm.Dock = System.Windows.Forms.DockStyle.Left;
            frm.Show();

            MUIMessageBox msgb = new MUIMessageBox(System.Windows.Forms.MessageBoxButtons.YesNo);
            
            msgb.Text = "messgae box";
            if (msgb.Show() == System.Windows.Forms.DialogResult.Yes)
            {
                Form1 frm2 = new Form1();
                frm2.MdiParent = this;
                frm2.Dock = System.Windows.Forms.DockStyle.Bottom;
                frm2.Show();
            }

        }
    }
}
