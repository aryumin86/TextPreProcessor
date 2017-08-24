using System;
using System.Collections.Generic;
using TPPLib.Entities;

namespace TPPLib.TPPOperations
{
    /// <summary>
    /// Лемматизировать токены.
    /// </summary>
    public class Lemmatize : TPPOperation
    {
        public Lemmatize(IEnumerable<Token> tokens) : base(tokens)
        {
        }

        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
