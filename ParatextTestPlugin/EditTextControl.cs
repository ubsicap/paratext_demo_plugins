using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using Paratext.PluginInterfaces;
using ProjectTextEditorPlugin.Properties;

namespace ProjectTextEditorPlugin
{
    public partial class EditTextControl : EmbeddedPluginControl
    {
        public const string savedDataId = "savedTextData.xml";
        public const string xmlRoot = "ExtraProjectData";

        private static readonly XmlSerializer dataSerializer = new XmlSerializer(typeof(ProjectTextData));
        private IProject project;
        private IWriteLock pluginFileLock;
		private string lastSavedValue;
        private bool textChanged;

		public EditTextControl()
		{
            InitializeComponent();
			label1.Tag = label1.Text;
		}
        
        /// <summary>
        /// Gets/sets the text in the textbox
        /// </summary>
        public string EditText
        {
            get { return txtText.Text; }
            set 
            { 
                txtText.Text = value;
                txtText.Select(txtText.Text.Length, 0);
				lastSavedValue = value;
			}
        }

		public override void OnAddedToParent(IPluginChildWindow parent, IWindowPluginHost host, string state)
		{
            parent.Icon = Resources.icon;
            parent.SetTitle(ProjectTextEditorPlugin.pluginName, false);
            UpdateProject(parent.CurrentState.Project);

			parent.SaveRequested += Parent_SaveRequested;
			parent.WindowClosing += Parent_WindowClosing;
			parent.ProjectChanged += Parent_ProjectChanged;
            parent.MegaMenuShowing += Parent_MegaMenuShowing;
		}

        public override string GetState()
		{
			return null;
		}

        public override void DoLoad(IProgressInfo progress)
        {
            // Nothing to do
        }

        private void Parent_ProjectChanged(IPluginChildWindow sender, IProject newProject)
        {
            UpdateProject(newProject);
        }

        private void Parent_SaveRequested(IPluginChildWindow sender)
        {
			if (lastSavedValue != EditText)
				SaveText();
        }

        private void Parent_WindowClosing(IPluginChildWindow sender, System.ComponentModel.CancelEventArgs args)
        {
            PromptAndSave(args);
        }

		private void PromptAndSave(System.ComponentModel.CancelEventArgs cancelEventArgs = null)
		{
			if (lastSavedValue == EditText)
				return;

			var result = MessageBox.Show(this, "Do you want to save the text?", ProjectTextEditorPlugin.pluginName,
				cancelEventArgs == null ? MessageBoxButtons.YesNo : MessageBoxButtons.YesNoCancel);
			switch (result)
			{
				case DialogResult.Cancel:
                    Debug.Assert(cancelEventArgs != null);
					cancelEventArgs.Cancel = true;
					break;
				case DialogResult.Yes:
					SaveText();
					break;
			}
		}

        private void Parent_MegaMenuShowing(IPluginChildWindow sender)
        {
            undoToolStripMenuItem.Enabled = textChanged;
        }
        
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateProject(project); // Reload from disk
        }
        
        private void txtText_TextChanged(object sender, EventArgs e)
        {
            textChanged = true;
			ObtainLock();
        }

        private void DisposeLock(IWriteLock lockToDispose)
		{
            Debug.Assert(lockToDispose == pluginFileLock);

            PromptAndSave();
			pluginFileLock?.Dispose();
			pluginFileLock = null;
		}

		protected override void OnEnter(EventArgs e)
		{
			base.OnEnter(e);
			ObtainLock();
		}

		private void ObtainLock()
		{
			if (pluginFileLock == null && project != null)
				pluginFileLock = project.RequestWriteLock(this, DisposeLock, savedDataId);
		}

		private void UpdateProject(IProject newProject)
		{
			if (project != null)
			{
				PromptAndSave();
				newProject.ProjectDataChanged -= NewProjectOnProjectDataChanged;
			}

			project = newProject;
			pluginFileLock?.Dispose();
			pluginFileLock = null;
            newProject.ProjectDataChanged += NewProjectOnProjectDataChanged;

			NewProjectOnProjectDataChanged(newProject, ProjectDataChangeType.WholeProject);
		}

		private void NewProjectOnProjectDataChanged(IProject sender, ProjectDataChangeType details)
		{
			Debug.Assert(pluginFileLock == null);
			Debug.Assert(sender == project);

			if (details != ProjectDataChangeType.WholeProject)
				return;

			pluginFileLock = project.RequestWriteLock(this, DisposeLock, savedDataId);
			txtText.Enabled = pluginFileLock != null;

			label1.Text = string.Format((txtText.Enabled ? (string)label1.Tag : "{0} project is not editable."), project.ShortName);

			try
			{
				TextReader reader = project.GetPluginData(this, savedDataId);
				if (reader == null)
				{
					EditText = "";
					return;
				}

				using (reader)
				{
					ProjectTextData data = (ProjectTextData)dataSerializer.Deserialize(reader);
					EditText = string.Join(Environment.NewLine, data.Lines);
					textChanged = false;
				}
			}
			catch (Exception e)
			{
				EditText = "";
				MessageBox.Show($"Unable to load the text:\n{e.Message}", ProjectTextEditorPlugin.pluginName);
			}
		}

		/// <summary>
        /// Saves the current text.
        /// </summary>
        private void SaveText()
		{
			string text = EditText;

            ProjectTextData data = new ProjectTextData();
            data.Lines = text.Split(new [] {'\n', '\r'}, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                if (pluginFileLock == null)
					throw new Exception("Ack! We didn't get a lock!");
                project.PutPluginData(pluginFileLock, this, savedDataId, writer => dataSerializer.Serialize(writer, data));
			}
            catch (Exception e)
            {
                MessageBox.Show($"Unable to save the text:\n{e.Message}", ProjectTextEditorPlugin.pluginName);
				return;
			}

            pluginFileLock.SendNotifications();
			lastSavedValue = text;
            textChanged = false;
		}

        [XmlRoot(xmlRoot)]
        public class ProjectTextData
        {
            [XmlElement("LineOfTextualData")]
            public string[] Lines { get; set; } 
        }
    }
}
