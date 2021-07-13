using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Paratext.PluginInterfaces;

namespace ReferencePluginL
{
	public partial class AddNoteDialog : Form
	{
		private IVerseRef m_Verse;
		public IVerseRef Verse
		{
			get => m_Verse; 
			set
			{
				m_Verse = value;
				m_VerseTextBox.Text = FormText(m_Verse);
			} 
		}

		public IUserInfo Assignee
		{
			get
			{
				int index = m_assigneeComboBox.SelectedIndex;
				if (index <= 0) // Not selected or "<none>"
				{
					return null;
				}
				return (IUserInfo)m_assigneeComboBox.SelectedItem;
			}
		}

		public string SelectedText
		{
			get => m_selectTextTextBox.Text;
		}

		public bool WholeWord
		{
			get => m_wholeWordCheckBox.Checked;
		}

		private string FormText(IVerseRef r) =>
			$"{r.BookCode} {r.ChapterNum}:{r.VerseNum}";


		private IProject m_project;

		public AddNoteDialog(IProject project)
		{
			InitializeComponent();
			m_project = project;
			m_assigneeComboBox.Items.Clear();
			m_assigneeComboBox.Items.Add("<none>");
			foreach (var user in m_project.NonObserverUsers)
			{
				m_assigneeComboBox.Items.Add(user);
			}
		}
	}
}
