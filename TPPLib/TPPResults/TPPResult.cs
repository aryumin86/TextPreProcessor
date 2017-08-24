using System;
namespace TPPLib.TPPResults
{
    /// <summary>
    /// Резльутат, возвращаемый клиенту
    /// </summary>
    public abstract class TPPResult
    {
        /// <summary>
        /// Конвертация результата в txt.
        /// </summary>
        /// <returns>The to text.</returns>
        public abstract object ConvertToTXT();

        /// <summary>
        /// Конвертация результата в CSV.
        /// </summary>
        /// <returns>The to tcsv.</returns>
        public abstract object ConvertToTCSV();

        /// <summary>
        /// Конвертация результата в XLSX.
        /// </summary>
        /// <returns>The to xlsx.</returns>
        public abstract object ConvertToXLSX();
    }
}
