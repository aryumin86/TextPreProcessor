﻿using System;
using System.Collections.Generic;
using TPPLib.Entities;

namespace TPPLib.TPPOperations
{
    /// <summary>
    /// Операция удаления табуированной лексики. Это может быть мат, ругательство
    /// или иная лексика, регулярные выражения к которой задаются в файлике (по 
    /// умолчанию tabu.txt).
    /// </summary>
    public class RemoveTabuWords : TPPOperation
    {
        private string replacer = string.Empty;

        public RemoveTabuWords()
        {
            
        }

        public override void Execute(IEnumerable<Token> tokens)
        {
            throw new NotImplementedException();
        }
    }
}
