using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Paratext.PluginInterfaces;

namespace ReferencePluginH
{
    public class PluginH : IParatextWindowPlugin
    {
		private ControlH theControl;
		public const string pluginName = "Reference Plugin H";
		public string Name => pluginName;
		public string Description => "Exercises the Paratext List Window.";
		public Version Version => new Version(1, 0);
		public string VersionString => Version.ToString();
		public string Publisher => "SIL/UBS";
		public IEnumerable<KeyValuePair<string, XMLDataMergeInfo>> MergeDataInfo => null;

		public IEnumerable<WindowPluginMenuEntry> PluginMenuEntries
		{
			get
			{
				yield return new WindowPluginMenuEntry("PluginH...", Run, PluginMenuLocation.ScrTextTools);
				yield return new WindowPluginMenuEntry("PluginH...", MenuClicked, PluginMenuLocation.ListDefault);
			}
		}

		/// <summary>
		/// Called by Paratext when the menu item created for this plugin was clicked.
		/// </summary>
		private void Run(IWindowPluginHost host, IParatextChildState windowState)
		{
			theControl = new ControlH(host);
			host.ShowEmbeddedUi(theControl, windowState.Project);
		}
		private void MenuClicked(IWindowPluginHost host, IParatextChildState windowState)
		{
			theControl.MenuClicked();
		}
	}
}
