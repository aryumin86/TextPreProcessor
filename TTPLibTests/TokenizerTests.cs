using System;
using TPPLib.Entities;
using TPPLib.Tokenizers;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TTPLibTests
{
    public class TokenizerTests
    {
		[Fact]
		[Trait("Category", "Unit")]
		public void RusTokenizer_Really_Tokenizes()
		{
            var rawText = new Token()
            {
                TextId = "1",
                Content = "Это какой-то #текст... Это второе предложение!.. Всё?",
                TokenType = TokenType.FULL_TEXT
            };

            var tokenizer = new RusTokenizer();
            var words = tokenizer.TokenizeToWords(rawText);

            Assert.True(words.Count() != 0);
		}

        [Fact]
        [Trait("Category", "Unit")]
        public void RusTokenizer_Correctly_Split_Text_To_Sentences_Without_Shortages(){

            Token rawText = new Token()
            {
                TokenType = TokenType.FULL_TEXT,
				TextId = "1",
                Content = @"
Это какой-то #текст... Это второе предложение! (Всё?) 
 Вот тут нету точки и др. вот. 
Г-н Иванов родился в 1765 г. в гор. Урюпинск и мкр. четвертый. 
...
$
%
-=
"
			};

			var tokenizer = new RusTokenizer();
			var centences = tokenizer.TokenizeToSentences(rawText);

            Assert.True(centences.Count() == 5);
		}


		[Fact]
		[Trait("Category", "Unit")]
		public void RusTokenizer_Does_Not_Split_Shortages_As_Separate_Sentences()
		{
            var texts = GetSentencesWithShortages();

			var tokenizer = new RusTokenizer();

            foreach(var text in texts){
                Assert.True(tokenizer.TokenizeToSentences(text).Count() == 1);
            }
		}

        private IEnumerable<Token> GetSentencesWithShortages(){
            return new List<Token>
            {
                new Token(){
                    Content = "Этот человек живет в г.Урюпинск",
                    TokenType = TokenType.FULL_TEXT
                },
				new Token(){
					Content = "А этот - в г. Джакарта",
                    TokenType = TokenType.FULL_TEXT
                },
				new Token(){
					Content = "А этот по адресу пос. Знаменка д. 4 корп. 1 кв. 666 эт. 66, кот. около с. Оболдуевка",
                    TokenType = TokenType.FULL_TEXT
                },
				new Token(){
					Content = "А этот по адресу пос.Знаменка д.4 корп.1 кв.666 эт.66, кот.около с.Оболдуевка",
                    TokenType = TokenType.FULL_TEXT
                }
            };
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void Tokenizer_Correctly_Splits_To_Paragraphs()
        {
            var t = new Token()
            {
                Content = "Предложение в абзаце1. \r\n А вот это второй абзац... вот"
            };

            var tokenizer = new RusTokenizer();
            var sents = tokenizer.TokenizeToParagraphs(t);

            Assert.True(sents.Count() == 2);
        }
    }
}
