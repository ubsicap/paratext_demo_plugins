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

namespace ReferencePluginL
{
	public partial class ControlL : EmbeddedPluginControl
	{
		private IProject m_project;
		private int m_booknum;
		private IVerseRef m_verseRef;
		private IReadOnlyList<IProjectNote> m_noteList;

		public ControlL()
		{
			InitializeComponent();
		}
		public override void OnAddedToParent(IPluginChildWindow parent, IWindowPluginHost host, string state)
		{
			parent.SetTitle(PluginL.pluginName);
			parent.ProjectChanged += ProjectChanged;
			parent.VerseRefChanged += VerseRefChanged;

			SetProject(parent.CurrentState.Project);
			m_verseRef = parent.CurrentState.VerseRef;

			RowStyle rowStyle = new RowStyle(SizeType.AutoSize);
			m_tableLayoutPanel.RowStyles.Add(rowStyle);

			AddHeaderRow();
		}

		private void VerseRefChanged(IPluginChildWindow sender, IVerseRef oldReference, IVerseRef newReference)
		{
			m_verseRef = newReference;
		}

		private void AddHeaderRow()
		{
			Label author = new Label { Text = "Author" };
			m_tableLayoutPanel.SetRow(author, 0);
			m_tableLayoutPanel.SetColumn(author, 0);
			m_tableLayoutPanel.Controls.Add(author);

			Label comment = new Label { Text = "Comment" };
			m_tableLayoutPanel.SetRow(comment, 0);
			m_tableLayoutPanel.SetColumn(comment, 1);
			m_tableLayoutPanel.Controls.Add(comment);

			Label created = new Label { Text = "Created" };
			m_tableLayoutPanel.SetRow(created, 0);
			m_tableLayoutPanel.SetColumn(created, 2);
			m_tableLayoutPanel.Controls.Add(created);

			Label language = new Label { Text = "Language" };
			m_tableLayoutPanel.SetRow(language, 0);
			m_tableLayoutPanel.SetColumn(language, 3);
			m_tableLayoutPanel.Controls.Add(language);

			Label assignee = new Label { Text = "Assignee" };
			m_tableLayoutPanel.SetRow(assignee, 0);
			m_tableLayoutPanel.SetColumn(assignee, 4);
			m_tableLayoutPanel.Controls.Add(assignee);
		}

		public override string GetState()
		{
			return null;
		}

		public override void DoLoad(IProgressInfo progressInfo)
		{
		}

		private void ProjectChanged(IPluginChildWindow sender, IProject newProject)
		{
			SetProject(newProject);
		}

		private void SetProject(IProject newProject)
		{
			m_project = newProject;

			UpdateBookList();
		}

		private void UpdateBookList()
		{
			m_BookComboBox.Items.Clear();
			if (m_project == null)
				return;
			var bookList = m_project.AvailableBooks;
			foreach (var book in bookList)
			{
				m_BookComboBox.Items.Add(book.Code);
			}
		}

		private void OnBookSelectionChanged(object sender, EventArgs e)
		{
			m_NotesListBox.Items.Clear();
			int index = m_BookComboBox.SelectedIndex;
			if (index < 0)
			{
				return;
			}
			m_booknum = m_project.AvailableBooks[index].Number;
			int chapters = m_project.Versification.GetLastChapter(m_booknum);
			m_ChapterComboBox.Items.Clear();
			m_ChapterComboBox.Items.Add("All");
			for (int i=1; i <= chapters; i++)
			{
				m_ChapterComboBox.Items.Add(i.ToString());
			}
			m_ChapterComboBox.SelectedIndex = 0;
			UpdateNotesList();
		}

		private void UpdateNotesList()
		{
			m_NotesListBox.Items.Clear();
			bool refreshed = RefreshNoteList();
			if (refreshed)
			{
				foreach (var note in m_noteList)
				{
					m_NotesListBox.Items.Add(note.Anchor.VerseRefStart);
				}
				UpdateNoteDisplay();
			}
		}

		private bool RefreshNoteList()
		{
			int index = m_BookComboBox.SelectedIndex;
			if (index < 0)
			{
				return false;
			}
			m_booknum = m_project.AvailableBooks[index].Number;
			int chapter = m_ChapterComboBox.SelectedIndex;
			bool onlyUnresolved = !m_includeResolvedCheckBox.Checked;
			m_noteList = m_project.GetNotes(m_booknum, chapter, onlyUnresolved);
			return true;
		}

		private void OnVerseSelectionChanged(object sender, EventArgs e)
		{
			UpdateNoteDisplay();
		}

		private void UpdateNoteDisplay()
		{
			int index = m_NotesListBox.SelectedIndex;
			if (index < 0)	// Nothing selected
			{
				return;
			}

			var note = m_noteList[index];

			if (note.AssignedUser == null)
			{
				m_assignedToTextBox.Text = "";
			}
			else
			{
				m_assignedToTextBox.Text = note.AssignedUser.Name;
			}
			if (note.ReplyToUser == null)
			{
				m_replyToTextBox.Text = "";
			}
			else
			{
				m_replyToTextBox.Text = note.ReplyToUser.Name;
			}

			m_commentsReadCheckBox.Checked = note.IsRead;
			m_resolvedCheckBox.Checked = note.IsResolved;

			m_tableLayoutPanel.Controls.Clear();
			AddHeaderRow();
			m_tableLayoutPanel.RowCount = note.Comments.Count + 1;
			int row = 1;
			foreach (var comment in note.Comments)
			{
				AddText(row, 0, comment.Author.Name);

				TextBox contents = AddText(row, 1, "");
				contents.WordWrap = true;
				contents.Multiline = true;
				contents.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

				List<string> text = new List<string>();
				if (comment.Contents != null)
				{
					foreach (var paragraph in comment.Contents)
					{
						text.Add(paragraph.ToString());
					}
				}
				contents.Lines = text.ToArray();

				Size size = contents.Size;
				size = contents.GetPreferredSize(size);
				contents.Size = size;

				AddText(row, 2, comment.Created.ToString());
				AddText(row, 3, comment.Language.Id);
				AddText(row, 4, comment.AssignedUser.Name);

				row++;
			}
		}

