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

        /// <summary>
        /// Удалятель стоп-слов. Решил пока что задавать пути к стоп словам в конструкторе, 
        /// так как неясно, как сделать конфиг, одинаково пригодный для .net и .net core. 
        /// </summary>
        /// <param name="russian"></param>
        /// <param name="english"></param>
        /// <param name="pathToRus"></param>
        /// <param name="pathToEng"></param>
        public RemoveStopWords(bool russian, bool english, string pathToRus = "", string pathToEng = "")
        {
            if(pathToRus == string.Empty)
                pathToRus = "~/../../TPPLib/LibDataWorkItems/RusStopWords.txt";
            if(pathToEng == string.Empty)
                pathToEng = "~/../../TPPLib/LibDataWorkItems/EngStopWords.txt";

            russianStopWords = new HashSet<string>(File.ReadAllLines(pathToRus)
                .Where(l => !l.StartsWith("#"))
                .Select(l => l.Trim())
                .ToArray());

            englishStopWords = new HashSet<string>(File.ReadAllLines(pathToEng)
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
                if (russianStopWords.Contains(t.Content.Trim()))
                    t.Content = string.Empty;

                if (englishStopWords.Contains(t.Content.Trim()))
                    t.Content = string.Empty;
            }
        }
    }
}
