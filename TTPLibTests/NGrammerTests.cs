using System;
using Xunit;
using System.Collections.Generic;
using TPPLib.Entities;
using TPPLib;
using System.Linq;

namespace TTPLibTests
{
    public class NGrammerTests
    {
		[Fact]
		[Trait("Category", "Unit")]
        public void NGrammer_Returns_Correct_NGramms_Num(){

            NGrammer ngrammer = new NGrammer();

            //биграммы
            var words = GenerateListOfWords((15));
            var tt = ngrammer.CreateNGramms(words, 2, saveBaseNGramms: false);
            Assert.True(tt.Count() == 14);

            //триграммы
            words = GenerateListOfWords((15));
            tt = ngrammer.CreateNGramms(words, 3, saveBaseNGramms: false);
			Assert.True(tt.Count() == 13);

            //4-граммы
            words = GenerateListOfWords((15));
            tt = ngrammer.CreateNGramms(words, 4, saveBaseNGramms: false);
			Assert.True(tt.Count() == 12);


            //очень короткий список токенов подается на вход
            words = GenerateListOfWords((3));
            tt = ngrammer.CreateNGramms(words, 3, saveBaseNGramms: false);
            Assert.True(tt.Count() == 3);
        }

        private List<Token> GenerateListOfWords(int num){
            var words = new List<Token>();

            for (int i = 0; i < num; i++){
                words.Add(new Token()
                {
                    Content = "слово" + i,
                    TokenType = TokenType.WORD
                });
            }

            return words;
        }
    }
}
