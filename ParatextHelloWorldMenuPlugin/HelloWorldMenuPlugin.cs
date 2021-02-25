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
        
        public string Description => "Displays a message box when a menu item is clicked.";
        
        public Version Version => new Version(2, 0);
        
        public string VersionString => Version.ToString();
        
        public string Publisher => "SIL/UBS";
        
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
            }
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
