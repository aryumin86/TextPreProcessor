using System;
using System.Collections.Generic;
using TPPLib.Entities;

namespace TPPLib
{
    /// <summary>
    /// Токенизатор. Позволяет получить из исходного текста отдельные слова / предложения / абзацы. 
    /// При этом токены не являются очищенными от пунктуации и пр.
    /// </summary>
    public class Tokenizer
    {
        /// <summary>
        /// Токенизация для получения отдельных слов.
        /// </summary>
        /// <returns>The to word.</returns>
        /// <param name="raw">Raw.</param>
        public IEnumerable<Word> TokenizeToWord(RawText raw){
            return null;
        }

        /// <summary>
        /// Токенизация для получения предложений исходного текста.
        /// </summary>
        /// <returns>The to NG ramms.</returns>
        /// <param name="raw">Raw.</param>
        public IEnumerable<Sentence> TokenizeToSentences(RawText raw){
            return null;
        }

        /// <summary>
        /// Токенизация для получения параграфов исходного текста.
        /// </summary>
        /// <returns>The to paragraphs.</returns>
        /// <param name="raw">Raw.</param>
        public IEnumerable<Paragraph> TokenizeToParagraphs(RawText raw){
            return null;
        }
    }
}
