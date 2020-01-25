using Jbpc.Common.Excel.ExtensionMethods;
using Microsoft.Office.Interop.Excel;

namespace Jbpc.Common.Reports
{
    public static class SetReportGrid
    {
        public static void SetGrid(Range rngHome, ValuesGrid valuesGrid, int? gridColumns = null, bool formatGrid = true, bool applyFlter = true, bool force = false )
        {
            if (!valuesGrid.Any()) return;

            var msg = rngHome.A1_A1();

            var rngGrid = rngHome.get_Resize(valuesGrid.Rows, valuesGrid.Columns);

            msg = rngGrid.A1_A1();

            rngGrid.Value2 = valuesGrid.Values;

            rngGrid = rngHome.get_Resize(valuesGrid.Rows, gridColumns.HasValue ? gridColumns : valuesGrid.Columns);

            msg = rngGrid.A1_A1();

            if ((valuesGrid.Rows < 10000 || force) && formatGrid)
            {
                rngGrid.FormatGrid();
            }
            if (applyFlter)
            {
                rngGrid.ApplyAutoFilterToReportBlock();
            }
        }
    }
}
