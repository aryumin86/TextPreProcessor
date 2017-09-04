using System;
using System.Collections.Generic;

namespace TPPLib.Entities
{
    /// <summary>
    /// Токен. В конкретной реализации может быть словом, n-граммой предложением, абзацем. 
    /// Также это может быть полный текст - текст не подвергался предварительно токенизации.
    /// Представляет собой обычный текст.
    /// </summary>
    public abstract class Token
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
        /// Позиция (индекс) токена в родительском токене.
        /// </summary>
        /// <value>The position in parent.</value>
        public int? PositionInParent { get; set; }

        /// <summary>
        /// Стартовая позиция токена (индекс слова) во всем тексте.
        /// </summary>
        /// <value>The token start position.</value>
        public int? TokenStartPosition { get; set; }
    }
}
