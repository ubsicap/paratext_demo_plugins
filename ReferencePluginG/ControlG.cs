using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Paratext.PluginInterfaces;

namespace ReferencePluginG
{
	public partial class ControlG : EmbeddedPluginControl
	{
		Thread m_UpdateThread;

		// m_Exists is used for two purposes:
		// 1. So we don't create a second window if Paratext closed with one open.
		// 2. So we don't update the text if the window is closing.
		public static bool s_exists;

		IProject m_project;
		IVerseRef m_verseRef;
		IPluginChildWindow m_parent;

		public ControlG()
		{
			InitializeComponent();

			s_exists = true;
			m_project = null;
			m_verseRef = null;
		}

		public override void OnAddedToParent(IPluginChildWindow parent, IWindowPluginHost host, string state)
		{
			m_parent = parent;
			if (parent.CurrentState == null)
			{
				m_project = null;
				m_verseRef = null;
			}
			else
			{
				m_project = parent.CurrentState.Project;
				m_verseRef = parent.CurrentState.VerseRef;
			}

			parent.SetTitle(PluginG.pluginName);
			parent.WindowClosing += WindowClosing;
			parent.ProjectChanged += ProjectChanged;
			parent.VerseRefChanged += VerseRefChanged;
			if (m_project != null)
			{
				m_project.ProjectDataChanged += ProjectDataChanged;
			}

			m_UpdateThread = new Thread(UpdateTimeWorker);
			m_UpdateThread.Start();
		}

		public override string GetState()
		{
			return null;
		}

		public override void DoLoad(IProgressInfo progressInfo)
		{
			if (m_parent != null)
			{
				if (m_parent.CurrentState != null)
				{
					m_project = m_parent.CurrentState.Project;
					m_verseRef = m_parent.CurrentState.VerseRef;
					Invoke((Action)(() => ShowProjectInfo()));
				}
			}
		}

		public void ProjectChanged(IPluginChildWindow sender, IProject newProject)
		{
			if (m_project != null)
			{
				m_project.ProjectDataChanged -= ProjectDataChanged;
			}
			m_project = newProject;
			if (m_project != null)
			{
				m_project.ProjectDataChanged += ProjectDataChanged;
			}

			m_verseRef = sender.CurrentState.VerseRef;
			ShowProjectInfo();
		}

		public void VerseRefChanged(IPluginChildWindow sender, IVerseRef oldReference, IVerseRef newReference)
		{
			m_project = sender.CurrentState.Project;
			m_verseRef = newReference;
			ShowProjectInfo();
		}

		public void WindowClosing(IPluginChildWindow sender, CancelEventArgs args)
		{
			s_exists = false;
		}

		public void ProjectDataChanged(IProject sender, ProjectDataChangeType details)
		{
			MessageBox.Show($"Project has changed: {details}");
			ShowProjectInfo();
		}

		public void UpdateTime()
		{
			timeTextBox.Text = DateTime.Now.ToString();
		}

		public void UpdateTimeWorker()
		{
			bool wasActive = false;
			while (true)
			{
				Thread.Sleep(1 * 1000);
				if (s_exists)
				{
					Invoke((Action)(() => UpdateTime()));
					wasActive = true;
				}
				else
				{
					if (wasActive)
					{
						return;
					}
				}
			}
		}

		private void ShowProjectInfo()
		{
			List<string> lines = new List<string>();
			if (m_project == null)
			{
				lines.Add("No Project");
			}
			else
			{
				lines.Add($"Project Information");
				lines.Add($"ID: {m_project.ID}");
				lines.Add($"Name: {m_project.ShortName}");
				lines.Add($"Versification: {m_project.Versification.Type}");
				lines.Add($"Language: {m_project.LanguageName}");
				lines.Add($"Type: {m_project.Type}");
				if (m_project.BaseProject != null)
				{
					lines.Add($"Base Project: {m_project.BaseProject.ShortName}");
				}
				lines.Add("");
				lines.Add("Permissions:");
				lines.Add($"Can edit {m_verseRef.BookCode}: {m_project.CanEdit(this, m_verseRef.BookNum)}");
				lines.Add($"Can edit plugin data: {m_project.CanEdit(this, DataType.PluginData)}");
				lines.Add($"Can edit spelling status: {m_project.CanEdit(this, DataType.SpellingStatus)}");
				lines.Add($"Can edit Biblical terms renderings: {m_project.CanEdit(this, DataType.TermRenderings)}");
				lines.Add($"Can edit Biblical terms list: {m_project.CanEdit(this, DataType.TermsList)}");
				lines.Add($"Can approve parallel passage status: {m_project.CanEdit(this, DataType.ParallelPassageStatus)}");
				lines.Add($"Can update project progress: {m_project.CanEdit(this, DataType.ProjectProgress)}");
				lines.Add("");
				lines.Add($"Number of available books: {m_project.AvailableBooks.Count()}");
				lines.Add("Available Books:");
				foreach (var book in m_project.AvailableBooks)
				{
					string editable = m_project.CanEdit(this, book.Number) ?
						"editable" : "not editable";
					string scope = book.InProjectScope ? "in scope" : "not in scope";
					lines.Add($"{book.Code} is {editable} and is {scope}");
				}
			}
			projectTextBox.Lines = lines.ToArray();
		}
	}
}
