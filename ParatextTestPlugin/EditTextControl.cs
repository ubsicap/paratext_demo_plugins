using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using Paratext.PluginInterfaces;

namespace ProjectTextEditorPlugin
{
    public partial class EditTextControl : EmbeddedPluginControl
    {
        private const string savedDataId = "savedTextData.xml";
        public const string xmlRoot = "ExtraProjectData";

        private readonly XmlSerializer dataSerializer = new XmlSerializer(typeof(ProjectTextData));
        private IProject project;
		private string lastSavedValue;

		public EditTextControl()
		{
            InitializeComponent();
			label1.Tag = label1.Text;
			Title = ProjectTextEditorPlugin.pluginName;
		}

		public EditTextControl(IProject project) : this()
        {
			UpdateProject(project);
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

		public override bool IncludeReferenceInTitleBar => false;

		public override void OnAddedToParent(IPluginChildWindow parent)
        {
            parent.SaveRequested += Parent_SaveRequested;
            parent.WindowClosing += Parent_WindowClosing;
            parent.ProjectChanged += Parent_ProjectChanged;
        }

		public override string GetState()
		{
			return null;
		}

		public override void RestoreFromState(IVerseRef reference, IProject proj, string state)
		{
			UpdateProject(proj);
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
        
        private void UpdateProject(IProject newProject)
        {
            project = newProject;
			label1.Text = string.Format((string)label1.Tag, project.ShortName);

			TextReader reader = project.GetPluginDataReader(this, savedDataId);
            if (reader == null)
                return;

            using (reader)
            {
                ProjectTextData data = (ProjectTextData)dataSerializer.Deserialize(reader);
                EditText = string.Join(Environment.NewLine, data.Lines);
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
                MergeLevel[] mergeLevels = {new MergeLevel("/" + xmlRoot, ".")};
                using (TextWriter writer = project.GetPluginDataWriter(this, savedDataId, mergeLevels))
                    dataSerializer.Serialize(writer, data);
            }
            catch
            {
                MessageBox.Show("Unable to save the text. :(", ProjectTextEditorPlugin.pluginName);
            }

			lastSavedValue = text;
		}

        [XmlRoot(xmlRoot)]
        public class ProjectTextData
        {
            [XmlElement("LineOfTextualData")]
            public string[] Lines { get; set; } 
        }
    }
}
