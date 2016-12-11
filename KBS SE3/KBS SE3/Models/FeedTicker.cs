using System;
//using System.Threading;
using System.Windows.Forms;
using KBS_SE3.Properties;

namespace KBS_SE3.Models {
    class FeedTicker {
        private int _tickTime;
        private static Feed _feed;
        private Timer _stateTimer = new Timer();

        public FeedTicker(int t, Feed f) {
            _tickTime = t;
            _feed = f;
            _startTimer();
        }

        public void StartTimerIfEnabled() {
            if (Settings.Default.feedTickerEnabled) _stateTimer.Start();
        }

        public void StopTimerIfEnabled() {
            if (_stateTimer.Enabled) _stateTimer.Stop();
        }

        public void TimerStateChanged(bool state) {
            if (state) _stateTimer.Start();
            else _stateTimer.Stop();
        }

        public void ChangeTickTime(int tickTime) {
            _stateTimer.Stop();
            _tickTime = tickTime * 1000;
            _stateTimer.Interval = _tickTime;
            StartTimerIfEnabled();
        }

        public static void Tick(object sender, EventArgs e) => _feed.UpdateFeed();

        /*
        * Starts the timer with a standard timetick interval (set to 30 seconds as standard)
        * Adds an eventhandler to the feeds get updated everytime stateTimer ticks
        */
        private void _startTimer() {
            _stateTimer.Interval = (_tickTime);
            _stateTimer.Tick += new EventHandler(Tick);
            StartTimerIfEnabled();
        }

    }
}
