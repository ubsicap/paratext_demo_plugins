using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Paratext.PluginInterfaces;

namespace ReferencePluginM
{
    public class PluginM : IParatextStandalonePlugin
    {
        public const string pluginName = "Reference Plugin M";
        public string Name => pluginName;
        public string GetDescription(string locale) => "Demonstrates writing to the Paratext log.";
        public Version Version => new Version(1, 0);
        public string VersionString => Version.ToString();
        public string Publisher => "SIL/UBS";
        public IEnumerable<KeyValuePair<string, XMLDataMergeInfo>> MergeDataInfo => null;

        public IEnumerable<PluginMenuEntry> PluginMenuEntries
        {
            get
            {
                yield return new PluginMenuEntry("Plugin M...", Run, PluginMenuLocation.Help);
            }
        }

        /// <summary>
        /// Called by Paratext when the menu item created for this plugin was clicked.
        /// </summary>
        private void Run(IPluginHost host, IParatextChildState windowState)
        {
            AddLogEntryDialog dialog = new AddLogEntryDialog();
            dialog.ShowDialog();
            if (dialog.DialogResult == DialogResult.OK)
            {
                List<string> stringParams = new List<string>();
                if (string.IsNullOrEmpty(dialog.Param1) == false)
                {
                    stringParams.Add(dialog.Param1);
                }
                if (string.IsNullOrEmpty(dialog.Param2) == false)
                {
                    stringParams.Add(dialog.Param2);
                }
                if (string.IsNullOrEmpty(dialog.Param3) == false)
                {
                    stringParams.Add(dialog.Param3);
                }
                host.Log(this, dialog.LogString, stringParams.ToArray());

                if (dialog.FlushToDisk)
                {
                    host.FlushLog();
                }
            }
            dialog.Dispose();
        }
    }
}
