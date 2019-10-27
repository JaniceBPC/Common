using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using Microsoft.Office.Interop.Excel;

namespace Jbpc.Common.ExtensionMethods.Sql
{
    public static class SqlCommandExtensionMethods
    {
        public static void Append(this SqlCommand c, long v) => c.Parameters.Add(ParameterName(c), SqlDbType.BigInt).Value = v;
        public static void Append(this SqlCommand c, int v) => c.Parameters.Add(ParameterName(c), SqlDbType.Int).Value = v;
        public static void Append(this SqlCommand c, uint v) => c.Parameters.Add(ParameterName(c), SqlDbType.Int).Value = v;
        public static void Append(this SqlCommand c, short v) => c.Parameters.Add(ParameterName(c), SqlDbType.SmallInt).Value = v;
        public static void Append(this SqlCommand c, ushort v) => c.Parameters.Add(ParameterName(c), SqlDbType.SmallInt).Value = UShortToInt16(v);
        public static void Append(this SqlCommand c, byte v) => c.Parameters.Add(ParameterName(c), SqlDbType.TinyInt).Value = v;
        public static void Append(this SqlCommand c, bool v) => c.Parameters.Add(ParameterName(c), SqlDbType.Bit).Value = v;
        public static void Append(this SqlCommand c, float v) => c.Parameters.Add(ParameterName(c), SqlDbType.Real).Value = v;
        public static void Append(this SqlCommand c, double v) => c.Parameters.Add(ParameterName(c), SqlDbType.Float).Value = v;
        public static void Append(this SqlCommand c, TimeSpan v) => c.Parameters.Add(ParameterName(c), SqlDbType.BigInt).Value = v.Ticks;
        public static void Append(this SqlCommand c, DateTime v) => c.Parameters.Add(ParameterName(c), SqlDbType.DateTime).Value = v;

        public static void Append(this SqlCommand command, long? v)
        {
            command.Parameters.Add(ParameterName(command), SqlDbType.BigInt).Value = v.HasValue ? v.Value : (object)DBNull.Value;
        }
        public static void Append(this SqlCommand command, int? v)
        {
            command.Parameters.Add(ParameterName(command), SqlDbType.Int).Value = v.HasValue ? v.Value : (object)DBNull.Value;
        }
        public static void Append(this SqlCommand command, uint? v)
        {
            command.Parameters.Add(ParameterName(command), SqlDbType.Int).Value = v.HasValue ? v.Value : (object)DBNull.Value;
        }
        public static void Append(this SqlCommand command, ushort? v)
        {
            command.Parameters.Add(ParameterName(command), SqlDbType.SmallInt).Value = v.HasValue ? UShortToInt16(v.Value) : (object)DBNull.Value;
        }
        public static void Append(this SqlCommand command, float? v)
        {
            command.Parameters.Add(ParameterName(command), SqlDbType.Real).Value = v.HasValue ? v.Value : (object)DBNull.Value;
        }
        public static void Append(this SqlCommand command, double? v)
        {
            command.Parameters.Add(ParameterName(command), SqlDbType.Float).Value = v.HasValue ? v.Value : (object)DBNull.Value;
        }
        public static void Append(this SqlCommand command, bool? v)
        {
            command.Parameters.Add(ParameterName(command), SqlDbType.Bit).Value = v.HasValue ? v.Value : (object)DBNull.Value;
        }
        public static void Append(this SqlCommand c, DateTime? v)
        {
            c.Parameters.Add(ParameterName(c), SqlDbType.Bit).Value = v.HasValue ? v.Value : (object)DBNull.Value;
        }
        public static void Append(this SqlCommand command, TimeSpan? v)
        {
            command.Parameters.Add(ParameterName(command), SqlDbType.BigInt).Value = v.HasValue ? v.Value.Ticks : (object)DBNull.Value;
        }
        public static void AppendTimeSpanInSeconds(this SqlCommand command, TimeSpan? v)
        {
            if (!v.HasValue)
            {
                command.Parameters.Add(ParameterName(command), SqlDbType.Int).Value = (object)DBNull.Value;

                return;
            }
            var value = v.Value.Ticks / TimeSpan.TicksPerSecond;

            command.Parameters.Add(ParameterName(command), SqlDbType.Int).Value = value;
        }
        private static Int16 UShortToInt16(ushort value)
        {
            return BitConverter.ToInt16(BitConverter.GetBytes(value), 0);
        }
        public static void Append(this SqlCommand command, string value, int maxLength, bool truncate = false, bool blankOk = true)
        {
            if (value == null)
            {
                command.Parameters.Add(ParameterName(command), SqlDbType.Char).Value = (object)DBNull.Value;
                return;
            }

            value = value.Trim();

            if (value == "" && !blankOk) throw new ApplicationException($"Text for {ParameterName(command)} is Blank");

            if (value.Length > maxLength && !truncate) throw new ApplicationException($"Text for {ParameterName(command)} length={value.Length} is greater than {maxLength}");

            if (value.Length > maxLength)
            {
                command.Parameters.Add(ParameterName(command), SqlDbType.Char).Value = new String(value.Take(maxLength).ToArray());

                return;
            }
            command.Parameters.Add(ParameterName(command), SqlDbType.Char).Value = value;
        }
        private static string ParameterName(SqlCommand command) => $"@{Q(command.Parameters.Count)}";
        private static string Q(int nth) => TempSqlVariableNameGenerator.Generate(nth+1);
        public static string PrettyPrint(this SqlCommand command, List<string> fieldNames)
        {
            var parameters = command.Parameters;

            var list = new List<SqlParameter>();

            for (int i = 0; i < parameters.Count; i++)
            {
                list.Add(parameters[i]);
            }

            var zip = list.Zip(Enumerable.Range(1, list.Count), (x, y) => new {Nth = y, Parameter = x.PrettyPrint(y>=fieldNames.Count ? "n/a" : fieldNames[y - 1]) })
                .ToList();

            return string.Join($"{Environment.NewLine}", zip.Select(x => $"{x.Nth}) {x.Parameter}"));
        }
    }
}
