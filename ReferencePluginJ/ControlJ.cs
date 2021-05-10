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

namespace ReferencePluginJ
{
	public partial class ControlJ : EmbeddedPluginControl
	{

		IProject m_project;

		public ControlJ()
		{
			InitializeComponent();
			m_project = null;
		}

		public override void OnAddedToParent(IPluginChildWindow parent, IWindowPluginHost host, string state)
		{
			parent.SetTitle(PluginJ.pluginName);
			SetProject(parent.CurrentState.Project);

			host.ActiveWindowSelectionChanged += ActiveWindowSelectionChanged;
			parent.ProjectChanged += ProjectChanged;
		}

		public override string GetState()
		{
			return null;
		}

		public override void DoLoad(IProgressInfo progressInfo)
		{
		}

		private void ActiveWindowSelectionChanged(IPluginHost host, IParatextChildState activeWindowState, IReadOnlyList<ISelection> currentSelections)
		{
			if (activeWindowState.Project == null)
			{
				textBox.Text = "Active window does not have a project associated with it.";
				return;
			}

			if (false == activeWindowState.Project.Equals(m_project))
			{
				textBox.Text = "Active window is for a different project.";
				return;
			}

			if (currentSelections == null)
			{
				textBox.Text = "Nothing selected.";
				return;
			}

			var texts = currentSelections.OfType<IScriptureTextSelection>();
			List<string> lines = new List<string>();
			foreach (var text in texts)
			{
				lines.Add(text.SelectedText);
			}

			if (lines.Count == 0)
			{
				textBox.Text = "Selection has no text selected";
				return;
			}

			if ((lines.Count == 1) && (lines[0].Length == 0))
			{
				textBox.Text = "Selection is empty";
				return;
			}

			textBox.Lines = lines.ToArray();
		}

		private void ProjectChanged(IPluginChildWindow sender, IProject newProject)
		{
			SetProject(newProject);
		}

		private void SetProject(IProject newProject)
		{
			if (m_project != null)
				m_project.ProjectDeleted -= HandleProjectDeleted;

			m_project = newProject;
			if (newProject != null)
			{
				newProject.ProjectDeleted += HandleProjectDeleted;
			}
		}

		private void HandleProjectDeleted()
		{
			m_project = null;
		}

	}
}
