using System;
using System.Windows.Forms;
using Casualty_Radar.Properties;
using Casualty_Radar.Core;

namespace Casualty_Radar.Models {
    /// <summary>
    /// Class which instantiates a time ticker which updates the feed in a given interval
    /// </summary>
    public class FeedTicker {
        private int _tickTime;
        private static Feed _feed;
        private Timer _stateTimer = new Timer();

        public FeedTicker(int t, Feed f) {
            _tickTime = t;
            _feed = f;
            StartTimer();
        }

        /// <summary>
        /// Starts the timer if the user has it enabled in settings
        /// </summary>
        public void StartTimerIfEnabled() {
            if (Settings.Default.feedTickerEnabled && !_stateTimer.Enabled) _stateTimer.Start();
        }

        /// <summary>
        /// Stops the timer if the user has it enabled in settings
        /// </summary>
        public void StopTimerIfEnabled() {
            if (_stateTimer.Enabled) _stateTimer.Stop();
        }

        /// <summary>
        /// Starts or stops the timer based on the given state
        /// </summary>
        /// <param name="state">Indicates whether the timer should be started or stopped</param>
        public void TimerStateChanged(bool state) {
            if (state) _stateTimer.Start();
            else _stateTimer.Stop();
        }

        /// <summary>
        /// Changes the interval for the ticker based on a given value
        /// </summary>
        /// <param name="tickTime">New ticker interval</param>
        public void ChangeTickTime(int tickTime) {
            _stateTimer.Stop();
            _tickTime = tickTime * 1000;
            _stateTimer.Interval = _tickTime;
            StartTimerIfEnabled();
        }

        public static void Tick(object sender, EventArgs e) => _feed.UpdateFeed();

        /// <summary>
        /// Starts the timer with a standard timetick interval (set to 30 seconds as standard).
        /// Adds an eventhandler to the feeds get updated everytime stateTimer ticks
        /// </summary>
        private void StartTimer() {
            _stateTimer.Interval = _tickTime;
            _stateTimer.Tick += Tick;
            StartTimerIfEnabled();
        }

    }
}
