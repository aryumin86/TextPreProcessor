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
            var rawText = new RawText()
            {
                TextId = "1",
                Content = "Это какой-то #текст... Это второе предложение!.. Всё?"
            };

            var tokenizer = new RusTokenizer();
            var words = tokenizer.TokenizeToWords(rawText);

            Assert.True(words.Count() != 0);
		}

        [Fact]
        [Trait("Category", "Unit")]
        public void RusTokenizer_Correctly_Split_Text_To_Sentences_Without_Shortages(){

			RawText rawText = new RawText()
			{
				TextId = "1",
                Content = @"
Это какой-то #текст... Это второе предложение! (Всё?) 
 Вот тут нету точки и др 
...
$
%
-=
"
			};

			var tokenizer = new RusTokenizer();
			var centences = tokenizer.TokenizeToSentences(rawText);

            Assert.True(centences.Count() == 4);
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

        private IEnumerable<RawText> GetSentencesWithShortages(){
            return new List<RawText>
            {
                new RawText(){
                    Content = ""
                },
				new RawText(){
					Content = ""
				},
				new RawText(){
					Content = ""
				},
				new RawText(){
					Content = ""
				},
				new RawText(){
					Content = ""
				},
				new RawText(){
					Content = ""
				},
				new RawText(){
					Content = ""
				}
            };
        }
    }
}
