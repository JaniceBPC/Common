using Universal.ExtensionMethods;
using System;

namespace Universal.Excel
{
    using Microsoft.Office.Interop.Excel;

    public static class WorksheetUsedRange
    {
        public static Range GetUsedWorksheetRange(Workbook workbook, string worksheetName = null)
        {
            worksheetName = worksheetName ?? workbook.LastWorksheet().Name;

            var worksheet = workbook.GetWorksheet(worksheetName);

            if (worksheet == null) throw new ApplicationException($"Failed to open worksheet={worksheetName}, in workbook={worksheetName}");

            var range = worksheet.UsedRange;

            return range;
        }

    }
}
