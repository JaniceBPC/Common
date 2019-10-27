using System;
using System.Threading.Tasks;
using Jbpc.Common.Excel;

namespace Jbpc.Common.Reports
{
    public static class ReportDispatcher
    {
        public static void DispatchReport(IReportDriver reportDriver, bool visible = true)
        {
            Before(visible);

            try
            {
                var workbook = ExcelOperations.OpenReportWorkbook(reportDriver.TemplateWorkbookName);

                ExcelOperations.PerformWithLock(() => reportDriver.GenerateReport(workbook));
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error trapped while generating report {reportDriver.GetType().Name}", ex);
            }

            After(visible);
        }
        public static void DispatchReport(Action generateReport, bool visible = true)
        {
            ; Before(visible);

            try
            {
                ExcelOperations.PerformWithLock(generateReport);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error trapped while generating report", ex);
            }

            After(visible);
        }
        public static async Task DispatchReportAsync(IReportDriver reportDriver, bool visible = true)
        {
            Before(visible);

            try
            {
                var workbook = ExcelOperations.OpenReportWorkbook(reportDriver.TemplateWorkbookName);
                
                await Task.Run(() => ExcelOperations.PerformWithLock(() => reportDriver.GenerateReport(workbook)));
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error trapped while generating report {reportDriver.GetType().Name}", ex);
            }

            After(visible);
        }
        public static async Task DispatchReportAsync(Action generateReport, bool visible = true)
        {
;           Before(visible);

            try
            {
                await Task.Run(() => ExcelOperations.PerformWithLock( generateReport));
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error trapped while generating report", ex);
            }

            After(visible);
        }
        private static void Before(bool visible)
        {
            ExcelOperations.MakeWorkbookVisible(visible);
            ExcelOperations.ScreenUpdating(false);
            ExcelOperations.DisplayAlerts(false);
        }
        private static void After(bool visible)
        {
            ExcelOperations.MakeWorkbookVisible(visible);
            ExcelOperations.ScreenUpdating(true);
            ExcelOperations.DisplayAlerts(true);
        }
    }
}
