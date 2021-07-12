using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Paratext.PluginInterfaces;

namespace ReferencePluginK
{
	public class PluginK : IParatextWindowPlugin
	{
		public const string pluginName = "Reference Plugin K";
		public string Name => pluginName;
		public string GetDescription(string locale) => "Demonstrates accessing Biblical Terms.";
		public Version Version => new Version(1, 0);
		public string VersionString => Version.ToString();
		public string Publisher => "SIL/UBS";
		public IEnumerable<KeyValuePair<string, XMLDataMergeInfo>> MergeDataInfo => null;

		public IEnumerable<WindowPluginMenuEntry> PluginMenuEntries
		{
			get
			{
				yield return new WindowPluginMenuEntry("PluginK...", Run, PluginMenuLocation.ScrTextDefault);
			}
		}

		/// <summary>
		/// Called by Paratext when the menu item created for this plugin was clicked.
		/// </summary>
		private void Run(IWindowPluginHost host, IParatextChildState windowState)
		{
			host.ShowEmbeddedUi(new ControlK(), windowState.Project);
		}
	}
}