		private TextBox AddText(int row, int column, string text)
		{
			TextBox textbox = new TextBox
			{
				Text = text,
				ReadOnly = true,
				Dock = DockStyle.Fill
			};
			m_tableLayoutPanel.SetRow(textbox, row);
			m_tableLayoutPanel.SetColumn(textbox, column);
			m_tableLayoutPanel.Controls.Add(textbox);
			return textbox;
		}

		private void OnAddComment(object sender, EventArgs e)
		{
			AddCommentDialog dialog = new AddCommentDialog(m_project);
			dialog.ShowDialog();
			if (dialog.DialogResult == DialogResult.OK)
			{
				if (dialog.m_comment.Lines.Length == 0)
				{
					MessageBox.Show("Comment cannot be empty");
				}
				else
				{
					List<CommentParagraph> paragraphs = FormParagraphs(dialog.m_comment.Lines);
					IWriteLock writeLock = m_project.RequestWriteLock(
						this,
						WriteLockReleaseRequested,
						WriteLockScope.ProjectNotes);
					if (writeLock == null)
					{
						MessageBox.Show("Can't get a write lock");
					}
					else
					{
						int index = m_NotesListBox.SelectedIndex;
						var note = m_noteList[index];
						IUserInfo assignee = dialog.Assignee;

						note.AddNewComment(writeLock, paragraphs, assignedUser: assignee);

						writeLock.Dispose();
					}
				}
				RefreshNoteList();
				UpdateNoteDisplay();
			}

			dialog.Dispose();

		}

		private static List<CommentParagraph> FormParagraphs(string[] lines)
		{
			List<CommentParagraph> paragraphs = new List<CommentParagraph>();
			foreach (string line in lines)
			{
				FormattedString[] formattedStrings = { new FormattedString(line) };
				paragraphs.Add(new CommentParagraph(formattedStrings));
			}
			return paragraphs;
		}

		private void WriteLockReleaseRequested(IWriteLock obj)
		{
			throw new NotImplementedException();
		}

		private void AddNewNote(object sender, EventArgs e)
		{
			AddNoteDialog dialog = new AddNoteDialog(m_project);
			dialog.Verse = m_verseRef;
			dialog.ShowDialog();
			if (dialog.DialogResult == DialogResult.OK)
			{
				if (dialog.m_comment.Lines.Length == 0)
				{
					MessageBox.Show("Comment cannot be empty");
				}
				else
				{
					IWriteLock writeLock = m_project.RequestWriteLock(
						this, 
						WriteLockReleaseRequested, 
						WriteLockScope.ProjectNotes);

					if (writeLock == null)
					{
						MessageBox.Show("Can't get a write lock");
					}
					else
					{
						string text = dialog.SelectedText;
						IScriptureTextSelection anchor = null;
						if (string.IsNullOrEmpty(text))
						{
							anchor = m_project.GetScriptureSelectionForVerse(dialog.Verse);
						}
						else
						{
							IReadOnlyList<IScriptureTextSelection> anchors;
							anchors = m_project.FindMatchingScriptureSelections(dialog.Verse, text, wholeWord:dialog.WholeWord);
							if (anchors.Count != 0)
							{
								anchor = anchors[0];
							}
						}
						if (anchor == null)
						{
							MessageBox.Show("Nothing matches selection");
						}
						else
						{
							List<CommentParagraph> paragraphs = FormParagraphs(dialog.m_comment.Lines);

							IUserInfo assignee = dialog.Assignee;

							m_project.AddNote(writeLock, anchor, paragraphs, assignedUser: assignee);
						}
						writeLock.Dispose();
					}
				}
				UpdateNotesList();
			}
			dialog.Dispose();
		}

		private void ResolveClicked(object sender, EventArgs e)
		{
			int index = m_NotesListBox.SelectedIndex;
			if (index < 0)  // Nothing selected
			{
				MessageBox.Show("Select a note first.");
				return;
			}
			var note = m_noteList[index];
			if (note.IsResolved == false)
			{
				IWriteLock writeLock = m_project.RequestWriteLock(
					this,
					WriteLockReleaseRequested,
					WriteLockScope.ProjectNotes);
				if (writeLock == null)
				{
					MessageBox.Show("Can't get a write lock");
				}
				else
				{
					note.Resolve(writeLock);
					writeLock.Dispose();
					UpdateNotesList();
				}
			}
		}

		private void IncludeResolvedChanged(object sender, EventArgs e)
		{
			UpdateNotesList();
		}

		private void SelectedChapterChanged(object sender, EventArgs e)
		{
			UpdateNotesList();
		}
	}
}
