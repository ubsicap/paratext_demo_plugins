using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Paratext.PluginInterfaces;
using Newtonsoft.Json;

namespace ReferencePluginI
{
	public partial class ControlI : EmbeddedPluginControl
	{
		private IWindowPluginHost m_Host;
		private IVerseRef m_Reference;
		private IProject m_Project;
		private List<IUSFMToken> m_Tokens;
		private IWriteLock m_WriteLock;

		public ControlI()
		{
			InitializeComponent();
		}

		public ControlI(IWindowPluginHost host) : this()
		{
			m_Host = host;
			m_WriteLock = null;
		}

		public override void OnAddedToParent(IPluginChildWindow parent, IWindowPluginHost host, string state)
		{
			parent.SetTitle(PluginI.pluginName);

			m_Host = host;
			m_Project = parent.CurrentState.Project;
			m_Reference = parent.CurrentState.VerseRef;
			chapterText.Text = "Click 'Get Chapter'";
			bookName.Text = m_Reference.BookCode;
			chapterNumber.Text = m_Reference.ChapterNum.ToString();
			chapterText.Text = "";
			chapterText.BringToFront();
			changedCheckBox.Checked = false;
			EnableRadioButtons();
			UsfmRadioButton.Checked = true;
			UsfmTokensRadioButton.Checked = false;
			UsxRadioButton.Checked = false;
			m_WriteLock = null;
			lockedCheckBox.Checked = false;

			parent.VerseRefChanged += ReferenceChanged;
			parent.WindowClosing += WindowClosing;
			parent.SaveRequested += SaveRequested;
			parent.ProjectChanged += ProjectChanged;
		}

		public override string GetState()
		{
			return null;
		}

		public override void DoLoad(IProgressInfo progressInfo)
		{
		}

		public void Quit(object sender, EventArgs e)
		{
			Unlock();
		}

		private void Unlock()
		{
			chapterText.Text = "";
			chapterText.BringToFront();
			changedCheckBox.Checked = false;
			if (m_WriteLock != null)
			{
				m_WriteLock.Dispose();
				m_WriteLock = null;
			}
			lockedCheckBox.Checked = false;
			EnableRadioButtons();
		}

		public void ScriptureTextChanged(object sender, EventArgs e)
		{
			changedCheckBox.Checked = true;
		}

		private void ReleaseRequested(IWriteLock writeLock)
		{
			PromptSaveAndUnlock();
		}

		private void SaveRequested(IPluginChildWindow sender)
		{
			PutScripture();
		}

		private void WindowClosing(IPluginChildWindow sender, CancelEventArgs args)
		{
			PromptSaveAndUnlock();
		}

		private void ProjectChanged(IPluginChildWindow sender, IProject newProject)
		{
			// Save the old project first:
			PromptSaveAndUnlock();

			// Then remember the new project
			m_Project = newProject;
		}

		private void PromptSaveAndUnlock()
		{
			if (changedCheckBox.Checked)
			{
				var response = MessageBox.Show("Save changed data?", "Plugin F", MessageBoxButtons.YesNo);
				if (response == DialogResult.Yes)
				{
					PutScripture();
				}
			}

			// Return to the unlocked state:
			Unlock();
		}

		public void GetScripture(object sender, EventArgs e)
		{
			if (m_Project == null)
			{
				MessageBox.Show("No project selected");
				return;
			}

			if (m_WriteLock != null)
			{
				MessageBox.Show("'Quit' to release current lock before getting more Scripture");
				return;
			}

			lockedCheckBox.Checked = true;

			if (UsfmRadioButton.Checked)
			{
				m_WriteLock = m_Project.RequestWriteLock(this, ReleaseRequested, m_Reference.BookNum, m_Reference.ChapterNum);
				chapterText.Text = m_Project.GetUSFM(m_Reference.BookNum, m_Reference.ChapterNum);
				chapterText.BringToFront();
			}
			else if (UsfmTokensRadioButton.Checked)
			{
				m_WriteLock = m_Project.RequestWriteLock(this, ReleaseRequested, m_Reference.BookNum, m_Reference.ChapterNum);
				IEnumerable<IUSFMToken> tokens = m_Project.GetUSFMTokens(m_Reference.BookNum, m_Reference.ChapterNum);
				GetUsfmTokens(tokens);
			}
			else // UsxRadioButton.Checked
			{
				m_WriteLock = m_Project.RequestWriteLock(this, ReleaseRequested, m_Reference.BookNum);
				chapterText.Text = m_Project.GetUSX(m_Reference.BookNum);
				chapterText.BringToFront();
			}

			if (m_WriteLock == null)
			{
				Unlock();
				MessageBox.Show("Unable to get a Write Lock");
				EnableRadioButtons();
			}
			else
			{
				DisableRadioButtons();
			}

			changedCheckBox.Checked = false;
		}

		private void EnableRadioButtons()
		{
			UsfmRadioButton.Enabled = true;
			UsfmTokensRadioButton.Enabled = true;
			UsxRadioButton.Enabled = true;
		}

		private void DisableRadioButtons()
		{
			UsfmRadioButton.Enabled = false;
			UsfmTokensRadioButton.Enabled = false;
			UsxRadioButton.Enabled = false;
		}

