using System;

namespace Universal.Reports
{
    public abstract class AbstractReportGenerator
    {
        protected virtual string TimeHhMm(TimeSpan? timeSpan, string noValueText = "--") => !timeSpan.HasValue ? noValueText : TimeHhMm(timeSpan.Value);
        protected virtual string TimeHhMm(TimeSpan timeSpan) => $"{timeSpan.Hours:#0}:{timeSpan.Minutes:00}";
        protected virtual string F(DateTime v, string format = "yyyy-MM-dd") => v.ToString(format);
        protected virtual string F(DateTime? v, string format = "yyyy-MM-dd", string noValueText = "--") => !v.HasValue ? noValueText : F(v.Value, format);
        protected virtual string F(TimeSpan? v) => !v.HasValue ? "" : F(v.Value);
        protected virtual string F(TimeSpan v) => $"{v.Hours:00}:{v.Minutes:00}:{v.Seconds:00}";
        protected virtual string F(double? v, string format = "F0", string noValueText = "--") => !v.HasValue ? noValueText : F(v.Value, format: format);
        protected virtual string F(double v, string format = "F1") => v.ToString(format);
        protected virtual string F(float? v) => F((double?)v);
        protected virtual string F(float v) => F((double)v);
        protected virtual string F(int? v, string format = "0,#", string noValueText = "--") => !v.HasValue ? noValueText : F(v.Value, format: format);
        protected virtual string F(uint v) => F((int)v);
        protected virtual string F(uint? v) => F((int?)v);
        protected virtual string F(ushort v) => F((int)v);
        protected virtual string F(ushort? v) => F((int?)v);
        protected virtual string F(byte v) => F((int)v);
        protected virtual string F(byte? v) => F((int?)v);
        protected virtual string F(int v, string format = "0,#") => v.ToString(format);
        protected virtual string F(bool v, bool showYes = true, bool showNo = true) => v ? Text("Y", showYes) : Text("N", showNo);
        private string Text(string text, bool flag = true, string noValueText = "--") => !flag ? noValueText : text;
        protected virtual string F(bool? v, string noValueText = "--") => !v.HasValue ? noValueText : v.Value ? "Y" : "N";
    }
}
