using ModernUI.Structures.Style;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Extended;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using ModernUI.Structures.Extensions;

namespace ModernUI.Structures.Core.Forms.MessageBoxes
{
    public class MUIMessageBox : MUIBaseForm
    {

        private const int BUTTON_WIDTH = 80;
        private const int BUTTON_HEIGHT = 20;

        public MUIMessageBox()
            : this(new DefaultStyle(), MessageBoxButtons.OKCancel, new Size(600, 300)) { }

        public MUIMessageBox(IStyleManager styleManager)
            : this(styleManager, MessageBoxButtons.OKCancel, new Size(600, 300)) { }

        public MUIMessageBox(MessageBoxButtons buttons)
            : this(new DefaultStyle(), buttons, new Size(600, 300)) { }

        public MUIMessageBox(IStyleManager styleManager, MessageBoxButtons buttons)
            : this(styleManager, buttons, new Size(600, 300)) { }

        public MUIMessageBox(IStyleManager styleManager, MessageBoxButtons buttons, Size size)
            : base(styleManager, size)
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.TopMost = true;
            Buttons = buttons;

            this.Load += MUIMessageBox_Load;
        }

        void MUIMessageBox_Load(object sender, EventArgs e)
        {
            CreateTitleBar();
            RegisterEvents();
            SetupButtons();
        }

        private MessageBoxButtons _buttons;
        public MessageBoxButtons Buttons
        {
            get
            {
                return _buttons;
            }
            set
            {
                _buttons = value;
            }
        }

        public new DialogResult Show()
        {
            return ShowDialog();
        }

        public new DialogResult ShowDialog()
        {
            return base.ShowDialog();
        }

        private void SetupButtons()
        {

            switch (Buttons)
            {
                case MessageBoxButtons.OK:
                    this.Controls.Add(CreateButton("OK", System.Windows.Forms.DialogResult.OK));
                    break;
                case MessageBoxButtons.OKCancel:
                    this.Controls.Add(CreateButton("OK", System.Windows.Forms.DialogResult.OK));
                    this.Controls.Add(CreateButton("CANCEL", System.Windows.Forms.DialogResult.Cancel));
                    break;
                case MessageBoxButtons.AbortRetryIgnore:
                    this.Controls.Add(CreateButton("ABORT", System.Windows.Forms.DialogResult.Abort));
                    this.Controls.Add(CreateButton("RETRY", System.Windows.Forms.DialogResult.Retry));
                    this.Controls.Add(CreateButton("IGNORE", System.Windows.Forms.DialogResult.Ignore));
                    break;
                case MessageBoxButtons.YesNoCancel:
                    this.Controls.Add(CreateButton("YES", System.Windows.Forms.DialogResult.Yes));
                    this.Controls.Add(CreateButton("NO", System.Windows.Forms.DialogResult.No));
                    this.Controls.Add(CreateButton("CANCEL", System.Windows.Forms.DialogResult.Cancel));
                    break;
                case MessageBoxButtons.YesNo:
                    this.Controls.Add(CreateButton("YES", System.Windows.Forms.DialogResult.Yes));
                    this.Controls.Add(CreateButton("NO", System.Windows.Forms.DialogResult.No));
                    break;
                case MessageBoxButtons.RetryCancel:
                    this.Controls.Add(CreateButton("RETRY", System.Windows.Forms.DialogResult.Retry));
                    this.Controls.Add(CreateButton("CANCEL", System.Windows.Forms.DialogResult.Cancel));
                    break;


            }


            //position the buttons in the middle,
            Control[] controls = this.GetControlsByType(typeof(Button));

            int left = controls[0].Left;
            int right = controls[controls.Length - 1].Left + controls[controls.Length - 1].Width;
            int width = right - left;

            int moveControl = ((this.Width / 2) - left) - (width / 2) + left;

            foreach (Control item in controls)
            {
                item.Left += (moveControl - left);
            }
        }

        private Button CreateButton(string caption, DialogResult returnResult)
        {
            Control[] controls = this.GetControlsByType(typeof(Button));
            int totalButtons = (int)Buttons;
            int buttonCount = controls.Length;
            Point location = new Point(0, Size.Height - (BUTTON_HEIGHT + GetTitleBarHeigth() + 20));
            if (buttonCount == 0)
            {
                location.X = (Size.Width / 2) - (BUTTON_WIDTH + 5);
            }
            else
            {
                location.X = controls[buttonCount - 1].Left + controls[buttonCount - 1].Width + 10;
            }

            return new Button()
                    {
                        Text = caption,
                        Size = new Size(BUTTON_WIDTH, BUTTON_HEIGHT),
                        Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                        Location = location,
                        FlatStyle = FlatStyle.Flat,
                        DialogResult = returnResult
                    };
        }

        private void InitializeComponent()
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }


    }
}

