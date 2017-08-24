using System;
using System.Collections.Generic;
using TPPLib.Entities;

namespace TPPLib.TPPOperations
{
    /// <summary>
    /// Удаление HTML и JS из текста токена.
    /// </summary>
    public class RemoveHtmlAndJs : TPPOperation
    {
        public RemoveHtmlAndJs(IEnumerable<Token> tokens) : base(tokens)
        {
        }

        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
