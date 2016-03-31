using System.Drawing;
using ModernUI.Structures.Core.Forms.MessageBoxes;
using ModernUI.Structures.Style;
using ModernUI.Structures.Interfaces;

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
            IStyleManager manager = new DarkStyle() { BackColor = Color.Aqua, ForeColor = Color.PaleGreen, MdiParentBackColor = Color.Olive, TitleBarBackColor = Color.Yellow, TitleBarForeColor = Color.Black };
            Form1 frm = new Form1();
            frm.StyleManager = manager;
            frm.MdiParent = this;
            //frm.Dock = System.Windows.Forms.DockStyle.Left;
            frm.Show();

            MUIMessageBox msgb = new MUIMessageBox(System.Windows.Forms.MessageBoxButtons.YesNo);
            msgb.StyleManager = manager;

            msgb.Text = "messgae box";
            if (msgb.Show() == System.Windows.Forms.DialogResult.Yes)
            {
                Form1 frm2 = new Form1();
                frm2.StyleManager = manager;
                frm2.MdiParent = this;
                frm2.Dock = System.Windows.Forms.DockStyle.Bottom;
                frm2.Show();
            }

        }
    }
}
