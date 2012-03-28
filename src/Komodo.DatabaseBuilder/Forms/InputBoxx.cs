using System;
using System.Drawing;
using System.Windows.Forms;
using Komodo.App.Properties;

namespace Komodo.App.Forms
{
    public partial class InputBoxx : Form
    {
        private const int MaxPrompts = 5;
        private const int YDelta = 46;
        private static readonly Point LabelOne = new Point(3,25);
        private static readonly Point TextBoxOne = new Point(6,48);

        private TextBox[] _textboxes;
        private Label[] _labels;

        public enum InputBoxButtons
        {
            OkCancel,
            OkClearCancel
        };

        public enum InputBoxIcon
        {
            Error,
            Question,
            Information,
            Warning,
            None
        };

        public InputBoxx()
        {
            InitializeComponent();
        }

        public DialogResult Show(string title, string prompt, string defaultText, out string value)
        {
            BuildView(title,new[]{prompt},new[]{defaultText},InputBoxButtons.OkCancel,InputBoxIcon.None,false);
            value = _results[0];
            var result = DialogResult;
            return result;
        }

        public DialogResult Show(string title, string[] prompts, string[] defaultText, out string[] value, InputBoxButtons buttons, InputBoxIcon icon, bool confirmation)
        {
            if (prompts.Length > MaxPrompts)
                throw new ArgumentOutOfRangeException("prompts");
            if(defaultText.Length > MaxPrompts)
                throw new ArgumentOutOfRangeException("defaultText");
            BuildView(title, prompts, defaultText, buttons, icon, confirmation);
            value = _results;
            var result = DialogResult;
            return result;
        }

        public DialogResult Show(string title, string[] prompts, string[] defaultText, out string[] value, InputBoxButtons buttons, InputBoxIcon icon)
        {
            return Show(title, prompts, defaultText, out value, buttons, icon, false);
        }

        public DialogResult Show(string title, string[] prompts, string[] defaultText, out string[] value, InputBoxButtons buttons)
        {
            return Show(title, prompts, defaultText, out value, buttons, InputBoxIcon.None, false);
        }

        public DialogResult Show(string title, string[] prompts, string[] defaultText, out string[] value)
        {
            return Show(title, prompts, defaultText, out value, InputBoxButtons.OkCancel, InputBoxIcon.None, false);
        }

        private string[] _results;
        private void OkBtnClick(object sender, EventArgs e)
        {
            var results = new string[_textboxes.Length];
            if (_confirmation)
            {
                var message = "";
                for (var i = 0; i < _textboxes.Length; i++)
                {
                    message += _prompts[i] + " - " + _textboxes[i].Text;
                }
                var confResult = MessageBox.Show(this, @"Please confirm", message, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                if (confResult == DialogResult.Cancel)
                {
                    DialogResult = DialogResult.Cancel;
                    Hide();
                }
                else if (confResult == DialogResult.Yes)
                {
                    DialogResult = DialogResult.OK;
                    for (int i = 0; i < _textboxes.Length; i++)
                    {
                        results[i] = _textboxes[i].Text;
                    }
                    _results = results;
                    Hide();
                }
                else if (confResult == DialogResult.No)
                {

                }
            }
            else
            {
                DialogResult = DialogResult.OK;
                for (int i = 0; i < _textboxes.Length; i++)
                {
                    results[i] = _textboxes[i].Text;
                }
                _results = results;
                Hide();
            }
        }

        private bool _confirmation;
        private string[] _prompts;
        private void BuildView(string title, string[] prompts, string[] defaultTest, InputBoxButtons buttons, InputBoxIcon icon, bool confirmation)
        {
            _confirmation = confirmation;
            _prompts = prompts;
            var textBoxWidth = icon == InputBoxIcon.None ? 448 : 340;
            Text = title;
            _textboxes = new TextBox[defaultTest.Length];
            _labels = new Label[defaultTest.Length];
            switch (icon)
            {
                case InputBoxIcon.None:
                    splitContainer1.Panel1Collapsed = true;
                    break;
                case InputBoxIcon.Information:
                    splitContainer1.Panel1Collapsed = false;
                    pictureBox1.Image = Resources.Information;
                    break;
                case InputBoxIcon.Error:
                    splitContainer1.Panel1Collapsed = false;
                    pictureBox1.Image = Resources.Error;
                    break;
                case InputBoxIcon.Question:
                    splitContainer1.Panel1Collapsed = false;
                    pictureBox1.Image = Resources.Question;
                    break;
                case InputBoxIcon.Warning:
                    splitContainer1.Panel1Collapsed = false;
                    pictureBox1.Image = Resources.Warning;
                    break;
            }
            switch (buttons)
            {
                case InputBoxButtons.OkCancel:
                    button3.Visible = false;
                    button1.Text = @"Ok";
                    button1.Click += (OkBtnClick);
                    break;
                case InputBoxButtons.OkClearCancel:
                    button3.Visible = true;
                    button3.Text = @"Ok";
                    button3.Click += (OkBtnClick);
                    button1.Text = @"Clear";
                    button1.Click += (s, ee) =>
                                         {
                                             foreach (var textBox in _textboxes)
                                             {
                                                 textBox.Clear();
                                             }
                                         };
                    break;
            }
            button2.Text = @"Cancel";
            button2.Click += (s, ee) =>
                                 {
                                     Hide();
                                     DialogResult = DialogResult.Cancel;
                                 };

            for (var i = 0; i < defaultTest.Length; i++)
            {
                _labels[i] = new Label
                                 {
                                     Text = prompts[i],
                                     Location = new Point(LabelOne.X,LabelOne.Y + (YDelta * i))
                                 };
                _textboxes[i] = new TextBox
                                    {
                                        Text = defaultTest[i],
                                        Location = new Point(TextBoxOne.X,TextBoxOne.Y + (YDelta * i)),
                                        Size = new Size(textBoxWidth,20)
                                    };
                _textboxes[i].BringToFront();
                splitContainer1.Panel2.Controls.Add(_labels[i]);
                splitContainer1.Panel2.Controls.Add(_textboxes[i]);
            }
            if(_prompts.Length > 2)
            {
                Size = new Size(Size.Width,170 +((YDelta+20) * (_prompts.Length - 2)));
            }
            ShowDialog();
        }
    }
}
