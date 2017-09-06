using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TPPLib.Entities;
using System.Linq;

namespace TPPLib.TextsImporters
{
    /// <summary>
    /// Импортер из файлов txt. Если нужно присвоить id тексту, то 
    /// оно должно идти в самом начале текста в формате: #1# (решетка + сам id + решетка).
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
            var files = Directory.GetFiles(dir)
                .Where(f => f.EndsWith(".txt"));

            string id;
            string content;

            foreach (var f in files)
            {
                var fileContent = File.ReadAllText(f, enc);

                var texts = fileContent.Split(new string[] { _delimeter }, 
                    StringSplitOptions.RemoveEmptyEntries);

                foreach(var text in texts)
                {
                    string[] lines = text.Split(new string[] { Environment.NewLine },
                        StringSplitOptions.RemoveEmptyEntries);

                    id = lines.First(s => s.Trim().StartsWith("#")
                    && s.Trim().EndsWith("#"));

                    content = string.Join(Environment.NewLine,
                        lines.Where(s => !s.Trim().StartsWith("#") &&
                        s.Trim().EndsWith("#")));

                    yield return new Token()
                    {
                        TextId = id != null ? id.Trim('#') : null,
                        Content = content,
                        TokenType = TokenType.FULL_TEXT
                    };
                }
            }
        }
    }
}
