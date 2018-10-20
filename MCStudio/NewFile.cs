using System;
using System.Windows.Forms;

namespace MCStudio
{
    public partial class NewFile : Form
    {

        public string FileFormat { get; set; }

        public NewFile()
        {
            InitializeComponent();
        }

        private void clJson_Click(object sender, EventArgs e)
        {
            FileFormat = "json";
            DialogResult = DialogResult.OK;
            Close();
        }

        private void clFunction_Click(object sender, EventArgs e)
        {
            FileFormat = "mcfunction";
            DialogResult = DialogResult.OK;
            Close();
        }

        private void clCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
