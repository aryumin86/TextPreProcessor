using System;
using TPPLib.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TPPLib
{
    /// <summary>
    /// Класс базовой очистки текстов. 
    /// </summary>
    public class BasicTextCleaner
    {
        /// <summary>
        /// Базовая очистка текста.
        /// </summary>
        /// <param name="raw"></param>
        public IEnumerable<Token> MakeBasicCleaning(IEnumerable<Token> tokens)
        {
            foreach (var t in tokens)
            {
                t.Content = t.Content.ToLower();
                t.Content = Regex.Replace(t.Content, @"\s+", " ",
                                          RegexOptions.Compiled | RegexOptions.Singleline);
                t.Content = t.Content.Trim();
            }

            tokens = tokens.Where(to => !string.IsNullOrWhiteSpace(to.Content));

            return tokens;
        }

        /// <summary>
        /// Удаление email.
        /// </summary>
        /// <param name="raw"></param>
        [Obsolete]
        public void RemoveEmails(RawText raw)
        {

        }

        /// <summary>
        /// Удаление хеш-тегов.
        /// </summary>
        /// <param name="raw"></param>
        [Obsolete]
        public void RemoveHashTags(RawText raw)
        {

        }

        /// <summary>
        /// Удаление урлов.
        /// </summary>
        /// <param name="raw"></param>
        [Obsolete]
        public void RemoveUrls(RawText raw)
        {

        }

        /// <summary>
        /// Удаление html и js тегов.
        /// </summary>
        /// <param name="raw"></param>
        [Obsolete]
        public void RemoveHtmlAndJsTags(RawText raw)
        {

        }

        /// <summary>
        /// Удаление пунктуации.
        /// </summary>
        /// <param name="raw"></param>
        [Obsolete]
        public void RemovePunctuation(RawText raw)
        {

        }

        /// <summary>
        /// Удаление одиночно стоящих цифр.
        /// </summary>
        /// <param name="raw"></param>
        [Obsolete]
        public void RemoveSingleStaingNumbers(RawText raw)
        {

        }
    }
}
