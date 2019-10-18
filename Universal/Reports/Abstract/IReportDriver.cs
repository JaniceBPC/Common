using Universal.Excel;
using Microsoft.Office.Interop.Excel;

namespace Universal.Reports
{
    public interface IReportDriver
    {
        void GenerateReport(Workbook excelOperations);
        string TemplateWorkbookName { get;  }
    }
}
