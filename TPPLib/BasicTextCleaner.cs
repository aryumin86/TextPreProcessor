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
        public void RemoveEmails(Token raw)
        {

        }

        /// <summary>
        /// Удаление хеш-тегов.
        /// </summary>
        /// <param name="raw"></param>
        [Obsolete]
        public void RemoveHashTags(Token raw)
        {

        }

        /// <summary>
        /// Удаление урлов.
        /// </summary>
        /// <param name="raw"></param>
        [Obsolete]
        public void RemoveUrls(Token raw)
        {

        }

        /// <summary>
        /// Удаление html и js тегов.
        /// </summary>
        /// <param name="raw"></param>
        [Obsolete]
        public void RemoveHtmlAndJsTags(Token raw)
        {

        }

        /// <summary>
        /// Удаление пунктуации.
        /// </summary>
        /// <param name="raw"></param>
        [Obsolete]
        public void RemovePunctuation(Token raw)
        {

        }

        /// <summary>
        /// Удаление одиночно стоящих цифр.
        /// </summary>
        /// <param name="raw"></param>
        [Obsolete]
        public void RemoveSingleStaingNumbers(Token raw)
        {

        }
    }
}
