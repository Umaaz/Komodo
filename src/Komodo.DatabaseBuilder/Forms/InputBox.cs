using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Komodo.App.Forms
{
    public class InputBox
    {
        /// <summary>
        /// Shows a single input dialogue box, with confirmation request.
        /// </summary>
        /// <param name="title">Title for the dialogue, shown in title bar</param>
        /// <param name="promptText">prompt to be displayed above textbox</param>
        /// <param name="defaultText">default text to display in textbox</param>
        /// <param name="value">value for input to be put into</param>
        /// <param name="confirmation">boolean value for confirmation default = true</param>
        /// <returns>returns the dialogue button the user clicked</returns>
        public static DialogResult Show(string title, string promptText, String defaultText, out String value, Boolean confirmation = true)
        {
            Boolean? result = null;
            var dresult = DialogResult.None;
            var tvalue = string.Empty;
            while (!result.HasValue)
            {
                dresult = Show(title, promptText, defaultText, out tvalue);
                switch (dresult)
                {
                    case DialogResult.OK:
                        {
                            if (confirmation)
                            {
                                var message = "Are you sure the following information is correct?\n";
                                message += promptText + ": " + tvalue;
                                defaultText = tvalue;
                                if (MessageBox.Show(message, @"Please Confirm!", MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation) == DialogResult.Yes)
                                {
                                    result = true;
                                }
                            }
                        }
                        break;
                    case DialogResult.Cancel:
                        result = false;
                        break;
                }
            }
            value = tvalue;
            return dresult;
        }

        /// <summary>
        /// Shows simple one textbox input dialogue without confirmation
        /// </summary>
        /// <param name="title">Title for the dialogue, shown in title bar</param>
        /// <param name="promptText">prompt to be displayed above textbox</param>
        /// <param name="defaultText">default text to display in textbox</param>
        /// <param name="value">value for input to be put into</param>
        /// <returns>returns the dialogue button the user clicked</returns>
        public static DialogResult Show(string title, string promptText, String defaultText, out String value)
        {
            var form = new Form();
            var label = new Label();
            var textBox = new TextBox();
            var buttonOk = new Button();
            var buttonCancel = new Button();
            form.StartPosition = FormStartPosition.CenterParent;
            form.Text = title;
            label.Text = promptText;
            textBox.Text = defaultText;
            
            buttonOk.Text = @"OK";
            buttonCancel.Text = @"Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(309, 72, 75, 23);
            buttonCancel.SetBounds(228, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            var dialogResult = form.ShowDialog();
            value = textBox.Text.Trim();
            return dialogResult;
        }
        static Point _labelStartpoint = new Point(18, 25);
        static Point _textBoxStartpoint = new Point(21, 41);
        private static TextBox NewTextBox(String defaultText, int index)
        {
            var aTextBox = new TextBox
            {
                Text = defaultText,
                Location = new Point(_textBoxStartpoint.X, ((index) * 39)+ _textBoxStartpoint.Y),
                Tag = index,
                Visible = true,
                Size = new Size(258,20)
                
            };
            return aTextBox;
        }

        private static Label NewLabel(String message, int index)
        {
            var alabel = new Label
            {
                Text = message,
                Location = new Point(_labelStartpoint.X, ((index) * 39) + _labelStartpoint.Y),
                Tag = index,
                Visible = true
            };
            return alabel;
        }
        /// <summary>
        /// displays a dialogue box with several textboxes
        /// </summary>>
        /// <param name="title">Title for the dialogue, shown in title bar</param>
        /// <param name="promptText">prompt to be displayed above textbox, as an array 0 index at top</param>
        /// <param name="defaultText">default text to display in textbox, as an array 0 index at top</param>
        /// <param name="results">value for input to be put into, as an array 0 index at top</param>
        /// <param name="requestConfirmation">boolean value for confirmation default = true</param>
        /// <returns>returns the dialogue button the user clicked</returns>
        public static DialogResult Show(String title, String[] promptText, String[] defaultText, out string[] results, Boolean requestConfirmation = true)
        {
            var dresult = DialogResult.None;
            Boolean? result = null;
            var tResults = new string[promptText.Length];
            while (!result.HasValue)
            {
                dresult = Show(title, promptText, defaultText, out tResults);
                switch (dresult)
                {
                    case DialogResult.OK:
                        {
                            if (requestConfirmation)
                            {
                                var message = "Are you sure the following information is correct?" + Environment.NewLine;
                                for (var i = 0; i < promptText.Count(); i++)
                                {
                                    message += promptText[i] + " - " + tResults[i] + Environment.NewLine;
                                }
                                defaultText = tResults;
                                if (MessageBox.Show(message, @"Please Confirm!", MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation) == DialogResult.Yes)
                                {
                                    result = true;
                                }
                            }
                        }
                        break;
                    case DialogResult.Cancel:
                        result = false;
                        break;
                }
            }
            results = tResults;
            return dresult;
        }
        /// <summary>
        /// displays a dialogue box with several textboxes
        /// </summary>>
        /// <param name="title">Title for the dialogue, shown in title bar</param>
        /// <param name="promptText">prompt to be displayed above textbox, as an array 0 index at top</param>
        /// <param name="defaultText">default text to display in textbox, as an array 0 index at top</param>
        /// <param name="results">value for input to be put into, as an array 0 index at top</param>
        /// <returns>returns the dialogue button the user clicked</returns>
        public static DialogResult Show(String title, String[] promptText, String[] defaultText, out string[] results)
        {
            if (promptText.Length != defaultText.Length)
            {
                throw new ArgumentOutOfRangeException(@"promptText",@"promptText.count() must equal defaultText.count()");
            }
            var form = new Form();
            var labels = new List<Label>();
            var textBoxes = new List<TextBox>();
            var buttonOk = new Button();
            var buttonCancel = new Button();
            form.StartPosition = FormStartPosition.CenterParent;
            for (var i = 0; i < promptText.Count(); i++)
            {
                var alabel = NewLabel(promptText[i], i);
                labels.Add(alabel);
                form.Controls.Add(alabel);

                var atextbox = NewTextBox(defaultText[i], i);
                textBoxes.Add(atextbox);
                form.Controls.Add(atextbox);
                atextbox.BringToFront();
            }

            var right = labels.Max(x => x.Right);

            form.Text = title;

            buttonOk.Text = @"Ok";
            buttonCancel.Text = @"Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            form.ClientSize = new Size(396, 107 + ((promptText.Count()-1) * _textBoxStartpoint.Y));
            form.Controls.AddRange(new Control[] {buttonOk, buttonCancel});
            form.ClientSize = new Size(Math.Max(300, right + 10), form.ClientSize.Height);
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            buttonOk.SetBounds(form.ClientSize.Width - 85, form.ClientSize.Height - 33, 75, 23);
            buttonCancel.SetBounds(form.ClientSize.Width - 160, form.ClientSize.Height - 33, 75, 23);

            var dialogResult = form.ShowDialog();
            results = new string[promptText.Length];
            for (var index = 0; index < textBoxes.Count; index++)
            {
                results[index] = textBoxes[index].Text;
            }
            return dialogResult;
        }
    }
}
