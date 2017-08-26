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
        private static int _minWordLength = 3;

        public RemoveShortWords(IEnumerable<Token> tokens) : base(tokens)
        {
        }

        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
