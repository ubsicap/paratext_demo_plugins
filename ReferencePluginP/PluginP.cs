using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Paratext.PluginInterfaces;


namespace ReferencePluginP
{
    public class PluginP : IParatextWindowPlugin
    {
		public const string pluginName = "Reference Plugin P";
		public string Name => pluginName;
		public string GetDescription(string locale) => "Demonstrates accessing style info.";
		public Version Version => new Version(1, 0);
		public string VersionString => Version.ToString();
		public string Publisher => "SIL/UBS";
		public IDataFileMerger GetMerger(IPluginHost host, string dataIdentifier) => throw new NotImplementedException();

		public IEnumerable<WindowPluginMenuEntry> PluginMenuEntries
		{
			get
			{
				yield return new WindowPluginMenuEntry("PluginP...", Run, PluginMenuLocation.ScrTextProject);
			}
		}

		public void Run(IWindowPluginHost host, IParatextChildState windowState)
		{
			ControlP theControl = new ControlP();
			host.ShowEmbeddedUi(theControl, windowState.Project);
		}
	}
}
