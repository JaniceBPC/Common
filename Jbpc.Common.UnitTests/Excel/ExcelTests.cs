using Jbpc.Common.Excel;
using NUnit.Framework;

namespace Jbpc.Common.UnitTests.Excel
{
    [TestFixture]
    public class ExcelTests
    {
        [Test]
        public void ExpandedTypeName_SimpleType()
        {
            var workbook = ExcelOperations.NewWorkbook;

            Assert.NotNull(workbook);
        }
        [Test]
        public void Net_Std()
        {
            var workbook = Office.Class1.Application;

            Assert.NotNull(workbook);
        }
    }
}
