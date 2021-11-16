using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Paratext.PluginInterfaces;

namespace ReferencePluginD
{
	class AnnotationSource : IPluginAnnotationSource
	{
		private Regex[] m_regexes;
		public AnnotationSource()
		{
			m_regexes = new Regex[]
				{
				new Regex("Jesus", RegexOptions.Compiled),
				new Regex("Christ", RegexOptions.Compiled)
				};
		}

		public event EventHandler AnnotationsChanged;

		public bool MaintainSelectionsOnWordBoundaries => false;

		public IReadOnlyList<AnnotationStyle> GetStyleInfo(double zoom)
		{
			return new[]
			{
				new AnnotationStyle("jesus", "font-weight: bold;"),
				new AnnotationStyle("christ", "font-style: italic;")
			};
		}

		public IReadOnlyList<IPluginAnnotation> GetAnnotations(IVerseRef verseRef, string usfm)
		{
			List<IPluginAnnotation> annotations = new List<IPluginAnnotation>();
			var styles = GetStyleInfo(0.0);
			for (int i=0; i < m_regexes.Count(); i++)
			{
				Regex regex = m_regexes[i];
				string style = styles[i].Name;
				foreach (Match match in regex.Matches(usfm))
				{
					Selection sel = new Selection(match.Value, usfm.Substring(0, match.Index),
						usfm.Substring(match.Index + match.Length), verseRef, match.Index);
					annotations.Add(new Annotation(sel, style));
				}
			}

			return annotations;
		}

		private sealed class Annotation : IPluginAnnotation
		{
			public Annotation(IScriptureTextSelection selection, string styleName)
			{
				ScriptureSelection = selection;
				StyleName = styleName;
			}
			public IScriptureTextSelection ScriptureSelection { get; }

			public string StyleName { get; }

			public string Icon => "cross.png";

			public string IconToolTipText => null;

			public bool Click(MouseButton button, bool onIcon, Point location)
			{
				string icon = onIcon ? "on icon" : "off icon";
				MessageBox.Show($"Clicked with {button} button {icon} at {location}");
				return true;
			}
		}

		private sealed class Selection : IScriptureTextSelection
		{
			public Selection(string selectedText, string beforeContext, string afterContext,
				IVerseRef verseRef, int offset)
			{
				SelectedText = selectedText;
				BeforeContext = beforeContext;
				AfterContext = afterContext;
				VerseRefStart = verseRef;
				VerseRefEnd = verseRef;
				Offset = offset;
			}

			public IVerseRef VerseRefStart { get; }

			public IVerseRef VerseRefEnd { get; }

			public string SelectedText { get; }

			public int Offset { get; }

			public string BeforeContext { get; }

			public string AfterContext { get; }

			public bool Equals(ISelection other)
			{
				throw new NotImplementedException();
			}
		}

	}
}
