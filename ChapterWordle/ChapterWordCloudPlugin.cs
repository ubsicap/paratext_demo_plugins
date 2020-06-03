using System;
using System.AddIn;
using System.AddIn.Pipeline;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using AddInSideViews;

namespace ChapterWordCloudPlugin
{
    /// <summary>
    /// Simple plugin that shows a text box that the user can enter text into. The text is
    /// then persisted with the other Paratext project data.
    /// </summary>
    [AddIn(pluginName, Description = "Shows a \"Word Cloud\" of the current chapter.", Version = "1.0", Publisher = "SIL/UBS")]
    [QualificationData(PluginMetaDataKeys.menuText, "&" + pluginName + "...")]
    [QualificationData(PluginMetaDataKeys.insertAfterMenuName, "Tools|Advanced")]
    [QualificationData(PluginMetaDataKeys.enableWhen, WhenToEnable.nonResourceProjectActive)]
    [QualificationData(PluginMetaDataKeys.multipleInstances, CreateInstanceRule.always)]
    public class ChapterWordCloudPlugin : IParatextAddIn
    {
        public const string pluginName = "Chapter Word Cloud";

        private WordCloudForm form;

        /// <summary>
        /// Called by Paratext when the menu item created for this plugin was clicked.
        /// </summary>
        public void Run(IHost ptHost, string activeProjectName)
        {
            Form formToShow;
            lock (this)
            {
                IScrExtractor extractor = ptHost.GetScriptureExtractor(activeProjectName, ExtractorType.USFM);
                string vrsName = ptHost.GetProjectVersificationName(activeProjectName);
                int currRef = ptHost.GetCurrentRef(vrsName);
                int book = currRef / 1000000;
                int chapter = (currRef / 1000) % 1000;
                int bookAndChapter = (currRef / 1000) * 1000;
                int startOfChapter = bookAndChapter + 1;
                int endOfChapter = bookAndChapter + ptHost.GetLastVerse(book, chapter, vrsName);
                string text = extractor.Extract(startOfChapter, endOfChapter);
                StringBuilder bldr = new StringBuilder();
                bool skipping = false;
                for (int i = 0; i < text.Length; i++)
                {
                    char ch = text[i];
                    if (ch == ' ')
                        skipping = false;
                    else
                        skipping |= (ch == '\\');
                    if (!skipping)
                        bldr.Append(ch);
                }
                formToShow = form = new WordCloudForm(bldr.ToString());
            }
            Application.Run(formToShow);
            Environment.Exit(0);
        }

        public void RequestShutdown()
        {
            lock (this)
            {
                if (form != null)
                {
                    form.Close();
                }
            }
        }

        public Dictionary<string, IPluginDataFileMergeInfo> DataFileKeySpecifications
        {
            get
            {
                return null;
            }
        }
    }
}