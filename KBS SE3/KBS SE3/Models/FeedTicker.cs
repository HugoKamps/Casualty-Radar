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
        private int tickTime = 30000;
        private static Feed feed;
        public Boolean timerOnOff { get; set; }

        public FeedTicker(int t, Feed f)
        {
            tickTime = t;
            feed = f;
            timerOnOff = true;

            startTimer();
        }

        private void startTimer()
        {
            Timer stateTimer = new Timer();
            stateTimer.Interval = (tickTime);
            stateTimer.Tick += new EventHandler(Tick);
            stateTimer.Start();
        }

        public static void Tick(Object sender, EventArgs e)
        {
            feed.UpdateFeed();
        }
    }
}
