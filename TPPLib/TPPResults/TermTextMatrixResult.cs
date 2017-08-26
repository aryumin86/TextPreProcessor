using System;
using System.Collections.Generic;

namespace TPPLib.TPPResults
{
    public class TermTextMatrixResult : TPPResult
    {
        List<string> terms = new List<string>();

        public override object ConvertToTCSV()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Удаление из матрицы строк, в которых сумма встречаимостей любых
        /// термов меньше аргумента min.
        /// </summary>
        /// <param name="min">Minimum.</param>
        public void RemoveTooSparseLines(int min){
            throw new NotImplementedException();
        }

        /// <summary>
        /// Удаление из матрицы столбцов (термов), встречамость которых (сумма по столбцу)
        /// ниже значения аргумента min.
        /// </summary>
        /// <param name="min">Minimum.</param>
        public void RemoveTooSparceVectors(int min){
            throw new NotImplementedException();
        }

        public override object ConvertToTXT()
        {
            throw new NotImplementedException();
        }

        public override object ConvertToXLSX()
        {
            throw new NotImplementedException();
        }
    }
}
