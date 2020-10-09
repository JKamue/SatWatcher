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

        public void SelectSatellite(Satellite sat)
        {
            _selectedSatellites.Add(sat);
            OnSelectionChanged(EventArgs.Empty);
        }

        public void RemoveSatellite(Satellite sat)
        {
            _selectedSatellites.RemoveAll(s => s.ID == sat.ID);
            OnSelectionChanged(EventArgs.Empty);
        }

        public IImmutableList<Satellite> SelectedSatellites => _selectedSatellites.ToImmutableList();

        protected virtual void OnSelectionChanged(EventArgs e)
        {
            SelectionChanged?.Invoke(this, e);
        }
    }
}
