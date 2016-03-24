using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using ModernUI.Structures.Style;

namespace ModernUI.Structures.Core.Forms
{
    public class MUIForm : MUIBaseForm
    {

        public MUIForm()
            : this (new DefaultStyle(), new Size(600,600))
        {

        }

        public MUIForm(Size size)
            : this(new DefaultStyle(), size)
        {

        }

        public MUIForm(IStyleManager manager)
            : this(manager, new Size(600, 600))
        {

        }

        public MUIForm(IStyleManager manager, Size size)
            : base(manager, size)
        {
            this.Load += MUIForm_Load;
        }

        void MUIForm_Load(object sender, EventArgs e)
        {
            CreateTitleBar();
        }


       
    }
}
