using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Paratext.PluginInterfaces;


namespace ReferencePluginI
{
	public class PluginI : IParatextWindowPlugin
	{
		public const string pluginName = "Reference Plugin I";
		public string Name => pluginName;
		public string GetDescription(string locale) => "Exercises reading and writing scripture data.";
		public Version Version => new Version(1, 0);
		public string VersionString => Version.ToString();
		public string Publisher => "SIL/UBS";
		public IEnumerable<KeyValuePair<string, XMLDataMergeInfo>> MergeDataInfo => null;

		public IEnumerable<WindowPluginMenuEntry> PluginMenuEntries
		{
			get
			{
				yield return new WindowPluginMenuEntry("PluginI...", Run, PluginMenuLocation.ScrTextTools);
			}
		}

		/// <summary>
		/// Called by Paratext when the menu item created for this plugin was clicked.
		/// </summary>
		private void Run(IWindowPluginHost host, IParatextChildState windowState)
		{
			host.ShowEmbeddedUi(new ControlI(), windowState.Project);
		}
	}
}
