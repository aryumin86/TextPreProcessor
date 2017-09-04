using System;
namespace TPPLib.Entities
{
    /// <summary>
    /// Предложение.
    /// </summary>
    public class Sentence : Token
    {
        public Sentence() { }

        public Sentence(string textId, string Content)
        {
            this.TextId = textId;
            this.Content = Content;
        }
    }
}
