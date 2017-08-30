using System;
using System.Collections.Generic;
using TPPLib.Entities;
using TPPLib.Stemmers;
using System.Linq;

namespace TPPLib.TPPOperations
{
    /// <summary>
    /// Реализовать стемминг токенов.
    /// </summary>
    public class MakeStemming : TPPOperation
    {
        private AbstractStemmer _stemmer;

        public MakeStemming(AbstractStemmer stemmer){
            _stemmer = stemmer;
        }

		public override void Execute(IEnumerable<Token> tokens)
		{
            if (!tokens.All(t => t is Word))
                throw new ArgumentException("Tokenizing is avaliable only for tokens of type Word");

            foreach (var t in tokens)
                t.Content = _stemmer.Stem(t.Content);
		}
    }
}
