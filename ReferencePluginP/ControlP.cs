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


namespace ReferencePluginP
{
	public partial class ControlP : EmbeddedPluginControl
	{
		private IVerseRef m_Reference;
		private IProject m_Project;

		public ControlP()
		{
			InitializeComponent();
		}

		public override void OnAddedToParent(IPluginChildWindow parent, IWindowPluginHost host, string state)
		{
			parent.SetTitle(PluginP.pluginName);
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
			Invoke((Action)(() => ShowStyle()));
		}

		public void ProjectChanged(IPluginChildWindow sender, IProject newProject)
		{
			m_Project = newProject;
			m_Reference = sender.CurrentState.VerseRef;
			ShowStyle();
		}

		public void VerseRefChanged(IPluginChildWindow sender, IVerseRef oldReference, IVerseRef newReference)
		{
			m_Reference = newReference;
			ShowStyle();
		}

		private void ShowStyle()
		{
			List<string> lines = new List<string>();
			var markers = m_Project.ScriptureMarkerInformation;
			foreach (var marker in markers)
			{
				if (marker is ICharacterMarkerInfo ch)
				{
					string style = $"{ch.Marker}: ";
					style += GetStyle(ch);
					lines.Add(style);
				}
				if (marker is INoteMarkerInfo notemarker)
				{
					string style = $"{notemarker.Marker}: ";
					style += GetStyle(notemarker);
					lines.Add(style);
				}
				if (marker is IParagraphMarkerInfo paramarker)
				{
					string style = $"{paramarker.Marker}: ";
					style += GetStyle(paramarker);
					if (paramarker.Justification.HasValue)
					{
						style += $"{paramarker.Justification.Value} ";
					}
					if (paramarker.LeftMargin.HasValue)
					{
						style += $"Left Margin: {paramarker.LeftMargin.Value} ";
					}
					if (paramarker.RightMargin.HasValue)
					{
						style += $"Right Margin: {paramarker.RightMargin.Value} ";
					}
					if (paramarker.FirstLineIndent.HasValue)
					{
						style += $"First Line Indent: {paramarker.FirstLineIndent.Value} ";
					}
					if (paramarker.LineSpacing.HasValue)
					{
						style += $"Line Spacing: {paramarker.LineSpacing.Value} ";
					}
					if (paramarker.SpaceBefore.HasValue)
					{
						style += $"Space Before: {paramarker.SpaceBefore.Value} ";
					}
					if (paramarker.SpaceAfter.HasValue)
					{
						style += $"Space After: {paramarker.SpaceAfter.Value} ";
					}
					lines.Add(style);
				}

			}
			textBox.Lines = lines.ToArray();
		}

		private string GetStyle(IStyledMarkerInfo info)
		{
			string style = "";
			style += info.FontFamily;
			style += " ";
			if (false == string.IsNullOrEmpty(info.FontFamily))
			{
				style += $"{info.FontFamily} ";
			}
			if (info.FontSize.HasValue)
			{
				style += $"Size: {info.FontSize.Value} ";
			}
			if (info.Color.HasValue)
			{
				Color color = info.Color.Value;
				if (color.IsNamedColor)
				{
					style += $"Color: {color.Name} ";
				}
				else
				{
					style += $"{color} ";
				}
			}
			if (info.Bold == true)
			{
				style += "Bold ";
			}
			if (info.Italic == true)
			{
				style += "Italic ";
			}
			if (info.SmallCaps == true)
			{
				style += "SmallCaps  ";
			}
			if (info.Subscript == true)
			{
				style += "Subscript ";
			}
			if (info.Superscript == true)
			{
				style += "Superscript ";
			}
			if (info.Underline == true)
			{
				style += "Underline ";
			}

			return style;
		}
	}
}
