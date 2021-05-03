using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Paratext.PluginInterfaces;


namespace ReferencePluginE
{
    public class PluginE : IParatextWindowPlugin
    {
		public const string pluginName = "Reference Plugin E";
		public string Name => pluginName;
		public string Description => "Demonstrates reading Scripture text.";
		public Version Version => new Version(1, 0);
		public string VersionString => Version.ToString();
		public string Publisher => "SIL/UBS";
		public IEnumerable<KeyValuePair<string, XMLDataMergeInfo>> MergeDataInfo => null;

		public IEnumerable<WindowPluginMenuEntry> PluginMenuEntries
		{
			get
			{
				yield return new WindowPluginMenuEntry("PluginE...", Run, PluginMenuLocation.ScrTextProject);
			}
		}

		public void Run(IWindowPluginHost host, IParatextChildState windowState)
		{
			ControlE theControl = new ControlE();
			host.ShowEmbeddedUi(theControl, windowState.Project);
		}
	}
}
