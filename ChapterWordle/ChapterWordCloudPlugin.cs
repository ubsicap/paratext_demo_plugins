using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using JetBrains.Annotations;
using Paratext.PluginInterfaces;

namespace ChapterWordCloudPlugin
{
    /// <summary>
    /// Simple plugin that shows a word cloud based on the text of the current chapter.
    /// </summary>
	[PublicAPI]
	public class ChapterWordCloudPlugin : IParatextStandalonePlugin
    {
        public const string pluginName = "Chapter Word Cloud";
	//	private WordCloudForm form;

		//public void RequestShutdown()
  //      {
  //          lock (this)
		//	{
		//		form?.Close();
		//	}
  //      }

		public string Name => pluginName;
		public string Description => "Shows a \"Word Cloud\" of the current chapter.";
		public Version Version => new Version(2, 0);
		public string VersionString => Version.ToString();
		public string Publisher => "SIL/UBS";

		public IEnumerable<IPluginMenuEntry<IPluginHost>> PluginMenuEntries
		{
			get
			{
				yield return new MenuEntry();
			}
		}

		/// <summary>
		/// Called by Paratext when the menu item created for this plugin was clicked.
		/// </summary>
		private static void Run(IPluginHost host, IParatextChildWindow window)
		{
			Form formToShow;
			//lock (this)
			//{
				var project = window.Project;
				IScriptureExtractor extractor = project.GetScriptureExtractor(ExtractorType.USFM);
				IVersification vrs = project.Versification;
				var currRef = window.CurrentScriptureReference.AsBBBCCCVVV;
				int book = currRef / 1000000;
				int chapter = (currRef / 1000) % 1000;
				int bookAndChapter = (currRef / 1000) * 1000;
				int startOfChapter = bookAndChapter + 1;
				int endOfChapter = bookAndChapter + vrs.GetLastVerse(book, chapter);
				string text = extractor.Extract(startOfChapter, endOfChapter);
				StringBuilder bldr = new StringBuilder();
				bool skipping = false;
				for (int i = 0; i < text.Length; i++)
				{
					char ch = text[i];
					if (ch == ' ')
						skipping = false;
					else
						skipping |= (ch == '\\');
					if (!skipping)
						bldr.Append(ch);
				}
				formToShow = /* form = */ new WordCloudForm(bldr.ToString());
				formToShow.Show();
			//}
			//Application.Run(formToShow);
		}

		private class MenuEntry : IPluginMenuEntry<IPluginHost>
		{
			public string GetText(string locale)
			{
				return "&" + pluginName + "...";
			}

			public PluginMenuLocation Location => PluginMenuLocation.ScrTextTools;

			public IEnumerable<string> InsertAfterMenuHierarchy => null;

			public string ImagePath => null;
			public WhenToShow ShowWhen => WhenToShow.EditableProject;
			public Action<IPluginHost, IParatextChildWindow> Clicked => Run;
		}
	}
}