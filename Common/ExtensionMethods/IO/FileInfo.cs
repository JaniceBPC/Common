using System.IO;

namespace Jbpc.Common.ExtensionMethods
{
    public static class FileInfoExtensionMethods
    {
        public static bool IsFileLocked(this FileInfo file)
        {
            FileStream stream = null;

            if (!file.Exists) return false;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            return false;
        }
        public static FileInfo AvailableFile(this FileInfo fileInfo)
        {
            if (!fileInfo.Exists || !fileInfo.IsFileLocked())
                return fileInfo;
            else
            {
                int i = 1;
                string extension = Path.GetExtension(fileInfo.FullName);
                string fileName = fileInfo.Name.Replace(extension, "");

                do
                {
                    string fileNameVariant = Path.Combine(fileInfo.DirectoryName, $"{fileName} ({i++}){extension}");

                    fileInfo = new FileInfo(fileNameVariant);
                } while (fileInfo.Exists && fileInfo.IsFileLocked());

                return fileInfo;
            }
        }

    }
}

