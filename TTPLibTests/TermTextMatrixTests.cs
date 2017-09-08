using System;
using System.Collections.Generic;
using System.Text;
using TPPLib;
using TPPLib.Entities;
using TPPLib.Tokenizers;
using TPPLib.TPPOperations;
using Xunit;
using System.Linq;
using TPPLib.Stemmers;
using TPPLib.TPPResults;
using System.IO;

namespace TTPLibTests
{
    public class TermTextMatrixTests
    {
        /// <summary>
        /// Находит правильное количество вхождений образца в 
        /// текст по свойству Content в тексте.
        /// </summary>
        [Fact]
        [Trait("Category", "Unit")]
        public void Find_All_Samples_Count_In_Text_Content_Prop()
        {
            var text = new Token()
            {
                Content = "Это какой-то текст. В этом тексте"
            };
        }

        /// <summary>
        /// Находит правильное количество вхождений образца в 
        /// текст, оперируя только массивом текстов с дочерними 
        /// токенами у каждого - термами или n-граммами.
        /// </summary>
        [Fact]
        [Trait("Category", "Unit")]
        public void Find_All_Samples_Count_Using_Just_TermsTokens()
        {
            List<Token> texts = new List<Token>()
            {
                new Token()
                {
                    Content = "Это какой-то текст. В этом тексте много текста. Он про попугаев и других животных",
                    TextId = "1",
                    TokenType = TokenType.FULL_TEXT
                },

                new Token()
                {
                    Content = "Это уже какой-то другой текст. В нем много всего интересного. Он про кенгуру и черепах...",
                    TextId = "2",
                    TokenType = TokenType.FULL_TEXT
                }
            };

            var cleaner = new BasicTextCleaner();
            var tokenizer = new RusTokenizer();

            List<TPPOperation> ops = new List<TPPOperation>()
            {
                new RemovePunctuation()
            };

            var @operator = new TPPOperator(texts, ops);

            foreach (var t in texts)
            {
                @operator.Exucute();
            }

            texts = cleaner.MakeBasicCleaning(texts).Select(to => (Token)to).ToList();

            ops = new List<TPPOperation>()
            {
                new RemoveShortWords(),
                new RemoveStopWords(true, false, 
                pathToRus : "../../../../TPPLib/LibDataWorkItems/RusStopWords.txt", 
                pathToEng : "../../../../TPPLib/LibDataWorkItems/EngStopWords.txt"),
                new MakeStemming(new RusStemmer())
            };

            foreach (var t in texts)
            {
                t.ChildrenTokens = tokenizer.TokenizeToWords(t).Select(to => to).ToList();
                @operator = new TPPOperator(t.ChildrenTokens, ops);
                @operator.Exucute();
                t.ChildrenTokens = cleaner.MakeBasicCleaning(t.ChildrenTokens).Select(to => (Token)to).ToList();
            };            

            TermTextMatrix<int> ttm = new TermTextMatrix<int>(texts);

            Assert.True(ttm.Matrix.GetLength(0) == 2);
            Assert.True(ttm.Matrix.GetLength(1) == 9);
        }

        /// <summary>
        /// В общем это не тест никакой, а просто метод, создающий файлик csv на основе 
        /// Term-Text матрицы.
        /// </summary>
        [Fact]
        [Trait("Category", "Unit")]
        public void Create_Term_Text_CSV_Matrix()
        {
            List<Token> texts = new List<Token>()
            {
                new Token()
                {
                    Content = "Это какой-то текст. В этом тексте много текста. Он про попугаев и других животных",
                    TextId = "1",
                    TokenType = TokenType.FULL_TEXT
                },

                new Token()
                {
                    Content = "Это уже какой-то другой текст. В нем много всего интересного. Он про кенгуру и черепах...",
                    TextId = "2",
                    TokenType = TokenType.FULL_TEXT
                }
            };

            var cleaner = new BasicTextCleaner();
            var tokenizer = new RusTokenizer();

            List<TPPOperation> ops = new List<TPPOperation>()
            {
                new RemovePunctuation()
            };

            var @operator = new TPPOperator(texts, ops);

            foreach (var t in texts)
            {
                @operator.Exucute();
            }

            texts = cleaner.MakeBasicCleaning(texts).Select(to => (Token)to).ToList();

            ops = new List<TPPOperation>()
            {
                new RemoveShortWords(),
                new RemoveStopWords(true, false,
                pathToRus : "../../../../TPPLib/LibDataWorkItems/RusStopWords.txt",
                pathToEng : "../../../../TPPLib/LibDataWorkItems/EngStopWords.txt"),
                new MakeStemming(new RusStemmer())
            };

            foreach (var t in texts)
            {
                t.ChildrenTokens = tokenizer.TokenizeToWords(t).Select(to => to).ToList();
                @operator = new TPPOperator(t.ChildrenTokens, ops);
                @operator.Exucute();
                t.ChildrenTokens = cleaner.MakeBasicCleaning(t.ChildrenTokens).Select(to => (Token)to).ToList();
            };

            TermTextMatrix<int> ttm = new TermTextMatrix<int>(texts);

            TermTextMatrixResult<int> ttmr = new TermTextMatrixResult<int>(ttm, '\t');
            var res = ttmr.ConvertToTCSV();

            File.WriteAllText("csv_rez.csv", res, Encoding.UTF8);
        }
    }
}
