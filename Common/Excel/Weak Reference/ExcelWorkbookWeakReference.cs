using Microsoft.Office.Interop.Excel;
using System;

namespace Jbpc.Common.Excel
{
    public class ExcelWorkbookWeakReference : IDisposable
    {
        public bool IsAlreadyOpened { get; set; }
        public Workbook Workbook { get; set;  }
        public string WorkbookName { get; set;  }
        public string Path { get; set; }
        public void Dispose()
        {
            if (!IsAlreadyOpened && Workbook != null)
            {
                Workbook.Close();
            }
        }
    }
}
