using System;
using System.Collections.Generic;
using System.Text;
using TPPLib.Entities;

namespace TPPLib.TextsImporters
{
    /// <summary>
    /// Импортер текстов из XLSX.
    /// </summary>
    public class XLSXImporter : AbstractTextImporter
    {
        public XLSXImporter(string dir, Encoding enc) : base(dir, enc)
        {
        }

        public override IEnumerable<RawText> ImportTexts()
        {
            throw new NotImplementedException();
        }
    }
}
