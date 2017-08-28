using System;
using System.Text.RegularExpressions;

namespace TTPLibTests
{
    public class BasicTextsCleanerTests
    {
        /// <summary>
        /// Удаление задвоенных /затроенных и пр. пробелов и trim всей строки.
        /// </summary>
        /// <param name="raw"></param>
        /// <returns></returns>
        public string RemoveDoubleSpacesAndTrim(string raw)
        {
            return Regex.Replace(raw, @"\s+", " ").Trim();
        }
    }
}
