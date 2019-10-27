using System;
using Jbpc.Common.GeoCoordinates;

namespace Jbpc.Common.ExtensionMethods
{
    using Common.GeoCoordinates;

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
