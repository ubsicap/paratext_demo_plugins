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

		public ControlE()
		{
			InitializeComponent();
		}

		public override void OnAddedToParent(IPluginChildWindow parent, IWindowPluginHost host, string state)
		{
			parent.SetTitle(PluginE.pluginName);
			m_Project = parent.CurrentState.Project;
			m_Reference = parent.CurrentState.VerseRef;

			parent.ProjectChanged += ProjectChanged;
			parent.VerseRefChanged += VerseRefChanged;
		}

		public override string GetState()
		{
			return null;
		}

		public override void DoLoad(IProgressInfo progressInfo)
		{
			// Since DoLoad is done on a different thread than what was used
			// to create the control, we need to use the Invoke method.
			Invoke((Action)(() => ShowScripture()));
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
					lines.Add($"{marker.Type} Marker: {marker.Data}");
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
					lines.Add("Unexpected token type: " + token.ToString());
				}
			}
			textBox.Lines = lines.ToArray();
		}
	}
}
