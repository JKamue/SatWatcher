using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SatWatcher.Data;
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
            var database = new SqLiteDb();

            foreach (var sat in database.GetAllSatellites())
            {
                var newTles = TLEApi.GetCurrentTleData(sat);
                database.UpdateTle(newTles);
            }

            var sats = database.GetAllSatellites();
            foreach (var sat in sats)
                satController.SelectSatellite(sat);

            satController.FocusSatellite(sats[0]);

            Controller = new BufferedScreenController(pnlSimulation, satController);
        }
    }
}
