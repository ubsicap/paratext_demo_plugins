using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
		public static bool m_Exists;

		IProject m_Project;
		IVerseRef m_VerseRef;
		IPluginHost m_Host;

		public ControlG()
		{
			InitializeComponent();

			m_Exists = true;
		}

		public override void OnAddedToParent(IPluginChildWindow parent, IWindowPluginHost host, string state)
		{
			m_Host = host;
			if (m_Host.ActiveWindowState == null)
			{
				if (parent.CurrentState == null)
				{
					m_Project = null;
					m_VerseRef = null;
				}
				else
				{
					m_Project = parent.CurrentState.Project;
					m_VerseRef = parent.CurrentState.VerseRef;
				}
			}
			else
			{
				m_Project = m_Host.ActiveWindowState.Project;
				m_VerseRef = m_Host.ActiveWindowState.VerseRef;
			}

			parent.SetTitle(PluginG.pluginName);
			parent.WindowClosing += WindowClosing;
			parent.ProjectChanged += ProjectChanged;
			parent.VerseRefChanged += VerseRefChanged;

			m_UpdateThread = new Thread(UpdateTimeWorker);
			m_UpdateThread.Start();

			ShowProjectInfo();
		}

		public override string GetState()
		{
			return null;
		}

		public override void DoLoad(IProgressInfo progressInfo)
		{
			if (m_Host != null)
			{
				if (m_Host.ActiveWindowState != null)
				{
					m_Project = m_Host.ActiveWindowState.Project;
					m_VerseRef = m_Host.ActiveWindowState.VerseRef;
					Invoke((Action)(() => ShowProjectInfo()));
				}
			}
		}

		public void ProjectChanged(IPluginChildWindow sender, IProject newProject)
		{
			m_Project = newProject;
			m_VerseRef = sender.CurrentState.VerseRef;
			ShowProjectInfo();
		}

		public void VerseRefChanged(IPluginChildWindow sender, IVerseRef oldReference, IVerseRef newReference)
		{
			m_Project = sender.CurrentState.Project;
			m_VerseRef = newReference;
			ShowProjectInfo();
		}

		public void WindowClosing(IPluginChildWindow sender, CancelEventArgs args)
		{
			m_Exists = false;
		}

		public void UpdateTime()
		{
			timeTextBox.Text = DateTime.Now.ToString();
		}

		public void UpdateTimeWorker()
		{
			while (true)
			{
				Thread.Sleep(1 * 1000);
				if (m_Exists)
				{
					Invoke((Action)(() => UpdateTime()));
				}
			}
		}

		private void ShowProjectInfo()
		{
			List<string> lines = new List<string>();
			if (m_Project == null)
			{
				lines.Add("No Project");
			}
			else
			{
				lines.Add($"Project Information");
				lines.Add($"ID: {m_Project.ID}");
				lines.Add($"Name: {m_Project.ShortName}");
				lines.Add($"Versification: {m_Project.Versification.Type}");
				lines.Add($"Language: {m_Project.LanguageName}");
				lines.Add($"Type: {m_Project.Type}");
				if (m_Project.BaseProject != null)
				{
					lines.Add($"Base Project: {m_Project.BaseProject.ShortName}");
				}
				lines.Add($"Number of available books: {m_Project.AvailableBooks.Count()}");
				lines.Add("Permissions:");
				lines.Add($"Can edit {m_VerseRef.BookCode}: {m_Project.CanEdit(this, m_VerseRef.BookNum)}");
				lines.Add($"Can edit data: {m_Project.CanEdit(this, DataType.PluginData)}");
				lines.Add($"Can edit spelling status: {m_Project.CanEdit(this, DataType.SpellingStatus)}");
				lines.Add($"Can edit Biblical terms rendering: {m_Project.CanEdit(this, DataType.TermRenderings)}");
				lines.Add($"Can edit Biblical terms list: {m_Project.CanEdit(this, DataType.TermsList)}");
				lines.Add($"Can approve parallel passage status: {m_Project.CanEdit(this, DataType.ParallelPassageStatus)}");
				lines.Add($"Can update project progress: {m_Project.CanEdit(this, DataType.ProjectProgress)}");
			}
			projectTextBox.Lines = lines.ToArray();
		}
	}
}
