using System;

namespace W4Homework2
{
    class Program
    {
        static void Main(string[] args)
        {
            Clock clock1 = new Clock(2020,3,14,12,7,11);
            clock1.alarm1.Alarm();
        }
    }

    public delegate void clockHandler(object sender, TickEventArgs args);

    public class TickEventArgs
    {
        public DateTime Time
        {
            get; set;
        }
    }

    class alarm
    {
        public event clockHandler onAlarm;
        public event clockHandler onTick;
 
        public DateTime alarmTime
        {
            get; set;
        }
        public void Alarm()
        {
            TickEventArgs args = new TickEventArgs()
            {
                Time = DateTime.Now
            };
            TimeSpan span;
            while (true)
            {
                onTick(this, args);
                System.Threading.Thread.Sleep(1000);
                span = alarmTime.Subtract(args.Time);
                if (span.TotalSeconds<1&&span.TotalSeconds>0)
                    onAlarm(this, args);
            }
        }
    }

    class Clock
    { 
        public alarm alarm1 = new alarm();

        public Clock(int yyyy, int MM, int dd, int hh, int mm, int ss)
        {
            alarm1.alarmTime = new DateTime(yyyy, MM, dd, hh, mm, ss);
            alarm1.onTick += addTime;
            alarm1.onTick += show;
            alarm1.onAlarm += ringing;
        }

        public void addTime(object sender,TickEventArgs args)
        {
            args.Time = DateTime.Now;
        }

        public void show(object sender, TickEventArgs args)
        {
            Console.WriteLine("Tick："+args.Time.ToString("T"));
        }

        public void ringing(object sender, TickEventArgs args)
        {
            Console.WriteLine("Ringing now!");
        }
    }
}


