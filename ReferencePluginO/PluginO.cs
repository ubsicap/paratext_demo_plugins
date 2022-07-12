using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Paratext.PluginInterfaces;

namespace ReferencePluginO
{
    public class PluginO : IParatextWindowPlugin
    {
		public const string pluginName = "Reference Plugin O";
		public string Name => pluginName;
		public string GetDescription(string locale) => "Demonstrates accessing project lists.";
		public Version Version => new Version(1, 0);
		public string VersionString => Version.ToString();
		public string Publisher => "SIL/UBS";
		public IDataFileMerger GetMerger(IPluginHost host, string dataIdentifier)
		{
			return new MyMerger();
		}

		public IEnumerable<WindowPluginMenuEntry> PluginMenuEntries
		{
			get
			{
				yield return new WindowPluginMenuEntry("PluginO...", Run, PluginMenuLocation.ParatextAdvanced);
			}
		}

		public void Run(IWindowPluginHost host, IParatextChildState windowState)
		{
			ControlO theControl = new ControlO();
			host.ShowEmbeddedUi(theControl, null);
		}
	}

	public class MyMerger : IDataFileMerger
	{
		public string Merge(string theirs, string mine, string parent)
		{
			return mine;
		}
	}
}
