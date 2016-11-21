using KBS_SE3.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KBS_SE3.Models
{
    class FeedTicker
    {
        private int _tickTime = 30000;
        private static Feed _feed;
        public Boolean timerOnOff { get; set; }

        public FeedTicker(int t, Feed f)
        {
            _tickTime = t;
            _feed = f;

            // Start the timer
            startTimer();
        }

        private void startTimer()
        {
            // Create a new timer
            Timer stateTimer = new Timer();
            // Set the interval
            stateTimer.Interval = (_tickTime);
            // Add event handler and start the timer
            stateTimer.Tick += new EventHandler(Tick);
            stateTimer.Start();
        }

        public static void Tick(Object sender, EventArgs e)
        {
            // Update the feed on timer tick
            _feed.UpdateFeed();
        }
    }
}
