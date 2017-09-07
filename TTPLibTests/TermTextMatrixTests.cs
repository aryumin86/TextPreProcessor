using System;
using System.Collections.Generic;
using System.Text;
using TPPLib.Entities;
using Xunit;

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
        /// текст, оперируя только массивом токенов (термов) с id текстов.
        /// </summary>
        [Fact]
        [Trait("Category", "Unit")]
        public void Find_All_Samples_Count_Using_Just_TermsTokens()
        {
            var text = new Token()
            {
                Content = "Это какой-то текст. В этом тексте"
            };
        }
    }
}
