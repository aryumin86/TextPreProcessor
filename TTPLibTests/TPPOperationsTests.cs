using System;
using TPPLib.TPPOperations;
using TPPLib;
using Xunit;
using System.Collections.Generic;
using TPPLib.Entities;
using System.Linq;
using System.Text.RegularExpressions;

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

            var tokens = GeTokensContainingtEmailsToRemove();

            @operator = new TPPOperator(tokens, ops);
            @operator.Exucute();

            Assert.True(tokens.Where(t => t is Word).Select(t => t.Content).All(t => string.IsNullOrWhiteSpace(t)));
            Assert.True(tokens.Where(t => t is Sentence).Select(t => t.Content).All(t => !t.Contains("address@mail.ru")));
        }

        private static List<Token> GeTokensContainingtEmailsToRemove()
        {
            List<Token> emailStrings = new List<Token>
            {
                new Word(null, "smth@mail.ru"),
                new Word(null, "smth@mail.com"),
                new Word(null, "мыло@почта.рф"),
                new Sentence(null, "какой-то текст... address@mail.ru и еще текст"),
                new Sentence(null,  "текст (address@mail.ru) текст")
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

            var tokens = GetTokensContainingHashTagsToRemove();

            @operator = new TPPOperator(tokens, ops);
            @operator.Exucute();

            Assert.True(tokens.Where(t => t is Word)
                .All(t => !t.Content.Trim().StartsWith("#")));
            Assert.True(tokens.Where(t => t is Sentence)
                .All(t => !t.Content.Contains("hash_Tag") || !t.Content.Contains("#")));
        }

        private static List<Token> GetTokensContainingHashTagsToRemove()
        {
            List<Token> hashTagsStrings = new List<Token>
            {
                new Word(null, "#тег"),
                new Word(null, "#hash_Tag"),
                new Sentence(null, "текст #тег текст"),
                new Sentence(null, "текст #hash_Tag текст")
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

        }

        [Fact]
        [Trait("Category", "Unit")]
        public void Html_And_JS_Should_Be_Removed_From_Raw_Text()
        {
            List<TPPOperation> ops = new List<TPPOperation>{
                new RemoveHtmlAndJs()
            };

            var tokens = GetTokensWithHtmlOrJsTagsToRemove();

            @operator = new TPPOperator(tokens, ops);
            @operator.Exucute();

            Assert.True(tokens.Where(t => t is Word)
                .All(t => string.IsNullOrWhiteSpace(t.Content)));
            Assert.False(tokens.Where(t => t is Sentence)
                .Any(t => Regex.IsMatch(t.Content, @"(<[^>]*>)|(<[\s\S]*?</[^>]*>)")));
        }

        private static List<Token> GetTokensWithHtmlOrJsTagsToRemove()
        {
            List<Token> withHtmlOrJsTagsStrings = new List<Token>
            {
                new Word(null, "<a>"),
                new Word(null, "<абв>"),
                new Word(null, "</абв>"),
                new Sentence(null, "текст <a>smth</a> текст"),
                new Sentence(null, "текст <абв>smth</абв> трр  <another>что-то</another> текст")
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

            var tokens = GetTokensWithLinksToRemove();

            @operator = new TPPOperator(tokens, ops);
            @operator.Exucute();

            Assert.True(tokens.Where(t => t is Word)
                .All(t => string.IsNullOrWhiteSpace(t.Content)));
            Assert.False(tokens.Where(t => t is Sentence)
                .Any(t => Regex.IsMatch(t.Content, @"\bhttps?:\/\/(www\.)?[-a-zа-я0-9@:%._\+~#=]{2,256}\.[a-zа-я]{2,6}\b([-a-zа-я0-9@:%_\+.~#?&//=]*)\b")));
            Assert.False(tokens.Where(t => t is Sentence)
                .Any(t => Regex.IsMatch(t.Content, @"\bxn--\S*\b")));
        }

        private static List<Token> GetTokensWithLinksToRemove()
        {
            List<Token> withLiksStrings = new List<Token>
            {
                new Word(null, "http://haha.ru"),
                new Word(null, "https://haha.ru/hoho?smth=123&a=no"),
                new Word(null, "xn--d1acufc"),
                new Word(null, "http://субдомен.домен.рф/какой-то-путь"),
                new Word(null, "http://www.haha.ru"),
                new Word(null, "http://content-analysis.ru"),

                new Sentence(null, "текст http://haha.ru текст"),
                new Sentence(null, "текст https://haha.ru/hoho?smth=123&a=no текст"),
                new Sentence(null, "текст xn--d1acufc текст"),
                new Sentence(null, "текст http://субдомен.домен.рф/какой-то-путь текст"),
                new Sentence(null, "текст http://www.haha.ru текст http://haha.ru"),
                new Sentence(null, "текст http://content-analysis.ru текст"),
            };

            return withLiksStrings;
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void Punctuation_Should_Be_Removed_From_Raw_Text()
        {

        }

        [Fact]
        [Trait("Category", "Unit")]
        public void Short_Words_Should_Be_Removed_From_WordsTokens()
        {

        }

        [Fact]
        [Trait("Category", "Unit")]
        public void Single_Standing_Numbers_Should_Be_Removed_From_AnyType_Token()
        {

        }

        [Fact]
        [Trait("Category", "Unit")]
        public void Stop_Words_Should_Be_Removed_From_WordsTokens()
        {

        }

        [Fact]
        [Trait("Category", "Unit")]
        public void Tabu_Words_Should_Be_Removed_From_WordsTokens()
        {

        }


        #endregion

        #region IntegrationTests





        #endregion

    }
}
