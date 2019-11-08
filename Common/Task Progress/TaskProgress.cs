using System;
using Jbpc.Common.ExtensionMethods;

namespace Jbpc.Common
{
    public class TaskProgress
    {
        public static TaskProgress  ReportPhase(string name) => new TaskProgress(name);
        public TaskProgress() { }
        public TaskProgress(string name)
        {
            Name = name;
        }
        public TimeSpan? TimeToCompleteStep { get; set; }
        public string Name { get;  set; }
        public string PhaseName { get; set; } = "";
        public bool IsCanceled { get; set; }
        public Exception Exception { get; set; }
        public double? PercentComplete { get; set; }
        public int? Phase { get; set; }
        public int? NumberOfPhases { get; set; }
        public void Reset()
        {
            PhaseName = "";
            Phase = null;
            NumberOfPhases = null;
            PercentComplete = null;
        }
        private string DebugPrintString => ToString();
        public override string ToString()
        {
            if (IsCanceled) return $"Canceled - {Name}";

            var msg = Name;

            if (TimeToCompleteStep.HasValue) return $"Completed {Name}, {TimeToCompleteStep.Value.SmartFormat()}";

            if (PhaseName == "") return msg;

            msg = $"{msg} - {PhaseName}";

            if (!Phase.HasValue || !NumberOfPhases.HasValue) return msg;

            msg = $"{msg} ({Phase.Value} of {NumberOfPhases.Value})";

            if (!PercentComplete.HasValue) return msg;

            msg = $"{msg}, {PercentComplete.Value:F0}% Complete";

            return msg;
        }
    }
}
