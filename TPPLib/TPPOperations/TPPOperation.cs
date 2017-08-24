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
        /// Коллекция токенов, каждый из которых должен быть подвергнут обработке 
        /// операцией Execute();
        /// </summary>

        private IEnumerable<Token> _tokesToProcess;
        /// <summary>
        /// Основная операция.
        /// </summary>
        public abstract void Execute();

        public TPPOperation(IEnumerable<Token> tokens){
            this._tokesToProcess = tokens;
        }
    }
}
