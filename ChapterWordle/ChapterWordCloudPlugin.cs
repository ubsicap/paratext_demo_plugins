using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Paratext.PluginInterfaces;
using static System.String;

namespace ChapterWordCloudPlugin
{
    /// <summary>
    /// Simple plugin that shows a word cloud based on the text of the current chapter.
    /// </summary>
	[PublicAPI]
	public class ChapterWordCloudPlugin : IParatextWindowPlugin
    {
        public const string pluginName = "Chapter Word Cloud";
		public string Name => pluginName;
		public string Description => "Shows a \"Word Cloud\" of the current chapter.";
		public Version Version => new Version(2, 0);
		public string VersionString => Version.ToString();
		public string Publisher => "SIL/UBS";

		public IEnumerable<IPluginMenuEntry<IWindowPluginHost>> PluginMenuEntries
		{
			get
			{
				yield return new MenuEntry();
			}
		}

		/// <summary>
		/// Called by Paratext when the menu item created for this plugin was clicked.
		/// </summary>
		private static void Run(IWindowPluginHost host, IParatextChildState activeWindow)
		{
			var wordle = new WordCloudControl(activeWindow.CurrentVerseRef, activeWindow.Project);
			host.ShowEmbeddedUi(wordle);
		}

		private class MenuEntry : IPluginMenuEntry<IWindowPluginHost>
		{
			public string GetText(string locale)
			{
				return "&" + pluginName + "...";
			}

			public PluginMenuLocation Location => PluginMenuLocation.ScrTextTools;

			public IEnumerable<string> InsertAfterMenuHierarchy => null;

			public string ImagePath => null;
			public WhenToShow ShowWhen => WhenToShow.EditableProject;
			public Action<IWindowPluginHost, IParatextChildState> Clicked => Run;
		}
	}
}