using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ModernUI.Structures.Extensions
{
   public static class FormExtensions
    {
       public static Control[] GetControlsByType(this Form form, Type controlType)
       {
           List<Control> controls = new List<Control>();
           foreach (Control control in form.Controls)
           {
               if (control.GetType() == controlType)
               {
                   controls.Add(control);
               }
           }

           return controls.ToArray();
       }
    }
}
