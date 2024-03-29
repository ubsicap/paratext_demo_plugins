﻿using System;
using System.Collections.Generic;

using Paratext.PluginInterfaces;


namespace ReferencePluginC
{
	public class PluginC : IParatextWindowPlugin
	{
		public const string pluginName = "Reference Plugin C";
		public string Name => pluginName;
		public string GetDescription(string locale) => "Demonstrates Synchronizing Scripture reference; tab menus.";
		public Version Version => new Version(1, 0);
		public string VersionString => Version.ToString();
		public string Publisher => "SIL/UBS";

		public IEnumerable<WindowPluginMenuEntry> PluginMenuEntries
		{
			get
			{
				yield return new WindowPluginMenuEntry("PluginC...", Run, PluginMenuLocation.ScrTextProject);
			}
		}

		public IDataFileMerger GetMerger(IPluginHost host, string dataIdentifier) => throw new NotImplementedException();

		public void Run(IWindowPluginHost host, IParatextChildState windowState)
		{
			ControlC theControl = new ControlC();
			host.ShowEmbeddedUi(theControl, windowState.Project);
		}
	}
}
