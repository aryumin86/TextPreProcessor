using System;
using System.Collections.Generic;

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

        /// <summary>
        /// Токены исходного текста (могут быть словами, абзацами, предложениями и др.
        /// </summary>
        public List<Token> Tokens = new List<Token>();
    }
}
