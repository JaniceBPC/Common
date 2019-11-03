using System.Drawing.Drawing2D;

namespace Jbpc.Common.Reports
{
    public class ValuesGrid 
    {
        public ValuesGrid(int numRows, int numColumns)
        {
            Values = new object[numRows, numColumns];
        }
        public int NthRow { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1044:Properties should not be write only", Justification = "<Pending>")]
        public object this[int nthColumn]
        {
            set => SetValue(nthColumn, value);
        }
        public void SetValue(int nthColumn, object value)
        {
            if (nthColumn>=Values.GetLength(1)) System.Diagnostics.Debugger.Break();

            Values[NthRow, nthColumn] = value;
        }
        public object[,] Values { get; }
        public int Columns => Values.GetLength(1);
        public int Rows => Values.GetLength(0);
        public bool Any() => Rows > 0;
        public override string ToString() => $"Values grid, rows={Rows}, cols={Columns}";
    }

}

