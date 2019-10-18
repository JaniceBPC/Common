using System;

namespace Universal.ExtensionMethods
{
    public static class TempSqlVariableNameGenerator
    {
        public static string Generate(int nth)
        {
            if (nth < 1) throw new ApplicationException($@"{nth} nth parameter cannot be less than 1");
            if (nth > 256) throw new ApplicationException($@"{nth} > More than 256 SqlParameters???");

            int dividend = nth;
            string columnName = "";

            while (dividend > 0)
            {
                var modulo = (dividend - 1) % 26;
                columnName = $"{Convert.ToChar(65 + modulo)}{columnName}";
                dividend = (int)((dividend - modulo) / 26);
            }

            return columnName;
        }
    }
}
