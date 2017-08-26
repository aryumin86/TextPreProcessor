using System;

namespace TPPLib.Stemmers
{
    /// <summary>
    /// Стеммер.
    /// </summary>
    public abstract class AbstractStemmer
    {
        public abstract string Stem(string raw);
    }
}
