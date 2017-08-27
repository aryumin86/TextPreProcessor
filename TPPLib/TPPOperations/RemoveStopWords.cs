﻿using System;
using System.Collections.Generic;
using TPPLib.Entities;

namespace TPPLib.TPPOperations
{
    /// <summary>
    /// Удаление стоп-слов.
    /// </summary>
    public class RemoveStopWords : TPPOperation
    {
        /// <summary>
        /// Список стоп слов.
        /// </summary>
        private static HashSet<string> _stopWords;

        public RemoveStopWords()
        {
            //TODO список стоп слов должен выгружаться из файла, а его директория должна быть в конфиге (в каком?...)
        }

        public override void Execute(IEnumerable<Token> tokens)
        {
            throw new NotImplementedException();
        }
    }
}