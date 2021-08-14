using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Paratext.PluginInterfaces;


namespace ReferencePluginN
{
    public class PluginN : IParatextWindowPlugin
    {
		public const string pluginName = "Reference Plugin N";
		public string Name => pluginName;
		public string GetDescription(string locale) => "Demonstrates accessing style info.";
		public Version Version => new Version(1, 0);
		public string VersionString => Version.ToString();
		public string Publisher => "SIL/UBS";
		public IEnumerable<KeyValuePair<string, XMLDataMergeInfo>> MergeDataInfo => null;

		public IEnumerable<WindowPluginMenuEntry> PluginMenuEntries
		{
			get
			{
				yield return new WindowPluginMenuEntry("PluginN...", Run, PluginMenuLocation.ScrTextProject);
			}
		}

		public void Run(IWindowPluginHost host, IParatextChildState windowState)
		{
			ControlN theControl = new ControlN();
			host.ShowEmbeddedUi(theControl, windowState.Project);
		}
	}
}
