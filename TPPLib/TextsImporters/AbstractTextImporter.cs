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
        /// Директория загрузки файлов с текстами.
        /// </summary>
        protected string dir;

        /// <summary>
        /// Кодировка файлов с текстами.
        /// </summary>
        protected Encoding enc;

        public AbstractTextImporter(string dir, Encoding enc){
            this.dir = dir;
            this.enc = enc;
        }

        /// <summary>
        /// Загруить тексты из файлов в указанной в конструкторе директории.
        /// </summary>
        /// <returns>The texts.</returns>
		public abstract IEnumerable<Token> ImportTexts();
    }
}
