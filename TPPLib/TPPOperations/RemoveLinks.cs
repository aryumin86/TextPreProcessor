using System;
using System.Collections.Generic;
using TPPLib.Entities;

namespace TPPLib.TPPOperations
{
    /// <summary>
    /// Удалить ссылки из токенов.
    /// </summary>
    public class RemoveLinks : TPPOperation
    {
        public RemoveLinks(IEnumerable<Token> tokens) : base(tokens)
        {
        }

        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
