using System.Windows.Forms;
using Paratext.PluginInterfaces;

namespace ReferencePluginL
{
	public partial class AddCommentDialog : Form
	{
		public AddCommentDialog(IProject project)
		{
			InitializeComponent();
			m_assigneeListBox.Items.Clear();
			m_assigneeListBox.Items.Add("<none>");
			foreach (var user in project.NonObserverUsers)
			{
				m_assigneeListBox.Items.Add(user);
			}
		}
		public IUserInfo Assignee
		{
			get
			{
				int index = m_assigneeListBox.SelectedIndex;
				if (index <= 0) // Not selected or "<none>"
				{
					return null;
				}
				return (IUserInfo)m_assigneeListBox.SelectedItem;
			}
		}

	}
}
