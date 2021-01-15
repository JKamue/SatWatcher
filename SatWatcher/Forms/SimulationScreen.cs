using System;
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
        private TimeTravel TimeTravel;

        public SimulationScreen()
        {
            InitializeComponent();
            var satController = new SatellitesController();
            var database = new SqLiteDb();

            foreach (var sat in database.GetAllSatellites())
            {
                var newTles = TLEApi.GetCurrentTleData(sat);
                if (newTles.IsSuccess)
                    database.UpdateTle(newTles.Value);
            }

            Controller = new BufferedScreenController(pnlSimulation, satController, database);
            SatChooser = new SatChooser(satController, database);
            TimeTravel = new TimeTravel();
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

        private void timeTravelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimeTravel.Show();
            TimeTravel.BringToFront();
        }
    }
}
