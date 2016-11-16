using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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

            TimerCallback callback = new TimerCallback(Tick);

            Timer stateTimer = new Timer(callback, null, 0, tickTime);

            while (timerOnOff)
            {
                Thread.Sleep(100);
            }
        }

        public static void Tick(Object stateInfo)
        {
            feed.UpdateFeed();
        }
    }
}
