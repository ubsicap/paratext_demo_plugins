using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Paratext.PluginInterfaces;

namespace ReferencePluginD
{
    public class PluginD : IParatextScrTextAnnotationPlugin
    {
        public string Name => "ReferencePluginD";

        public string Description => "Demonstrates how to annotate scripture text.";

        public Version Version => new Version(1, 0);

        public string VersionString => Version.ToString();

        public string Publisher => "SIL/UBS";

        public IEnumerable<KeyValuePair<string, XMLDataMergeInfo>> MergeDataInfo => null;

        public IEnumerable<PluginAnnotationMenuEntry> PluginAnnotationMenuEntries
        {
            get
            {
                PluginAnnotationMenuEntry entry = new PluginAnnotationMenuEntry("Highlight name of Jesus",
                    proj => new AnnotationSource(proj));

                yield return entry;
            }
        }
    }
}
