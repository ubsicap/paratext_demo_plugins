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
        private readonly TestPlugin plugin;
        private IProject project;

        public EditTextControl(TestPlugin plugin, IProject project)
        {
            InitializeComponent();
            this.plugin = plugin;
            label1.Text = string.Format(label1.Text, project.ShortName);

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
            }
        }

        public override string Title => TestPlugin.pluginName + " - " + project.ShortName;

        public override void OnAddedToParent(IPluginChildWindow parent)
        {
            parent.SaveRequested += Parent_SaveRequested;
            parent.WindowClosing += Parent_WindowClosing;
            parent.ProjectChanged += Parent_ProjectChanged;
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
            if (MessageBox.Show(this, "Do you want to save the text?", TestPlugin.pluginName,
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SaveText(EditText);
            }
        }
        
        private void UpdateProject(IProject newProject)
        {
            project = newProject;

            TextReader reader = project.GetPluginDataReader(plugin, savedDataId);
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
                MergeLevel[] mergeLevels = new[] {new MergeLevel("/" + xmlRoot, ".")};
                using (TextWriter writer = project.GetPluginDataWriter(plugin, savedDataId, mergeLevels))
                    dataSerializer.Serialize(writer, data);
            }
            catch
            {
                MessageBox.Show("Unable to save the text. :(", TestPlugin.pluginName);
            }
        }

        [XmlRoot(xmlRoot)]
        public class ProjectTextData
        {
            [XmlElement("LineOfTextualData")]
            public string[] Lines { get; set; } 
        }
    }
}
