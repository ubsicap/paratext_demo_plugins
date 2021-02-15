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
	public class TipOfTheDayPlugin : IParatextStartupAutomaticPlugin
    {
        private static readonly string[] tips = new [] { 
            "Did you know you can create your own plugins? Visit https://github.com/ubsicap/paratext_demo_plugins for more information.",
            "When you are doing a send/receive, make sure you are connected to the internet... or not.",
            "Biblical terms can be shown for whatever verse you are on. Just click on File > Open Biblical Terms Renderings.",
            "If you want to do a back translation, create a new project and choose the Back Translation project type."
        };

		public string Name => "Tip-of-the-Day";
		public string Description => "Displays a tip whenever Paratext's main form is displayed.";
		public Version Version => new Version(2, 0);
		public string VersionString => Version.ToString();
		public string Publisher => "SIL/UBS";

		/// <summary>
		/// Shows the tip-of-the-day (automatically run by Paratext).
		/// </summary>
		public void Run(IPluginHost host)
		{
			int tipToShow = DateTime.Now.Day % tips.Length;
			MessageBox.Show(tips[tipToShow], host.ApplicationName + " Tip-of-the-Day Plugin Demo",
				MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}
}
