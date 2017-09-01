using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TPPLib.Entities;

namespace TPPLib.TPPOperations
{
    public class RemovePunctuation : TPPOperation
    {
        private Regex _regex = new Regex(@"[^\dа-яa-z\s]",
            RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase);

        public override void Execute(ref IEnumerable<Token> tokens)
        {
            foreach (var t in tokens)
            {
                t.Content = _regex.Replace(t.Content, " ");
            }
        }
    }
}
