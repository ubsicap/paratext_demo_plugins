using System;
using System.Collections.Generic;
using Paratext.PluginInterfaces;

namespace ReferencePluginQ
{
    public partial class ControlQ : EmbeddedPluginControl
    {
        private IProject m_Project;
        private IWindowPluginHost m_Host;
        private List<IProject> m_ProjectList;
        private IVerseRef m_VerseRef;


        public ControlQ()
        {
            InitializeComponent();
            m_ProjectList = new List<IProject>();
        }

        public override void OnAddedToParent(IPluginChildWindow parent, IWindowPluginHost host, string state)
        {
            m_Host = host;
            parent.SetTitle(PluginQ.pluginName);
            m_Project = null;

            parent.VerseRefChanged += VerseRefChanged;
        }

        private void UpdateProjectList()
        {
            m_ProjectList.Clear();
            var windows = m_Host.AllOpenWindows;
            ProjectsListBox.Items.Clear();
            foreach (var window in windows)
            {
                if (window is ITextCollectionChildState tc)
                {
                    var projects = tc.AllProjects;
                    foreach (var proj in projects)
                    {
                        m_ProjectList.Add(proj);
                        ProjectsListBox.Items.Add(proj.ShortName);
                    }
                    m_VerseRef = tc.VerseRef;
                    break;
                }
            }
            if (ProjectsListBox.Items.Count > 0)
            {
                ProjectsListBox.SelectedIndex = 0;
                ProjectListBox_SelectedIndexChanged(null, null);
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
            Invoke((Action)(() => UpdateProjectList()));
            Invoke((Action)(() => ShowScripture()));
        }

        public void VerseRefChanged(IPluginChildWindow sender, IVerseRef oldReference, IVerseRef newReference)
        {
            m_VerseRef = newReference;
            ShowScripture();
        }

        private void ShowScripture()
        {
            List<string> lines = new List<string>();
            if (m_Project == null)
            {
                lines.Add("No project to display");
            }
            else
            {
                lines.Add("USFM Tokens:");
                IEnumerable<IUSFMToken> tokens = null;
                bool sawException = false;
                try
                {
                    tokens = m_Project.GetUSFMTokens(m_VerseRef.BookNum, m_VerseRef.ChapterNum, m_VerseRef.VerseNum);
                }
                catch (Exception e)
                {
                    lines.Add($" Cannot get the USFM Tokens for this project because {e.Message}");
                    sawException = true;
                }

                if ((tokens == null) && (sawException == false))
                {
                    lines.Add("Cannot get the USFM Tokens for this project");
                }

                if (tokens != null)
                {
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
                        else if (token is IUSFMAttributeToken)
                        {
                            lines.Add("Attribute Token: " + token.ToString());
                        }
                        else
                        {
                            lines.Add("Unexpected token type: " + token.ToString());
                        }
                    }
                }

                lines.Add("");
                lines.Add("USFM Text:");
                sawException = false;
                try
                {
                    lines.Add(m_Project.GetUSFM(m_VerseRef.BookNum, m_VerseRef.ChapterNum, m_VerseRef.VerseNum));
                }
                catch (Exception e)
                {
                    lines.Add($" Cannot get the USFM Text for this project because {e.Message}");
                    sawException = true;
                }

                if ((tokens == null) && (sawException == false))
                {
                    lines.Add("Cannot get the USFM Text for this project");
                }

                textBox.Lines = lines.ToArray();
            }
        }

        private void ProjectListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool found = false;
            if (ProjectsListBox.SelectedItem != null)
            {
                string name = ProjectsListBox.SelectedItem.ToString();
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
            }
            if (!found)
            {
                textBox.Text = $"Cannot find project.";
            }

        }

        private void RefreshCollectionButton_Click(object sender, EventArgs e)
        {
            UpdateProjectList();
            ShowScripture();
        }
    }
}
