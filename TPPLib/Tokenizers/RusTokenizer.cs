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
		public override IEnumerable<Token> TokenizeToSentences(Token raw)
		{
            string substitutor = "_POINT_";

			List<Token> res = new List<Token>();

			char[] delims = new char[]{
				'\n' , '.', '?', '!', '\r'
			};

			string abbrs = 
                @"(?<=\b(гор|г|пос|стр|кот|с|д|эт|кв|корп|др|мкр))(\.)";

            raw.Content = Regex.Replace(raw.Content.ToLower(), abbrs, substitutor);

            int pos = 0;

            res = raw.Content.Split(delims, StringSplitOptions.RemoveEmptyEntries)
                     .Select(x => new Token()
                     {
                         Content = x,
                         ParentToken = raw,
                         TextId = raw.TextId,
                         PositionInParent = pos++,
                         TokenType = TokenType.SENTENCE
                     })
                     .ToList();

            res = res.Where(x => Regex.IsMatch(x.Content, @"[а-яА-Яa-zA-Z]")).ToList();

            res.ForEach(x => x.Content = x.Content.Replace(substitutor, "."));

            raw.Content = raw.Content.Replace(substitutor, ".");

			return res;
		}

        public override IEnumerable<Token> TokenizeToWords(Token raw)
        {
            List<Token> res = new List<Token>();

            char[] delims = new char[]{
                ' ','-','!',',',';','?'
            };

            int pos = 0;

            return raw.Content.Split(delims, StringSplitOptions.RemoveEmptyEntries)
                      .Select(t => new Token { TextId = raw.TextId, Content = t.Trim(), TokenType = TokenType.WORD, PositionInParent = pos++ }).ToList();
        }
    }
}
