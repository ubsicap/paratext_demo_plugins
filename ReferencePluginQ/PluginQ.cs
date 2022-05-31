using System;
using System.Collections.Generic;
using Paratext.PluginInterfaces;

namespace ReferencePluginQ
{
    public class PluginQ : IParatextWindowPlugin
    {
        public const string pluginName = "Reference Plugin Q";
        public string Name => pluginName;
        public string GetDescription(string locale) => "Demonstrates using Text Collections.";
        public Version Version => new Version(1, 0);
        public string VersionString => Version.ToString();
        public string Publisher => "SIL/UBS";

        public IEnumerable<WindowPluginMenuEntry> PluginMenuEntries
        {
            get
            {
                yield return new WindowPluginMenuEntry("PluginQ...", Run, PluginMenuLocation.ParatextAdvanced);
            }
        }

        public IDataFileMerger GetMerger(IPluginHost host, string dataIdentifier) => throw new NotImplementedException();

        public void Run(IWindowPluginHost host, IParatextChildState windowState)
        {
            ControlQ theControl = new ControlQ();
            host.ShowEmbeddedUi(theControl, null);
        }
    }
}
