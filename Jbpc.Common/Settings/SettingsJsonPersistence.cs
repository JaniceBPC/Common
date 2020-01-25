using Newtonsoft.Json;
using System;
using System.IO;

namespace Jbpc.Common
{
    public class SettingsJsonPersistence<T> where T : class
    {
        private readonly string _filePath;

        public SettingsJsonPersistence(string fileName)
        {
            _filePath = GetLocalFilePath(fileName);
        }

        private string GetLocalFilePath(string fileName)
        {
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            return Path.Combine(appData, fileName);
        }

        public T LoadSettings() =>
            File.Exists(_filePath) ?
                JsonConvert.DeserializeObject<T>(File.ReadAllText(_filePath)) :
                null;

        public void SaveSettings(T settings)
        {
            string json = JsonConvert.SerializeObject(settings);
            File.WriteAllText(_filePath, json);
        }
    }
}
