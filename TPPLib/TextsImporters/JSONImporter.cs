using System;
using System.Collections.Generic;
using System.Text;
using TPPLib.Entities;

namespace TPPLib.TextsImporters
{
    /// <summary>
    /// Импортер текстов из JSON.
    /// </summary>
    public class JSONImporter : AbstractTextImporter
    {
        public override IEnumerable<Token> ImportTexts(string dir, Encoding enc)
        {
            throw new NotImplementedException();
        }
    }
}
