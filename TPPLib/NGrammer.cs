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

            List<Token> res = new List<Token>();

            for (int i = 0; i < tokens.Count; i++){
                
            }

            return res;
        }
    }
}
