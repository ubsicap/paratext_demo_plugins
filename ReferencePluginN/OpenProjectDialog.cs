using Paratext.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ReferencePluginN
{
    public partial class OpenProjectDialog : Form
    {
        #region ResourceCategory
        public enum ResourceCategory
        {
            Standard,
            Dictionary,
            SLT,
        }
        #endregion

        #region SLTResource
        public enum SLTResource
        {
            HEB,
            LXX,
        }
        #endregion

        private IPluginHost m_host;
        private IProject m_project;
        private const string _openForceNew = "Force New";
        private const string _openUseExisting = "Use Existing";
        private const string _openQuickReference = "Quick Reference";
        private const string _hebGrk = "HEB/GRK";
        private const string _lxxGrk = "LXX/GRK";

        private List<IReadOnlyProject> selectableProjectList;
        public IReadOnlyProject SelectedProject = null;
        public ResourceCategory SelectedResourceCategory;
        public SLTResource SelectedSLTResource;
        public SLTProject SelectedSLTProject;
        public OpenWindowBehavior SelectedOpenWindowBehavior;
        public IVerseRef SelectedVerseRef;
        public string SelectedDictionaryEntry;
        public int SelectedWordToSelect;

        public OpenProjectDialog()
        {
            InitializeComponent();
        }

        public void LoadControl(IPluginHost host, IProject project)
        {
            m_host = host;
            m_project = project;
            selectableProjectList = m_host.AllResources.Union(m_host.AllEnhancedResources).ToList();
            LoadOpenOptionCombo();
            LoadReferenceList();

            txtBook_BCV.Text = "40";
            txtBook_SLT.Text = "40";
            txtChapter_BCV.Text = "1";
            txtChapter_SLT.Text = "1";
            txtVerse_BCV.Text = "1";
            txtVerse_SLT.Text = "1";
            txtEntry_Dictionary.Text = "Entry";
            txtWord_SLT.Text = "0";
        }

        private void LoadOpenOptionCombo()
        {
            this.cbOpenOption_BCV.Items.Clear();
            this.cbOpenOption_BCV.Items.Add(_openForceNew);
            this.cbOpenOption_BCV.Items.Add(_openUseExisting);
            this.cbOpenOption_BCV.Items.Add(_openQuickReference);
            cbOpenOption_BCV.SelectedIndex = 0;

            this.cbOpenOption_Dictionary.Items.Clear();
            this.cbOpenOption_Dictionary.Items.Add(_openForceNew);
            this.cbOpenOption_Dictionary.Items.Add(_openUseExisting);
            this.cbOpenOption_Dictionary.Items.Add(_openQuickReference);
            cbOpenOption_Dictionary.SelectedIndex = 0;

            this.cbOpenOption_SLT.Items.Clear();
            this.cbOpenOption_SLT.Items.Add(_openForceNew);
            this.cbOpenOption_SLT.Items.Add(_openUseExisting);
            this.cbOpenOption_SLT.Items.Add(_openQuickReference);
            cbOpenOption_SLT.SelectedIndex = 0;
        }

        private void LoadReferenceList()
        {
            selectableProjectList.Sort(CompareProjects);

            lstProject_BCV.BeginUpdate();
            lstProject_BCV.Items.Clear();

            var gcn = selectableProjectList.FirstOrDefault(x => x.LongName.Contains("Global Consultant"));

            var standardResource = selectableProjectList.Where(x =>
                (x.Type == ProjectType.Standard && !x.LongName.Contains("Global Consultant")) || (x.Type == ProjectType.Xml && string.Equals(x.ShortName, "attributetest", StringComparison.OrdinalIgnoreCase)) || x.Type == ProjectType.EnhancedResource);
            
            var dictionary = selectableProjectList.Where(x =>
                x.Type == ProjectType.Dictionary || (x.Type == ProjectType.Xml &&
                                                     !string.Equals(x.ShortName, "attributetest",
                                                         StringComparison.OrdinalIgnoreCase)));
            foreach (IReadOnlyProject proj in standardResource)
                lstProject_BCV.Items.Add(CreateListItem(proj));

            lstProject_BCV.EndUpdate();

            lstProject_Dictionary.BeginUpdate();
            lstProject_Dictionary.Items.Clear();

            foreach (IReadOnlyProject proj in dictionary)
                lstProject_Dictionary.Items.Add(CreateListItem(proj));

            lstProject_Dictionary.EndUpdate();

            cbSelect_SLT.BeginUpdate();
            cbSelect_SLT.Items.Clear();

            cbSelect_SLT.Items.Add(_hebGrk);
            cbSelect_SLT.Items.Add(_lxxGrk);

            cbSelect_SLT.EndUpdate();
            cbSelect_SLT.SelectedIndex = 0;
        }

        private static int CompareProjects(IReadOnlyProject a, IReadOnlyProject b)
        {
            int result = string.Compare(a.Type.ToString(), b.Type.ToString(), StringComparison.OrdinalIgnoreCase);

            if (result == 0)
                result = string.Compare(a.ShortName, b.ShortName, StringComparison.OrdinalIgnoreCase);

            return result;
        }

        private static ListViewItem CreateListItem(IReadOnlyProject xmlProject)
        {
            ListViewItem lvi = new ListViewItem { Text = xmlProject.ToString() };
            lvi.SubItems.Add(xmlProject.Type.ToString());
            lvi.SubItems.Add(xmlProject.LanguageName);
            lvi.Tag = xmlProject;
            return lvi;
        }

        private OpenWindowBehavior ConvertOpenWindowBehavior(string selectedOpenOption)
        {
            if (string.Equals(selectedOpenOption, _openForceNew, StringComparison.OrdinalIgnoreCase))
                return OpenWindowBehavior.ForceNew;
            if (string.Equals(selectedOpenOption, _openUseExisting, StringComparison.OrdinalIgnoreCase))
                return OpenWindowBehavior.UseExisting;
            if (string.Equals(selectedOpenOption, _openQuickReference, StringComparison.OrdinalIgnoreCase))
                return OpenWindowBehavior.QuickReference;

            return OpenWindowBehavior.ForceNew;
        }

        private SLTProject ConvertSltResource(SLTResource resource)
        {
            if (resource == SLTResource.HEB)
                return SLTProject.HebrewGreek;
            
            return SLTProject.SeptuagintGreek;
        }

        private void btnOpen_BCV_Click(object sender, EventArgs e)
        {
            if (lstProject_BCV.SelectedItems.Count > 0)
            {
                SelectedResourceCategory = ResourceCategory.Standard;
                SelectedProject = (IReadOnlyProject)lstProject_BCV.SelectedItems[0].Tag;
                if (txtBook_BCV.Text.Trim() == "" ||
                    txtChapter_BCV.Text.Trim() == "" ||
                    txtVerse_BCV.Text.Trim() == "")
                {
                    MessageBox.Show("The Book Num, Chapter Num, and Verse Num need to be filled in.");
                    this.DialogResult = DialogResult.None;
                    return;
                }

                try
                {
                    int book = Convert.ToInt32(txtBook_BCV.Text);
                    int chapter = Convert.ToInt32(txtChapter_BCV.Text);
                    int verse = Convert.ToInt32(txtVerse_BCV.Text);
                    SelectedVerseRef = m_project.Versification.CreateReference(book, chapter, verse);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating a verse reference: " + ex.Message);
                    this.DialogResult = DialogResult.None;
                    return;
                }
                SelectedOpenWindowBehavior = ConvertOpenWindowBehavior((string)cbOpenOption_BCV.SelectedItem);
            }
            else
            {
                MessageBox.Show("Please select a resource to open.");
                this.DialogResult = DialogResult.None;
                return;
            }

            Close();
        }

        private void btnOpen_Dictionary_Click(object sender, EventArgs e)
        {
            if (lstProject_Dictionary.SelectedItems.Count > 0)
            {
                SelectedResourceCategory = ResourceCategory.Dictionary;
                SelectedProject = (IReadOnlyProject) lstProject_Dictionary.SelectedItems[0].Tag;
                SelectedOpenWindowBehavior = ConvertOpenWindowBehavior((string)cbOpenOption_Dictionary.SelectedItem);
                SelectedDictionaryEntry = txtEntry_Dictionary.Text ?? "";
            }
            else
            {
                MessageBox.Show("Please select a dictionary to open.");
                this.DialogResult = DialogResult.None;
                return;
            }


            Close();
        }

        private void btnOpen_SLT_Click(object sender, EventArgs e)
        {
            if (cbSelect_SLT.SelectedItem != null)
            {
                SelectedResourceCategory = ResourceCategory.SLT;
                SelectedSLTResource = cbSelect_SLT.SelectedItem == _hebGrk ? SLTResource.HEB : SLTResource.LXX;
                SelectedSLTProject = ConvertSltResource(SelectedSLTResource);
                SelectedOpenWindowBehavior = ConvertOpenWindowBehavior((string)cbOpenOption_SLT.SelectedItem);
                if (txtBook_SLT.Text.Trim() == "" ||
                    txtChapter_SLT.Text.Trim() == "" ||
                    txtVerse_SLT.Text.Trim() == "")
                {
                    MessageBox.Show("The Book Num, Chapter Num, and Verse Num need to be filled in.");
                    this.DialogResult = DialogResult.None;
                    return;
                }

                try
                {
                    int book = Convert.ToInt32(txtBook_SLT.Text);
                    int chapter = Convert.ToInt32(txtChapter_SLT.Text);
                    int verse = Convert.ToInt32(txtVerse_SLT.Text);
                    SelectedVerseRef = m_project.Versification.CreateReference(book, chapter, verse);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating a verse reference: " + ex.Message);
                    this.DialogResult = DialogResult.None;
                    return;
                }

                SelectedWordToSelect = txtWord_SLT.Text.Trim() == "" ? -1 : Convert.ToInt32(txtWord_SLT.Text.Trim());
            }

            Close();
        }

        private void Numeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

    }
}
