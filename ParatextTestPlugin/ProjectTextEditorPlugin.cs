﻿using System;
using System.Collections.Generic;
using System.Xml.XPath;
using Paratext.PluginInterfaces;

namespace ProjectTextEditorPlugin
{
    /// <summary>
    /// Simple plugin that shows a text box that the user can enter text into. The text is
    /// then persisted with the other Paratext project data.
    /// </summary>
    public class ProjectTextEditorPlugin : IParatextWindowPlugin
    {
        public const string pluginName = "Project Text Editor";

		public string Name => pluginName;

        public Version Version => new Version(1, 0);

        public string VersionString => Version.ToString();

        public string Publisher => "SIL/UBS";

        public IEnumerable<WindowPluginMenuEntry> PluginMenuEntries 
        {
            get 
            { 
                WindowPluginMenuEntry entry = new WindowPluginMenuEntry("&" + pluginName + "...", Run, 
                    PluginMenuLocation.ScrTextProject, @"icon.gif");
                entry.LocalizedTextNeeded += delegate(string defaultText, string locale)
                {
                    switch (locale)
                    {
                        case "es": return "Editor de texto para proyectos...";
                        default: return defaultText;
                    }
                };
                yield return entry;
            }
        }

		public IDataFileMerger GetMerger(IPluginHost ptHost, string dataIdentifier)
		{
			if (dataIdentifier != EditTextControl.savedDataId)
				throw new NotImplementedException($"Cannot get a merger for {dataIdentifier}.");
			return ptHost.GetXmlMerger(new XMLDataMergeInfo(false, 
				new XMLListKeyDefinition(XPathExpression.Compile("/" + EditTextControl.xmlRoot), XPathExpression.Compile("."))));
		}

        public string GetDescription(string locale)
        {
            return "Shows a text box into which the user can enter text, which" +
                " is then saved with the other project data.";
        }
        
        /// <summary>
        /// Called by Paratext when the menu item created for this plugin was clicked.
        /// </summary>
        private static void Run(IWindowPluginHost ptHost, IParatextChildState activeProjectState)
        {
            EditTextControl control = new EditTextControl();
            ptHost.ShowEmbeddedUi(control, activeProjectState.Project);
        }
    }
}
