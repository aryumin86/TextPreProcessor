using System;
using System.Collections.Generic;
using System.Text;

namespace TPPLib.TPPResults
{
    public class TermTextMatrixResult<T> : TPPResult where T: struct
    {
        /// <summary>
        /// Term-text матрица, из которой будет сформирован файл.
        /// </summary>
        private TermTextMatrix<T> _ttm;

        /// <summary>
        /// Разделитель столбцов в CSV.
        /// </summary>
        private char _delimeter;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ttm"></param>
        /// <param name="delimeter"></param>
        /// <param name="removeTooSparceLines"></param>
        /// <param name="removeTooSparceTermsVectors"></param>
        public TermTextMatrixResult(TermTextMatrix<T> ttm, char delimeter, 
            bool removeTooSparceLines = false, bool removeTooSparceTermsVectors = false) : base()
        {
            this._ttm = ttm;
            this._delimeter = delimeter;
        }

        public override string ConvertToTCSV()
        {
            StringBuilder sb = new StringBuilder();

            for(int row = 0; row < this._ttm.textsIds.Count; row++)
            {
                //делаем шапку
                if (row == 0)
                {
                    sb.Append(_delimeter);
                    for (int column = 0; column < this._ttm.words.Count; column++)
                    {
                        if (row == 0)                        {

                            sb.Append(_ttm.words[column].Key);
                            sb.Append(_delimeter);
                        }
                    }
                    sb.Append(Environment.NewLine);
                }

                sb.Append(this._ttm.textsIds[row]);

                for (int column = 0; column < this._ttm.words.Count; column++)
                {
                    sb.Append(_delimeter);
                    sb.Append(this._ttm.Matrix[row,column]);
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Удаление из матрицы строк, в которых сумма встречаимостей любых
        /// термов меньше аргумента min.
        /// </summary>
        /// <param name="min">Minimum.</param>
        private void RemoveTooSparseLines(int min){
            throw new NotImplementedException();
        }

        /// <summary>
        /// Удаление из матрицы столбцов (термов), встречамость которых (сумма по столбцу)
        /// ниже значения аргумента min.
        /// </summary>
        /// <param name="min">Minimum.</param>
        private void RemoveTooSparceVectors(int min){
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
