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
        /// <returns>Массив слов</returns>
        /// <param name="raw">Исходный текст</param>
        public abstract IEnumerable<Word> TokenizeToWords(Token raw);

        /// <summary>
        /// Токенизация для получения предложений исходного текста.
        /// </summary>
        /// <returns>Массив слов</returns>
        /// <param name="raw">Исходный текст</param>
        public abstract IEnumerable<Sentence> TokenizeToSentences(Token raw);

        /// <summary>
        /// Токенизация для получения параграфов исходного текста.
        /// </summary>
        /// <returns>Массив параграфов</returns>
        /// <param name="raw">Исходный текст</param>
        public IEnumerable<Paragraph> TokenizeToParagraphs(Token raw)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Токенизация на массивы предложений.
        /// </summary>
        /// <param name="num">Желательное количество ПРЕДЛОЖЕНИЙ</param>
        /// <returns>массив массивов предложений</returns>
        public IEnumerable<List<Sentence>> TokenizeToSentencesListsSentRange(int num)
        {
            throw new NotImplementedException();
        }

		/// <summary>
		/// Токенизация на массив предложений.
		/// </summary>
		/// <returns></returns>
		/// <param name="num">Желательное количество СЛОВ</param>
		public IEnumerable<List<Sentence>> TokenizeToSentencesListsWordsRange(int num)
		{
			throw new NotImplementedException();
		}
    }
}