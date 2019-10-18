using System.Diagnostics;
using System.Linq;

namespace Universal.Excel
{
    public static class KillExcelProcess
    {
        public static Process[] ExcelProcesses => Process.GetProcessesByName("EXCEL");
        public static Process[] HeadlessExcProcesses = ExcelProcesses.Where(x=> x.MainWindowTitle.Length==0).ToArray();

        public static void KillHeadlessExcelProcesses()
        {
            var processList = HeadlessExcProcesses;

            foreach (var process in processList)
            {
                process.Kill();
            }
        }
    }
}
