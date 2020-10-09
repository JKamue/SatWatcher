using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatWatcher.Calculators
{
    class CoordinateCalculator
    {
        private readonly Size _size;

        public CoordinateCalculator(Size size)
        {
            _size = size;
        }

        public PointF MapPoint(PointF p) => new PointF(MapLatitude(p.X), MapLongitude(p.Y));

        public float MapLongitude(float lng) => Map(lng, 90, -90, 0, _size.Height);

        public float MapLatitude(float lat) => Map(lat, -180, 180, 0, _size.Width);

        public static float Map(float value, float fromSource, float toSource, float fromTarget, float toTarget)
        {
            return (value - fromSource) / (toSource - fromSource) * (toTarget - fromTarget) + fromTarget;
        }
    }
}
