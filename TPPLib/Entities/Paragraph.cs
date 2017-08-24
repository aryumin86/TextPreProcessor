using System;
namespace TPPLib.Entities
{
    /// <summary>
    /// Параграф.
    /// </summary>
    public class Paragraph : Token
    {
		/// <summary>
		/// Номер абзаца в тексте.
		/// </summary>
		/// <value>The number in text.</value>
		public int NumInText { get; set; }
    }
}
