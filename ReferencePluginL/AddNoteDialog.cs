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
		private IVerseRef m_startVerse;
		private IVerseRef m_endVerse;
		public IVerseRef StartVerse
		{
			get => m_startVerse; 
			set
			{
				m_startVerse = value;
				m_startTextBox.Text = FormText(m_startVerse);
			} 
		}

		public IVerseRef EndVerse
		{
			get => m_endVerse; 
			set
			{
				m_endVerse = value;
				m_endTextBox.Text = FormText(m_endVerse);
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

		private string FormText(IVerseRef r) =>
			$"{r.BookCode} {r.ChapterNum}:{r.VerseNum}";


		private IProject m_project;

		public AddNoteDialog(IProject project)
		{
			InitializeComponent();
			m_project = project;
			m_assigneeListBox.Items.Clear();
			m_assigneeListBox.Items.Add("<none>");
			foreach (var user in m_project.NonObserverUsers)
			{
				m_assigneeListBox.Items.Add(user);
			}
		}

		private void OnIncrVerseClicked(object sender, EventArgs e)
		{
			m_endVerse = m_endVerse.GetNextVerse(m_project);
			m_endTextBox.Text = FormText(m_endVerse);
		}

		private void OnDecrVerseClicked(object sender, EventArgs e)
		{
			m_endVerse = m_endVerse.GetPreviousVerse(m_project);
			m_endTextBox.Text = FormText(m_endVerse);
		}

		
	}
}
