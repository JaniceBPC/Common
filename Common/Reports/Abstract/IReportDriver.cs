using Jbpc.Common.Excel;
using Microsoft.Office.Interop.Excel;

namespace Jbpc.Common.Reports
{
    public interface IReportDriver
    {
        void GenerateReport(Workbook excelOperations);
        string TemplateWorkbookName { get;  }
    }
}
