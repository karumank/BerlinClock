using BerlinClock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BerlinClock.Services
{
    public class ClockService
    {
        private static ClockService instance;
        private List<ClockUnit> clockUnitList = null;

        private ClockService()
        {
            if (clockUnitList == null)
            {
                clockUnitList = new List<ClockUnit>();
            }
        }

        public static ClockService Instance()
        {
            if(instance == null)
            {
                instance = new ClockService();
            }

            return instance;
        }

        public void AddClockUnit(ClockUnit clckUnit)
        {
            clockUnitList.Add(clckUnit);
        }

        public List<ClockUnit> GetAllClockUnits ()
        {
            return clockUnitList.ToList();
        }

        public void Reset() { clockUnitList.Clear(); }
    }
}