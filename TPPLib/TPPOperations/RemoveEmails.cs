using System;
using System.Collections.Generic;
using TPPLib.Entities;
using System.Text.RegularExpressions;

namespace TPPLib.TPPOperations
{
    public class RemoveEmails : TPPOperation
    {
        private readonly string _emailPattern = @"\b([a-z0-9_\.-]+)@([a-z0-9_\.-]+)\.([a-z\.]{2,6})$\b";
        private Regex _emailRegex = null; 

        public RemoveEmails()
        {
            this._emailRegex = new Regex(_emailPattern, RegexOptions.Compiled | RegexOptions.Singleline);
        }

        public override void Execute(IEnumerable<Token> tokens)
        {
            foreach(var token in tokens){
                _emailRegex.Replace(token.Content, " ");
            }
        }
    }
}
