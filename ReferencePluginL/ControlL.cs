using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Paratext.PluginInterfaces;

namespace ReferencePluginL
{
    public partial class ControlL : EmbeddedPluginControl
    {
        public ControlL()
        {
            InitializeComponent();
        }
		public override void OnAddedToParent(IPluginChildWindow parent, IWindowPluginHost host, string state)
		{
			parent.SetTitle(PluginL.pluginName);

		}

		public override string GetState()
		{
			return null;
		}

		public override void DoLoad(IProgressInfo progressInfo)
		{
		}
	}
}
