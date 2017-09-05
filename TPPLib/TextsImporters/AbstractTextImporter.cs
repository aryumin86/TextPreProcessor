using System;
using System.Text;
using System.Collections.Generic;
using TPPLib.Entities;


namespace TPPLib.TextsImporters
{
    /// <summary>
    /// Абстрактный загрузчик текстов из разных источников.
    /// </summary>
    public abstract class AbstractTextImporter{

        /// <summary>
        /// Загруить тексты из файлов в указанной в конструкторе директории.
        /// </summary>
        /// <returns>The texts.</returns>
		public abstract IEnumerable<Token> ImportTexts(string dir, Encoding enc);
    }
}
