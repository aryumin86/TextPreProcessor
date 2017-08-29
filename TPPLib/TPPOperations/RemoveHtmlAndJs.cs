using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TPPLib.Entities;

namespace TPPLib.TPPOperations
{
    /// <summary>
    /// Удаление HTML и JS из текста токена.
    /// </summary>
    public class RemoveHtmlAndJs : TPPOperation
    {
        private Regex _regex1 = new Regex(@"<[\s\S]*?</[^>]*>", RegexOptions.Compiled
            | RegexOptions.Singleline | RegexOptions.IgnoreCase);
        private Regex _regex2 = new Regex(@"<[^>]*>", RegexOptions.Compiled 
            | RegexOptions.Singleline | RegexOptions.IgnoreCase);

        public override void Execute(IEnumerable<Token> tokens)
        {
            foreach (var t in tokens)
            {
                t.Content = _regex1.Replace(t.Content, " ");
                t.Content = _regex2.Replace(t.Content, " ");
            }
               
        }
    }
}
