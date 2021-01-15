using System;

namespace SatWatcher.Data.Dtos
{
    class PassSettingDto
    {
        public SqLiteDb.Location Location;
        public DateTime Start;
        public int Days;
        public double MinElevtation;
        public string[] SelectedSatellites;

        public PassSettingDto(SqLiteDb.Location location, DateTime start, int days, double minElevtation, string[] selectedSatellites)
        {
            Location = location;
            Start = start;
            Days = days;
            MinElevtation = minElevtation;
            SelectedSatellites = selectedSatellites;
        }
    }
}
