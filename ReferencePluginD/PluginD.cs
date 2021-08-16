using System;
using System.Collections.Generic;

using Paratext.PluginInterfaces;

namespace ReferencePluginD
{
	public class PluginD : IParatextScrTextAnnotationPlugin
	{
		public string Name => "ReferencePluginD";

		public string GetDescription(string locale) => "Demonstrates how to annotate scripture text.";

		public Version Version => new Version(1, 0);

		public string VersionString => Version.ToString();

		public string Publisher => "SIL/UBS";

		public IEnumerable<PluginAnnotationMenuEntry> PluginAnnotationMenuEntries
		{
			get
			{
				PluginAnnotationMenuEntry entry = new PluginAnnotationMenuEntry("Highlight name of Jesus",
					proj => new AnnotationSource(),
					"cross.png");

				yield return entry;
			}
		}

		public IDataFileMerger GetMerger(IPluginHost host, string dataIdentifier) => throw new NotImplementedException();
	}
}
