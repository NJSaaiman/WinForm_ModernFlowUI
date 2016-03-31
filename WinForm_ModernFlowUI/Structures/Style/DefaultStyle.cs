using ModernUI.Structures.Interfaces;
using System.Drawing;

namespace ModernUI.Structures.Style
{


    public class DefaultStyle : IStyleManager
    {
        public virtual System.Drawing.Color BackColor { get { return Color.Black; } set { } }
        public virtual System.Drawing.Color ForeColor { get { return Color.WhiteSmoke; } set { } }
        public virtual Color TitleBarBackColor { get { return Color.WhiteSmoke; } set { } }
        public virtual Color TitleBarForeColor { get { return Color.Black; } set { } }
        public virtual Color MdiParentBackColor { get { return Color.Wheat; } set { } }
        public virtual Buttons ButtonStyle { get { return new Buttons();} set {}}


        public class Buttons
        {
            public virtual System.Drawing.Color BackColor { get { return Color.Black; } set { } }
            public virtual System.Drawing.Color ForeColor { get { return Color.WhiteSmoke; } set { } }
        }
    }
}