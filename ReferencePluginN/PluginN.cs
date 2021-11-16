using Paratext.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ReferencePluginN
{
    public class PluginN : IParatextWindowPlugin
    {
        public const string pluginName = "Reference Plugin N";
        public string Name => pluginName;
        public string GetDescription(string locale) => "Demonstrates opening resources in Paratext.";
        public Version Version => new Version(1, 0);
        public string VersionString => Version.ToString();
        public string Publisher => "SIL/UBS";

        public IVerseRef VerseRef = null;

        public IEnumerable<WindowPluginMenuEntry> PluginMenuEntries
        {
            get
            {
                yield return new WindowPluginMenuEntry("PluginN...", Run, PluginMenuLocation.ScrTextProject);
            }
        }

        public IDataFileMerger GetMerger(IPluginHost host, string dataIdentifier) => throw new NotImplementedException();

        /// <summary>
        /// Called by Paratext when the menu item created for this plugin was clicked.
        /// </summary>
        private void Run(IWindowPluginHost host, IParatextChildState windowState)
        {
            IProject project = windowState.Project;
            OpenProjectDialog dialog = new OpenProjectDialog();
            dialog.LoadControl(host, project);
            dialog.ShowDialog();
            if (dialog.DialogResult == DialogResult.OK)
            {
                if (dialog.SelectedResourceCategory == OpenProjectDialog.ResourceCategory.Standard)
                {
                    host.OpenTextWindowFor(dialog.SelectedProject, dialog.SelectedOpenWindowBehavior, dialog.SelectedVerseRef);
                }
                else if (dialog.SelectedResourceCategory == OpenProjectDialog.ResourceCategory.Dictionary)
                {
                    host.OpenDictionaryWindowFor(dialog.SelectedProject, dialog.SelectedOpenWindowBehavior, dialog.SelectedDictionaryEntry);
                }
                else if (dialog.SelectedResourceCategory == OpenProjectDialog.ResourceCategory.SLT)
                {
                    host.OpenSLTWindowFor(dialog.SelectedSLTProject, dialog.SelectedOpenWindowBehavior, dialog.SelectedVerseRef, dialog.SelectedWordToSelect);
                }
            }
        }
    }
}
