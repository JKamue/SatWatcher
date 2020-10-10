using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatWatcher.Satellites
{
    class SatellitesController
    {
        private List<Satellite> _selectedSatellites = new List<Satellite>();

        public event EventHandler SelectionChanged;

        public Satellite MainSatellite { get; private set; }

        public void SelectSatellite(Satellite sat)
        {
            if (_selectedSatellites.Any(s => s.ID == sat.ID))
                return;

            _selectedSatellites.Add(sat);
            OnSelectionChanged(EventArgs.Empty);
        }

        public void FocusSatellite(Satellite sat)
        {
            MainSatellite = sat;
            SelectSatellite(sat);
            OnSelectionChanged(EventArgs.Empty);
        }

        public void RemoveSatellite(Satellite sat)
        {
            _selectedSatellites.RemoveAll(s => s.ID == sat.ID);
            OnSelectionChanged(EventArgs.Empty);

            if (MainSatellite == null)
                return;

            if (MainSatellite.ID == sat.ID)
            {
                MainSatellite = null;

                if (SelectedSatellites.Count > 0)
                    MainSatellite = SelectedSatellites[0];
            }
        }

        public IImmutableList<Satellite> SelectedSatellites => _selectedSatellites.ToImmutableList();

        protected virtual void OnSelectionChanged(EventArgs e)
        {
            SelectionChanged?.Invoke(this, e);
        }
    }
}
