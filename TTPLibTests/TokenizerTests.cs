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
		public void Russian_Tokenizer_Really_Tokenizes()
		{
            RawText rawText = new RawText()
            {
                Id = "1",
                Content = "Это какой-то #текст... Это второе предложение!.. Всё?"
            };

            var tokenizer = new RusTokenizer();
            var words = tokenizer.TokenizeToWords(rawText);

            Assert.True(words.Count() == 8);
		}

		[Fact]
		[Trait("Category", "Unit")]
        public void Russian_Tokenizer_Cleans_Punctuation(){
			RawText rawText = new RawText()
			{
				Id = "1",
                Content = "Это какой-то #текст... Это второе предложение!.. Всё?!@#$%^&*()_+-=|\\\".,~!№%::,,.;"
			};

			var tokenizer = new RusTokenizer();
			var words = tokenizer.TokenizeToWords(rawText);

            Assert.True(words.All(w => !Regex.IsMatch(w.Content, @"[\.,/\/\[\]!@#$%^&*()\-+=\{\}]")));
        }
    }
}
