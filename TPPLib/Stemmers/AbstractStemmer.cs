using System;

namespace TPPLib.Stemmers
{
    /// <summary>
    /// Стеммер.
    /// </summary>
    public abstract class AbstractStemmer
    {
        /// <summary>
        /// Основной метод стеммера - подвергунть токен стеммингу.
        /// </summary>
        /// <returns>The stem.</returns>
        /// <param name="raw">Raw.</param>
        public abstract string Stem(string raw);
    }
}
