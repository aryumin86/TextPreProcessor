using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TPPLib.Entities;

namespace TPPLib.TPPOperations
{
    /// <summary>
    /// Удалить ссылки из токенов.
    /// </summary>
    public class RemoveLinks : TPPOperation
    {
        private Regex _commonFormUrl = 
            new Regex(@"\bhttps?:\/\/(www\.)?[-a-zа-я0-9@:%._\+~#=]{2,256}\.[a-zа-я]{2,6}\b([-a-zа-я0-9@:%_\+.~#?&//=]*)\b", 
                RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase);

        private Regex _punyCodeUrl = new Regex(@"\b(xn--)\S+?\b", RegexOptions.Compiled
            | RegexOptions.Singleline | RegexOptions.IgnoreCase);

        public override void Execute(ref IEnumerable<Token> tokens)
        {
            foreach (var t in tokens)
            {
                t.Content = _commonFormUrl.Replace(t.Content, " ");
                t.Content = _punyCodeUrl.Replace(t.Content, " ");
            }
        }
    }
}
