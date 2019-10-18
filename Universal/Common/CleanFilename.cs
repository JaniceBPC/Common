using System.Linq;

namespace Universal
{
    public static class CleanFilename
    {
        public static string Clean(string fileName)
        {
            if (fileName == "") return "";

            var cleanFileNameChars = fileName.Replace("\\\\", "\\")
                .SkipWhile(x => fileName.Contains("$") && x != '$')
                .SkipWhile(x => x != '\\')
                .Skip(1)
                .ToArray();

            var cleanFileName =new string(cleanFileNameChars).Replace("\\","\\");

            return cleanFileName;
        }
    }
}
