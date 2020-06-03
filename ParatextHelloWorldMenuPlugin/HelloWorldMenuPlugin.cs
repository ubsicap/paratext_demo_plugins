using System;
using System.AddIn;
using System.AddIn.Pipeline;
using System.Collections.Generic;
using System.Windows.Forms;
using AddInSideViews;

namespace ParatextHelloWorldMenuPlugin
{
    /// <summary>
    /// Simple plugin that shows the active project when it's menu item is clicked.
    /// </summary>
    [AddIn("Hello World", Description = "Displays a message box when a menu item is clicked.", Version = "1.0", Publisher = "SIL/UBS")]
    [QualificationData(PluginMetaDataKeys.menuText, "Hello World Demo Menu Plugin...")]
    [QualificationData(PluginMetaDataKeys.insertAfterMenuName, "Tools|Advanced|Simplify Paratext Menus")]
    [QualificationData(PluginMetaDataKeys.multipleInstances, CreateInstanceRule.always)]
    public class HelloWorldMenuPlugin : IParatextAddIn
    {
        /// <summary>
        /// Called by Paratext when the menu item created for this plugin was clicked.
        /// </summary>
        public void Run(IHost host, string activeProjectName)
        {
            string message = string.IsNullOrEmpty(activeProjectName) ?
                "You clicked the menu item when there was no active project." :
                string.Format("You clicked the menu item while the {0} project was active.", activeProjectName);

            MessageBox.Show(message, "Paratext Menu Plugin Demo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Environment.Exit(0);
        }

        public void RequestShutdown()
        {
            // Just return and let Paratext kill the plugin process if the message box is still showing.
        }

        public Dictionary<string, IPluginDataFileMergeInfo> DataFileKeySpecifications
        {
            get { return null; }
        }
    }
}
