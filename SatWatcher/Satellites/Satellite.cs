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
    public class Satellite : IScreenObject
    {
        public readonly int ID;
        public readonly string Name;
        public readonly string[] _tle;
        public readonly string Type;
        public readonly string Frequency;
        public readonly Tle Tle;

        public Satellite(int id, string name, string[] tle, string type, string frequency)
        {
            ID = id;
            Name = name;
            _tle = tle;
            Type = type;
            Frequency = frequency;
            Tle = ParserTLE.parseTle(
                _tle[1],
                _tle[2],
                _tle[0]);
        }

        public void Draw(Graphics g)
        {
            throw new NotImplementedException();
        }

        public Rectangle GetBounds()
        {
            throw new NotImplementedException();
        }
    }
}
