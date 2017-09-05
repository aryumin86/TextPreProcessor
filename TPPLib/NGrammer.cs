using System;
using System.Collections.Generic;
using System.Text;
using TPPLib.Entities;

namespace TPPLib
{
    /// <summary>
    /// Формирует массив n-грамм на основе имеющегося списка токенов.
    /// n может быть задано. Также можно удалить из формируемого списка
    /// исходные токены, оставив только n-граммы.
    /// </summary>
    public class NGrammer
    {
        /// <summary>
        /// Формирует из исходного массива токенов массив n-грамм
        /// </summary>
        /// <param name="tokens">исходныне токены</param>
        /// <param name="n">длина формируемых n-грамм</param>
        /// <param name="saveBaseNGramms">сохранять ли исходные токены в возвращаемом массиве</param>
        /// <returns></returns>
        public IEnumerable<Token> CreateNGramms(List<Token> tokens, int n, bool saveBaseNGramms = true)
        {
            if (tokens.Count <= n)
                return tokens;

            var res = new List<Token>();
            Token t;

            for (int i = 0; i < tokens.Count - n + 1; i++){

                string content = tokens[i].Content;
                int j = i;

                int added = 1;
                while (added < n)
                {
                    content += (" " + tokens[++j].Content);
                    added++;
                }

                t = new Token()
                {
                    TextId = tokens[0].TextId,
                    TokenType = TokenType.NGRAMM,
                    Content = content
                };

                res.Add(t);
            }

            if (saveBaseNGramms)
                res.AddRange(tokens);

            return res;
        }
    }
}
