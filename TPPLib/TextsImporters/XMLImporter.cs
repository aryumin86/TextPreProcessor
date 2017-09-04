using System;
using System.Collections.Generic;
using System.Text;
using TPPLib.Entities;

namespace TPPLib.TextsImporters
{
    public class XMLImporter : AbstractTextImporter
    {
        public XMLImporter(string dir, Encoding enc) : base(dir, enc)
        {
        }

        public override IEnumerable<Token> ImportTexts()
        {
            throw new NotImplementedException();
        }
    }
}
