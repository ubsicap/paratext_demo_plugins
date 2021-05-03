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


namespace ReferencePluginE
{
	public partial class ControlE : EmbeddedPluginControl
	{
		private IVerseRef m_Reference;
		private IProject m_Project;
		IWindowPluginHost m_Host;

		public ControlE()
		{
			InitializeComponent();
			m_Host = null;
		}
		public override void OnAddedToParent(IPluginChildWindow parent, IWindowPluginHost host, string state)
		{
			parent.SetTitle(PluginE.pluginName);
			m_Host = host;
			m_Project = parent.CurrentState.Project;
			m_Reference = parent.CurrentState.VerseRef;

			parent.ProjectChanged += ProjectChanged;
			parent.VerseRefChanged += VerseRefChanged;

			ShowScripture();
		}

		public override string GetState()
		{
			return null;
		}

		public override void DoLoad(IProgressInfo progressInfo)
		{
		}

		public void ProjectChanged(IPluginChildWindow sender, IProject newProject)
		{
			m_Project = newProject;
			m_Reference = sender.CurrentState.VerseRef;
			ShowScripture();
		}

		public void VerseRefChanged(IPluginChildWindow sender, IVerseRef oldReference, IVerseRef newReference)
		{
			m_Reference = newReference;
			ShowScripture();
		}

		private void ShowScripture()
		{
			IEnumerable<IUSFMToken> tokens = m_Project.GetUSFMTokens(m_Reference.BookNum, m_Reference.ChapterNum);
			List<string> lines = new List<string>();
			foreach (var token in tokens)
			{
				if (token is IUSFMMarkerToken marker)
				{
					switch (marker.Type)
					{
						case MarkerType.Book:
							lines.Add("Book Marker: " + marker.Data);
							break;
						case MarkerType.Chapter:
							lines.Add("Chapter Marker: " + marker.Data);
							break;
						case MarkerType.Verse:
							lines.Add("Verse Marker: " + marker.Data);
							break;
						default:
							lines.Add("Other Marker: " + marker.Data);
							break;
					}
				}
				else if (token is IUSFMTextToken textToken)
				{
					lines.Add("Text Token: " + textToken.Text);
				}
				else if (token is IUSFMAttributeToken )
				{
					lines.Add("Attribute Token: " + token.ToString());
				}
				else
				{
					lines.Add("Other token type: " + token.ToString());
				}
			}
			textBox.Lines = lines.ToArray();
		}
	}
}
