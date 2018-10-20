using System;
using System.Drawing;
using System.Windows.Forms;

namespace MCStudio
{
    public partial class InputDialog : Form
    {

        public string Message { get; set; }
        public DialogIcons MessageIcon { get; set; }
        public string Value { get; set; }

        private InputDialog()
        {
            InitializeComponent();
        }

        private void InputDialog_Load(object sender, EventArgs e)
        {
            label1.Text = Message;
            textBox1.Text = Value;
            switch (MessageIcon)
            {
                case DialogIcons.Asterisk:
                    pictureBox1.Image = SystemIcons.Asterisk.ToBitmap();
                    break;
                case DialogIcons.Error:
                    pictureBox1.Image = SystemIcons.Error.ToBitmap();
                    break;
                case DialogIcons.Exclamation:
                    pictureBox1.Image = SystemIcons.Exclamation.ToBitmap();
                    break;
                case DialogIcons.Question:
                    pictureBox1.Image = SystemIcons.Question.ToBitmap();
                    break;
                case DialogIcons.Hand:
                    pictureBox1.Image = SystemIcons.Hand.ToBitmap();
                    break;
                case DialogIcons.Information:
                    pictureBox1.Image = SystemIcons.Information.ToBitmap();
                    break;
                case DialogIcons.Warning:
                    pictureBox1.Image = SystemIcons.Warning.ToBitmap();
                    break;
            }
            textBox1.Focus();
        }

        public static string ShowDialog(string title, string message, DialogIcons icon, string defaultValue = "")
        {
            InputDialog dlg = new InputDialog();
            dlg.Text = title;
            dlg.Message = message;
            dlg.MessageIcon = icon;
            dlg.Value = defaultValue;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                return dlg.Value;
            }
            return null;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Value = textBox1.Text;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }

    public enum DialogIcons
    {
        Asterisk,
        Error,
        Exclamation,
        Question,
        Hand,
        Information,
        Warning
    }
}
