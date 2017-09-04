using System;
namespace TPPLib.Entities
{
    /// <summary>
    /// Тип токена.
    /// </summary>
    public enum TokenType
    {
        /// <summary>
        /// Полный текст.
        /// </summary>
        FULL_TEXT = 1,
        /// <summary>
        /// Абзац.
        /// </summary>
        PARAGRAPH = 2,
        /// <summary>
        /// Предложение.
        /// </summary>
        SENTENCE =3,
        /// <summary>
        /// Слово.
        /// </summary>
        WORD = 4,
        /// <summary>
        /// Какой-либо другой кусок текста.
        /// </summary>
        OTHER = 5
    }
}
