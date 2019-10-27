using System;
using System.IO;
using System.Reflection;

namespace Jbpc.Common
{
    public static class BuildTime
    {
        public static DateTime GetDateTime()
        {
            var entryAssembly = Assembly.GetEntryAssembly();
            var fileInfo = new FileInfo(entryAssembly.Location);

            return fileInfo.LastWriteTime;
        }
    }
}
