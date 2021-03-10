using System.Collections.Generic;

namespace Gma.CodeCloud.Controls.TextAnalyses.Extractors
{
    public class StringExtractor : BaseExtractor
    {
        private const int progressIndicatorCharCount = 100;

        private readonly string m_Text;
        private int charCount;

        public StringExtractor(string text, IProgressIndicator progressIndicator)
            : base(progressIndicator)
        {
            m_Text = text;
            ProgressIndicator = progressIndicator;
            if (progressIndicator != null)
                progressIndicator.Maximum = m_Text.Length / progressIndicatorCharCount;
        }

        public override IEnumerable<string> GetWords()
        {
            return GetWords(m_Text);
        }

        protected override void OnCharProcessed(char ch)
        {
            if (++charCount % progressIndicatorCharCount == 0)
                ProgressIndicator?.Increment(1);
        }
    }
}
