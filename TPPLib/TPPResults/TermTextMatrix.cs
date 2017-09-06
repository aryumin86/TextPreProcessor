using System;
using System.Collections.Generic;
using System.Text;
using TPPLib.Entities;
using System.Linq;

namespace TPPLib.TPPResults
{
    /// <summary>
    /// Term-text матрица.
    /// </summary>
    public class TermTextMatrix<T> where T : struct
    {
        /// <summary>
        /// Список содержит последовательность слов словаря,
        /// соответствующий порядку слов в матрице (в общем это
        /// столбцы term-text матрицы).
        /// Ключ - это само слово. Значение - его id в словаре.
        /// </summary>
        public List<KeyValuePair<string, int>> words;

        /// <summary>
        /// Список id текстов, загруженных для обработки 
        /// (последовтельность строк-текстов в term-text матрице)
        /// </summary>
        public List<string> textsIds;

        /// <summary>
        /// Сама term-text матрица.
        /// </summary>
        public T[,] Matrix { get; set; }

        /// <summary>
        /// Словарь слов массива текстов.
        /// </summary>
        public Dictionary<string, int> dict;

        public TermTextMatrix(List<Token> terms, List<Token> texts, bool justOccurrences = false)
        {
            dict = new Dictionary<string, int>();
            int termId = 0;
            foreach(var term in terms)
            {
                if (!dict.ContainsKey(term.Content))
                    dict.Add(term.Content, termId++);
            }

            words = dict.ToList();
            textsIds = texts.Select(t => t.TextId).ToList();

            this.Matrix = new T[texts.Count, words.Count()];

            for(int i = 0; i < texts.Count; i++)
            {
                for(int j = 0; j < words.Count; j++)
                {
                    if (justOccurrences)
                    {
                        if (texts[i].Content.Contains(words[j].Key))
                            Matrix[i, j] = 1;
                        else
                            Matrix[i, j] = 0;
                    }
                    else
                    {

                    }
                }
            }
        }
    }
}
