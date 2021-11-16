using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;

using Paratext.PluginInterfaces;

namespace ReferencePluginH
{
	public partial class ControlH : EmbeddedPluginControl
	{
		private IVerseRef m_Reference;
		private IProject m_Project;
		private IWindowPluginHost m_Host;

		public ControlH()
		{
			InitializeComponent();
			m_Host = null;
		}

		public ControlH(IWindowPluginHost host) : this()
		{
			m_Host = host;
		}

		public override void OnAddedToParent(IPluginChildWindow parent, IWindowPluginHost host, string state)
		{
			parent.SetTitle(PluginH.pluginName);

			m_Host = host;
			m_Project = parent.CurrentState.Project;
			m_Reference = parent.CurrentState.VerseRef;

			IReferenceListWindow refList = host.ReferenceList;
			refList.ListChanged += ListChanged;
			refList.SelectedItemChanged += SelectedItemChanged;
			refList.ItemDoubleClicked += ItemDoubleClicked;
		}

		public override string GetState()
		{
			return null;
		}

		public override void DoLoad(IProgressInfo progressInfo)
		{
		}

		public void GenerateList(object sender, EventArgs e)
		{
			IVersification versification = m_Project.Versification;
			List<RefItem> items = new List<RefItem>();

			IVerseRef start = versification.CreateReference(40, 1, 1);
			IVerseRef end = versification.CreateReference(40, 1, 1);
			RefItem item1 = new RefItem()
			{
				VerseRefStart = start,
				VerseRefEnd = end,
				SelectedText = "Text",
				BeforeContext = "Before",
				AfterContext = "After",
				Message = "This is an information message",
				MessageId = "Id1",
				Severity = SeverityLevel.Information
			};
			items.Add(item1);

			start = versification.CreateReference(40, 1, 2);
			end = versification.CreateReference(40, 1, 2);
			RefItem item2 = new RefItem()
			{
				VerseRefStart = start,
				VerseRefEnd = end,
				SelectedText = "Text",
				BeforeContext = "Before",
				AfterContext = "After",
				Message = "This is an error message",
				MessageId = "Id2",
				Severity = SeverityLevel.Error
			};
			items.Add(item2);

			start = versification.CreateReference(40, 1, 3);
			end = versification.CreateReference(40, 1, 3);
			RefItem item3 = new RefItem()
			{
				VerseRefStart = start,
				VerseRefEnd = end,
				SelectedText = "Text",
				BeforeContext = "Before",
				AfterContext = "After",
				Message = "This is a warning message",
				MessageId = "Id3",
				Severity = SeverityLevel.Warning
			};
			items.Add(item3);

			IReferenceListWindow refList = m_Host.ReferenceList;
			Action<IProgressInfo> rerunAction = null;
			if (enableRerunCheckBox.Checked)
			{
				rerunAction = Rerun;
			}
			refList.Load(m_Project, titleText.Text, items, true, rerunAction);
		}

		public void GetAllItems(object sender, EventArgs e)
		{
			IReferenceListWindow refList = m_Host.ReferenceList;
			IReadOnlyList<IReferenceListItem> mylist = refList.AllListItems;
			ShowItems(mylist);
		}

		public void GetDisplayedItems(object sender, EventArgs e)
		{
			IReferenceListWindow refList = m_Host.ReferenceList;
			IReadOnlyList<IReferenceListItem> mylist = refList.DisplayedListItems;
			ShowItems(mylist);
		}

		public void GetSelectedItems(object sender, EventArgs e)
		{
			IReferenceListWindow refList = m_Host.ReferenceList;
			IEnumerable<IReferenceListItem> mylist = refList.SelectedItems;
			ShowItems(mylist);
		}

		private void ShowItems(IEnumerable<IReferenceListItem> list)
		{
			ShowItems(list, null);
		}

		private void ShowItems(IEnumerable<IReferenceListItem> list, string prefix)
		{
			if (list != null)
			{
				List<string> lines = new List<string>();
				if (false == string.IsNullOrEmpty(prefix))
				{
					lines.Add(prefix);
				}
				foreach (var item in list)
				{
					string text = "";
					if (item.VerseRefStart != null)	// Denied items might have null selection
					{
						text += $"{item.VerseRefStart} {item.SelectedText} ";
					}
					text += $"{item.Severity} {item.Message}";
					lines.Add(text);
				}
				itemsText.Lines = lines.ToArray();
			}
		}

		public void Rerun(IProgressInfo progressInfo)
		{
			progressInfo.Initialize("Building list", 100, 0);
			for (int i=0; i<100; i++)
			{
				progressInfo.Value = i;
				Thread.Sleep(5 * 1000 / 100);
				if (progressInfo.CancelRequested)
				{
					MessageBox.Show("List generation canceled");
					return;
				}
			}
			IReferenceListWindow refList = m_Host.ReferenceList;
			IReadOnlyList<IReferenceListItem> mylist = refList.AllListItems;
		}

		public void ListChanged()
		{
			IReferenceListWindow refList = m_Host.ReferenceList;
			IReadOnlyList<IReferenceListItem> mylist = refList.AllListItems;
			ShowItems(mylist, "List changed to:");
		}

		public void SelectedItemChanged()
		{
			IReferenceListWindow refList = m_Host.ReferenceList;
			IEnumerable<IReferenceListItem> mylist = refList.SelectedItems;
			ShowItems(mylist, "Selected item changed to:");

		}

		public void ItemDoubleClicked(IReferenceListWindow sender, IReferenceListItem item)
		{
			itemsText.Text = $"Item {item.VerseRefStart} {item.SelectedText}, {item.Message} double-clicked";
		}

		public void MenuClicked()
		{
			itemsText.Text = "Menu clicked";
		}
	}

	class RefItem : IReferenceListItem
	{
		public IVerseRef VerseRefStart { get; set; }
		public IVerseRef VerseRefEnd { get; set; }
		public string SelectedText { get; set; }
		public int Offset { get; set; }
		public string BeforeContext { get; set; }
		public string AfterContext { get; set; }
		bool IEquatable<ISelection>.Equals(ISelection other)
		{
			throw new NotImplementedException();
		}
		public string Message { get; set; }
		public string MessageId { get; set; }
		public SeverityLevel Severity { get; set; }
	}

}
