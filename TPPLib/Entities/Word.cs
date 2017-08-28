using System;
namespace TPPLib.Entities
{
    /// <summary>
    ///  Слово.
    /// </summary>
    public class Word : Token
    {
        public Word() { }

        public Word(string textId, string Content)
        {
            this.TextId = textId;
            this.Content = Content;
        }
    }
}
