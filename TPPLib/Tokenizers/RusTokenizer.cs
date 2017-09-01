using System;
using System.Collections.Generic;
using TPPLib.Entities;

namespace TPPLib.Tokenizers
{
    /// <summary>
    ///  Токенизатор для русского языка.
    /// </summary>
    public class RusTokenizer : AbstractTokenizer
    {
        public override IEnumerable<Paragraph> TokenizeToParagraphs(RawText raw)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Sentence> TokenizeToSentences(RawText raw)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Word> TokenizeToWords(RawText raw)
        {
            throw new NotImplementedException();
        }
    }
}
