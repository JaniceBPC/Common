using System.Collections.Generic;
using Jbpc.Common.Excel;
using Jbpc.Common.Excel.ExtensionMethods;
using Jbpc.Common.Reports;
using Jbpc.Common.ExtensionMethods;
using Microsoft.Office.Interop.Excel;

namespace Jbpc.Common.Import
{
    public class ImportReport
    {
        private readonly string workbookFileName;
        private readonly string worksheetName;
        public ImportReport(string workbookFileName, string worksheetName)
        {
            this.workbookFileName = workbookFileName;
            this.worksheetName = worksheetName;
        }
        public void GenerateReport(List<IObjectImportResult> importResults)
        {
            using (var weakReference = ExcelWorkbookWeakReferenceFactory.Instantiate(workbookFileName))
            {
                GenerateReport(weakReference.Workbook, importResults);
            }
        }
        private void GenerateReport(Workbook sourceWorkbook, List<IObjectImportResult> importResults)
        {
            var worksheet = ReportWorksheet(sourceWorkbook);

            var workbook = (Workbook) worksheet.Parent;

            var usedRange = worksheet.UsedRange;

            var rngMessagesGrid = usedRange.DisplaceAndResize(1, usedRange.Columns.Count, usedRange.Rows.Count - 1, colWidth: 1);

            var a = $"{workbook.Name}.{worksheet.Name}";
            var q = rngMessagesGrid.A1_A1();

            var valuesGrid = new ValuesGrid(importResults.Count, 1);

            for (int i = 0; i < importResults.Count; i++)
            {
                valuesGrid[0] = importResults[i].ValidationResultCollection.ToString();

                valuesGrid.NthRow++;
            }

            workbook.DisplayGridlines(false);

            SetReportGrid.SetGrid(rngMessagesGrid, valuesGrid);

            rngMessagesGrid.EntireColumn.ColumnWidth = 40;
            rngMessagesGrid.HorizontalAlignment = XlHAlign.xlHAlignLeft;

            rngMessagesGrid.FormatGrid();
            rngMessagesGrid.ApplyAutoFilterToReportBlock();
            worksheet.Rows.AutoFit();

            rngMessagesGrid.DisplaceAndResize(-1).SetHeadingColumnName("Valuation Results");
        }
        private Worksheet ReportWorksheet(Workbook sourceWorkbook)
        {
            var worksheet = sourceWorkbook.GetWorksheet(worksheetName);

            var workbook = ExcelOperations.NewWorkbook;

            return worksheet.CreateCopyInWorkbook(workbook);
        }
    }
}
