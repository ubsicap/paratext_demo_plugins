using System;
using System.Windows.Forms;
using JetBrains.Annotations;
using Paratext.PluginInterfaces;

namespace ParatextTipOfTheDayPlugin
{
    /// <summary>
    /// Shows a Tip-of-the-Day dialog when Paratext starts.
    /// </summary>
    [PublicAPI]
	public class TipOfTheDayPlugin : IParatextMainWindowAutomaticPlugin
    {
        private static readonly string[] tips = { 
            "Did you know you can create your own plugins? Visit https://github.com/ubsicap/paratext_demo_plugins for more information.",
            "To do send/receive via the internet, your project must be registered.",
            "Biblical terms can be shown for whatever verse you are on. Just click on Tool > Biblical Terms Renderings.",
            "If you want to do a back translation, create a new project and choose the Back Translation project type."
        };

        public string Name => "Tip-of-the-Day";
		
        public Version Version => new Version(2, 0);
		
        public string VersionString => Version.ToString();
		
        public string Publisher => "SIL/UBS";

        public IDataFileMerger GetMerger(IPluginHost host, string dataIdentifier) => throw new NotImplementedException();

        public string GetDescription(string locale)
        {
            return "Displays a tip whenever Paratext's main form is displayed.";
        }
        
        /// <summary>
        /// Shows the tip-of-the-day (automatically run by Paratext).
        /// </summary>
        public void Run(IWindowPluginHost host)
        {
            int tipToShow = DateTime.Now.Day % tips.Length;
            MessageBox.Show(tips[tipToShow], host.ApplicationName + " Tip-of-the-Day Plugin Demo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
	}
}
