using System;
//using System.Threading;
using System.Windows.Forms;

namespace KBS_SE3.Models
{
    class FeedTicker
    {
        private int _tickTime = 30000;
        private static Feed _feed;
        private Timer _stateTimer = new Timer();

        public FeedTicker(int t, Feed f) {
            _tickTime = t;
            _feed = f;
            startTimer();
        }

        public static void Tick(object sender, EventArgs e) { 
            _feed.UpdateFeed();
        }


        /*
        * Starts the timer with a standard timetick interval (set to 30 seconds as standard)
        * Adds an eventhandler to the feeds get updated everytime stateTimer ticks
        */
        private void startTimer() {
            _stateTimer.Interval = (_tickTime);
            _stateTimer.Tick += new EventHandler(Tick);
            _stateTimer.Start();
        }

    }
}
