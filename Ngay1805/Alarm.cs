using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ngay1805
{
    public class Alarm
    {
        public delegate void AlarmHandler();
        public event AlarmHandler OnAlarmRing;
        public void SetAlarm(int s)
        {
            Console.WriteLine($"Alarm set for {s} seconds");
            Thread.Sleep( s*1000 );
            Ring();
        }

        private void Ring()
        {
            if(OnAlarmRing != null)
            {
                OnAlarmRing();
            }
        }
    }
}
