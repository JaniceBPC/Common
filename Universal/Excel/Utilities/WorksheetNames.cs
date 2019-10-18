using System;
using System.Collections.Generic;
using Universal.ExtensionMethods;

namespace Universal.Excel
{
    public static class WorksheetNames
    {
        public static List<string> Names(string workbookFilename)
        {
            if (workbookFilename == null)
            {
                throw new ApplicationException($"Open workbook - workbook name is null: {workbookFilename}");
            }
            var workbook = ExcelOperations.OpenWorkbookWithRetry(workbookFilename);

            return workbook.WorksheetNames();
        }
    }
}
