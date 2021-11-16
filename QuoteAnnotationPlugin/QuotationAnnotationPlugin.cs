using System;
using System.Collections.Generic;
using Paratext.PluginInterfaces;

namespace QuoteAnnotationPlugin
{
    /// <summary>
    /// Simple plugin that shows a text box that the user can enter text into. The text is
    /// then persisted with the other Paratext project data.
    /// </summary>
    public class QuotationAnnotationPlugin : IParatextScrTextAnnotationPlugin
    {
        public string Name => "Quote Marking Plugin";

        public Version Version => new Version(1, 0);

        public string VersionString => Version.ToString();

        public string Publisher => "SIL/UBS";

        public IDataFileMerger GetMerger(IPluginHost host, string dataIdentifier) => throw new NotImplementedException();
        
        public IEnumerable<PluginAnnotationMenuEntry> PluginAnnotationMenuEntries 
        {
            get 
            { 
                PluginAnnotationMenuEntry entry = new PluginAnnotationMenuEntry("Highlight quotation marks", 
                    proj => new AnnotationSource(proj));

                entry.LocalizedTextNeeded += delegate(string defaultText, string locale)
                {
                    switch (locale)
                    {
                        case "es": return "Resaltar las comillas";
                        case "de": return "Anführungszeichen markieren";
                        default: return defaultText;
                    }
                };
                yield return entry;
            }
        }

        public string GetDescription(string locale)
        {
            return "Highlights the quotation marks of a project in the project text.";
        }
    }
}
