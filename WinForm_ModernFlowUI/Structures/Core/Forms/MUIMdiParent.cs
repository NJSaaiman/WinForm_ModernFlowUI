using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using ModernUI.Structures.Style;
using ModernUI.Structures.Extensions;
using System.Windows.Forms;
using ModernUI.Structures.Interfaces;

namespace ModernUI.Structures.Core.Forms
{
    public class MUIMdiParent : MUIBaseForm
    {
        public MUIMdiParent()
            : this(new DefaultStyle(), new Size(600,600))
        {
            
        }
        public MUIMdiParent(IStyleManager manager, Size size)
            : base(manager, size)
        {
            this.IsMdiContainer = true;
            Control[] controls = this.GetControlsByType(typeof(MdiClient));
            foreach (Control item in controls)
            {
                item.BackColor = StyleManager.MdiParentBackColor;
            }

            this.MainMenuStrip = new MenuStrip() { Visible = false};
            this.Load += MUIMdiParent_Load;
        }

        void MUIMdiParent_Load(object sender, EventArgs e)
        {
            CreateTitleBar();
            RegisterEvents();
        }
    }
}
