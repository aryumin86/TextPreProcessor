using System;
using System.Collections.Generic;
using TPPLib.Entities;
using System.Linq;
using System.Text.RegularExpressions;

namespace TPPLib.Tokenizers
{
    /// <summary>
    ///  Токенизатор для русского языка.
    /// </summary>
    public class RusTokenizer : AbstractTokenizer
    {
		public override IEnumerable<Sentence> TokenizeToSentences(Token raw)
		{
            string substitutor = "_POINT_";

			List<Sentence> res = new List<Sentence>();

			char[] delims = new char[]{
				'\n' , '.', '?', '!'
			};

			string abbrs = 
                @"(?<=\b(гор|г|пос|стр|кот|с|д|эт|кв|корп))(\.)";

            raw.Content = Regex.Replace(raw.Content.ToLower(), abbrs, substitutor);

            res = raw.Content.Split(delims, StringSplitOptions.RemoveEmptyEntries)
                     .Select(x => new Sentence()
                     {
                         Content = x,
                         ParentToken = raw,
                         TextId = raw.TextId
                     }).ToList();

            res.ForEach(x => x.Content = x.Content.Replace(substitutor, "."));

            raw.Content = raw.Content.Replace(substitutor, ".");

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
