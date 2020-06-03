using System;
using System.AddIn;
using System.AddIn.Pipeline;
using System.Collections.Generic;
using System.Windows.Forms;
using AddInSideViews;

namespace ParatextTipOfTheDayPlugin
{
    /// <summary>
    /// Shows a Tip-of-the-Day dialog when Paratext starts.
    /// </summary>
    [AddIn("Tip-of-the-Day", Description = "Displays a tip whenever Paratext's main form is displayed.", Version = "1.0", Publisher = "SIL/UBS")]
    [QualificationData(PluginMetaDataKeys.runWhen, WhenToRun.mainFormShown)]
    public class TipOfTheDayPlugin : IParatextAddIn
    {
        private static readonly string[] tips = new [] { 
            "Did you know you can create your own plugins? Visit bitbucket.org/paratext/paratext-demo-plugins for more information.",
            "When you are doing a send/receive, make sure you are connected to the internet... or not.",
            "Biblical terms can be shown for whatever verse you are on. Just click on File > Open Biblical Terms Renderings.",
            "If you want to do a back translation, create a new project and choose the Back Translation project type."
        };

        /// <summary>
        /// Shows the tip-of-the-day when Run is called by Paratext.
        /// </summary>
        public void Run(IHost host, string activeProjectName)
        {
            int tipToShow = DateTime.Now.Day % tips.Length;
            MessageBox.Show(tips[tipToShow], host.ApplicationName + " Tip-of-the-Day Plugin Demo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
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
