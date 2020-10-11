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

        private SatChooser SatChooser;
        private PassCalculator PassCalculator;

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

            Controller = new BufferedScreenController(pnlSimulation, satController, database);
            SatChooser = new SatChooser(satController, database);
            PassCalculator = new PassCalculator(satController, database);
        }

        private void selectSatellitesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SatChooser.Show();
            SatChooser.BringToFront();
        }

        private void predictPassesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PassCalculator.Show();
            PassCalculator.BringToFront();
        }
    }
}
