using System;
using System.Collections.Generic;

namespace TPPLib.Entities
{
    /// <summary>
    /// Токен. Какой-либо сегмент исходного текста 
    /// или сам исходный текст целиком.
    /// </summary>
    public class Token
    {
        /// <summary>
        /// Текстовое содержимое токена.
        /// </summary>
        /// <value>The content.</value>
        public string Content { get; set; }

        /// <summary>
        /// Id текста, которрый содержит токен (или коим токен является).
        /// </summary>
        /// <value>The text identifier.</value>
        public string TextId { get; set; }

        /// <summary>
        /// Дочерние токены (могут быть словами, абзацами, предложениями и др.
        /// </summary>
        public List<Token> ChildrenTokens = new List<Token>();

        /// <summary>
        /// Родительский токен. Может быть только не у RawText.
        /// </summary>
        /// <value>The parent.</value>
        public Token ParentToken { get; set; }

        /// <summary>
        /// Позиция (индекс) токена в родительском токене. Начинается с 0.
        /// </summary>
        /// <value>The position in parent.</value>
        public int? PositionInParent { get; set; }

        /// <summary>
        /// Тип токена.
        /// </summary>
        public TokenType TokenType { get; set; }

        public Token() { }

        public Token(string textId, string content, TokenType tokenType, Token parent = null, List<Token> children = null,  int? positionInParent = null)
        {
            this.TextId = textId;
            this.Content = content;
            this.TokenType = tokenType;
            this.ParentToken = parent;
            this.ChildrenTokens = children;
            this.PositionInParent = positionInParent;
        }
    }
}
