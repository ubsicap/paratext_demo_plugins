using System;
using System.Collections.Generic;

using Paratext.PluginInterfaces;

namespace ReferencePluginG
{
    public class PluginG : IParatextMainWindowAutomaticPlugin
    {
		public const string pluginName = "Reference Plugin G";
		public string Name => pluginName;
		public string Description => "Demonstrates starting plugin when Paratext main window opens.\n"+
			"The plugin opens a Paratext window that displays project settings and user permissions.";
		public Version Version => new Version(1, 0);
		public string VersionString => Version.ToString();
		public string Publisher => "SIL/UBS";
		public IEnumerable<KeyValuePair<string, XMLDataMergeInfo>> MergeDataInfo => null;

		public void Run(IWindowPluginHost host)
		{
			if (false == ControlG.s_exists)
			{
				ControlG theControl = new ControlG();
				host.ShowEmbeddedUi(theControl, null);
			}
		}
	}
}
