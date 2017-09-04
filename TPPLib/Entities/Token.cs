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
        public string Content { get; set; }
        public string TextId { get; set; }

        /// <summary>
        /// Дочерние токены (могут быть словами, абзацами, предложениями и др.
        /// </summary>
        public List<Token> Tokens = new List<Token>();
    }
}
