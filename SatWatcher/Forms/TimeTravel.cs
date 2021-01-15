using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SatWatcher.Calculators;

namespace SatWatcher.Forms
{
    public partial class TimeTravel : Form
    {
        public TimeTravel()
        {
            InitializeComponent();
            FormClosing += TimeTravelHider;

            cbxNumber.SelectedIndex = 2;
            cbxTime.SelectedIndex = 1;

            dtpCurrentTime.Value = TimeKeeper.Now();

            TimeKeeper.OnTimespanChanged += UpdateTime;
            TimeKeeper.OnRealTimeSet += ProhibitInput;
            TimeKeeper.OnVirtualTimeSet += AllowInput;

            dtpCurrentTime.ValueChanged += UpdateTimeKeeper;
            rdbRealtime.Click += OnRdbRealtimeClick;
            rdbSimulation.Click += OnRdbSimulationClick;

            rdbRealtime.Checked = true;

            SetInputStatus(false);

            var updateTimer = new Timer();
            updateTimer.Tick += UpdateTime;
            updateTimer.Interval = 500;
            updateTimer.Start();
        }

        private void TimeTravelHider(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        public void UpdateTime(object s, EventArgs e) => dtpCurrentTime.Value = TimeKeeper.Now();

        public void UpdateTimeKeeper(object s, EventArgs e)
        {
            if (dtpCurrentTime.Enabled)
                TimeKeeper.SetTime(dtpCurrentTime.Value);
        }

        private void OnRdbSimulationClick(object s, EventArgs e) => TimeKeeper.SetVirtualTime();
        private void OnRdbRealtimeClick(object s, EventArgs e) => TimeKeeper.SetRealtime();

        public void AllowInput(object s, EventArgs e) => SetInputStatus(true);
        public void ProhibitInput(object s, EventArgs e) => SetInputStatus(false);

        public void SetInputStatus(bool allowed)
        {
            dtpCurrentTime.Enabled = allowed;
            cbxTime.Enabled = allowed;
            cbxNumber.Enabled = allowed;
            btnAdd.Enabled = allowed;
            btnReset.Enabled = allowed;
            btnSub.Enabled = allowed;

            rdbSimulation.Checked = allowed;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TimeKeeper.AddTimeSpan(new TimeSpan(0, 0, GetSeconds()));
        }

        private int GetSeconds()
        {
            var number = float.Parse(cbxNumber.SelectedItem.ToString());
            var type = cbxTime.SelectedItem.ToString();
            var param = new Dictionary<string, int> { { "seconds", 1 }, { "minutes", 60 }, {"hours", 60*60}, {"days", 60*60*24} };
            return (int) Math.Round(number * param[type]);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            TimeKeeper.SetVirtualTime(true);
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            TimeKeeper.AddTimeSpan(new TimeSpan(0, 0, -1 * GetSeconds()));
        }
    }
}
