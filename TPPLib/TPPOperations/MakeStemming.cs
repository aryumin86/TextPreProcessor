using System;
using System.Collections.Generic;
using TPPLib.Entities;

namespace TPPLib.TPPOperations
{
    /// <summary>
    /// Реализовать стемминг токенов.
    /// </summary>
    public class MakeStemming : TPPOperation
    {
		public MakeStemming(IEnumerable<Token> tokens) : base(tokens)
        {
		}

		public override void Execute()
		{
			throw new NotImplementedException();
		}
    }
}
