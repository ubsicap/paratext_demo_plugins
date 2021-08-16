using System;
using System.Collections.Generic;
using Paratext.PluginInterfaces;

namespace ReferencePluginE
{
    public class PluginE : IParatextWindowPlugin
    {
		public const string pluginName = "Reference Plugin E";
		public string Name => pluginName;
		public string GetDescription(string locale) => "Demonstrates reading Scripture text.";
		public Version Version => new Version(1, 0);
		public string VersionString => Version.ToString();
		public string Publisher => "SIL/UBS";

		public IEnumerable<WindowPluginMenuEntry> PluginMenuEntries
		{
			get
			{
				yield return new WindowPluginMenuEntry("PluginE...", Run, PluginMenuLocation.ScrTextProject);
			}
		}

		public IDataFileMerger GetMerger(IPluginHost host, string dataIdentifier) => throw new NotImplementedException();

		public void Run(IWindowPluginHost host, IParatextChildState windowState)
		{
			ControlE theControl = new ControlE();
			host.ShowEmbeddedUi(theControl, windowState.Project);
		}
	}
}