		private void GetUsfmTokens(IEnumerable<IUSFMToken> tokens)
		{
			m_Tokens = new List<IUSFMToken>();

			tableLayoutPanel.SuspendLayout();
			int[] widths = tableLayoutPanel.GetColumnWidths();
			int width = widths[1] - 15;
			tableLayoutPanel.BringToFront();
			tableLayoutPanel.Controls.Clear();
			tableLayoutPanel.RowCount = 0;

			foreach (var token in tokens)
			{
				TextBox labelTextBox = new TextBox();
				labelTextBox.ReadOnly = true;

				TextBox dataTextBox = new TextBox();
				dataTextBox.ReadOnly = true;
				dataTextBox.Width = width;

				if (token is IUSFMMarkerToken marker)
				{
					m_Tokens.Add(token);
					switch (marker.Type)
					{
						case MarkerType.Book:
							labelTextBox.Text = "Book";
							break;
						case MarkerType.Chapter:
							labelTextBox.Text = "Chapter";
							break;
						case MarkerType.Verse:
							labelTextBox.Text = "Verse";
							break;
						case MarkerType.Paragraph:
							labelTextBox.Text = "Paragraph";
							break;
						case MarkerType.Character:
							labelTextBox.Text = "Character";
							break;
						case MarkerType.Note:
							labelTextBox.Text = "Note";
							break;
						case MarkerType.End:
							labelTextBox.Text = "End";
							break;
						case MarkerType.Milestone:
							labelTextBox.Text = "Milestone";
							break;
						case MarkerType.MilestoneEnd:
							labelTextBox.Text = "MilestoneEnd";
							break;
						default:
							labelTextBox.Text = "Default Marker";
							break;
					}
					dataTextBox.Text = marker.Data;
				}
				else if (token is IUSFMTextToken textToken)
				{
					TextToken newToken = new TextToken(textToken);
					m_Tokens.Add(newToken);
					labelTextBox.Text = "Text";
					dataTextBox.Text = textToken.Text;
					dataTextBox.ReadOnly = false;
					dataTextBox.Multiline = true;
					dataTextBox.ScrollBars = ScrollBars.Both;
					dataTextBox.TextChanged += new System.EventHandler(this.ScriptureTextChanged);
				}
				else if (token is IUSFMAttributeToken)
				{
					m_Tokens.Add(token);
					labelTextBox.Text = "Attribute";
					dataTextBox.Text = token.ToString();
				}
				else
				{
					m_Tokens.Add(token);
					labelTextBox.Text = "Other";
					dataTextBox.Text = token.ToString();
				}

				tableLayoutPanel.Controls.Add(labelTextBox);
				tableLayoutPanel.Controls.Add(dataTextBox);
			}
			tableLayoutPanel.ResumeLayout();

		}

		public void PutScripture(object sender, EventArgs eArgs)
		{
			PutScripture();
		}

		private void PutScripture()
		{
			if (m_Project == null)
			{
				MessageBox.Show("No project selected");
				return;
			}

			if (m_WriteLock == null)
			{
				MessageBox.Show("'Get' before trying to 'Put'");
				return;
			}

			if (false == changedCheckBox.Checked)
			{
				MessageBox.Show("Data not changed; won't Put it");
				return;
			}

			bool putSucceeded = false;
			if (UsfmRadioButton.Checked)
			{
				string text = chapterText.Text;
				try
				{
					m_Project.PutUSFM(m_WriteLock, text, m_Reference.BookNum);
					putSucceeded = true;
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Exception caught:\n{ex.Message}");
				}
			}
			else if (UsfmTokensRadioButton.Checked)
			{
				UpdateModifiedTokens();
				try
				{
					m_Project.PutUSFMTokens(m_WriteLock, m_Tokens, m_Reference.BookNum);
					putSucceeded = true;
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Exception caught:\n{ex.Message}");
				}
			}
			else if (UsxRadioButton.Checked)
			{
				string text = chapterText.Text;
				try
				{
					m_Project.PutUSX(m_WriteLock, text);
					putSucceeded = true;
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Exception caught:\n{ex.Message}");
				}
			}

			if (putSucceeded)
			{
				changedCheckBox.Checked = false;
				m_WriteLock.SendNotifications();
			}
		}

		private void ReferenceChanged(IPluginChildWindow sender, IVerseRef oldReference, IVerseRef newReference)
		{
			if ((m_Reference.BookNum != newReference.BookNum)
				|| (m_Reference.ChapterNum != newReference.ChapterNum))
			{
				PromptSaveAndUnlock();
				m_Reference = newReference;
				chapterText.Text = "Click 'Get Chapter'";
				chapterText.BringToFront();
				bookName.Text = m_Reference.BookCode;
				chapterNumber.Text = m_Reference.ChapterNum.ToString();
				changedCheckBox.Checked = false;
			}
		}


		private void UpdateModifiedTokens()
		{
			for (int row=0; row < m_Tokens.Count; row++)
			{
				if (m_Tokens[row] is TextToken textToken)
				{
					TextBox data = (TextBox)tableLayoutPanel.GetControlFromPosition(1, row);
					textToken.Text = data.Text;
				}
			}
		}
	}

	class TextToken : IUSFMTextToken
	{
		public TextToken(IUSFMTextToken token)
		{
			Text = token.Text;
			VerseRef = token.VerseRef;
			VerseOffset = token.VerseOffset;
			IsSpecial = token.IsSpecial;
			IsFigure = token.IsFigure;
			IsFootnoteOrCrossReference = token.IsFootnoteOrCrossReference;
			IsScripture = token.IsScripture;
			IsMetadata = token.IsMetadata;
			IsPublishableVernacular = token.IsPublishableVernacular;
		}

		public string Text {get; set; }

		public IVerseRef VerseRef {get; set; }

		public int VerseOffset {get; set; }

		public bool IsSpecial {get; set; }

		public bool IsFigure {get; set; }

		public bool IsFootnoteOrCrossReference {get; set; }

		public bool IsScripture {get; set; }

		public bool IsMetadata {get; set; }

		public bool IsPublishableVernacular {get; set; }
	}
}
