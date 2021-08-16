using System.Windows.Forms;

namespace ReferencePluginM
{
	public partial class AddLogEntryDialog : Form
	{
		public string LogString
		{
			get => m_logStringTextBox.Text;
		}

		public string Param1
		{
			get => m_param1TextBox.Text;
		}

		public string Param2
		{
			get => m_param2TextBox.Text;
		}

		public string Param3
		{
			get => m_param3TextBox.Text;
		}

		public AddLogEntryDialog()
		{
			InitializeComponent();
		}

		public bool FlushToDisk
		{
			get => m_flushToDiskCheckBox.Checked;
		}
	}
}
