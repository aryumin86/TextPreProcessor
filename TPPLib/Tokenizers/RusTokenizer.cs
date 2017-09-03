using System;
using System.Collections.Generic;
using TPPLib.Entities;
using System.Linq;

namespace TPPLib.Tokenizers
{
    /// <summary>
    ///  Токенизатор для русского языка.
    /// </summary>
    public class RusTokenizer : AbstractTokenizer
    {
        public override IEnumerable<Word> TokenizeToWords(RawText raw)
        {
            List<Word> res = new List<Word>();

            char[] delims = new char[]{
                ' ','-','!',',',';','?'
            };

            return raw.Content.Split(delims, StringSplitOptions.RemoveEmptyEntries)
                      .Select(t => new Word { TextId = raw.Id, Content = t.Trim() }).ToList();
        }
    }
}
