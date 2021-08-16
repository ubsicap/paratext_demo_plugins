using System;
using System.Collections.Generic;

using Paratext.PluginInterfaces;

namespace ReferencePluginL
{
	public class PluginL : IParatextWindowPlugin
	{
		public const string pluginName = "Reference Plugin L";
		public string Name => pluginName;
		public string GetDescription(string locale) => "Demonstrates accessing project notes.";
		public Version Version => new Version(1, 0);
		public string VersionString => Version.ToString();
		public string Publisher => "SIL/UBS";

		public IEnumerable<WindowPluginMenuEntry> PluginMenuEntries
		{
			get
			{
				yield return new WindowPluginMenuEntry("PluginL...", Run, PluginMenuLocation.ScrTextDefault);
			}
		}

		public IDataFileMerger GetMerger(IPluginHost host, string dataIdentifier) => throw new NotImplementedException();

		/// <summary>
		/// Called by Paratext when the menu item created for this plugin was clicked.
		/// </summary>
		private void Run(IWindowPluginHost host, IParatextChildState windowState)
		{
			host.ShowEmbeddedUi(new ControlL(), windowState.Project);
		}
	}
}
