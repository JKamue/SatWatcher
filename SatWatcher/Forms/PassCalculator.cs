using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using One_Sgp4;
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

            var location = _db.GetPosition();
            nbxLocLat.Value = location.lat;
            nbxLocLng.Value = location.lng;


            lviewPasses.View = View.Details;
            lviewPasses.GridLines = true;
            lviewPasses.FullRowSelect = true;

            lviewPasses.Columns.Add("Start", 120);
            lviewPasses.Columns.Add("Name", 60);
            lviewPasses.Columns.Add("Duration", 55);
            lviewPasses.Columns.Add("Elevation", 60);
        }

        private void PassCalcHider(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            var location = _db.GetPosition();
            var home = new Coordinate(location.lat, location.lng);

            lviewPasses.Items.Clear();
            List<SatPass> satPasses = new List<SatPass>();

            foreach (var sat in _satellites.SelectedSatellites)
            {
                var passes = SatFunctions.CalculatePasses(home, sat.Tle, new EpochTime(dtpStart.Value), 15, (int)nbxSpanDays.Value, Sgp4.wgsConstant.WGS_84);
                passes.ForEach(p => satPasses.Add(new SatPass(sat.Name, p)));
            }

            satPasses = satPasses
                .Where(p => p.Pass.getPassDetailOfMaxElevation().elevation >= (double)nbxMinElev.Value)
                .OrderBy(p => p.Pass.getStartEpoch().getEpoch())
                .ToList();

            foreach (var pass in satPasses)
            {
                string[] arr = new string[4];
                arr[0] = pass.Pass.getPassDetailOfMaxElevation().time.ToString();
                arr[1] = pass.Name;
                arr[2] = (pass.Pass.getPassDetailsAtEnd().time.toDateTime() - pass.Pass.getPassDetailsAtStart().time.toDateTime()).ToString();
                arr[3] = Math.Round(pass.Pass.getPassDetailOfMaxElevation().elevation, 2).ToString();

                var itm = new ListViewItem(arr);
                lviewPasses.Items.Add(itm);
            }
        }

        private void btnStoreLocation_Click(object sender, EventArgs e)
        {
            var lat = (long) nbxLocLat.Value;
            var lng = (long) nbxLocLng.Value;
            _db.SetLocation(new SqLiteDb.Location(lat, lng));
        }

        private struct SatPass
        {
            public readonly string Name;
            public readonly Pass Pass;

            public SatPass(string name, Pass pass)
            {
                Name = name;
                Pass = pass;
            }
        }
    }
}
