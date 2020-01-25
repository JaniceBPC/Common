using Jbpc.Common.Excel;
using Microsoft.Office.Interop.Excel;

namespace Jbpc.Common.Reports
{
    public abstract class AbstractReportDriver : IReportDriver
    {
        public virtual string TemplateWorkbookName => "Blank Template.xlsx";
        public abstract void GenerateReport(Workbook workbook);
    }
}
