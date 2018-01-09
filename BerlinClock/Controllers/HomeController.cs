using BerlinClock.Models;
using BerlinClock.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BerlinClock.Controllers
{

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetClockUnitTimes(string inputTime)
        {
            ClockService clockService = ClockService.Instance();
            clockService.Reset();
            try
            {
                var time = TimeSpan.Parse(inputTime);
                //For seconds block lights
                if (time.Seconds % 2 == 0)
                {
                    clockService.AddClockUnit(new ClockUnit() { TimeUnit = "Seconds", isActive = true, RowCount = 0, ColumnCount = 0, RowColor = "yellow" });
                }
                else
                {
                    clockService.AddClockUnit(new ClockUnit() { TimeUnit = "Seconds", isActive = false, RowCount = 0, ColumnCount = 0, RowColor = "NA" });
                }

                var hourColumnCount = 0;

                //For 5-hour block lights
                for (var i = 5; i <= 20; i += 5)
                {

                    //if hour greater than 5, then light red
                    //otherwise light is off
                    if (time.Hours >= i)
                    {
                        clockService.AddClockUnit(new ClockUnit() { TimeUnit = "Hours", isActive = true, RowCount = 1, ColumnCount = hourColumnCount, RowColor = "red" });
                    }
                    else
                    {
                        clockService.AddClockUnit(new ClockUnit() { TimeUnit = "Hours", isActive = false, RowCount = 1, ColumnCount = hourColumnCount, RowColor = "NA" });
                    }
                    hourColumnCount++;
                }

                //For 1-hour block lights
                for (var i = 1; i <= 4; i++)
                {
                    if (time.Hours % 5 >= i)
                    {
                        clockService.AddClockUnit(new ClockUnit() { TimeUnit = "Hours", isActive = true, RowCount = 2, ColumnCount = i, RowColor = "red" });
                    }
                    else
                    {
                        clockService.AddClockUnit(new ClockUnit() { TimeUnit = "Hours", isActive = false, RowCount = 2, ColumnCount = i, RowColor = "NA" });
                    }
                }

                var minuteColumnCount = 0;
                //For 5-minute block lights
                for (var i = 5; i <= 55; i += 5)
                {
                    if (time.Minutes >= i)
                    {
                        if (i % 15 == 0)
                        {
                            clockService.AddClockUnit(new ClockUnit() { TimeUnit = "Minutes", isActive = true, RowCount = 3, ColumnCount = minuteColumnCount, RowColor = "red" });
                        }
                        else
                        {
                            clockService.AddClockUnit(new ClockUnit() { TimeUnit = "Minutes", isActive = true, RowCount = 3, ColumnCount = minuteColumnCount, RowColor = "yellow" });
                        }
                    }
                    else
                    {
                        clockService.AddClockUnit(new ClockUnit() { TimeUnit = "Minutes", isActive = false, RowCount = 3, ColumnCount = minuteColumnCount, RowColor = "NA" });
                    }

                    minuteColumnCount++;
                }

                //For 1-minute block lights
                for (var i = 1; i <= 4; i++)
                {
                    if (time.Minutes % 5 >= i)
                    {
                        clockService.AddClockUnit(new ClockUnit() { TimeUnit = "Minutes", isActive = true, RowCount = 4, ColumnCount = i, RowColor = "yellow" });
                    }
                    else
                    {
                        clockService.AddClockUnit(new ClockUnit() { TimeUnit = "Minutes", isActive = false, RowCount = 4, ColumnCount = i, RowColor = "NA" });
                    }
                }
                return Json(clockService.GetAllClockUnits(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message }, JsonRequestBehavior.AllowGet);
            }

            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}