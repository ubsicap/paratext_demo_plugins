using System;
using System.Collections.Generic;
using Paratext.PluginInterfaces;

namespace ReferencePluginE
{
	public partial class ControlE : EmbeddedPluginControl
	{
		private IVerseRef m_Reference;
		private IProject m_Project;
		private IReadOnlyList<IProject> m_ProjectList;
		private int m_SelectedProjectNumber;
		private IWindowPluginHost m_Host;

		public ControlE()
		{
			InitializeComponent();
			m_SelectedProjectNumber = -1;
		}

		public override void OnAddedToParent(IPluginChildWindow parent, IWindowPluginHost host, string state)
		{
			m_Host = host;
			parent.SetTitle(PluginE.pluginName);
			m_Project = parent.CurrentState.Project;
			m_Reference = parent.CurrentState.VerseRef;
			UpdateProjectList();

			parent.ProjectChanged += ProjectChanged;
			parent.VerseRefChanged += VerseRefChanged;
		}

		private void UpdateProjectList()
		{
			m_ProjectList = m_Host.GetAllProjects(IncResourcesCheckBox.Checked);
			ProjectListBox.Items.Clear();
			int item = 0;
			foreach (var proj in m_ProjectList)
			{
				ProjectListBox.Items.Add(proj.ShortName);
				if (proj == m_Project)
				{
					m_SelectedProjectNumber = item;
				}
				item++;
			}
			if (m_SelectedProjectNumber >= 0)
			{
				ProjectListBox.SelectedIndex = m_SelectedProjectNumber;
			}
		}

		public override string GetState()
		{
			return null;
		}

		public override void DoLoad(IProgressInfo progressInfo)
		{
			// Since DoLoad is done on a different thread than what was used
			// to create the control, we need to use the Invoke method.
			Invoke((Action)(() => ShowScripture()));
		}

		public void ProjectChanged(IPluginChildWindow sender, IProject newProject)
		{
			m_Project = newProject;
			m_Reference = sender.CurrentState.VerseRef;
			ShowScripture();
		}

		public void VerseRefChanged(IPluginChildWindow sender, IVerseRef oldReference, IVerseRef newReference)
		{
			m_Reference = newReference;
			ShowScripture();
		}

		private void ShowScripture()
		{
			IEnumerable<IUSFMToken> tokens = m_Project.GetUSFMTokens(m_Reference.BookNum, m_Reference.ChapterNum);
			if (tokens == null)
			{
				textBox.Text = "Cannot get the USFM Tokens for this project";
				return;
			}

			List<string> lines = new List<string>();
			foreach (var token in tokens)
			{
				if (token is IUSFMMarkerToken marker)
				{
					lines.Add($"{marker.Type} Marker: {marker.Data}");
				}
				else if (token is IUSFMTextToken textToken)
				{
					lines.Add("Text Token: " + textToken.Text);
				}
				else if (token is IUSFMAttributeToken )
				{
					lines.Add("Attribute Token: " + token.ToString());
				}
				else
				{
					lines.Add("Unexpected token type: " + token.ToString());
				}
			}
			textBox.Lines = lines.ToArray();
		}

		private void ProjectListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			string name = ProjectListBox.SelectedItem.ToString();
			bool found = false;
			foreach (var proj in m_ProjectList)
			{
				if (name == proj.ShortName)
				{
					m_Project = proj;
					ShowScripture();
					found = true;
					break;
				}
			}
			if (!found)
			{
				textBox.Text = $"Cannot find project named {name}";
			}

		}

		private void IncludeResourcesCheckBox_Click(object sender, EventArgs e)
		{
			UpdateProjectList();
		}
	}
}
