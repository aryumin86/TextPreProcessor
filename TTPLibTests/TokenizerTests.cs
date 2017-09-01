using System;
using Xunit;

namespace TTPLibTests
{
    public class TokenizerTests
    {
		[Fact]
		[Trait("Category", "Unit")]
		public void Russian_Tokenizer_Should_Not_Tokenize_SpecialCases_When_To_Words()
		{
			//например, не дробить что-нибудь или г.Москва или г-н Иванов
		}
    }
}
