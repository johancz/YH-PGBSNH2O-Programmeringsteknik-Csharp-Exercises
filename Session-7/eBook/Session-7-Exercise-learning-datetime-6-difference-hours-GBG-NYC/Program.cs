// https://csharp.jakobkallin.com/learning/
// Exercise 6:
// Write a program that shows the current difference in hours between Gothenburg and New York City.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Session_7_Exercise_learning_datetime_6_difference_hours_GBG_NYC
{
    public class Program
    {
        public static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            IReadOnlyCollection<TimeZoneInfo> tzi = TimeZoneInfo.GetSystemTimeZones();

            //// Find TimeZone ids:
            //foreach (TimeZoneInfo tzi_timeZone in tzi)
            //{
            //    int tzi_UTCoffset = tzi_timeZone.BaseUtcOffset.Hours;

            //    if (tzi_UTCoffset > 0)
            //    {
            //        Console.Write(tzi_timeZone.DisplayName);
            //        Console.CursorLeft = tzi.Max(x => x.DisplayName.Length) + 1;
            //        Console.Write(tzi_timeZone.Id + "\n");
            //    }
            //}

            DateTime dt_nyc = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "US Eastern Standard Time");
            DateTime dt_gbg = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "Central Europe Standard Time");

            int difference_hours = dt_gbg.Hour - dt_nyc.Hour;
            Console.WriteLine("New York City is " + difference_hours + " hours behind Gothenburg.");

            TimeSpan ts_diff = dt_gbg - dt_nyc;
            // Use '.TotalHours' instead of '.Hours' because the largest timezone difference is apparently 26 hours
            Console.WriteLine("New York City is " + Math.Round(ts_diff.TotalHours) + " hours behind Gothenburg.");
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Test()
        {
            using FakeConsole console = new FakeConsole("test");
            Program.Main();
            //Assert.AreEqual("New York City is 6 hours behind Gothenburg.", console.Lines[0]);
            //Assert.AreEqual("New York City is 6 hours behind Gothenburg.", console.Lines[1]);
            CollectionAssert.AreEqual(new[] {
                "New York City is 6 hours behind Gothenburg.",
                "New York City is 6 hours behind Gothenburg."
            }, console.Lines);
        }
    }
}
