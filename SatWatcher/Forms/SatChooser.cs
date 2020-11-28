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
    partial class SatChooser : Form
    {
        private SatellitesController Satellites;
        private SqLiteDb Db;
        private List<Satellite> storedSatellites;

        public SatChooser(SatellitesController satellites, SqLiteDb db)
        {
            StartPosition = FormStartPosition.CenterParent;
            InitializeComponent();
            Satellites = satellites;
            Db = db;
            FormClosing += SatChooserHider;
            UpdateAllLists();
        }

        private void UpdateAllLists()
        {
            UpdateSatList();
            UpdateShownSatList();
        }

        private void UpdateSatList()
        {
            lbxStoredSats.Items.Clear();
            storedSatellites = Db.GetAllSatellites().OrderBy(s => s.Name).ToList();
            foreach (var sat in storedSatellites)
            {
                if (Satellites.SelectedSatellites.Where(s => s.ID == sat.ID).ToList().Count == 0)
                    lbxStoredSats.Items.Add(new ListBoxItem(sat.Name, sat.ID));
            }
        }

        private void UpdateShownSatList()
        {
            lbxShownSats.Items.Clear();
            foreach (var sat in Satellites.SelectedSatellites.OrderBy(s => s.Name).ToList())
            {
                lbxShownSats.Items.Add(new ListBoxItem(sat.Name, sat.ID));
            }
        }

        private void SatChooserHider(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void btnAddToShown_Click(object sender, EventArgs e)
        {
            foreach (ListBoxItem lbxItem in lbxStoredSats.SelectedItems)
                Satellites.SelectSatellite(GetSatellite(lbxItem));

            UpdateAllLists();
        }

        private void btnRemoveFromShown_Click(object sender, EventArgs e)
        {
            foreach (ListBoxItem lbxItem in lbxShownSats.SelectedItems)
                Satellites.RemoveSatellite(GetSatellite(lbxItem));

            UpdateAllLists();
        }

        private void lbxShownSats_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var index = lbxShownSats.IndexFromPoint(e.Location);
            if (index == System.Windows.Forms.ListBox.NoMatches)
                return;

            var listBoxItem = lbxShownSats.Items[index];
            Satellites.FocusSatellite(GetSatellite((ListBoxItem) listBoxItem));
        }

        private Satellite GetSatellite(ListBoxItem item)
        {
            return storedSatellites.First(s => s.ID == item.Id);
        }

        private void btnAddSat_Click(object sender, EventArgs e)
        {
            var sat = TLEApi.GetSatellite((long) nbxNorad.Value);
            if (sat.IsFailure)
            {
                MessageBox.Show(sat.Error, "Daten nicht empfangen");
                return;
            }
            
            Db.AddSatellite(sat.Value);
            UpdateAllLists();
        }
    }

    class ListBoxItem
    {
        public string Name;
        public float Id;

        public override string ToString()
        {
            return Id + " - " + Name;
        }

        public ListBoxItem(string name, float id)
        {
            Name = name;
            Id = id;
        }
    }
}
