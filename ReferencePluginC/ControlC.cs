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


namespace ReferencePluginC
{
	public partial class ControlC : EmbeddedPluginControl
	{
		private IVerseRef m_Reference;
		private IProject m_Project;
		IWindowPluginHost m_Host;

		public ControlC()
		{
			InitializeComponent();
		}
		public override void OnAddedToParent(IPluginChildWindow parent, IWindowPluginHost host, string state)
		{
			parent.SetTitle(PluginC.pluginName);
			m_Host = host;
			m_Project = parent.CurrentState.Project;
			m_Reference = parent.CurrentState.VerseRef;

			parent.ProjectChanged += ProjectChanged;
			parent.VerseRefChanged += VerseRefChanged;

			ShowCurrentInfo();
		}

		private void ShowCurrentInfo()
		{
			List<string> lines = new List<string>();
			lines.Add($"Project name: {m_Project.ShortName}");
			lines.Add($"Current Book: {m_Reference.BookCode}");
			lines.Add($"Current Chapter: {m_Reference.ChapterNum}");
			lines.Add($"Current Verse: {m_Reference.VerseNum}");
			textBox.Lines = lines.ToArray();
		}

		public override string GetState()
		{
			return null;
		}

		public override void DoLoad(IProgressInfo progressInfo)
		{
		}

		public void ProjectChanged(IPluginChildWindow sender, IProject newProject)
		{
			m_Project = newProject;
			m_Reference = sender.CurrentState.VerseRef;
			ShowCurrentInfo();
		}

		public void VerseRefChanged(IPluginChildWindow sender, IVerseRef oldReference, IVerseRef newReference)
		{
			m_Reference = newReference;
			ShowCurrentInfo();
		}

		public void NextVerse(Object sender, EventArgs e)
		{
			m_Reference = m_Reference.GetNextVerse(m_Project);
			var syncGroup = m_Host.ActiveWindowState.SyncReferenceGroup;
			m_Host.SetReferenceForSyncGroup(m_Reference, syncGroup);
		}

		public void PreviousVerse(Object sender, EventArgs e)
		{
			m_Reference = m_Reference.GetPreviousVerse(m_Project);
			var syncGroup = m_Host.ActiveWindowState.SyncReferenceGroup;
			m_Host.SetReferenceForSyncGroup(m_Reference, syncGroup);
		}
	}
}
