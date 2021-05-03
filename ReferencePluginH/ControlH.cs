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

			IReferenceList refList = host.ReferenceList;
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
			IVerseRef start = versification.CreateReference(40, 1, 1);
			IVerseRef end = versification.CreateReference(40, 1, 1);
			Selection selection1 = new Selection(start, end, "Text", 0, "Before", "After");

			List<RefItem> items = new List<RefItem>();

			RefItem item1 = new RefItem()
			{
				Selection = selection1,
				Message = "This is an information message",
				MessageId = "Id1",
				Severity = SeverityLevel.Information
			};
			items.Add(item1);

			RefItem item2 = new RefItem()
			{
				Selection = selection1,
				Message = "This is an error message",
				MessageId = "Id2",
				Severity = SeverityLevel.Error
			};
			items.Add(item2);

			RefItem item3 = new RefItem()
			{
				Selection = selection1,
				Message = "This is a warning message",
				MessageId = "Id3",
				Severity = SeverityLevel.Warning
			};
			items.Add(item3);

			IReferenceList refList = m_Host.ReferenceList;
			Action<IProgressInfo> rerunAction = null;
			if (enableRerunCheckBox.Checked)
			{
				rerunAction = Rerun;
			}
			refList.Load(m_Project, titleText.Text, items, true, rerunAction);
		}

		public void GetAllItems(object sender, EventArgs e)
		{
			IReferenceList refList = m_Host.ReferenceList;
			IReadOnlyList<IReferenceListItem> mylist = refList.AllListItems;
			ShowItems(mylist);
		}

		public void GetDisplayedItems(object sender, EventArgs e)
		{
			IReferenceList refList = m_Host.ReferenceList;
			IReadOnlyList<IReferenceListItem> mylist = refList.DisplayedListItems;
			ShowItems(mylist);
		}

		public void GetSelectedItems(object sender, EventArgs e)
		{
			IReferenceList refList = m_Host.ReferenceList;
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
					if (item.Selection != null)	// Denied items might have null selection
					{
						text += $"{item.Selection.VerseRefStart} {item.Selection.SelectedText} ";
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
			IReferenceList refList = m_Host.ReferenceList;
			IReadOnlyList<IReferenceListItem> mylist = refList.AllListItems;
		}

		public void ListChanged()
		{
			IReferenceList refList = m_Host.ReferenceList;
			IReadOnlyList<IReferenceListItem> mylist = refList.AllListItems;
			ShowItems(mylist, "List changed to:");
		}

		public void SelectedItemChanged()
		{
			IReferenceList refList = m_Host.ReferenceList;
			IEnumerable<IReferenceListItem> mylist = refList.SelectedItems;
			ShowItems(mylist, "Selected item changed to:");

		}

		public void ItemDoubleClicked(IReferenceList sender, IReferenceListItem item)
		{
			itemsText.Text = $"Item {item.Selection.VerseRefStart} {item.Selection.SelectedText}, {item.Message} double-clicked";
		}

		public void MenuClicked()
		{
			itemsText.Text = "Menu clicked";
		}
	}

	class RefItem : IReferenceListItem
	{
		public Selection Selection { get; set; }
		public string Message { get; set; }
		public string MessageId { get; set; }
		public SeverityLevel Severity { get; set; }
	}

}
