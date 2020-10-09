using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using One_Sgp4;
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

        public void DrawLocation(Graphics g)
        {
            throw new NotImplementedException();
        }

        public void DrawLine(Graphics g)
        {
            throw new NotImplementedException();
        }

        public Rectangle GetBounds()
        {
            throw new NotImplementedException();
        }
    }
}
