using System;
namespace TPPLib.Entities
{
    /// <summary>
    /// Предложение.
    /// </summary>
    public class Sentence : Token
    {
        /// <summary>
        /// Номер предложения в тексте.
        /// </summary>
        /// <value>The number in text.</value>
        public int NumInText { get; set; }

        public Sentence() { }

        public Sentence(string textId, string Content)
        {
            this.TextId = textId;
            this.Content = Content;
        }
    }
}
