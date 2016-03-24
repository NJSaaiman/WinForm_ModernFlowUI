using ModernUI.Structures.Style;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Extended;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ModernUI.Structures.Core.Forms
{
    public partial class MUIBaseForm : Form
    {
        private Size _clientSize;
        private Label _title;

        [Description("Title"), Category("Modern UI")]
        public Label Title
        {
            get
            {
                if (_title == null)
                {
                    _title = new Label();
                }
                return _title;
            }
            set
            {
                _title = value;
            }
        }

        [Description("Form Label"), Category("Modern UI")]
        public new string Text
        {
            get
            {

                return Title.Text;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    value = "";
                }
                Title.Text = value;
                base.Text = value;
            }
        }

        private PictureBox minimise = new PictureBox(); // this doesn't even have to be a label!
        private PictureBox maximise = new PictureBox(); // this will simulate our this.maximise box
        private PictureBox close = new PictureBox(); // simulates the this.close box

        private bool drag = false; // determine if we should be moving the form
        private Point startPoint = new Point(0, 0); // also for the moving
        private IStyleManager _styleManager;
        private Size _size;

        public MUIBaseForm()
            : this(new DefaultStyle(), new Size(600, 600)) { }

        public MUIBaseForm(IStyleManager manager, Size size)
            : base()
        {
            InitializeComponent();
            Size = size;
            StyleManager = manager;



            this.Load += MUIBaseForm_Load;
            this.FormClosing += MUIBaseForm_FormClosing;
            
        }

        void MUIBaseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Resize -= MUIBaseForm_Resize;
            this.Paint -= MessageBox_Paint;
        }

        void MUIBaseForm_Load(object sender, EventArgs e)
        {
            this.Resize += MUIBaseForm_Resize;
            this.Paint += MessageBox_Paint;
            
        }

        void MUIBaseForm_Resize(object sender, EventArgs e)
        {
            //Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 10, 10));
            this.close.Location = new Point(this.Width - 30, 3);
            this.Title.Width = this.Width;
            this.maximise.Location = new Point(this.close.Left - 30, 3);
            this.minimise.Location = new Point(this.maximise.Left - 30, 3); // give it a default location

        }

        [Description("Size"), Category("Modern UI")]
        public new Size Size
        {
            get
            {
                return _size;
            }
            set
            {
                if (value != null)
                {
                    this.Width = value.Width;
                    this.Height = value.Height;


                }
                _size = value;
                //if (ClientSize != value)
                //{
                //    ClientSize = value;
                //}
            }
        }

        [Description("A System.Windows.Forms.FormBorderStyle that represents the style of border to display for the form. The value is FormBorderStyle.None."), Category("Modern UI")]
        public new FormBorderStyle FormBorderStyle
        {
            get
            {
                return base.FormBorderStyle;
            }
            private set
            {
                base.FormBorderStyle = value;
            }
        }


        [Description("Client Size"), Category("Modern UI")]
        public new Size ClientSize
        {
            get
            {
                return _clientSize;
            }
            set
            {
                if (value != null)
                {

                    base.ClientSize = value;


                }
                _clientSize = value;
                //if (Size != value)
                //{
                //    Size = value;
                //}
            }
        }

        [Description("Style Manager"), Category("Modern UI")]
        public IStyleManager StyleManager
        {
            get
            {
                return _styleManager;
            }
            set
            {
                if (value != null)
                {
                    this.BackColor = value.BackColor;
                    this.ForeColor = value.ForeColor;
                }
                _styleManager = value;
            }
        }

        #region Title bar
        protected void CreateTitleBar()
        {
            int widthOffset = this.WindowState == FormWindowState.Maximized ? this.Width : Size.Width;
            if (this.Modal)
            {
                widthOffset = this.Width;
            }

            this.Title.Location = new Point(0,0); // assign the location to the form location
            this.Title.Width = widthOffset; // make it the same width as the form
            this.Title.AutoSize = false;
            this.Title.Height = 30; // give it a default height (you may want it taller/shorter)
            this.Title.Text = this.Text;
            this.Title.TextAlign = ContentAlignment.MiddleLeft;
            this.Title.BackColor = StyleManager.TitleBarBackColor;
            this.Title.ForeColor = StyleManager.TitleBarForeColor;
            this.Controls.Add(this.Title); // add it to the form's controls, so it gets displayed

            if (ControlBox)
            {
                this.close.Text = "Close";
                this.close.Location = new Point(widthOffset - 30, 3);
                this.close.BackgroundImage = Default_Images.Form_Close;
                this.close.BackColor = StyleManager.TitleBarBackColor;
                this.close.SizeMode = PictureBoxSizeMode.AutoSize;
                this.close.Width = 24; // this is just to make it fit nicely
                this.close.Height = 24;
                this.close.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                this.Controls.Add(this.close);
                this.close.BringToFront();

                this.close.MouseEnter += new EventHandler(Control_MouseEnter);
                this.close.MouseLeave += new EventHandler(Control_MouseLeave);
                this.close.MouseClick += new MouseEventHandler(Control_MouseClick);

                if (MaximizeBox)
                {
                    this.maximise.Text = "Maximise";
                    this.maximise.Location = new Point(this.close.Left - 30, 3);
                    this.maximise.BackgroundImage = this.WindowState != FormWindowState.Maximized ? Default_Images.Form_Minimize : Default_Images.Form_Maximize;
                    this.maximise.BackColor = StyleManager.TitleBarBackColor; // remember, we want it to match the background
                    this.maximise.Width = 24;
                    this.maximise.Height = 24;
                    this.maximise.SizeMode = PictureBoxSizeMode.AutoSize;
                    this.maximise.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                    this.Controls.Add(this.maximise); // add it to the form
                    this.maximise.BringToFront();

                    this.maximise.MouseEnter += new EventHandler(Control_MouseEnter);
                    this.maximise.MouseLeave += new EventHandler(Control_MouseLeave);
                    this.maximise.MouseClick += new MouseEventHandler(Control_MouseClick);
                }

                if (MinimizeBox)
                {
                    this.minimise.Text = "Minimise"; // Doesn't have to be
                    this.minimise.Location = new Point(this.maximise.Left - 30, 3); // give it a default location
                    this.minimise.BackgroundImage = Default_Images.Form_ToTaskbar;
                    this.minimise.BackColor = StyleManager.TitleBarBackColor;  // remember, we want it to match the background
                    this.minimise.Width = 24;
                    this.minimise.Height = 24;
                    this.minimise.SizeMode = PictureBoxSizeMode.AutoSize;
                    this.minimise.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                    this.Controls.Add(this.minimise); // add it to the form's controls
                    this.minimise.BringToFront(); // bring it to the front, to display it above the picture box

                    this.minimise.MouseEnter += new EventHandler(Control_MouseEnter);
                    this.minimise.MouseLeave += new EventHandler(Control_MouseLeave);
                    this.minimise.MouseClick += new MouseEventHandler(Control_MouseClick);
                } 
            }

            
            

            this.Title.MouseDown += new MouseEventHandler(Title_MouseDown);
            this.Title.MouseUp += new MouseEventHandler(Title_MouseUp);
            this.Title.MouseMove += new MouseEventHandler(Title_MouseMove);
        }

        private void Control_MouseEnter(object sender, EventArgs e)
        {
            if (sender.Equals(this.close))
                this.close.ForeColor = Color.White;
            else if (sender.Equals(this.maximise))
                this.maximise.ForeColor = Color.White;
            else // it's the minimise label
                this.minimise.ForeColor = Color.White;
        }

        private void Control_MouseLeave(object sender, EventArgs e)
        { // return them to their default colours
            if (sender.Equals(this.close))
                this.close.ForeColor = Color.Red;
            else if (sender.Equals(this.maximise))
                this.maximise.ForeColor = Color.Red;
            else // it's the minimise label
                this.minimise.ForeColor = Color.Red;
        }

        private void Control_MouseClick(object sender, MouseEventArgs e)
        {
            if (sender.Equals(this.close))
                this.Close(); // close the form
            else if (sender.Equals(this.maximise))
            { // maximise is more interesting. We need to give it different functionality,
                // depending on the window state (Maximise/Restore)
                if (this.WindowState != FormWindowState.Maximized)
                {
                    this.WindowState = FormWindowState.Maximized;
                    this.maximise.Text = "Restore"; // change the text
                    this.maximise.BackgroundImage = Default_Images.Form_Minimize;
                    this.Title.Width = this.Width; // stretch the title bar

                }
                else // we need to restore
                {
                    this.WindowState = FormWindowState.Normal;
                    this.maximise.Text = "Maximise";
                    this.maximise.BackgroundImage = Default_Images.Form_Maximize;
                }

                // Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 10, 10));
            }
            else // it's the minimise label
                this.WindowState = FormWindowState.Minimized; // minimise the form
        }

        void Title_MouseUp(object sender, MouseEventArgs e)
        {
            this.drag = false;
        }

        void Title_MouseDown(object sender, MouseEventArgs e)
        {
            int offset = (this.IsMdiChild ? 30 : 0);
            this.startPoint = new Point(e.Location.X, e.Location.Y - offset);
            this.drag = true;
        }

        void Title_MouseMove(object sender, MouseEventArgs e)
        {
            int offset = (this.IsMdiChild ?  30 : 0);
            if (this.drag)
            { // if we should be dragging it, we need to figure out some movement
                Point p1 = new Point(e.X, e.Y - offset);
                Point p2 = this.PointToScreen(p1);
                Point p3 = new Point(p2.X - this.startPoint.X,
                                     p2.Y - this.startPoint.Y - offset);
                this.Location = p3;
            }
        }

        #endregion
        void MessageBox_Paint(object sender, PaintEventArgs e)
        {
            ExtendedGraphics g = new ExtendedGraphics(e.Graphics);

            ControlPaint.DrawBorder(g.Graphics, this.ClientRectangle, StyleManager.BackColor, ButtonBorderStyle.Solid);
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect, // x-coordinate of upper-left corner
            int nTopRect, // y-coordinate of upper-left corner
            int nRightRect, // x-coordinate of lower-right corner
            int nBottomRect, // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
         );

        protected int GetTitleBarHeigth()
        {
            Rectangle screenRectangle = RectangleToScreen(this.ClientRectangle);

            return screenRectangle.Top - this.Top;
        }



    }
}
