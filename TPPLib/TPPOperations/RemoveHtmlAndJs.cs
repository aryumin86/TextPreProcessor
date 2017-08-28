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
        private Regex _regex = new Regex(@"<[^>]*>", RegexOptions.Compiled 
            | RegexOptions.Singleline | RegexOptions.IgnoreCase);

        public override void Execute(IEnumerable<Token> tokens)
        {
            foreach (var t in tokens)
                t.Content = _regex.Replace(t.Content, " ");
        }
    }
}
