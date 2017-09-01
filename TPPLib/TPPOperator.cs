using System;
using System.Collections.Generic;
using TPPLib.Entities;
using TPPLib.TPPOperations;

namespace TPPLib
{
    /// <summary>
    /// Осуществляет запуск операций обработки поступающего текста.
    /// </summary>
    public class TPPOperator
    {
        private IEnumerable<Token> _tokens;
        private IEnumerable<TPPOperation> _ops;

        public TPPOperator(IEnumerable<Token> tokens, List<TPPOperation> ops){
            this._tokens = tokens;
            this._ops = ops;
        }

        private void VerifyOpsChain(){
            throw new NotImplementedException();
        }

        /// <summary>
        /// Выполняет все операции -ops над всеми токенами _tokens.
        /// </summary>
        public void Exucute(){
            foreach (var o in _ops)
                o.Execute(_tokens);
        }
    }
}
