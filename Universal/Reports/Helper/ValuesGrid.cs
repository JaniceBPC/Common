using System.Drawing.Drawing2D;

namespace Universal.Reports
{
    public class ValuesGrid 
    {
        private object[,] matrix;
        public ValuesGrid(int numRows, int numColumns)
        {
            matrix = new object[numRows, numColumns];
        }
        public int NthRow { get; set; }
        public object this[int nthColumn]
        {
            set => SetValue(nthColumn, value);
        }
        public void SetValue(int nthColumn, object value)
        {
            if (nthColumn>=matrix.GetLength(1)) System.Diagnostics.Debugger.Break();

            matrix[NthRow, nthColumn] = value;
        }
        public object[,] Values => matrix;
        public int Columns => matrix.GetLength(1);
        public int Rows => matrix.GetLength(0);
        public bool Any() => Rows > 0;
        public override string ToString() => $"Values grid, rows={Rows}, cols={Columns}";
    }

}

