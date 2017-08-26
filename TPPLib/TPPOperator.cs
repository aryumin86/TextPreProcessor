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
        List<Token> tokens;
        List<TPPOperation> ops;

        public TPPOperator(List<Token> tokens, List<TPPOperation> ops){
            this.tokens = tokens;
            this.ops = ops;
        }

        private void VerifyOpsChain(){
            throw new NotImplementedException();
        }

         
    }
}
