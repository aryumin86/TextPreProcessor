using System;
using System.Collections.Generic;
using TPPLib.Entities;

namespace TPPLib.Tokenizers
{
    /// <summary>
    /// Токенизатор. Позволяет получить из исходного текста отдельные слова / предложения / абзацы. 
    /// При этом токены не являются очищенными от пунктуации и пр.
    /// </summary>
    public abstract class AbstractTokenizer
    {
        /// <summary>
        /// Токенизация для получения отдельных слов.
        /// </summary>
        /// <returns>The to word.</returns>
        /// <param name="raw">Raw.</param>
        public abstract IEnumerable<Word> TokenizeToWords(RawText raw);

        /// <summary>
        /// Токенизация для получения предложений исходного текста.
        /// </summary>
        /// <returns>The to NG ramms.</returns>
        /// <param name="raw">Raw.</param>
        public IEnumerable<Sentence> TokenizeToSentences(RawText raw)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Токенизация для получения параграфов исходного текста.
        /// </summary>
        /// <returns>The to paragraphs.</returns>
        /// <param name="raw">Raw.</param>
        public IEnumerable<Paragraph> TokenizeToParagraphs(RawText raw)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Токенизация на массивы предложений.
        /// </summary>
        /// <param name="num">Желательная длина массивов предложений</param>
        /// <returns></returns>
        public IEnumerable<List<Sentence>> TokenizeToSentencesLists(int num)
        {
            throw new NotImplementedException();
        }
    }
}
