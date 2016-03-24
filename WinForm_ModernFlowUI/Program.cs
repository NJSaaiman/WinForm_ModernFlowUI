using ModernUI.Structures.Style;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using ModernUI.Structures.Core;
using System.Windows.Forms;
using ModernUI.Structures.Core.Forms;
using ModernUI.Structures.Core.Forms.MessageBoxes;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
    class Program
    {
        static void Main(string[] args)
        {
           
           
            Application.EnableVisualStyles();
            Task.Factory.StartNew(() => loadforms());

            //while (true) { }
           
        }

        private static void loadforms()
        {
            
        }
    }
}
