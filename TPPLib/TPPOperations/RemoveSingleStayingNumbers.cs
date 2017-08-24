using System;
using System.Collections.Generic;
using TPPLib.Entities;

namespace TPPLib.TPPOperations
{
    /// <summary>
    /// Удаление отдельно стоящих чисел.
    /// </summary>
    public class RemoveSingleStayingNumbers : TPPOperation
    {
        public RemoveSingleStayingNumbers(IEnumerable<Token> tokens) : base(tokens)
        {
        }

        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
