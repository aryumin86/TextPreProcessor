using System;
using TPPLib.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TPPLib
{
    /// <summary>
    /// Класс базовой очистки текстов.
    /// Думал, что здесь будет значительно методов, но,видимо,
    /// нередко может пригодится сделать очистку текстов с помощью этого
    /// класса.
    /// </summary>
    public class BasicTextCleaner
    {
        /// <summary>
        /// Базовая очистка текста.
        /// </summary>
        /// <param name="raw"></param>
        public void MakeBasicCleaning(RawText raw){
            raw.Content = raw.Content.ToLower();
            raw.Content = Regex.Replace(raw.Content, 
                @"\s+", " ", RegexOptions.Compiled | RegexOptions.Singleline);
        }

        /// <summary>
        /// Удаление email.
        /// </summary>
        /// <param name="raw"></param>
        public void RemoveEmails(RawText raw)
        {

        }

        /// <summary>
        /// Удаление хеш-тегов.
        /// </summary>
        /// <param name="raw"></param>
        public void RemoveHashTags(RawText raw)
        {

        }

        /// <summary>
        /// Удаление урлов.
        /// </summary>
        /// <param name="raw"></param>
        public void RemoveUrls(RawText raw)
        {

        }

        /// <summary>
        /// Удаление html и js тегов.
        /// </summary>
        /// <param name="raw"></param>
        public void RemoveHtmlAndJsTags(RawText raw)
        {

        }

        /// <summary>
        /// Удаление пунктуации.
        /// </summary>
        /// <param name="raw"></param>
        public void RemovePunctuation(RawText raw)
        {

        }

        /// <summary>
        /// Удаление одиночно стоящих цифр.
        /// </summary>
        /// <param name="raw"></param>
        public void RemoveSingleStaingNumbers(RawText raw)
        {

        }

        public IEnumerable<Token> MakeBasicCleaning(IEnumerable<Token> tokens){
            tokens = tokens.Where(t => !string.IsNullOrWhiteSpace(t.Content));
            foreach (var t in tokens)
                t.Content = Regex.Replace(t.Content, @"\s+", " ", 
                                          RegexOptions.Compiled | RegexOptions.Singleline);

            return tokens;
        }
    }
}
