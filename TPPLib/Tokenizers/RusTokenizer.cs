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
		public override IEnumerable<Sentence> TokenizeToSentences(Token raw)
		{
			List<Sentence> res = new List<Sentence>();

			char[] delims = new char[]{
				'\n' , '.' , ',' , '?', '!'
			};

			string[] abbrs = new string[] {
                //с точками
                "гор.", "г.", "пос.", "стр.", "кот.",  "", "", "",

                //с дефисами
                "г-н", "р-н", "", "", ""
			};

			raw.Content.Split();

			return res;
		}

        public override IEnumerable<Word> TokenizeToWords(Token raw)
        {
            List<Word> res = new List<Word>();

            char[] delims = new char[]{
                ' ','-','!',',',';','?'
            };

            return raw.Content.Split(delims, StringSplitOptions.RemoveEmptyEntries)
                      .Select(t => new Word { TextId = raw.TextId, Content = t.Trim() }).ToList();
        }
    }
}
