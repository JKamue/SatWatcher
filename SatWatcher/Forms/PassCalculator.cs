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

namespace SatWatcher.Forms
{
    partial class PassCalculator : Form
    {
        private readonly SatellitesController _satellites;
        private readonly SqLiteDb _db;

        public PassCalculator(SatellitesController satellites, SqLiteDb database)
        {
            _satellites = satellites;
            _db = database;

            InitializeComponent();
            FormClosing += PassCalcHider;
        }

        private void PassCalcHider(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {

        }

        private void btnStoreLocation_Click(object sender, EventArgs e)
        {
            var lat = (long) nbxLocLat.Value;
            var lng = (long) nbxLocLng.Value;
            _db.SetLocation(new SqLiteDb.Location(lat, lng));
        }
    }
}
