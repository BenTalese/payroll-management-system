using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Shift
    {
        public int ShiftID { get; private set; }
        public DateTime ShiftDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public Shift()
        {
            ShiftDate = DateTime.Now;
            StartTime = ShiftDate.TimeOfDay;
            EndTime = StartTime.Add(TimeSpan.FromHours(1));
        }

        public Shift(int id, DateTime date, TimeSpan sTime, TimeSpan eTime)
        {
            ShiftID = id;
            ShiftDate = date;
            StartTime = sTime;
            EndTime = eTime;
        }
    }
}