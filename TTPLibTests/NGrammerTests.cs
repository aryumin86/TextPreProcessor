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
        public void NGrammer_Returns_Corrent_NGramms_Num(){

            NGrammer ngrammer = new NGrammer();
            var words = GenerateListOfWords((15));

            //биграммы
            var tt = ngrammer.CreateNGramms(words, 2);
            Assert.True(tt.Count() == 14);


			//триграммы
			tt = ngrammer.CreateNGramms(words, 3);
			Assert.True(tt.Count() == 13);


			//4-граммы
			tt = ngrammer.CreateNGramms(words, 4);
			Assert.True(tt.Count() == 13);

        }

        private List<Token> GenerateListOfWords(int num){
            var words = new List<Token>();

            for (int i = 0; i < num; i++){
                words.Add(new Word()
                {
                    Content = "слово" + i
                });
            }

            return words;
        }
    }
}
