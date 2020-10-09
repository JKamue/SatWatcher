using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SatWatcher.Satellites;
using SatWatcher.Screen;

namespace SatWatcher.Forms
{
    public partial class SimulationScreen : Form
    {
        private BufferedScreenController Controller;

        public SimulationScreen()
        {
            InitializeComponent();
            var satController = new SatellitesController();
            var iss = new Satellite(25544, "ISS (ZARYA)",
                "1 25544U 98067A 20282.49977912 .00004092 00000-0 81550-4 0 9990",
                "2 25544 51.6442 147.8049 0001578 5.7979 62.1290 15.49295258249583", "SSTV", "145.800");
            var meteorM2 = new Satellite(40069, "METEOR-M 2",
                "1 40069U 14037A 20282.44112405 -.00000029 00000-0 58769-5 0 9991",
                "2 40069 98.4930 315.6513 0004974 325.2073 34.8784 14.20675771324254", "LRPT", "137.100");


            satController.SelectSatellite(iss);
            satController.SelectSatellite(meteorM2);
            satController.FocusSatellite(iss);
            Controller = new BufferedScreenController(pnlSimulation, satController);
        }
    }
}
