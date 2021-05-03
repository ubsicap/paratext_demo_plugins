using System;
using System.Collections.Generic;

using Paratext.PluginInterfaces;

namespace ReferencePluginG
{
    public class PluginG : IParatextMainWindowAutomaticPlugin
    {
		public const string pluginName = "Reference Plugin G";
		public string Name => pluginName;
		public string Description => "Demonstrates calling plugin at Paratext main window opening that opens a Paratext window and getting project data.";
		public Version Version => new Version(1, 0);
		public string VersionString => Version.ToString();
		public string Publisher => "SIL/UBS";
		public IEnumerable<KeyValuePair<string, XMLDataMergeInfo>> MergeDataInfo => null;

		public void Run(IWindowPluginHost host)
		{
			if (false == ControlG.m_Exists)
			{
				ControlG theControl = new ControlG();
				host.ShowEmbeddedUi(theControl, null);
			}
		}
	}
}
