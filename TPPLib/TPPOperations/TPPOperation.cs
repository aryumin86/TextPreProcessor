using System;
using TPPLib.Entities;
using System.Collections.Generic;

namespace TPPLib.TPPOperations
{
    /// <summary>
    /// Операция, производимая над токеном (над текстом / словом / n-граммом / предложением / абзацем).
    /// </summary>
    public abstract class TPPOperation
    {
        /// <summary>
        /// Основная операция.
        /// </summary>
        public abstract void Execute(IEnumerable<Token> tokens);
    }
}
