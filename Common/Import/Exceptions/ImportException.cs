using System;

namespace Jbpc.Common.Import
{
    public class ImportException 
    {
        public ImportException(string message) 
        {
            this.LogMessage = message;
        }
        public bool IsLogAndContinue { get; set; } = true;
        public string LogMessage { get; set; } = "";
        public override string ToString() => $"Message={LogMessage}";
    }
}
