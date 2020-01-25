using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Jbpc.Common.ExtensionMethods;

namespace Jbpc.Common
{
    public static class OutputFile
    {
        public static void Output(string path, char[] text)
        {
            FileInfo fileInfo = new FileInfo(path);

            if (fileInfo.IsFileLocked())
                fileInfo = fileInfo.AvailableFile();

            var streamWriter = new StreamWriter(fileInfo.FullName); ;

            char[] buffer = text.Cast<char>().ToArray();

            streamWriter.Write(buffer);

            streamWriter.Close();
        }
    }
}
