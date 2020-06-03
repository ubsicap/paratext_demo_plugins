using System.Windows.Forms;

namespace ProjectTextEditorPlugin
{
    public partial class EditTextForm : Form
    {
        public EditTextForm(string projectName)
        {
            InitializeComponent();
            label1.Text = string.Format(label1.Text, projectName);
        }

        /// <summary>
        /// Gets/sets the text in the textbox
        /// </summary>
        public string EditText
        {
            get { return txtText.Text; }
            set 
            { 
                txtText.Text = value;
                txtText.Select(txtText.Text.Length, 0);
            }
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
