using System;
using TPPLib.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TPPLib
{
    /// <summary>
    /// Класс базовой очистки текстов.
    /// </summary>
    public class BasicTextCleaner
    {
        public string MakeBasicCleaning(RawText raw){
            throw new NotImplementedException();
        }

        public IEnumerable<Token> MakeBasicCleaning(IEnumerable<Token> tokens){
            tokens = tokens.Where(t => !string.IsNullOrWhiteSpace(t.Content));
            foreach (var t in tokens)
                t.Content = Regex.Replace(t.Content, @"\s+", " ", 
                                          RegexOptions.Compiled | RegexOptions.Singleline);

            return tokens;
        }
    }
}
