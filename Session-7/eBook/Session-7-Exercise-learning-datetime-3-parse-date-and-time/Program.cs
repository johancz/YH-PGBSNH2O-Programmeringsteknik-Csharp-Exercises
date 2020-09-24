using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Session_7_Exercise_learning_datetime_3_parse_date_and_time
{
    public class Program
    {
        public static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            DateTime dt;

            Console.WriteLine("Enter date and time in this format \"YYYY-MM-DD HH:MM:SS\"");
            while (!DateTime.TryParse(Console.ReadLine(), out dt))
            {
                Console.Write("Invalid date & time format, try again: ");
            }

            Console.WriteLine("Year: " + dt.Year);
            Console.WriteLine("Month: " + dt.ToString("MMMM"));
            Console.WriteLine("Day of the Month: " + dt.Day);
            Console.WriteLine("Day of the Week: " + dt.DayOfWeek);
            Console.WriteLine("Hour: " + dt.Hour);
            Console.WriteLine("Minute: " + dt.Minute);
            Console.WriteLine("Second: " + dt.Second);
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Test_Output()
        {
            using FakeConsole console = new FakeConsole("2010-01-02 12:34:56");
            Program.Main();
            CollectionAssert.AreEqual(new[] {
                "Year: 2010",
                "Month: January",
                "Day of the Month: 2",
                "Day of the Week: Saturday",
                "Hour: 12",
                "Minute: 34",
                "Second: 56"
            }, console.Lines);
        }
    }
}
