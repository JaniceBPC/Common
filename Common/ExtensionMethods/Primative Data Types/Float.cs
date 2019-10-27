using System;
using System.Runtime.InteropServices;

namespace Jbpc.Common.ExtensionMethods
{
    public static class FloatExtensionMethods
    {
        // AlmostEqual2sComplement

        public static bool Equal(float? a, float? b) => !a.HasValue && !b.HasValue || a.HasValue && b.HasValue && Equal(a.Value, b.Value);
        public static bool Equal(float a, float b) => Equal(a, b, 3);
        public static bool Equal(float a, float b, int maxDeltaBits)
        {
            //int aInt = BitConverter.ToInt32(BitConverter.GetBytes(a), 0);
            int aInt = FloatToIntSafeBitConverter.Convert(a);
            if (aInt < 0)
                aInt = Int32.MinValue - aInt;  // Int32.MinValue = 0x80000000

            int bInt = FloatToIntSafeBitConverter.Convert(b);
            if (bInt < 0)
                bInt = Int32.MinValue - bInt;

            int intDiff = Math.Abs(aInt - bInt);

            return intDiff <= (1 << maxDeltaBits);
        }
        [StructLayout(LayoutKind.Explicit)]
        struct FloatToIntSafeBitConverter
        {
            public static int Convert(float value) => new FloatToIntSafeBitConverter(value).IntValue;
            public FloatToIntSafeBitConverter(float floatValue) : this()
            {
                FloatValue = floatValue;
            }
            [FieldOffset(0)]
            public readonly int IntValue;
            [FieldOffset(0)]
            public readonly float FloatValue;
        }
    }

}
