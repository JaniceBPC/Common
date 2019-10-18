using Microsoft.Office.Interop.Excel;

namespace Universal.ExtensionMethods
{
    public static class WorksheetExtensionMethods
    {
        public static Range RangeForCell(this Worksheet worksheet, int nthRow, int nthCol)
        {
            return worksheet.Cells[nthRow, nthCol] as Range;
        }
    }
}
