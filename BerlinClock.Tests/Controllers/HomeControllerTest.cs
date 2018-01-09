using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BerlinClock;
using BerlinClock.Controllers;
using BerlinClock.Services;
using BerlinClock.Models;
using Newtonsoft.Json;
using System.Web.Script.Serialization;

namespace BerlinClock.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetClockUnitTimes()
        {
            // Arrange
            HomeController controller = new HomeController();
            ClockService clockService = ClockService.Instance();

            var inputTime = "05:30";
            // Act
            var result = controller.GetClockUnitTimes(inputTime);
  
            clockService.Reset();
            clockService.AddClockUnit(new ClockUnit() { TimeUnit = "Seconds", isActive = true, RowCount = 0, ColumnCount = 0, RowColor = "yellow" });
            clockService.AddClockUnit(new ClockUnit() { TimeUnit = "Hours", isActive = true, RowCount = 1, ColumnCount = 0, RowColor = "red" });
            clockService.AddClockUnit(new ClockUnit() { TimeUnit = "Hours", isActive = false, RowCount = 1, ColumnCount = 1, RowColor = "NA" });
            clockService.AddClockUnit(new ClockUnit() { TimeUnit = "Hours", isActive = false, RowCount = 1, ColumnCount = 2, RowColor = "NA" });
            clockService.AddClockUnit(new ClockUnit() { TimeUnit = "Hours", isActive = false, RowCount = 1, ColumnCount = 3, RowColor = "NA" });
            clockService.AddClockUnit(new ClockUnit() { TimeUnit = "Hours", isActive = false, RowCount = 2, ColumnCount = 1, RowColor = "NA" });
            clockService.AddClockUnit(new ClockUnit() { TimeUnit = "Hours", isActive = false, RowCount = 2, ColumnCount = 2, RowColor = "NA" });
            clockService.AddClockUnit(new ClockUnit() { TimeUnit = "Hours", isActive = false, RowCount = 2, ColumnCount = 3, RowColor = "NA" });
            clockService.AddClockUnit(new ClockUnit() { TimeUnit = "Hours", isActive = false, RowCount = 2, ColumnCount = 4, RowColor = "NA" });
            clockService.AddClockUnit(new ClockUnit() { TimeUnit = "Minutes", isActive = true, RowCount = 3, ColumnCount = 0, RowColor = "yellow" });
            clockService.AddClockUnit(new ClockUnit() { TimeUnit = "Minutes", isActive = true, RowCount = 3, ColumnCount = 1, RowColor = "yellow" });
            clockService.AddClockUnit(new ClockUnit() { TimeUnit = "Minutes", isActive = true, RowCount = 3, ColumnCount = 2, RowColor = "red" });
            clockService.AddClockUnit(new ClockUnit() { TimeUnit = "Minutes", isActive = true, RowCount = 3, ColumnCount = 3, RowColor = "yellow" });
            clockService.AddClockUnit(new ClockUnit() { TimeUnit = "Minutes", isActive = true, RowCount = 3, ColumnCount = 4, RowColor = "yellow" });
            clockService.AddClockUnit(new ClockUnit() { TimeUnit = "Minutes", isActive = true, RowCount = 3, ColumnCount = 5, RowColor = "red" });
            clockService.AddClockUnit(new ClockUnit() { TimeUnit = "Minutes", isActive = false, RowCount = 3, ColumnCount = 6, RowColor = "NA" });
            clockService.AddClockUnit(new ClockUnit() { TimeUnit = "Minutes", isActive = false, RowCount = 3, ColumnCount = 7, RowColor = "NA" });
            clockService.AddClockUnit(new ClockUnit() { TimeUnit = "Minutes", isActive = false, RowCount = 3, ColumnCount = 8, RowColor = "NA" });
            clockService.AddClockUnit(new ClockUnit() { TimeUnit = "Minutes", isActive = false, RowCount = 3, ColumnCount = 9, RowColor = "NA" });
            clockService.AddClockUnit(new ClockUnit() { TimeUnit = "Minutes", isActive = false, RowCount = 3, ColumnCount = 10, RowColor = "NA" });
            clockService.AddClockUnit(new ClockUnit() { TimeUnit = "Minutes", isActive = false, RowCount = 4, ColumnCount = 1, RowColor = "NA" });
            clockService.AddClockUnit(new ClockUnit() { TimeUnit = "Minutes", isActive = false, RowCount = 4, ColumnCount = 2, RowColor = "NA" });
            clockService.AddClockUnit(new ClockUnit() { TimeUnit = "Minutes", isActive = false, RowCount = 4, ColumnCount = 3, RowColor = "NA" });
            clockService.AddClockUnit(new ClockUnit() { TimeUnit = "Minutes", isActive = false, RowCount = 4, ColumnCount = 4, RowColor = "NA" });

            var test = new JavaScriptSerializer().Serialize(result.Data);
            var test1 = new JavaScriptSerializer().Serialize(clockService.GetAllClockUnits());
            // Assert
            Assert.AreEqual(test, test1);
        }

    }
}
