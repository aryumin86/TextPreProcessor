using System;
using System.Collections.Generic;
using System.Text;
using TPPLib.Entities;

namespace TPPLib.TextsImporters
{
    /// <summary>
    /// Импортер из файлов txt. Если нужно присвоить id тексту, то 
    /// оно должно идти в самом начале текста в формате: #1 (решетка + сам id).
    /// Загружает тексты из указанной в конструкторе директории.
    /// </summary>
    public class TXTImporter : AbstractTextImporter
    {
        /// <summary>
        /// Разделитель текстов.
        /// </summary>
        private string _delimeter;
        private bool _recursive;

        /// <summary>
        /// Основной конструктор.
        /// </summary>
        /// <param name="delimeter"></param>
        /// <param name="recursive">загрузка будет идти рекурсивно, для всех txt файлов, находящихся
        /// в текущией директории и субдиректориях</param>
        public TXTImporter(string delimeter = "##NEW_RAWTEXT##", bool recursive = false) : base()
        {
            this._delimeter = delimeter;
            this._recursive = recursive;
        }

        public override IEnumerable<Token> ImportTexts(string dir, Encoding enc)
        {
            throw new NotImplementedException();
        }
    }
}
