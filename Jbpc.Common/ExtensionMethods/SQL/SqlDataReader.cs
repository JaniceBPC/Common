using System;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Jbpc.Common.ExtensionMethods.Sql
{
    public static class SqlDataReaderExtensionMethods
    {
        public static long Long(this SqlDataReader reader, string fieldName)
        {
            if (reader.IsDbNull(fieldName)) return default(long);

            return (long)reader[fieldName];
        }
        public static long? NullableLong(this SqlDataReader reader, string fieldName)
        {
            if (reader.IsDbNull(fieldName)) return null;

            return (long)reader[fieldName];
        }

        public static int Int(this SqlDataReader reader, string fieldName)
        {
            if (reader.IsDbNull(fieldName)) return default(int);

            return reader.ConvertType<int>(fieldName);
        }
        public static int? NullableInt(this SqlDataReader reader, string fieldName)
        {
            if (reader.IsDbNull(fieldName)) return null;

            return reader.ConvertType<int>(fieldName);
        }
        public static uint? NullableUInt(this SqlDataReader reader, string fieldName)
        {
            if (reader.IsDbNull(fieldName)) return null;

            return reader.ConvertType<uint>(fieldName);
        }
        public static uint UInt(this SqlDataReader reader, string fieldName)
        {
            if (reader.IsDbNull(fieldName)) return default(uint);

            return reader.ConvertType<uint>(fieldName);
        }
        public static short? NullableShort(this SqlDataReader reader, string fieldName)
        {
            if (reader.IsDbNull(fieldName)) return null;

            return reader.ConvertType<short>(fieldName);
        }
        public static short Short(this SqlDataReader reader, string fieldName)
        {
            if (reader.IsDbNull(fieldName)) return default(short);

            return reader.ConvertType<short>(fieldName);
        }
        public static ushort? NullableUShort(this SqlDataReader reader, string fieldName)
        {
            if (reader.IsDbNull(fieldName)) return null;

            return reader.ConvertUShort(fieldName);
        }
        public static ushort UShort(this SqlDataReader reader, string fieldName)
        {
            if (reader.IsDbNull(fieldName)) return default(ushort);

            return reader.ConvertUShort(fieldName);
        }
        public static byte? NullableByte(this SqlDataReader reader, string fieldName)
        {
            if (reader.IsDbNull(fieldName)) return null;

            return reader.ConvertType<byte>(fieldName);
        }
        public static byte Byte(this SqlDataReader reader, string fieldName)
        {
            if (reader.IsDbNull(fieldName)) return default(byte);

            return reader.ConvertType<byte>(fieldName);
        }
        public static bool Bool(this SqlDataReader reader, string fieldName)
        {
            if (reader.IsDbNull(fieldName)) return default(bool);

            return reader.ConvertType<bool>(fieldName);
        }

        public static float? NullableFloat(this SqlDataReader reader, string fieldName)
        {
            if (reader.IsDbNull(fieldName)) return null;

            return reader.ConvertType<float>(fieldName);
        }
        public static float Float(this SqlDataReader reader, string fieldName)
        {
            if (reader.IsDbNull(fieldName)) return default(float);

            return reader.ConvertType<float>(fieldName);
        }
        public static double? NullableDouble(this SqlDataReader reader, string fieldName)
        {
            if (reader.IsDbNull(fieldName)) return null;

            return reader.ConvertType<double>(fieldName);
        }
        public static bool? NullableBool(this SqlDataReader reader, string fieldName)
        {
            if (reader.IsDbNull(fieldName)) return null;

            return reader.ConvertType<bool>(fieldName);
        }
        public static double Double(this SqlDataReader reader, string fieldName)
        {
            if (reader.IsDbNull(fieldName)) return default(double);

            return reader.ConvertType<double>(fieldName);
        }
        public static string String(this SqlDataReader reader, string fieldName)
        {
            if (reader.IsDbNull(fieldName)) return default(string);

            return reader.ToString(fieldName).Trim();
        }
        public static DateTime DateTime(this SqlDataReader reader, string fieldName)
        {
            if (reader.IsDbNull(fieldName)) return default(DateTime);

            return reader.ConvertType<DateTime>(fieldName);
        }
        public static DateTime? NullableDateTime(this SqlDataReader reader, string fieldName)
        {
            if (reader.IsDbNull(fieldName)) return null;

            return reader.ConvertType<DateTime>(fieldName);
        }
        public static TimeSpan NullableTimeSpan(this SqlDataReader reader, string fieldName)
        {
            if (reader.IsDbNull(fieldName)) return default(TimeSpan);

            return TimeSpan.FromTicks(reader.ConvertType<long>(fieldName));
        }
        public static TimeSpan NullableTimeSpanInSeconds(this SqlDataReader reader, string fieldName)
        {
            if (reader.IsDbNull(fieldName)) return default(TimeSpan);

            var seconds = reader.ConvertType<uint>(fieldName);

            return TimeSpan.FromTicks(seconds*TimeSpan.TicksPerSecond);
        }
        public static TimeSpan? TimeSpanNullable(this SqlDataReader reader, string fieldName)
        {
            if (reader.IsDbNull(fieldName)) return null;

            return new TimeSpan(reader.ConvertType<long>(fieldName));
        }

        public static T ConvertType<T>(this SqlDataReader reader, string fieldName) => (T)Convert.ChangeType(reader[fieldName], typeof(T));
        public static string ToString(this SqlDataReader reader, string fieldName) => reader[fieldName].ToString();
        public static bool IsDbNull(this SqlDataReader reader, string fieldName) => DBNull.Value.Equals(reader[fieldName]);
        public static ushort ConvertUShort(this SqlDataReader reader, string fieldName)
        {
            short value = Convert.ToInt16(reader[fieldName]);

            return value <0 ? ushort.MaxValue : (ushort) value;
        }
    }
}
