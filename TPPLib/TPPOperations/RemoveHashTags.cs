using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TPPLib.Entities;

namespace TPPLib.TPPOperations
{
    /// <summary>
    /// Удалить хештеги - удаляет как символ решетки, так и само слово.
    /// </summary>
    public class RemoveHashTags : TPPOperation
    {
        private Regex _regex = new Regex(@"#\b\S+\b", RegexOptions.Compiled 
            | RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public override void Execute(IEnumerable<Token> tokens)
        {
            foreach (var t in tokens)
                t.Content = _regex.Replace(t.Content, " ");
        }
    }
}
