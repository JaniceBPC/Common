﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Jbpc.Common.Utilities
{
    public static class FileLockCheck
    {
        public static bool IsFileLocked(string filePath)
        {
            try
            {
                using var fileStream = File.Open(filePath, FileMode.Open);

                fileStream.DisposeAsync();
            }
            catch (IOException e)
            {
                var errorCode = Marshal.GetHRForException(e) & ((1 << 16) - 1);

                return errorCode == 32 || errorCode == 33;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"File lock check failed for={filePath}", ex);
            }

            return false;
        }
    }
}
