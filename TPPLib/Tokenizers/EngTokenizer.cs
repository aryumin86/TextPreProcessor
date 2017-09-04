using System;
using System.Collections.Generic;
using TPPLib.Entities;

namespace TPPLib.Tokenizers
{
    /// <summary>
    /// Токенизатор для английского языка.
    /// </summary>
    public class EngTokenizer : AbstractTokenizer
    {
        public override IEnumerable<Token> TokenizeToSentences(Token raw)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Token> TokenizeToWords(Token raw)
        {
            throw new NotImplementedException();
        }
    }
}
