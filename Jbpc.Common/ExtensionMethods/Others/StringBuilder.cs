using System;
using System.Text;

namespace Jbpc.Common.ExtensionMethods
{
    public static class StringBuilderExtensionMethods
    {
        public static void AppendSectionBreak(this StringBuilder sb, string repeatText= "-", int timesRepeat = 128, int blankLinesBefore = 2, int blankLinesAfter = 1)
        {
            for (var i = 0; i < blankLinesBefore; i++)
            {
                sb.AppendLine();
            }
            sb.AppendLine($"{Environment.NewLine}{repeatText.Repeat(timesRepeat)})");

            for (var i = 0; i < blankLinesAfter; i++)
            {
                sb.AppendLine();
            }
        }

    }
}