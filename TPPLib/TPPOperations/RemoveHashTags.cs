﻿using System;
using System.Collections.Generic;
using TPPLib.Entities;

namespace TPPLib.TPPOperations
{
    /// <summary>
    /// Удалить хештеги - удаляет как символ решетки, так и само слово.
    /// </summary>
    public class RemoveHashTags : TPPOperation
    {
        public RemoveHashTags(IEnumerable<Token> tokens) : base(tokens)
        {
        }

        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
