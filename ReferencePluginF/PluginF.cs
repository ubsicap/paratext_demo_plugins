using System;
using System.Collections.Generic;
using System.Xml.XPath;
using Paratext.PluginInterfaces;

namespace ReferencePluginF
{
	public class PluginF : IParatextWindowPlugin
	{
		public const string pluginName = "Reference Plugin F";
		public string Name => pluginName;
		public string GetDescription(string locale) => "Demonstrates saving plugin data with Paratext data.";
		public Version Version => new Version(1, 0);
		public string VersionString => Version.ToString();
		public string Publisher => "SIL/UBS";

		public IEnumerable<WindowPluginMenuEntry> PluginMenuEntries
		{
			get
			{
				yield return new WindowPluginMenuEntry("PluginF...", Run, PluginMenuLocation.ScrTextEdit);
			}
		}

		public IDataFileMerger GetMerger(IPluginHost ptHost, string dataIdentifier)
		{
			if (dataIdentifier != ControlF.savedDataId)
				throw new NotImplementedException($"Cannot get a merger for {dataIdentifier}.");
			return ptHost.GetXmlMerger(new XMLDataMergeInfo(false,
				new XMLListKeyDefinition(XPathExpression.Compile("/" + ControlF.xmlRoot), XPathExpression.Compile("."))));
		}

		public void Run(IWindowPluginHost host, IParatextChildState windowState)
		{
			ControlF theControl = new ControlF();
			host.ShowEmbeddedUi(theControl, windowState.Project);
		}
	}
}
