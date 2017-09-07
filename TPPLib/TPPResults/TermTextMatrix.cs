﻿using System;
using System.Collections.Generic;
using System.Text;
using TPPLib.Entities;
using System.Linq;
using System.Text.RegularExpressions;

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

        /// <summary>
        /// Поиск термов идет по свойству Content в объектах texts.
        /// объектах texts.
        /// </summary>
        /// <param name="terms"></param>
        /// <param name="texts"></param>
        /// <param name="justOccurrences"></param>
        public TermTextMatrix(List<Token> terms, List<Token> texts,  bool justOccurrences = false)
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
                            Matrix[i, j] = GetGen(1);
                        else
                            Matrix[i, j] = GetGen(0);
                    }
                    else
                    {
                        Matrix[i, j] = GetGen(CountSubstrings(texts[i].Content, words[j].Key));
                    }
                }
            }
        }

        /// <summary>
        /// Конструктор предполагает наличие id текста у каждого токена (терма)
        /// </summary>
        /// <param name="terms"></param>
        /// <param name="justOccurrences"></param>
        public TermTextMatrix(List<Token> terms, bool justOccurrences = false)
        {

        }

        /// <summary>
        /// Конвертировать struct в T.
        /// </summary>
        /// <typeparam name="U"></typeparam>
        /// <param name="val"></param>
        /// <returns></returns>
        private static T GetGen<U>(U val) where U : struct
        {
            if(val is int)
            {
                return (T)Convert.ChangeType(1, typeof(int));
            }
            else if(val is double)
            {
                return (T)Convert.ChangeType(1, typeof(double));
            }
            else if (val is byte)
            {
                return (T)Convert.ChangeType(1, typeof(byte));
            }
            else if (val is short)
            {
                return (T)Convert.ChangeType(1, typeof(short));
            }
            else if (val is long)
            {
                return (T)Convert.ChangeType(1, typeof(long));
            }
            else
            {
                throw new FormatException();
            }            
        }

        /// <summary>
        /// Находит число всех вхождений образца в текст.
        /// </summary>
        /// <param name="full">текст</param>
        /// <param name="sub">образец</param>
        /// <returns></returns>
        private static int CountSubstrings(string full, string sub)
        {
            for(int i = 0; i < full.Length - sub.Length; i++)
            {

            }

            return 0;
        }
    }
}