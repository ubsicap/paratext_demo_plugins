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
using Paratext.PluginInterfaces.ParatextInternal;

namespace ReferencePluginO
{
	public partial class ControlO : EmbeddedPluginControl
	{
		private IVerseRef m_Reference;
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
			m_Reference = parent.CurrentState.VerseRef;
			m_Host = host;

			parent.ProjectChanged += ProjectChanged;
			parent.VerseRefChanged += VerseRefChanged;
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
			m_Reference = sender.CurrentState.VerseRef;
			foreach (var item in m_ProjectsListBox.Items)
			{
				if (item.ToString().StartsWith(m_Project.ShortName))
				{
					m_ProjectsListBox.SelectedItem = item;
					break;
				}
			}
		}

		public void VerseRefChanged(IPluginChildWindow sender, IVerseRef oldReference, IVerseRef newReference)
		{
			m_Reference = newReference;
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

		private void LoadButton_Click(object sender, EventArgs e)
		{
			if (m_Project == null)
			{
				m_ContentsTextBox.Text = "Need to select a project first";
			}
			else
			{
				IProjectRootAccess root = (IProjectRootAccess)m_Project;
				try
				{
					var reader = root.GetPluginData(m_FileNameTextBox.Text);
					if (reader == null)
					{
						m_ContentsTextBox.Text = $"Cannot open file: {m_FileNameTextBox.Text}";
					}
					else
					{
						m_ContentsTextBox.Text = reader.ReadToEnd();
						reader.Close();
					}
				}
				catch (Exception ex)
				{
					if (ex.InnerException == null)
					{
						m_ContentsTextBox.Text = $"API threw exception: {ex.Message}";
					}
					else
					{
						m_ContentsTextBox.Text = $"API threw exception: {ex.Message}\r\n" +
							$"with inner exception {ex.InnerException.Message}";
					}
				}
			}
		}

		private void SaveButton_Click(object sender, EventArgs e)
		{
			if (m_Project == null)
			{
				m_ContentsTextBox.Text = "Need to select a project first";
			}
			else
			{
				IWriteLock writelock = null;
				string id = m_FileNameTextBox.Text;
				IProjectRootAccess root = (IProjectRootAccess)m_Project;
				try
				{
					writelock = root.RequestWriteLock(ReleaseRequested, id);
					if (writelock == null)
					{
						m_ContentsTextBox.Text = "Cannot get write lock for this project";
					}
					else
					{
					root.PutPluginData(writelock, id, writer => writer.Write(m_ContentsTextBox.Text));
					writelock.Dispose();
					writelock = null;
					}
				}
				catch (Exception ex)
				{
					if (ex.InnerException == null)
					{
						m_ContentsTextBox.Text = $"API threw exception: {ex.Message}";
					}
					else
					{
						m_ContentsTextBox.Text = $"API threw exception: {ex.Message}\r\n" +
							$"with inner exception {ex.InnerException.Message}";
					}
				}
				if (writelock != null)
				{
					writelock.Dispose();
				}
			}
		}
		private void ReleaseRequested(IWriteLock writeLock)
		{
			writeLock.Dispose();
		}

		private void m_DeleteButton_Click(object sender, EventArgs e)
		{
			if (m_Project == null)
			{
				m_ContentsTextBox.Text = "Need to select a project first";
			}
			else
			{
				IWriteLock writelock = null;
				string id = m_FileNameTextBox.Text;
				IProjectRootAccess root = (IProjectRootAccess)m_Project;
				try
				{
					writelock = root.RequestWriteLock(ReleaseRequested, id);
					if (writelock == null)
					{
						m_ContentsTextBox.Text = "Cannot get write lock for this project";
					}
					else
					{
						root.DeletePluginData(writelock, id);
						writelock.Dispose();
						writelock = null;
					}
				}
				catch (Exception ex)
				{
					if (ex.InnerException == null)
					{
						m_ContentsTextBox.Text = $"API threw exception: {ex.Message}";
					}
					else
					{
						m_ContentsTextBox.Text = $"API threw exception: {ex.Message}\r\n" +
							$"with inner exception {ex.InnerException.Message}";
					}
				}
				if (writelock != null)
				{
					writelock.Dispose();
				}
			}
		}
	}
}
