﻿using System;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;
using Paratext.PluginInterfaces;

namespace ReferencePluginF
{
	public partial class ControlF : EmbeddedPluginControl
	{
		public const string savedDataId = "PluginFData.xml";
		public const string xmlRoot = "ExtraProjectData";

		private string m_currentText;
		private string m_savedText;
		private IWriteLock m_writeLock;
		private IProject m_project;

		public ControlF()
		{
			InitializeComponent();
			m_currentText = null;
			m_savedText = null;
			m_writeLock = null;
			m_project = null;
		}

		public override void OnAddedToParent(IPluginChildWindow parent, IWindowPluginHost host, string state)
		{
			m_project = parent.CurrentState.Project;
			parent.SetTitle(PluginF.pluginName);
			parent.SaveRequested += SaveRequested;
			parent.WindowClosing += WindowClosing;
			parent.ProjectChanged += ProjectChanged;
		}

		public override string GetState()
		{
			return null;
		}

		public override void DoLoad(IProgressInfo progressInfo)
		{
			// Actually do the load:
			// Since DoLoad is done on a different thread than what was used
			// to create the control, we need to use the Invoke method.
			Invoke((Action)(() => LoadSavedText()));

			// Illustrate use of progressInfo
			const int MAX_TIME = 100;
			progressInfo.Initialize("Loading Reference F", MAX_TIME);
			for (int i = 0; i < MAX_TIME; i++)
			{
				if (progressInfo.CancelRequested)
				{
					m_writeLock.Dispose();
					m_writeLock = null;
					m_DataTextBox.Text = "";
					m_DataTextBox.ReadOnly = true;
					m_ModTimeTextBox.Text = "";
				}
				Thread.Sleep(20);
				progressInfo.Value = i;
			}
		}

		private void ReleaseRequested(IWriteLock writeLock)
		{
			writeLock.Dispose();
			m_writeLock = null;
			m_DataTextBox.ReadOnly = true;
		}

		private void LoadSavedText()
		{
			if (m_project == null)
			{
				MessageBox.Show("Project not provided");
				m_savedText = "";
				m_currentText = "";
				m_DataTextBox.Text = "";
				m_DataTextBox.ReadOnly = true;
				m_ModTimeTextBox.Text = "";
			}
			else
			{
				if (m_writeLock == null)
				{
					m_writeLock = m_project.RequestWriteLock(this, ReleaseRequested, savedDataId);
				}
				if (m_writeLock == null)
				{
					MessageBox.Show("Cannot get write lock; aborting loading data");
					m_savedText = "";
					m_currentText = "";
					m_DataTextBox.Text = "";
					m_DataTextBox.ReadOnly = true;
					m_ModTimeTextBox.Text = "";
					return;
				}

				TextReader reader = m_project.GetPluginData(this, savedDataId);
				if (reader != null)
				{
					try
					{
						//ProjectTextData data = (ProjectTextData)m_Serializer.Deserialize(reader);
						//m_savedText = string.Join(Environment.NewLine, data.Lines);
						m_savedText = reader.ReadToEnd();
					}
					catch (Exception e)
					{
						MessageBox.Show($"Unable to load data:\n{e.Message}");
						m_savedText = "";
					}
					reader.Close();
				}
				else
				{
					// This is normal if there was no data previously saved,
					// so don't bother with a MessageBox.
					m_savedText = "";
				}
				m_currentText = m_savedText;
				try
				{
					DateTime modDate = m_project.GetPluginDataModifiedTime(this, savedDataId);
					m_ModTimeTextBox.Text = modDate.ToString();
				}
				catch
				{
					m_ModTimeTextBox.Text = "";
				}
				m_DataTextBox.ReadOnly = false;
				m_DataTextBox.Text = m_currentText;
				m_DataTextBox.Select(0, 0);
			}
		}

		private void SaveRequested(IPluginChildWindow sender)
		{
			if (m_writeLock == null)
			{
				m_writeLock = m_project.RequestWriteLock(this, ReleaseRequested, savedDataId);
			}
			if (m_writeLock == null)
			{
				MessageBox.Show("Cannot get write lock; aborting saving data");
				m_savedText = "";
				m_currentText = "";
				m_DataTextBox.Text = "";
				m_DataTextBox.ReadOnly = true;
				m_ModTimeTextBox.Text = "";
				return;
			}

			m_currentText = m_DataTextBox.Text;

			try
			{
				m_project.PutPluginData(m_writeLock, this, savedDataId, writer => writer.Write(m_currentText));
			}
			catch (Exception e)
			{
				MessageBox.Show($"Unable to save data:\n{e.Message}");
			}
			m_savedText = m_currentText;
			try
			{
				DateTime modDate = m_project.GetPluginDataModifiedTime(this, savedDataId);
				m_ModTimeTextBox.Text = modDate.ToString();
			}
			catch
			{
				m_ModTimeTextBox.Text = "";
			}
		}

		private void Reload(object sender, EventArgs e)
		{
			LoadSavedText();
		}

		private void WindowClosing(IPluginChildWindow sender, CancelEventArgs args)
		{
			PromptSaveAndDispose(sender);
		}

		private void PromptSaveAndDispose(IPluginChildWindow sender)
		{
			if (m_DataTextBox.Text != m_savedText)
			{
				var response = MessageBox.Show("Save changed data?", "Plugin F", MessageBoxButtons.YesNo);
				if (response == DialogResult.Yes)
				{
					SaveRequested(sender);
				}
			}

			if (m_writeLock != null)
			{
				m_writeLock.Dispose();
				m_writeLock = null;
			}
		}

		private void ProjectChanged(IPluginChildWindow sender, IProject newProject)
		{
			// Save the old project first:
			PromptSaveAndDispose(sender);

			// Then load the new project
			m_project = newProject;
			LoadSavedText();
		}

	}
}
