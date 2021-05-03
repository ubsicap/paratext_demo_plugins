using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

using Paratext.PluginInterfaces;


namespace ReferencePluginF
{
    public class PluginF : IParatextWindowPlugin
    {
		public const string pluginName = "Reference Plugin F";
		public string Name => pluginName;
		public string Description => "Demonstrates saving plugin data with Paratext data.";
		public Version Version => new Version(1, 0);
		public string VersionString => Version.ToString();
		public string Publisher => "SIL/UBS";

		public IEnumerable<KeyValuePair<string, XMLDataMergeInfo>> MergeDataInfo
		{
			get
			{
				yield return new KeyValuePair<string, XMLDataMergeInfo>(ControlF.savedDataId,
					new XMLDataMergeInfo(false,
						new XMLListKeyDefinition(XPathExpression.Compile("/" + ControlF.xmlRoot), XPathExpression.Compile("."))));
			}
		}

		public IEnumerable<WindowPluginMenuEntry> PluginMenuEntries
		{
			get
			{
				yield return new WindowPluginMenuEntry("PluginF...", Run, PluginMenuLocation.ScrTextEdit);
			}
		}

		public void Run(IWindowPluginHost host, IParatextChildState windowState)
		{
			ControlF theControl = new ControlF();
			host.ShowEmbeddedUi(theControl, windowState.Project);
		}
	}
}
