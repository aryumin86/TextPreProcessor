using System;
using TPPLib.TPPOperations;
using TPPLib;
using Xunit;
using System.Collections.Generic;
using TPPLib.Entities;
using System.Linq;
using System.Text.RegularExpressions;
using TPPLib.Stemmers;

namespace TTPLibTests
{
    public class TPPOperationsTests
    {
        TPPOperator @operator;


        #region UnitTests

        [Fact]
        [Trait("Category", "Unit")]
        public void Emails_Should_Be_Removed_From_AnyType_Token_Test()
        {
            List<TPPOperation> ops = new List<TPPOperation>{
                new RemoveEmails()
            };

            IEnumerable<Token> tokens = GeTokensContainingtEmailsToRemove();

            @operator = new TPPOperator(tokens, ops);
            @operator.Exucute();

            Assert.True(tokens.Where(t => t.TokenType == TokenType.WORD).Select(t => t.Content).All(t => string.IsNullOrWhiteSpace(t)));
            Assert.True(tokens.Where(t => t.TokenType == TokenType.SENTENCE).Select(t => t.Content).All(t => !t.Contains("address@mail.ru")));
        }

        private static List<Token> GeTokensContainingtEmailsToRemove()
        {
            List<Token> emailStrings = new List<Token>
            {
                new Token(null, "smth@mail.ru", TokenType.WORD),
                new Token(null, "smth@mail.com", TokenType.WORD),
                new Token(null, "мыло@почта.рф", TokenType.WORD),
                new Token(null, "какой-то текст... address@mail.ru и еще текст", TokenType.SENTENCE),
                new Token(null,  "текст (address@mail.ru) текст", TokenType.SENTENCE)
            };

            return emailStrings;
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void HashTags_Should_Be_Removed_From_AnyType_Token()
        {
            List<TPPOperation> ops = new List<TPPOperation>{
                new RemoveHashTags()
            };

            IEnumerable<Token> tokens = GetTokensContainingHashTagsToRemove();

            @operator = new TPPOperator(tokens, ops);
            @operator.Exucute();

            Assert.True(tokens.Where(t => t.TokenType == TokenType.WORD)
                .All(t => !t.Content.Trim().StartsWith("#")));
            Assert.True(tokens.Where(t => t.TokenType == TokenType.SENTENCE)
                .All(t => !t.Content.Contains("hash_Tag") || !t.Content.Contains("#")));
        }

        private static List<Token> GetTokensContainingHashTagsToRemove()
        {
            List<Token> hashTagsStrings = new List<Token>
            {
                new Token(null, "#тег", TokenType.WORD),
                new Token(null, "#hash_Tag", TokenType.WORD),
                new Token(null, "текст #тег текст", TokenType.SENTENCE),
                new Token(null, "текст #hash_Tag текст", TokenType.SENTENCE)
            };

            return hashTagsStrings;
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void Words_Should_Be_Lemmatized()
        {

        }


        [Fact]
        [Trait("Category", "Unit")]
        public void Words_Should_Be_Stemmed()
        {
			List<TPPOperation> ops = new List<TPPOperation>{
				new MakeStemming(new RusStemmer())
			};

			IEnumerable<Token> tokens = GetWordsToStemm();

			@operator = new TPPOperator(tokens, ops);
			@operator.Exucute();

            Assert.True(tokens.Select(t => t.Content)
                        .Intersect(GetWordsToStemm().Select(tt => tt.Content)).Count() == 0);
        }

        private List<Token> GetWordsToStemm(){
            
			List<Token> wordsToStem = new List<Token>
			{
				new Token(null, "корова", TokenType.WORD),
				new Token(null, "стрекоза", TokenType.WORD)
			};

			return wordsToStem;
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void Html_And_JS_Should_Be_Removed_From_Raw_Text()
        {
            List<TPPOperation> ops = new List<TPPOperation>{
                new RemoveHtmlAndJs()
            };

            IEnumerable<Token> tokens = GetTokensWithHtmlOrJsTagsToRemove();

            @operator = new TPPOperator(tokens, ops);
            @operator.Exucute();

            Assert.True(tokens.Where(t => t.TokenType == TokenType.WORD)
                .All(t => string.IsNullOrWhiteSpace(t.Content)));
            Assert.False(tokens.Where(t => t.TokenType == TokenType.SENTENCE)
                .Any(t => Regex.IsMatch(t.Content, @"(<[^>]*>)|(<[\s\S]*?</[^>]*>)")));
        }

        private static List<Token> GetTokensWithHtmlOrJsTagsToRemove()
        {
            List<Token> withHtmlOrJsTagsStrings = new List<Token>
            {
                new Token(null, "<a>", TokenType.WORD),
                new Token(null, "<абв>", TokenType.WORD),
                new Token(null, "</абв>", TokenType.WORD),
                new Token(null, "текст <a>smth</a> текст", TokenType.SENTENCE),
                new Token(null, "текст <абв>smth</абв> трр  <another>что-то</another> текст", TokenType.SENTENCE)
            };

            return withHtmlOrJsTagsStrings;
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void Links_Should_Be_Removed_From_AnyTypeToken()
        {
            List<TPPOperation> ops = new List<TPPOperation>{
                new RemoveLinks()
            };

            IEnumerable<Token> tokens = GetTokensWithLinksToRemove();

            @operator = new TPPOperator(tokens, ops);
            @operator.Exucute();

            Assert.True(tokens.Where(t => t.TokenType == TokenType.WORD)
                .All(t => string.IsNullOrWhiteSpace(t.Content)));
            Assert.False(tokens.Where(t => t.TokenType == TokenType.SENTENCE)
                .Any(t => Regex.IsMatch(t.Content, @"\bhttps?:\/\/(www\.)?[-a-zа-я0-9@:%._\+~#=]{2,256}\.[a-zа-я]{2,6}\b([-a-zа-я0-9@:%_\+.~#?&//=]*)\b")));
            Assert.False(tokens.Where(t => t.TokenType == TokenType.SENTENCE)
                .Any(t => Regex.IsMatch(t.Content, @"\bxn--\S*\b")));
        }

        private static List<Token> GetTokensWithLinksToRemove()
        {
            List<Token> withLiksStrings = new List<Token>
            {
                new Token(null, "http://haha.ru", TokenType.WORD),
                new Token(null, "https://haha.ru/hoho?smth=123&a=no", TokenType.WORD),
                new Token(null, "xn--d1acufc", TokenType.WORD),
                new Token(null, "http://субдомен.домен.рф/какой-то-путь", TokenType.WORD),
                new Token(null, "http://www.haha.ru", TokenType.WORD),
                new Token(null, "http://content-analysis.ru", TokenType.WORD),

                new Token(null, "текст http://haha.ru текст", TokenType.SENTENCE),
                new Token(null, "текст https://haha.ru/hoho?smth=123&a=no текст", TokenType.SENTENCE),
                new Token(null, "текст xn--d1acufc текст", TokenType.SENTENCE),
                new Token(null, "текст http://субдомен.домен.рф/какой-то-путь текст", TokenType.SENTENCE),
                new Token(null, "текст http://www.haha.ru текст http://haha.ru", TokenType.SENTENCE),
                new Token(null, "текст http://content-analysis.ru текст", TokenType.SENTENCE),
            };

            return withLiksStrings;
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void Punctuation_Should_Be_Removed_From_Text()
        {
            List<TPPOperation> ops = new List<TPPOperation>{
                new RemovePunctuation()
            };

            IEnumerable<Token> tokens = GetStringsWithPunctuationToremove();

            @operator = new TPPOperator(tokens, ops);
            @operator.Exucute();

            Assert.False(tokens.Any(t => Regex.IsMatch(t.Content, @"[^\dа-яa-z\s]")));
        }

        private List<Token> GetStringsWithPunctuationToremove()
        {
            List<Token> withLiksStrings = new List<Token>
            {
                new Token(null, "-!@#$%^&*()_+=арбуз\"'<>№;%:?*", TokenType.WORD),
                new Token(null, "текст . -!@#$%^&*()_+=арбуз\"'<>№;%:?* текст , ", TokenType.SENTENCE)
            };

            return withLiksStrings;
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void Short_Words_Should_Be_Removed_From_WordsTokens()
        {
            List<TPPOperation> ops = new List<TPPOperation>{
                new RemoveShortWords()
            };

            IEnumerable<Token> tokens = GetShortWordsToRemove();

            @operator = new TPPOperator(tokens, ops);
            @operator.Exucute();

            Assert.False(tokens.Any(t => t.Content.Length < 3 && !string.IsNullOrWhiteSpace(t.Content)));
        }

        private List<Token> GetShortWordsToRemove()
        {
            List<Token> withLiksStrings = new List<Token>
            {
                new Token(null, "привет", TokenType.WORD),
                new Token(null, "да", TokenType.WORD),
                new Token(null, "я", TokenType.WORD),
                new Token(null, "нет", TokenType.WORD)
            };

            return withLiksStrings;
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void Single_Standing_Numbers_Should_Be_Removed_From_AnyType_Token()
        {
            List<TPPOperation> ops = new List<TPPOperation>{
                new RemoveSingleStayingNumbers()
            };

            IEnumerable<Token> tokens = GetSingleStayingNumbersToRemove();

            @operator = new TPPOperator(tokens, ops);
            @operator.Exucute();

            Assert.False(tokens.Any(t => Regex.IsMatch(t.Content, @"\b\d+\b")));
        }

        private List<Token> GetSingleStayingNumbersToRemove()
        {
            List<Token> singleNums = new List<Token>
            {
                new Token(null, "1", TokenType.WORD),
                new Token(null, "22", TokenType.WORD),
                new Token(null, "333", TokenType.WORD),
                new Token(null, "0", TokenType.WORD),

                new Token(null, "текст 1 текст", TokenType.SENTENCE),
                new Token(null, "текст 11 текст", TokenType.SENTENCE),
            };

            return singleNums;
        } 

        [Fact]
        [Trait("Category", "Unit")]
        public void Stop_Words_Should_Be_Removed_From_WordsTokens()
        {
            RemoveStopWords rsw = new RemoveStopWords(true, true, 
                pathToRus : "../../../../TPPLib/LibDataWorkItems/RusStopWords.txt", 
                pathToEng : "../../../../TPPLib/LibDataWorkItems/EngStopWords.txt");

            //русский язык
            List<TPPOperation> ops = new List<TPPOperation>{
               rsw
            };

            //английский язык
            IEnumerable<Token> tokens = GetWordsWithStopWords();

            @operator = new TPPOperator(tokens, ops);
            @operator.Exucute();

            Assert.False(tokens.Select(t => t.Content)
                .Intersect((rsw.englishStopWords.Union(rsw.russianStopWords))).Count() > 0);

        }

        private IEnumerable<Token> GetWordsWithStopWords()
        {
            List<Token> someOfWordsAreStopWords = new List<Token>
            {
                new Token(null, "да", TokenType.WORD),
                new Token(null, "попугай", TokenType.WORD),
                new Token(null, "под", TokenType.WORD),
                new Token(null, "рыбка", TokenType.WORD),

                new Token(null, "no", TokenType.WORD),
                new Token(null, "fish", TokenType.WORD),
                new Token(null, "yes", TokenType.WORD)
            };

            return someOfWordsAreStopWords;
        }

        private List<Token> GetTokensWithStopWordsToRemove()
        {
            return null;
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void Tabu_Words_Should_Be_Removed_From_WordsTokens()
        {
            //русский язык



            //английский язык


        }

        private string GetTabuWordsRegex()
        {
            return null;
        } 

        private List<Token> GetTokensWithTabuWords()
        {
            return null;
        }


        #endregion

        #region IntegrationTests





        #endregion

    }
}
