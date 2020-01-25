using System.IO;

namespace Jbpc.Common.Utilities
{
    public static class GenerateAnAvailablePathName
    {
        public static string Generate(string targetPathName)
        {
            string basePath = targetPathName;
            int i = 0;

            while (true)
            {
                if (!File.Exists(targetPathName))
                    return targetPathName;
                else
                {
                    if (!FileLockCheck.IsFileLocked(targetPathName))
                    {
                        File.Delete(targetPathName);

                        return targetPathName;
                    }
                    else
                        targetPathName = $"{basePath} ({i++})";
                }
            }
        }
    }
}
