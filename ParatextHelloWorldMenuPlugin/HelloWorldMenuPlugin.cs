using System;
using System.Collections.Generic;
using System.Windows.Forms;
using JetBrains.Annotations;
using Paratext.PluginInterfaces;

namespace ParatextHelloWorldMenuPlugin
{
    [PublicAPI]
    public class HelloWorldMenuPlugin : IParatextStandalonePlugin
    {
        public string Name => "Hello World";
        
        public Version Version => new Version(2, 0);
        
        public string VersionString => Version.ToString();
        
        public string Publisher => "SIL/UBS";
        
        public IEnumerable<KeyValuePair<string, XMLDataMergeInfo>> MergeDataInfo => null;

        public IEnumerable<PluginMenuEntry> PluginMenuEntries
        {
            get
            {
                PluginMenuEntry entry = new PluginMenuEntry("Hello World Demo Menu Plugin...", Run, PluginMenuLocation.ParatextAdvanced);
                entry.LocalizedTextNeeded += delegate(string defaultText, string locale)
                {
                    switch (locale)
                    {
                        case "es": return "Hola mundo...";
                        default: return defaultText;
                    }
                };
                yield return entry;

                // This is an example of how a plugin could throw an exception. Paratext should catch it and alert the user but
                // not send in an exception report.
                //yield return new PluginMenuEntry("Throw exception!",
                //    (host, state) => throw new InvalidOperationException("Don't click that!"), PluginMenuLocation.ParatextAdvanced);
            }
        }
        
        public string GetDescription(string locale)
        {
            return "Displays a message box when a menu item is clicked.";
        }

        /// <summary>
        /// Called by Paratext when the menu item created for this plugin was clicked.
        /// </summary>
        private static void Run(IPluginHost host, IParatextChildState state)
		{
			var activeProjectName = host.ActiveWindowState?.Project?.ShortName;
            string message = string.IsNullOrEmpty(activeProjectName) ?
                "You clicked the menu item when there was no active project." :
				$"You clicked the menu item while the {activeProjectName} project was active.";

            MessageBox.Show(message, "Paratext Menu Plugin Demo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
