using System;
using System.Text;
using TPPLib.TextsImporters;
using Xunit;
using System.Linq;

namespace TTPLibTests
{
    public class TextsImporterTests
    {
        /// <summary>
        /// Нерекурсивная загрузка txt из диретории.
        /// </summary>
        [Fact]
        [Trait("Category", "Unit")]
        public void Importer_NonRecursively_Correctly_Imports_From_Txt()
        {
            string filesDir = "../../../some_texts";
            var importer = new TXTImporter();
            var texts = importer.ImportTexts(filesDir, Encoding.UTF8);

            Assert.True(texts.Count() > 2);
        }

        /// <summary>
        /// Импорт из XLSX.
        /// </summary>
        [Fact]
        [Trait("Category", "Unit")]
        public void Importer_Correctly_Imports_From_XLSX()
        {

        }
    }
}
