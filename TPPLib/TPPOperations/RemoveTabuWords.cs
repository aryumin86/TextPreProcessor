using System;
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
        public RemoveTabuWords()
        {
            //TODO доставать регулрные выражения табуированной лексики надо из файлика, указанного в конфиге
        }

        public override void Execute(ref IEnumerable<Token> tokens)
        {
            throw new NotImplementedException();
        }
    }
}
