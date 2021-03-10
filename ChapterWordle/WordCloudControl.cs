using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
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

		public WordCloudControl()
		{
			InitializeComponent();
            progressBar1.Hide();
		}

		#region Implementation of EmbeddedPluginControl
		public override void OnAddedToParent(IPluginChildWindow parent, string state)
		{
            parent.SetTitle(ChapterWordCloudPlugin.pluginName);

			parent.VerseRefChanged += Parent_VerseRefChanged;
            parent.ProjectChanged += Parent_ProjectChanged;

            m_project = parent.CurrentState.Project;
            m_reference = parent.CurrentState.VerseRef;
		}

		public override string GetState()
		{
			return null;
		}

        public override void DoLoad()
        {
            UpdateWordle(null);
        }

        #endregion

        private void Parent_VerseRefChanged(IPluginChildWindow sender, IVerseRef oldReference, IVerseRef newReference)
		{
            Debug.Assert(oldReference.Equals(m_reference));
			m_reference = newReference;
			if (oldReference.BookNum != newReference.BookNum || oldReference.ChapterNum != newReference.ChapterNum)
                UpdateWordleAsync();
		}

        private void Parent_ProjectChanged(IPluginChildWindow sender, IProject newProject)
        {
            m_project = newProject;
            UpdateWordleAsync();
        }

        private Thread updateThread;

        private void UpdateWordleAsync()
        {
            if (updateThread != null && updateThread.IsAlive)
            {
                updateThread.Abort();
                updateThread.Join();
            }

            updateThread = new Thread(UpdateWordleWithProgress);
            updateThread.IsBackground = true;
            updateThread.Start();
        }

        private void UpdateWordleWithProgress()
        {
            IProgressIndicator progress = new ProgressBarWrapper(progressBar1);
            UpdateWordle(progress);
            Invoke(new Action(() => progressBar1.Hide()));
        }

        private void UpdateWordle(IProgressIndicator progress)
        {
            var tokens = m_project.GetUSFMTokens(m_reference.BookNum, m_reference.ChapterNum).OfType<IUSFMTextToken>();
            var text = string.Join(" ", tokens);

            IEnumerable<string> terms = new StringExtractor(text, progress);
            if (!terms.Any())
                terms = new[] {"Empty", "chapter"};

            cloudControl.WeightedWords = terms.CountOccurences().SortByOccurences();
        }

        #region ProgressBarWrapper class
        private class ProgressBarWrapper : IProgressIndicator
        {
            private readonly ProgressBar m_ProgressBar;

            public ProgressBarWrapper(ProgressBar toolStripProgressBar)
            {
                m_ProgressBar = toolStripProgressBar;
                m_ProgressBar.Invoke(new Action(() =>
                {
                    m_ProgressBar.Value = 0;
                    m_ProgressBar.Show();
                }));
            }

            public virtual int Maximum
            {
                get { return m_ProgressBar.Maximum; }
                set
                {
                    m_ProgressBar.Invoke(new Action(() => m_ProgressBar.Maximum = value));
                }
            }

            public virtual void Increment(int value)
            {
                m_ProgressBar.Invoke(new Action(() => m_ProgressBar.Increment(value)));
            }
        }
        #endregion
	}
}
