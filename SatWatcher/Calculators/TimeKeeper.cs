using System;

namespace SatWatcher.Calculators
{
    class TimeKeeper
    {
        private static DateTime _ownTime = DateTime.Now;
        public static event EventHandler OnTimespanChanged;
        public static event EventHandler OnRealTimeSet;
        public static event EventHandler OnVirtualTimeSet;

        private static bool _realTime = true;

        public static DateTime Now()
        {
            if (_realTime)
                return DateTime.Now;

            return _ownTime;
        }
        
        public static void SetRealtime()
        {
            _realTime = true;
            OnRealTimeSet?.Invoke(null, EventArgs.Empty);
        }

        public static void SetVirtualTime(bool isNew = false)
        {
            if(isNew)
                _ownTime = DateTime.Now;

            _realTime = false;
            OnVirtualTimeSet?.Invoke(null, EventArgs.Empty);
        }

        public static void AddTimeSpan(TimeSpan added)
        {
            _ownTime += added;
            OnTimespanChanged?.Invoke(null, EventArgs.Empty);
            SetVirtualTime();
        }

        public static void SetTime(DateTime dt)
        {
            _ownTime = dt;
            OnTimespanChanged?.Invoke(null, EventArgs.Empty);
            SetVirtualTime();
        }
    }
}
