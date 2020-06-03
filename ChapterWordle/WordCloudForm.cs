using System.Collections.Generic;
using System.Windows.Forms;
using Gma.CodeCloud.Controls.TextAnalyses.Extractors;
using Gma.CodeCloud.Controls.TextAnalyses.Processing;

namespace ChapterWordCloudPlugin
{
    public partial class WordCloudForm : Form
    {
        public WordCloudForm(string text)
        {
            InitializeComponent();

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
    }
}
