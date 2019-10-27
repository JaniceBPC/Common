using System;

namespace Jbpc.Common.Import
{
    public class ImportException : ApplicationException
    {
        public ImportException(string message) : base(message)
        {
            this.LogMessage = message;
        }
        public bool IsLogAndContinue { get; set; } = true;
        public string LogMessage { get; set; } = "";
        public override string ToString() => $"Message={LogMessage}";
    }
}
