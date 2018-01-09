using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BerlinClock.Models
{
    public class ClockUnit
    {
        public string TimeUnit { get; set; }
        public int RowCount { get; set; }
        public int ColumnCount { get; set; }
        public bool isActive { get; set; }
        public string RowColor { get; set; }
    }

    static class Units
    {
        public static string Hours = "Hours";
        public static string Minutes = "Minutes";
        public static string Seconds = "Seconds";
    }

}