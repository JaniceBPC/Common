﻿using System.Diagnostics;
using System.IO;

namespace Jbpc.Common
{
    public static class OpenExplorer
    {
        public static void Open(string path)
        {
            Process.Start(new ProcessStartInfo()
            {
                FileName = Path.GetDirectoryName(path),
                UseShellExecute = true,
                Verb = "open"
            });
        }
    }
}
