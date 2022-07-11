using System;

using Paratext.PluginInterfaces;

namespace ReferencePluginO
{
	public partial class ControlO : EmbeddedPluginControl
	{
		private IProject m_Project;
		private IWindowPluginHost m_Host;

		public ControlO()
		{
			InitializeComponent();
		}
		public override void OnAddedToParent(IPluginChildWindow parent, IWindowPluginHost host, string state)
		{
			parent.SetTitle(PluginO.pluginName);
			m_Project = parent.CurrentState.Project;
			m_Host = host;

			parent.ProjectChanged += ProjectChanged;
		}

		public override string GetState()
		{
			return null;
		}

		public override void DoLoad(IProgressInfo progressInfo)
		{
			// Since DoLoad is done on a different thread than what was used
			// to create the control, we need to use the Invoke method.
			Invoke((Action)(() => GetAllProjects()));
		}

		public void ProjectChanged(IPluginChildWindow sender, IProject newProject)
		{
			m_Project = newProject;
			foreach (var item in m_ProjectsListBox.Items)
			{
				if (item.ToString().StartsWith(m_Project.ShortName))
				{
					m_ProjectsListBox.SelectedItem = item;
					break;
				}
			}
		}

		private void GetAllProjects()
		{
			var projects = m_Host.GetAllProjects();

			m_ProjectsListBox.Items.Clear();
			foreach (var p in projects)
			{
				string text = $"{p.ShortName} is a {p.Type} Project";
				m_ProjectsListBox.Items.Add(text);
			}
		}

	}
}
