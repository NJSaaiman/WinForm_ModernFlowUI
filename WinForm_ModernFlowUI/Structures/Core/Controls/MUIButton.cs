using ModernUI.Structures.Interfaces;
using ModernUI.Structures.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ModernUI.Structures.Core.Controls
{
    

    public class MUIButton : Button, IControl
    {
        public event EventHandler BeforeStyleUpdate;
        public event EventHandler StyleUpdated;

        private IStyleManager _styleManager;
        public IStyleManager StyleManager
        {
            get
            {
                return _styleManager;
            }
            set
            {
                if (BeforeStyleUpdate != null)
                {
                    BeforeStyleUpdate(this, EventArgs.Empty);
                }

                _styleManager = value;
                ManagerUpdated();

                if (StyleUpdated != null)
                {
                    StyleUpdated(this, EventArgs.Empty);
                }
            }
        }

        public MUIButton()
            : this(new DefaultStyle())
        { }

        public MUIButton(IStyleManager manager)
        {
            StyleManager = manager;
        }


        private void ManagerUpdated()
        {
            this.BackColor = StyleManager.ButtonStyle.BackColor;
            this.ForeColor = StyleManager.ButtonStyle.ForeColor;
        }


        
    }

   
}
