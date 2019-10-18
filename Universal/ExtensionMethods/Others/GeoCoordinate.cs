using System;

namespace Universal.ExtensionMethods
{
    using Universal.GeoCoordinates;

    public static class GeoCoordinateExtensionMethods
    {
        public static double FEET_PER_METER = 3.28084;

        public static int GetDistanceToInFeet(this GeoCoordinate a, GeoCoordinate b)
        {
            var meters = a.GetDistanceTo(b);

            return (int)Math.Round(meters * FEET_PER_METER);
        }
    }
}
