using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Paratext.PluginInterfaces;

namespace ReferencePluginB
{
    public class PluginB : IParatextStandalonePlugin
    {
		public const string pluginName = "Reference Plugin B";
		public string Name => pluginName;
		public string Description => "Demonstrates creating menu entries at various locations.";
		public Version Version => new Version(1, 0);
		public string VersionString => Version.ToString();
		public string Publisher => "SIL/UBS";
		public IEnumerable<KeyValuePair<string, XMLDataMergeInfo>> MergeDataInfo => null;
		public IEnumerable<PluginMenuEntry> PluginMenuEntries
		{
			get
			{
				yield return new PluginMenuEntry("A...", RunA, PluginMenuLocation.MainDefault);
				yield return new PluginMenuEntry("B...", RunB, PluginMenuLocation.ParatextAdvanced);
				yield return new PluginMenuEntry("C...", RunC, PluginMenuLocation.Help);
				yield return new PluginMenuEntry("D...", RunD, PluginMenuLocation.ScrTextDefault);
				yield return new PluginMenuEntry("E...", RunE, PluginMenuLocation.ScrTextProject);
				yield return new PluginMenuEntry("F...", RunF, PluginMenuLocation.ScrTextProjectExportAndPrint);
				yield return new PluginMenuEntry("G...", RunG, PluginMenuLocation.ScrTextProjectAdvanced);
				yield return new PluginMenuEntry("H...", RunH, PluginMenuLocation.ScrTextEdit);
				yield return new PluginMenuEntry("I...", RunI, PluginMenuLocation.ScrTextInsert);
				yield return new PluginMenuEntry("J...", RunJ, PluginMenuLocation.ScrTextTools);
				yield return new PluginMenuEntry("K...", RunK, PluginMenuLocation.ScrTextToolsChecks);
				//yield return new PluginMenuEntry("L...", RunL, PluginMenuLocation.ListDefault);
			}
		}

		private static void RunA(IPluginHost host, IParatextChildState windowState)
		{
			MessageBox.Show("Menu Entry A clicked", pluginName,
				MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private static void RunB(IPluginHost host, IParatextChildState windowState)
		{
			MessageBox.Show("Menu Entry B clicked", pluginName,
				MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private static void RunC(IPluginHost host, IParatextChildState windowState)
		{
			MessageBox.Show("Menu Entry C clicked", pluginName,
				MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private static void RunD(IPluginHost host, IParatextChildState windowState)
		{
			MessageBox.Show("Menu Entry D clicked", pluginName,
				MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private static void RunE(IPluginHost host, IParatextChildState windowState)
		{
			MessageBox.Show("Menu Entry E clicked", pluginName,
				MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private static void RunF(IPluginHost host, IParatextChildState windowState)
		{
			MessageBox.Show("Menu Entry F clicked", pluginName,
				MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private static void RunG(IPluginHost host, IParatextChildState windowState)
		{
			MessageBox.Show("Menu Entry G clicked", pluginName,
				MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private static void RunH(IPluginHost host, IParatextChildState windowState)
		{
			MessageBox.Show("Menu Entry H clicked", pluginName,
				MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private static void RunI(IPluginHost host, IParatextChildState windowState)
		{
			MessageBox.Show("Menu Entry I clicked", pluginName,
				MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private static void RunJ(IPluginHost host, IParatextChildState windowState)
		{
			MessageBox.Show("Menu Entry J clicked", pluginName,
				MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private static void RunK(IPluginHost host, IParatextChildState windowState)
		{
			MessageBox.Show("Menu Entry K clicked", pluginName,
				MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private static void RunL(IPluginHost host, IParatextChildState windowState)
		{
			MessageBox.Show("Menu Entry L clicked", pluginName,
				MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

	}
}
