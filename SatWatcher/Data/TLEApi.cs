using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatWatcher.Data
{
    class TLEApi
    {
        public static TleLines GetCurrentTleData()
        {
            throw new NotImplementedException();
        }
    }

    struct TleLines
    {
        public readonly string Line1;
        public readonly string Line2;

        public TleLines(string tleLine1, string tleLine2)
        {
            Line1 = tleLine1;
            Line2 = tleLine2;
        }
    }
}
