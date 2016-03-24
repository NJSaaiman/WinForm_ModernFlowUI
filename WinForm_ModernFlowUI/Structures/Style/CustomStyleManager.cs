using System.Drawing;

namespace ModernUI.Structures.Style
{
    public class DarkStyle : DefaultStyle
    {

        private Color _titleBarForeColor;
        private Color _foreColor;
        private Color _backColor;
        private Color _titleBackColor;
        public override Color BackColor
        {
            get
            {
                if (_backColor.IsEmpty)
                {
                    _backColor = base.BackColor;
                }
                return _backColor;
            }
            set
            {
                _backColor = value;
            }
        }

        public override Color ForeColor
        {
            get
            {
                if (_foreColor.IsEmpty)
                {
                    _foreColor = base.ForeColor;
                }
                return _foreColor;
            }
            set
            {
                _foreColor = value;
            }
        }

        public override Color TitleBarBackColor
        {
            get
            {
               if (_titleBackColor.IsEmpty)
               {
                   _titleBackColor = base.TitleBarBackColor;
               }
               return _titleBackColor;
            }
            set
            {
                _titleBackColor = value;
            }
        }

        public override Color TitleBarForeColor
        {
            get
            {
                if (_titleBarForeColor.IsEmpty)
                {
                    _titleBarForeColor = base.TitleBarForeColor;
                }
                return _titleBarForeColor;
            }
            set
            {
                _titleBarForeColor = value;
            }
        }

    }
}
