using System;
using System.Collections.Generic;
using System.Text;
using TPPLib.Entities;

namespace TPPLib.TextsImporters
{
    /// <summary>
    /// Импортер из файлов txt.
    /// Рекурсивно загружает тексты из указанной в конструкторе директории
    /// </summary>
    public class TXTImporter : AbstractTextImporter
    {
        /// <summary>
        /// Разделитель текстов.
        /// </summary>
        private string _delimeter = "##NEW_RAWTEXT##";

        public TXTImporter(string dir, Encoding enc) : base(dir, enc)
        {
        }

        /// <summary>
        /// Импортировать тексты.
        /// </summary>
        /// <returns>The texts.</returns>
        public override IEnumerable<Token> ImportTexts()
        {
            throw new NotImplementedException();
        }
    }
}
