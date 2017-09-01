using System;
using System.Collections.Generic;
using System.IO;
using TPPLib.Entities;
using System.Linq;

namespace TPPLib.TPPOperations
{
    /// <summary>
    /// Удаление стоп-слов.
    /// </summary>
    public class RemoveStopWords : TPPOperation
    {
        /// <summary>
        /// Список стоп слов русского языка.
        /// </summary>
        public HashSet<string> russianStopWords;

        /// <summary>
        /// Список стоп слов английского языка.
        /// </summary>
        public HashSet<string> englishStopWords;

        public RemoveStopWords(bool russian, bool english)
        {
            russianStopWords = new HashSet<string>(File.ReadAllLines("../../../../TPPLib/LibDataWorkItems/RusStopWords.txt")
                .Where(l => !l.StartsWith("#"))
                .Select(l => l.Trim())
                .ToArray());

            englishStopWords = new HashSet<string>(File.ReadAllLines("../../../../TPPLib/LibDataWorkItems/EngStopWords.txt")
                .Where(l => !l.StartsWith("#"))
                .Select(l => l.Trim())
                .ToArray());

            if (!russian)
                russianStopWords.Clear();

            if (!english)
                englishStopWords.Clear();
        }

        public override void Execute(IEnumerable<Token> tokens)
        {
            foreach(var t in tokens){
                if (russianStopWords.Contains(t.Content))
                    t.Content = string.Empty;

                if (englishStopWords.Contains(t.Content))
                    t.Content = string.Empty;
            }
        }
    }
}
