using System;
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

		public override void OnAddedToParent(IPluginChildWindow parent, string state)
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

        public override void DoLoad()
        {
            // Nothing to do
        }

        private void Parent_ProjectChanged(IPluginChildWindow sender, IProject newProject)
        {
            UpdateProject(newProject);
        }

        private void Parent_SaveRequested(IPluginChildWindow sender)
        {
            SaveText(EditText);
        }

        private void Parent_WindowClosing(IPluginChildWindow sender, System.ComponentModel.CancelEventArgs args)
        {
            if (lastSavedValue == EditText)
                return;
			var result = MessageBox.Show(this, "Do you want to save the text?", ProjectTextEditorPlugin.pluginName,
				MessageBoxButtons.YesNoCancel);
			switch (result)
			{
				case DialogResult.Cancel:
					args.Cancel = true;
					break;
				case DialogResult.Yes:
					SaveText(EditText);
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
        }

        private void UpdateProject(IProject newProject)
        {
            project = newProject;
			label1.Text = string.Format((string)label1.Tag, project.ShortName);

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
        /// Saves the specified text to the Paratext settings directory.
        /// </summary>
        private void SaveText(string text)
        {
            ProjectTextData data = new ProjectTextData();
            data.Lines = text.Split(new [] {'\n', '\r'}, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                project.PutPluginData(this, savedDataId, writer => dataSerializer.Serialize(writer, data));
            }
            catch (Exception e)
            {
                MessageBox.Show($"Unable to save the text:\n{e.Message}", ProjectTextEditorPlugin.pluginName);
            }

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
