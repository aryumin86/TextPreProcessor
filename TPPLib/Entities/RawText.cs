using System;
namespace TPPLib.Entities
{
    /// <summary>
    /// Исходный текст.
    /// </summary>
    public class RawText
    {
        public string Id { get; set; }

        /// <summary>
        /// Содержание текста
        /// </summary>
        /// <value>The content.</value>
        public string Content { get; set; }
    }
}
