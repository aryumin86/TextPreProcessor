using System;
using TPPLib.TPPOperations;
using TPPLib;
using Xunit;
using System.Collections.Generic;
using TPPLib.Entities;
using System.Linq;

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

            List<Token> tokens = new List<Token> {
                new Word(){
                    Content = "smth@mail.ru"
                },
                new Word(){
                    Content = "smth@mail.com"
                },
                new Word(){
                    Content = "мыло@почта.рф"
                },
                new Sentence(){
                    Content = "какой-то текст... address@mail.ru и еще текст"
                },
                new Sentence(){
                    Content = "текст (address@mail.ru) текст"
                },
            };

            @operator = new TPPOperator(tokens, ops);
            @operator.Exucute();

            Assert.True(tokens.Where(t => t is Word).Select(t => t.Content).All(t => string.IsNullOrEmpty(t)));
            Assert.True(tokens.Where(t => t is Sentence).Select(t => t.Content).All(t => !t.Contains("address@mail.ru")));
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void HashTags_Should_Be_Removed_From_AnyType_Token()
        {

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

        }

        [Fact]
        [Trait("Category", "Unit")]
        public void Links_Should_Be_Removed_From_AnyTypeToken()
        {

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
