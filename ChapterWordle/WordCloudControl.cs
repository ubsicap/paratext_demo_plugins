using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Gma.CodeCloud.Controls.TextAnalyses.Extractors;
using Gma.CodeCloud.Controls.TextAnalyses.Processing;
using Paratext.PluginInterfaces;

namespace ChapterWordCloudPlugin
{
    public partial class WordCloudControl : EmbeddedPluginControl
    {
		private IVerseRef m_reference;
		private IProject m_project;

		public WordCloudControl(IVerseRef reference, IProject project)
        {
			m_reference = reference;
			m_project = project;
			InitializeComponent();

            Update();
        }

        private void Update()
		{
			progressBar1.Hide();
			var tokens = m_project.GetUSFMTokens(m_reference.BookNum, m_reference.ChapterNum).OfType<IUSFMTextToken>();
			var text = string.Join(" ", tokens);

			IProgressIndicator progress = new ProgressBarWrapper(progressBar1);

			IEnumerable<string> terms = new StringExtractor(text, progress);

			cloudControl.WeightedWords = terms.CountOccurences().SortByOccurences();

			progressBar1.Hide();
		}

        private class ProgressBarWrapper : IProgressIndicator
        {
            private readonly ProgressBar m_ProgressBar;

            public ProgressBarWrapper(ProgressBar toolStripProgressBar)
            {
                m_ProgressBar = toolStripProgressBar;
            }

            public int Value
            {
                get { return m_ProgressBar.Value; }
                set { m_ProgressBar.Value = value; }
            }

            public virtual int Maximum
            {
                get { return m_ProgressBar.Maximum; }
                set { m_ProgressBar.Maximum = value; }
            }

            public virtual void Increment(int value)
            {
                m_ProgressBar.Increment(value);
                Application.DoEvents();
            }
        }

		public override void OnAddedToParent(IPluginChildWindow parent)
		{
			parent.ReferenceChanged += Parent_ReferenceChanged;
		}

		private void Parent_ReferenceChanged(IVerseRef oldReference, IVerseRef newReference)
		{
			m_reference = newReference;
            Update();
		}

		public override string Title => ChapterWordCloudPlugin.pluginName;
	}
}
