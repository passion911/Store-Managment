using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Public
{
    public class TimePublic
    {
        private int _day;
        public int Day
        {
            get { return _day; }
            set { _day = value; }
        }
        private int _hour;
        public int Hour
        {
            get { return _hour; }
            set { _hour = value; }
        }
        private int _minute;
        public int Minute
        {
            get { return _minute; }
            set { _minute = value; }
        }
        private int _second;
        public int Second
        {
            get { return _second; }
            set { _second = value; }
        }

        public static TimePublic GetTimeRemaining(DateTime _dateTime)
        {
            TimePublic _time = new TimePublic();
            TimeSpan _timeSpan = _dateTime - DateTime.Now;
            _time.Day = _timeSpan.Days;
            _time.Hour = _timeSpan.Hours;
            _time.Minute = _timeSpan.Minutes;
            _time.Second = _timeSpan.Seconds;
            return _time;
        }
    }//end class
}
