using System;
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
    }
}
