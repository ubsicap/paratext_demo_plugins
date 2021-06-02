using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Paratext.PluginInterfaces;

namespace ReferencePluginL
{
	class Selection : IScriptureTextSelection
	{
		public Selection()
		{
			SelectedText = "";
			Offset = 0;
			BeforeContext = "";
			AfterContext = "";
		}

		public IVerseRef VerseRefStart { get; set; }

        public IVerseRef VerseRefEnd { get; set; }

        public string SelectedText { get; set; }

        public int Offset { get; set; }

        public string BeforeContext { get; set; }

        public string AfterContext { get; set; }

		bool IEquatable<ISelection>.Equals(ISelection other)
		{
			throw new NotImplementedException();
		}
	}
}
