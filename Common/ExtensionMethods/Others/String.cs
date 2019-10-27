using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Jbpc.Common.ExtensionMethods
{
    public static class StringExtensionMethods
    {
        public static string RemoveWhiteSpace(this string text) => new string(text.Where(x=> !char.IsWhiteSpace(x)).ToArray());
        public static string Repeat(this string s, int n)
        {
            return new String(Enumerable.Range(0, n).SelectMany(x => s).ToArray());
        }
        public static bool IsEmpty(this string str) => string.IsNullOrEmpty(str);
        public static List<string> SplitCommaSeparatedElements(this string inputText)
        {
            inputText = inputText.Trim();

            if (inputText == "")
            {
                return new List<string>();
            }

            var elements = inputText.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            return elements.Select(x => x.Trim()).ToList();
        }
        public static string Repeat(this char c, int n)
        {
            return new String(c, n);
        }
        public static string TidyUpName(this string name) => name.Trim().Replace("  ", " ");
        private static string M(IEnumerable<char> v) => new String(v.ToArray());

        public static string SplitCamelCaseToWords(this string camelCase)
        {
            var sb = new StringBuilder();

            sb.Append($"{camelCase[0]}");

            for (int i = 1; i < camelCase.Length-1; i++)
            {
                if (IsInsertBlankHere(camelCase[i - 1], camelCase[i], camelCase[i + 1]))
                {
                    sb.Append(" ");
                }

                sb.Append($"{camelCase[i]}");
            }

            sb.Append($"{camelCase[camelCase.Length - 1]}");

            return sb.ToString();
        }
        private static bool IsInsertBlankHere(char previous, char cursor, char next)
        {
            if (cursor == ' ') return true;

            if (char.IsLower(previous) && !char.IsLower(cursor)) return true;

            if (char.IsUpper(previous) && char.IsUpper(cursor) && char.IsLower(next)) return true;

            if (char.IsLetter(previous) && !char.IsLetter(cursor)) return true;

            if (!char.IsLetter(previous) && char.IsLetter(cursor)) return true;

            return false;
        }
        public static bool IsYes(this string text)
        {
            text = text.ToUpper();

            return text == "YES" || text == "Y";
        }
        public static bool IsNo(this string text)
        {
            text = text.ToUpper();

            return text == "NO" || text == "N";
        }
        public static bool IsValidWebHexColorCode(this string text)
        {
            if (text.Length != 5 || text.Length != 7) return false;
            if (text[0] != '#') return false;

            var ok = new String(text.ToUpper().ToList().SkipNext().ToArray());

            if (!System.Text.RegularExpressions.Regex.IsMatch(text, "[0-9|A-F]+")) return false;

            return true;
        }
        public static string [] Lines(this string text) => text.Split(new[] { $"n\r", $"{Environment.NewLine}" }, StringSplitOptions.RemoveEmptyEntries);
        public static int FromHex(string value)
        {
            if (value.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
            {
                value = value.Substring(2);
            }
            return int.Parse(value, NumberStyles.HexNumber);
        }
        //public static string SplitCamelCase(this string input)
        //{
        //    return Regex.Replace(input, @"((?<=[A-Z])([A-Z])(?=[a-z]))|((?<=[a-z]+)([A-Z]))", @" $0", RegexOptions.Compiled).Trim();
        //}

    }
}
