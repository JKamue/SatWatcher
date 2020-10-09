using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatWatcher.Screen
{
    interface IScreenObject
    {
        Rectangle GetBounds();
        void Draw(Graphics g);
    }
}
