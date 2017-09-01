using System;
using System.Collections.Generic;
using TPPLib.Entities;
using System.Text.RegularExpressions;

namespace TPPLib.TPPOperations
{
    public class RemoveEmails : TPPOperation
    {
        private readonly string _emailPattern = @"\b([a-zа-я0-9_\.-]+)@([a-zа-я0-9_\.-]+)\.([a-zа-я\.]{2,6})\b";
        private Regex _emailRegex = null; 

        public RemoveEmails()
        {
            this._emailRegex = new Regex(_emailPattern, RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase);
        }

        public override void Execute(ref IEnumerable<Token> tokens)
        {
            foreach(var token in tokens){
                token.Content = _emailRegex.Replace(token.Content, " ");
            }
        }
    }
}
