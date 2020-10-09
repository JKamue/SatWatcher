using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using One_Sgp4;
using SatWatcher.Calculators;
using SatWatcher.Screen;

namespace SatWatcher.Satellites
{
    public class Satellite
    {
        public readonly int ID;
        public readonly string Name;
        public readonly string Type;
        public readonly string Frequency;
        public readonly Tle Tle;

        public Satellite(int id, string name, string tleLine1, string tleLine2, string type, string frequency)
        {
            ID = id;
            Name = name;
            Type = type;
            Frequency = frequency;
            Tle = ParserTLE.parseTle(
                tleLine1,
                tleLine2,
                name);
        }

        public void DrawLocation(Graphics g, CoordinateCalculator cCalc)
        {
            Sgp4Data position = SatFunctions.getSatPositionAtTime(Tle, new EpochTime(DateTime.Now), Sgp4.wgsConstant.WGS_84);
            var point = SatFunctions.calcSatSubPoint(new EpochTime(DateTime.Now), position, Sgp4.wgsConstant.WGS_84);
            var mappedPoint = cCalc.MapPoint(new PointF((float)point.getLongitude(), (float)point.getLatitude()));
            mappedPoint = new PointF((float)Math.Round(mappedPoint.X), (float)Math.Round(mappedPoint.Y));

            var font = new Font("Times New Roman", 18, FontStyle.Bold, GraphicsUnit.Pixel);
            g.DrawString(Name, font, new SolidBrush(Color.OrangeRed), mappedPoint);
        }

        private List<Sgp4Data> CalculatePositionList(int start, int end)
        {
            var startTime = new EpochTime(DateTime.Now.AddMinutes(start));
            var endTime = new EpochTime(DateTime.Now.AddMinutes(end));

            var sgp4Propagator = new Sgp4(Tle, Sgp4.wgsConstant.WGS_84);
            sgp4Propagator.runSgp4Cal(startTime, endTime, 0.01);
            return sgp4Propagator.getResults();
        }

        public void DrawLine(Graphics g, CoordinateCalculator cCalc)
        {
            DrawLineSet(new EpochTime(DateTime.Now.AddMinutes(-30)), CalculatePositionList(-30, 0), Color.Red, cCalc, g);
            DrawLineSet(new EpochTime(DateTime.Now), CalculatePositionList(0, 90), Color.Yellow, cCalc, g);
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
