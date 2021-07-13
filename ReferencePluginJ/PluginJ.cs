using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Paratext.PluginInterfaces;


namespace ReferencePluginJ
{
	public class PluginJ : IParatextWindowPlugin
	{
		public const string pluginName = "Reference Plugin J";
		public string Name => pluginName;
		public string GetDescription(string locale) => "Demonstrates receiving notifications of selection changes.";
		public Version Version => new Version(1, 0);
		public string VersionString => Version.ToString();
		public string Publisher => "SIL/UBS";
		public IEnumerable<KeyValuePair<string, XMLDataMergeInfo>> MergeDataInfo => null;

		public IEnumerable<WindowPluginMenuEntry> PluginMenuEntries
		{
			get
			{
				yield return new WindowPluginMenuEntry("PluginJ...", Run, PluginMenuLocation.ScrTextEdit);
			}
		}

		/// <summary>
		/// Called by Paratext when the menu item created for this plugin was clicked.
		/// </summary>
		private void Run(IWindowPluginHost host, IParatextChildState windowState)
		{
			host.ShowEmbeddedUi(new ControlJ(), windowState.Project);
		}
	}
}
