using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TPPLib.Entities;

namespace TPPLib.TPPOperations
{
    /// <summary>
    /// Удаление отдельно стоящих чисел.
    /// </summary>
    public class RemoveSingleStayingNumbers : TPPOperation
    {
        private Regex _regex = new Regex(@"\b\d+\b",
            RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase);

        public override void Execute(IEnumerable<Token> tokens)
        {
            foreach (var t in tokens)
            {
                t.Content = _regex.Replace(t.Content, " ");
            }
        }
    }
}
