﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Gma.CodeCloud.Controls.TextAnalyses.Extractors;
using Gma.CodeCloud.Controls.TextAnalyses.Processing;
using Paratext.PluginInterfaces;

namespace ChapterWordCloudPlugin
{
    public partial class WordCloudControl : EmbeddedPluginControl
    {
        #region Member variables
		private IVerseRef m_reference;
		private IProject m_project;
		private Regex m_regexWordExtractor;
		private Thread m_updateThread;
		private IWindowPluginHost m_host;
		private string m_selectedText;
        #endregion
        
        #region Constructor
		public WordCloudControl()
		{
			InitializeComponent();
            progressBar1.Hide();
		}
        #endregion

		#region Implementation of EmbeddedPluginControl
		public override void OnAddedToParent(IPluginChildWindow parent, IWindowPluginHost host, string state)
		{
			m_host = host;
			parent.SetTitle(ChapterWordCloudPlugin.pluginName);

			parent.VerseRefChanged += Parent_VerseRefChanged;
            parent.ProjectChanged += Parent_ProjectChanged;

            SetProject(parent.CurrentState.Project);
			m_reference = parent.CurrentState.VerseRef;
			m_selectedText = state;
			selectedTextToolStripMenuItem.Checked = state != null;
		}

		private void SetProject(IProject project)
		{
			if (m_project != null)
				m_project.ProjectDeleted -= HandleProjectDeleted;

			m_project = project;
            project.ProjectDeleted += HandleProjectDeleted;
			m_regexWordExtractor = new Regex(m_project.Language.WordMatchRegex, RegexOptions.Compiled);
		}

		private void HandleProjectDeleted()
		{
			m_project = null;
		}

		public override string GetState()
		{
			return m_selectedText;
		}

        public override void DoLoad(IProgressInfo progress)
        {
            UpdateWordle(new ProgressInfoWrapper(progress));
        }

        #endregion

		#region Overridden Form methods
		protected override void OnHandleDestroyed(EventArgs e)
		{
			m_host.ActiveWindowSelectionChanged -= ActiveWindowSelectionChanged;
			base.OnHandleDestroyed(e);
		}
		#endregion

        #region Event handlers
        private void Parent_VerseRefChanged(IPluginChildWindow sender, IVerseRef oldReference, IVerseRef newReference)
		{
            Debug.Assert(oldReference.Equals(m_reference));
			m_reference = newReference;
			if (oldReference.BookNum != newReference.BookNum || oldReference.ChapterNum != newReference.ChapterNum)
                UpdateWordleAsync();
		}

        private void Parent_ProjectChanged(IPluginChildWindow sender, IProject newProject)
        {
            SetProject(newProject);
            UpdateWordleAsync();
        }

		private void currentChapterToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
		{
			selectedTextToolStripMenuItem.Checked = !currentChapterToolStripMenuItem.Checked;
			if (currentChapterToolStripMenuItem.Checked)
			{
				m_host.ActiveWindowSelectionChanged -= ActiveWindowSelectionChanged;
				m_selectedText = null;
				UpdateWordleWithProgress();
			}
		}

		private void selectedTextToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
		{
			currentChapterToolStripMenuItem.Checked = !selectedTextToolStripMenuItem.Checked;
			if (selectedTextToolStripMenuItem.Checked)
			{
				m_host.ActiveWindowSelectionChanged += ActiveWindowSelectionChanged;

                if (m_selectedText == null)
                    SetSelectedText(m_host.ActiveWindowState);
			}
		}

		private void ActiveWindowSelectionChanged(IPluginHost sender, IParatextChildState activeWindowState, IReadOnlyList<ISelection> currentSelections)
		{
			SetSelectedText(activeWindowState, currentSelections);
		}
		#endregion

		#region Private helper methods
		private void UpdateWordleAsync()
        {
            if (m_updateThread != null && m_updateThread.IsAlive)
            {
                m_updateThread.Abort();
                m_updateThread.Join();
            }

            m_updateThread = new Thread(UpdateWordleWithProgress);
            m_updateThread.IsBackground = true;
            m_updateThread.Start();
        }

        private void UpdateWordleWithProgress()
        {
            IProgressIndicator progress = new ProgressBarWrapper(progressBar1);
            UpdateWordle(progress);
            Invoke(new Action(() => progressBar1.Hide()));
        }

        private void SetSelectedText(IParatextChildState activeWindowState, IReadOnlyList<ISelection> selections = null)
		{
			if (activeWindowState.Project != null && !activeWindowState.Project.Equals(m_project))
				m_selectedText = "Active window is for a different project";
			else
			{
				if (selections == null)
					selections = m_host.ActiveWindowState.Selections;
				
				if (selections == null)
					m_selectedText = "Nothing selected";
				else if (selections.Any(s => s is IReferenceListItem) && !m_host.ReferenceList.Project.Equals(m_project))
                {
                    // Note that while a reference list has its project set based on the one that originally "created"
                    // it, more items can be added to later it based on a differnet project. While this is unusual, it
                    // means that m_host.ReferenceList.Project is only kind of informative and it not 100% reliable. The
                    // items themselves do not remember which project they were created for.
					m_selectedText = "Reference list is for a different project";
                }
				else
				{
					// TODO: Only include whole words.
					m_selectedText = string.Join(" ", selections.OfType<IScriptureTextSelection>().Select(s => s.SelectedText));
					if (string.IsNullOrWhiteSpace(m_selectedText))
						m_selectedText = "No Scripture text selected";
				}
			}

			UpdateWordleWithProgress();
		}

		private void UpdateWordle(IProgressIndicator progress)
		{
			string text;
			if (selectedTextToolStripMenuItem.Checked)
				text = m_selectedText;
			else
			{
				var tokens = m_project.GetUSFMTokens(m_reference.BookNum, m_reference.ChapterNum).OfType<IUSFMTextToken>();
				text = string.Join(" ", tokens);
			}

			IEnumerable<string> terms = m_regexWordExtractor.Matches(text).Cast<Match>().Select(m => m.Value).ToList(); //new StringExtractor(text, progress);
			if (!terms.Any())
			{
				terms = selectedTextToolStripMenuItem.Checked ? new[] {"Nothing", "selected"} :
					new[] {"Empty", "chapter"};
			}

			cloudControl.WeightedWords = terms.CountOccurences().SortByOccurences();
        }
        #endregion

        #region ProgressInfoWrapper class
        private sealed class ProgressInfoWrapper : IProgressIndicator
        {
            private readonly IProgressInfo m_Progress;
            private int m_Maximum;

            public ProgressInfoWrapper(IProgressInfo progress)
            {
                m_Progress = progress;
            }

            public int Maximum
            {
                get => m_Maximum;
                set
                {
                    m_Maximum = value;
                    m_Progress.Initialize("Loading...", m_Maximum);
                }
            }

            public void Increment(int value)
            {
                m_Progress.Value++;
            }
        }
        #endregion

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
