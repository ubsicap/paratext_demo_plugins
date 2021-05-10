using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Paratext.PluginInterfaces;

namespace ReferencePluginA
{
    public class PluginA : IParatextStartupAutomaticPlugin
	{
		IPluginHost m_host;

		public const string pluginName = "Reference Plugin A";
		public string Name => pluginName;
		public string Description => "Demonstrates calling plugin at Paratext startup."+
			" as well as getting user settings";
		public Version Version => new Version(1, 0);
		public string VersionString => Version.ToString();
		public string Publisher => "SIL/UBS";
		public IEnumerable<KeyValuePair<string, XMLDataMergeInfo>> MergeDataInfo => null;

		public void Run(IPluginHost host)
		{
			m_host = host;
			ShowUserSettings(host);

			host.UserSettings.UiLocaleChanged += UiLocaleChangedHandler;
		}

		private static void ShowUserSettings(IPluginHost host)
		{
			var settings = host.UserSettings;
			string text = "";

			text += $"Application name: {host.ApplicationName}\n";
			text += $"Application version: {host.ApplicationVersion}\n";
			text += $"Username: {host.UserInfo.Name}\n";
			text += $"UiLocale: {settings.UiLocale}\n";
			text += $"Auto save: {settings.AutoSave}\n";
			text += $"IsDragAndDropEnabled: {settings.IsDragAndDropEnabled}\n";
			text += $"IsFirefoxHardwareAccelerationEnabled: {settings.IsFirefoxHardwareAccelerationEnabled}\n";
			text += $"IsInternetAccessEnabled: {settings.IsInternetAccessEnabled}\n";
			text += $"IsSynchronizedScriptureReferencesEnabled: {settings.IsSynchronizedScriptureReferencesEnabled}\n";
			text += $"ShowFullMenus: {settings.ShowFullMenus}\n";


			MessageBox.Show(text, pluginName,
				MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		void UiLocaleChangedHandler(string newLocale)
		{
			ShowUserSettings(m_host);
		}
	}
}
