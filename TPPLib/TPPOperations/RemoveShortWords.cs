using System;
using System.Collections.Generic;
using TPPLib.Entities;

namespace TPPLib.TPPOperations
{
    /// <summary>
    /// Удаление коротких слов.
    /// </summary>
    public class RemoveShortWords :  TPPOperation
    {
        public override void Execute(ref IEnumerable<Token> tokens)
        {
            foreach(var t in tokens)
            {
                if (t.Content.Length < 3)
                    t.Content = string.Empty;
            }
        }
    }
}
