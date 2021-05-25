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


namespace ReferencePluginK
{
	public partial class ControlK : EmbeddedPluginControl
	{
		class ListType
		{
			public string label;
			public bool isProject;
			public BiblicalTermListType type;

			public ListType( string label, bool isProject, BiblicalTermListType type)
			{
				this.label = label;
				this.isProject = isProject;
				this.type = type;
			}

			public override string ToString() => label;
		}

		private ListType ProjectList = new ListType("Project", true, BiblicalTermListType.All );
		private ListType AllList = new ListType("All", false, BiblicalTermListType.All );
		private ListType MajorList = new ListType("Major", false, BiblicalTermListType.Major );


		private IWindowPluginHost m_host;
		private IProject m_project;
		private IBiblicalTermList m_list;

		public ControlK()
		{
			InitializeComponent();
		}
		public override void OnAddedToParent(IPluginChildWindow parent, IWindowPluginHost host, string state)
		{
			parent.SetTitle(PluginK.pluginName);

			m_host = host;
			m_project = parent.CurrentState.Project;

			m_whichListListBox.BeginUpdate();
			m_whichListListBox.Items.Add(ProjectList);
			m_whichListListBox.Items.Add(AllList);
			m_whichListListBox.Items.Add(MajorList);
			m_whichListListBox.SetSelected(0, true);
			m_whichListListBox.EndUpdate();
		}

		public override string GetState()
		{
			return null;
		}

		public override void DoLoad(IProgressInfo progressInfo)
		{
		}

		private void GetBiblicalTerms(object sender, EventArgs e)
		{
			ListType listType = (ListType)m_whichListListBox.SelectedItem;
			if (listType.isProject)
			{
				m_list = m_project.BiblicalTermList;
			}
			else
			{
				m_list = m_host.GetBiblicalTermList(listType.type);
			}

			m_termsListBox.BeginUpdate();
			m_termsListBox.DataSource = null;
			m_termsListBox.Items.Clear();
			m_termsListBox.DataSource = m_list.ToArray();
			m_termsListBox.DisplayMember = "Lemma";

			m_termsListBox.SetSelected(0, true);
			m_termsListBox.EndUpdate();
		}

		private void OpenBiblicalTermsTool(object sender, EventArgs e)
		{
			var window = m_host.BiblicalTermsWindow;
			window.Load(m_project, (IBiblicalTerm)m_termsListBox.SelectedItem, m_list);
		}

		private void TermSelectionChanged(object sender, EventArgs e)
		{
			m_referencesListBox.BeginUpdate();
			m_referencesListBox.Items.Clear();
			m_lemmaTextBox.Text = "";
			m_glossTextBox.Text = "";
			m_guessLabel.Text = "";
			m_renderingsTextBox.Text = "";

			if (m_termsListBox.SelectedItem != null)
			{
				IBiblicalTerm term = (IBiblicalTerm)m_termsListBox.SelectedItem;
				m_lemmaTextBox.Text = term.Lemma;
				string locale = null;
				if (m_localeTextBox.Text != "")
				{
					locale = m_localeTextBox.Text;
				}
				m_glossTextBox.Text = term.Gloss(locale);

				foreach (var r in ((IBiblicalTerm)m_termsListBox.SelectedItem).Occurrences)
				{
					m_referencesListBox.Items.Add($"{r.BookCode} {r.ChapterNum}:{r.VerseNum}");
				}

				var renderings = m_project.GetBiblicalTermRenderings(term, m_guessCheckBox.Checked);
				if (renderings != null)
				{
					m_guessLabel.Text = renderings.IsGuess ? "Is a guess" : "Is from rendering";
					m_renderingsTextBox.Lines = renderings.Renderings.ToArray();
				}
			}

			m_referencesListBox.EndUpdate();
		}

	}
}
