using System;
using System.Collections.Generic;
using System.Drawing;
using One_Sgp4;
using SatWatcher.Calculators;

namespace SatWatcher.Satellites
{
    public class Satellite
    {
        public readonly long ID;
        public readonly string Name;
        public readonly Tle Tle;
        public readonly string TleLine1;
        public readonly string TleLine2;

        public Satellite(long id, string name, string line1, string line2)
        {
            ID = id;
            Name = name;
            TleLine1 = line1;
            TleLine2 = line2;
            Tle = ParserTLE.parseTle(
                line1,
                line2,
                name);
        }

        public void DrawLocation(Graphics g, CoordinateCalculator cCalc)
        {
            Sgp4Data position = SatFunctions.getSatPositionAtTime(Tle, new EpochTime(TimeKeeper.Now()), Sgp4.wgsConstant.WGS_84);
            var point = SatFunctions.calcSatSubPoint(new EpochTime(TimeKeeper.Now()), position, Sgp4.wgsConstant.WGS_84);
            var mappedPoint = cCalc.MapPoint(new PointF((float)point.getLongitude(), (float)point.getLatitude()));
            mappedPoint = new PointF((float)Math.Round(mappedPoint.X), (float)Math.Round(mappedPoint.Y));

            g.DrawImage(Properties.Resources.satellite, mappedPoint.X-25, mappedPoint.Y-25, 50, 50);
            var font = new Font("Times New Roman", 18, FontStyle.Bold, GraphicsUnit.Pixel);
            g.DrawString(Name, font, new SolidBrush(Color.OrangeRed), mappedPoint.X, mappedPoint.Y + 15);
        }

        private List<Sgp4Data> CalculatePositionList(int start, int end)
        {
            var startTime = new EpochTime(TimeKeeper.Now().AddMinutes(start));
            var endTime = new EpochTime(TimeKeeper.Now().AddMinutes(end));

            var sgp4Propagator = new Sgp4(Tle, Sgp4.wgsConstant.WGS_84);
            sgp4Propagator.runSgp4Cal(startTime, endTime, 0.01);
            return sgp4Propagator.getResults();
        }

        public void DrawLine(Graphics g, CoordinateCalculator cCalc)
        {
            DrawLineSet(new EpochTime(TimeKeeper.Now().AddMinutes(-30)), CalculatePositionList(-30, 0), Color.Red, cCalc, g);
            DrawLineSet(new EpochTime(TimeKeeper.Now()), CalculatePositionList(0, 90), Color.Yellow, cCalc, g);
        }

        private void DrawLineSet(EpochTime startTime, List<One_Sgp4.Sgp4Data> data, Color c, CoordinateCalculator cCalc, Graphics g)
        {
            foreach (var point in data)
            {
                startTime.addMinutes(0.01);
                var position = SatFunctions.calcSatSubPoint(startTime, point, Sgp4.wgsConstant.WGS_84);
                var pointOverGround = cCalc.MapPoint(new PointF((float)position.getLongitude(), (float)position.getLatitude()));


                g.FillRectangle(new SolidBrush(c), new RectangleF(pointOverGround, new Size(1, 1)));
            }
        }

        public Rectangle GetBounds()
        {
            throw new NotImplementedException();
        }
    }
}
