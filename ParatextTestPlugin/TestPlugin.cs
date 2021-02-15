using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using Paratext.PluginInterfaces;

namespace ProjectTextEditorPlugin
{
    /// <summary>
    /// Simple plugin that shows a text box that the user can enter text into. The text is
    /// then persisted with the other Paratext project data.
    /// </summary>
    [AddIn(pluginName, Description = "Shows a text box into which the user can enter text, which" +
        " is then saved with the other project data.", Version = "1.0", Publisher = "SIL/UBS")]
    [QualificationData(PluginMetaDataKeys.menuText, "&" + pluginName + "...")]
    [QualificationData(PluginMetaDataKeys.insertAfterMenuName, "Tools|Advanced")]
    [QualificationData(PluginMetaDataKeys.menuImagePath, @"ProjectTextEditorPlugin\icon.gif")]
    [QualificationData(PluginMetaDataKeys.enableWhen, WhenToEnable.anyProjectActive)]
    [QualificationData(PluginMetaDataKeys.multipleInstances, CreateInstanceRule.forEachActiveProject)]
    public class TestPlugin : IParatextWindowPlugin // TODO: Make EmbeddedUiPluginInterfaces create a nuget package
    {
        private const string savedDataId = "savedTextData.xml";
        public const string xmlRoot = "ExtraProjectData";
        public const string pluginName = "Project Text Editor";

        private IHost host;
        private string projectName;
        private EditTextForm form;
        private readonly XmlSerializer dataSerializer = new XmlSerializer(typeof(ProjectTextData));

        /// <summary>
        /// Called by Paratext when the menu item created for this plugin was clicked.
        /// </summary>
        public void Run(IHost ptHost, string activeProjectName)
        {
            host = ptHost;
            projectName = activeProjectName;

            Form formToShow;
            lock (this)
            {
                formToShow = form = new EditTextForm(projectName);
                form.EditText = GetSavedText();
                form.Closed += form_Closed;
            }
            Application.Run(formToShow);
        }

        void form_Closed(object sender, EventArgs e)
        {
            lock (this)
            {
                if (form.DialogResult == DialogResult.OK)
                    SaveText(form.EditText);
                form = null;
            }
        }

        public void RequestShutdown()
        {
            lock(this)
            {
                if (form != null)
                {
                    form.Activate();
                    if (MessageBox.Show(form, "Do you want to save the text?", pluginName,
                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        SaveText(form.EditText);
                    }
                    form.Closed -= form_Closed;
                    form.Close();
                }
            }
        }

        public Dictionary<string, IPluginDataFileMergeInfo> DataFileKeySpecifications
        {
            get
            {
                Dictionary<string, IPluginDataFileMergeInfo> dictionary = new Dictionary<string, IPluginDataFileMergeInfo>();
                dictionary[savedDataId] = new PluginDataFileMergeInfo(new MergeLevel("/" + xmlRoot, "."));
                return dictionary;
            }
        }

        public void Activate(string activeProjectName)
        {
            InvokeOnMainWindowIfNotNull(() => form.Activate());
        }

        /// <summary>
        /// Gets any previously-saved text
        /// </summary>
        private string GetSavedText()
        {
            string text = host.GetPlugInData(this, projectName, savedDataId);
            if (text == null)
                return null;
            StringReader reader = new StringReader(text);
            ProjectTextData data = (ProjectTextData)dataSerializer.Deserialize(reader);
            return string.Join(Environment.NewLine, data.Lines);
        }

        /// <summary>
        /// Saves the specified text to the Paratext settings directory.
        /// </summary>
        private void SaveText(string text)
        {
            StringWriter writer = new StringWriter();
            ProjectTextData data = new ProjectTextData();
            data.Lines = text.Split(new [] {'\n', '\r'}, StringSplitOptions.RemoveEmptyEntries);
            dataSerializer.Serialize(writer, data);
            if (!host.PutPlugInData(this, projectName, savedDataId, writer.ToString()))
            {
                MessageBox.Show("Unable to save the text. :(", pluginName);
            }
        }

        private void InvokeOnMainWindowIfNotNull(Action action)
        {
            lock (this)
            {
                if (form != null)
                {
                    if (form.InvokeRequired)
                        form.Invoke(action);
                    else
                        action();
                }
            }
        }
    }

    [XmlRoot(TestPlugin.xmlRoot)]
    public class ProjectTextData
    {
        [XmlElement("LineOfTextualData")]
        public string[] Lines { get; set; } 
    }
}
