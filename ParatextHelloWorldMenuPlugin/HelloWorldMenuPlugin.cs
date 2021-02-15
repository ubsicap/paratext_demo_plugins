using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Paratext.PluginInterfaces;

namespace ParatextHelloWorldMenuPlugin
{
    public class HelloWorldMenuPlugin : IParatextStandalonePlugin
    {
        public string Name => "Hello World";
        
        public string Description => "Displays a message box when a menu item is clicked.";
        
        public Version Version => new Version(2, 0);
        
        public string VersionString => Version.ToString();
        
        public string Publisher => "SIL/UBS";
        
        public IEnumerable<IPluginMenuEntry<IPluginHost>> PluginMenuEntries
        {
            get
            {
                yield return new MenuEntry();
            }
        }

        /// <summary>
        /// Called by Paratext when the menu item created for this plugin was clicked.
        /// </summary>
        private static void Run(IPluginHost host, IParatextChildWindow window)
        {
            host.ActiveWindow
            string message = string.IsNullOrEmpty(activeProjectName) ?
                "You clicked the menu item when there was no active project." :
                string.Format("You clicked the menu item while the {0} project was active.", activeProjectName);

            MessageBox.Show(message, "Paratext Menu Plugin Demo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Environment.Exit(0);
        }

        private class MenuEntry : IPluginMenuEntry<IPluginHost>
        {
            public string GetText(string locale)
            {
                switch (locale)
                {
                    case "es": return "Hola mundo...";
                    default: return "Hello World Demo Menu Plugin...";
                }
            }

            public PluginMenuLocation Location => PluginMenuLocation.ParatextAdvanced;

            public IEnumerable<string> InsertAfterMenuHierarchy => null;

            public string ImagePath => null;
            public WhenToShow ShowWhen => WhenToShow.Always;
            public Action<IPluginHost, IParatextChildWindow> Clicked => Run;
        }
    }
}
