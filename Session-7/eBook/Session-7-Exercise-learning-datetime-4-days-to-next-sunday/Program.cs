using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Session_7_Exercise_learning_datetime_4_days_to_next_sunday
{
    public class Program
    {
        public static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
        }

        public static void DaysUntilWeekday(DayOfWeek from, DayOfWeek to)
        {
            int daysUntilWeekday = 0;
            DateTime from_dt = DateTime.Now;

            // Decrement or increment from 'now' until 'DayOfWeek' == 'from'. 
            while (from_dt.DayOfWeek != from)
            {
                if (from_dt.DayOfWeek > from) { from_dt = from_dt.AddDays(-1); }
                else if (from_dt.DayOfWeek < from) { from_dt = from_dt.AddDays(1); }
            }

            while (from_dt.DayOfWeek != to)
            {
                from_dt = from_dt.AddDays(1);
                daysUntilWeekday++;
            }

            Console.WriteLine(daysUntilWeekday + " days (from \"" + from + "\" to \"" + to + "\")");
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestInitialize]
        public void TestInit()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
        }

        [TestMethod]
        public void Test_DaysUntilMonday_FromAllDays()
        {
            DayOfWeek dayOfWeek = DayOfWeek.Monday;
            FakeConsole console = new FakeConsole();
            Program.DaysUntilWeekday(DayOfWeek.Tuesday, dayOfWeek);
            Program.DaysUntilWeekday(DayOfWeek.Wednesday, dayOfWeek);
            Program.DaysUntilWeekday(DayOfWeek.Thursday, dayOfWeek);
            Program.DaysUntilWeekday(DayOfWeek.Friday, dayOfWeek);
            Program.DaysUntilWeekday(DayOfWeek.Saturday, dayOfWeek);
            Program.DaysUntilWeekday(DayOfWeek.Sunday, dayOfWeek);
            CollectionAssert.AreEqual(new[] {
                "6 days (from \"Tuesday\" to \"" + dayOfWeek+ "\")",
                "5 days (from \"Wednesday\" to \"" + dayOfWeek+ "\")",
                "4 days (from \"Thursday\" to \"" + dayOfWeek+ "\")",
                "3 days (from \"Friday\" to \"" + dayOfWeek+ "\")",
                "2 days (from \"Saturday\" to \"" + dayOfWeek+ "\")",
                "1 days (from \"Sunday\" to \"" + dayOfWeek+ "\")",
            }, console.Lines);
        }

        [TestMethod]
        public void Test_DaysUntilTuesday_FromAllDays()
        {
            DayOfWeek dayOfWeek = DayOfWeek.Tuesday;
            FakeConsole console = new FakeConsole();
            Program.DaysUntilWeekday(DayOfWeek.Wednesday, dayOfWeek);
            Program.DaysUntilWeekday(DayOfWeek.Thursday, dayOfWeek);
            Program.DaysUntilWeekday(DayOfWeek.Friday, dayOfWeek);
            Program.DaysUntilWeekday(DayOfWeek.Saturday, dayOfWeek);
            Program.DaysUntilWeekday(DayOfWeek.Sunday, dayOfWeek);
            Program.DaysUntilWeekday(DayOfWeek.Monday, dayOfWeek);
            CollectionAssert.AreEqual(new[] {
                "6 days (from \"Wednesday\" to \"" + dayOfWeek+ "\")",
                "5 days (from \"Thursday\" to \"" + dayOfWeek+ "\")",
                "4 days (from \"Friday\" to \"" + dayOfWeek+ "\")",
                "3 days (from \"Saturday\" to \"" + dayOfWeek+ "\")",
                "2 days (from \"Sunday\" to \"" + dayOfWeek+ "\")",
                "1 days (from \"Monday\" to \"" + dayOfWeek+ "\")",
            }, console.Lines);
        }

        [TestMethod]
        public void Test_DaysUntilWednesday_FromAllDays()
        {
            DayOfWeek dayOfWeek = DayOfWeek.Wednesday;
            FakeConsole console = new FakeConsole();
            Program.DaysUntilWeekday(DayOfWeek.Thursday, dayOfWeek);
            Program.DaysUntilWeekday(DayOfWeek.Friday, dayOfWeek);
            Program.DaysUntilWeekday(DayOfWeek.Saturday, dayOfWeek);
            Program.DaysUntilWeekday(DayOfWeek.Sunday, dayOfWeek);
            Program.DaysUntilWeekday(DayOfWeek.Monday, dayOfWeek);
            Program.DaysUntilWeekday(DayOfWeek.Tuesday, dayOfWeek);
            CollectionAssert.AreEqual(new[] {
                "6 days (from \"Thursday\" to \"" + dayOfWeek+ "\")",
                "5 days (from \"Friday\" to \"" + dayOfWeek+ "\")",
                "4 days (from \"Saturday\" to \"" + dayOfWeek+ "\")",
                "3 days (from \"Sunday\" to \"" + dayOfWeek+ "\")",
                "2 days (from \"Monday\" to \"" + dayOfWeek+ "\")",
                "1 days (from \"Tuesday\" to \"" + dayOfWeek+ "\")",
            }, console.Lines);
        }

        [TestMethod]
        public void Test_DaysUntilThursday_FromAllDays()
        {
            DayOfWeek dayOfWeek = DayOfWeek.Thursday;
            FakeConsole console = new FakeConsole();
            Program.DaysUntilWeekday(DayOfWeek.Friday, dayOfWeek);
            Program.DaysUntilWeekday(DayOfWeek.Saturday, dayOfWeek);
            Program.DaysUntilWeekday(DayOfWeek.Sunday, dayOfWeek);
            Program.DaysUntilWeekday(DayOfWeek.Monday, dayOfWeek);
            Program.DaysUntilWeekday(DayOfWeek.Tuesday, dayOfWeek);
            Program.DaysUntilWeekday(DayOfWeek.Wednesday, dayOfWeek);
            CollectionAssert.AreEqual(new[] {
                "6 days (from \"Friday\" to \"" + dayOfWeek+ "\")",
                "5 days (from \"Saturday\" to \"" + dayOfWeek+ "\")",
                "4 days (from \"Sunday\" to \"" + dayOfWeek+ "\")",
                "3 days (from \"Monday\" to \"" + dayOfWeek+ "\")",
                "2 days (from \"Tuesday\" to \"" + dayOfWeek+ "\")",
                "1 days (from \"Wednesday\" to \"" + dayOfWeek+ "\")",
            }, console.Lines);
        }

        [TestMethod]
        public void Test_DaysUntilFriday_FromAllDays()
        {
            DayOfWeek dayOfWeek = DayOfWeek.Friday;
            FakeConsole console = new FakeConsole();
            Program.DaysUntilWeekday(DayOfWeek.Saturday, dayOfWeek);
            Program.DaysUntilWeekday(DayOfWeek.Sunday, dayOfWeek);
            Program.DaysUntilWeekday(DayOfWeek.Monday, dayOfWeek);
            Program.DaysUntilWeekday(DayOfWeek.Tuesday, dayOfWeek);
            Program.DaysUntilWeekday(DayOfWeek.Wednesday, dayOfWeek);
            Program.DaysUntilWeekday(DayOfWeek.Thursday, dayOfWeek);
            CollectionAssert.AreEqual(new[] {
                "6 days (from \"Saturday\" to \"" + dayOfWeek+ "\")",
                "5 days (from \"Sunday\" to \"" + dayOfWeek+ "\")",
                "4 days (from \"Monday\" to \"" + dayOfWeek+ "\")",
                "3 days (from \"Tuesday\" to \"" + dayOfWeek+ "\")",
                "2 days (from \"Wednesday\" to \"" + dayOfWeek+ "\")",
                "1 days (from \"Thursday\" to \"" + dayOfWeek+ "\")",
            }, console.Lines);
        }

        [TestMethod]
        public void Test_DaysUntilSaturday_FromAllDays()
        {
            DayOfWeek dayOfWeek = DayOfWeek.Saturday;
            FakeConsole console = new FakeConsole();
            Program.DaysUntilWeekday(DayOfWeek.Sunday, dayOfWeek);
            Program.DaysUntilWeekday(DayOfWeek.Monday, dayOfWeek);
            Program.DaysUntilWeekday(DayOfWeek.Tuesday, dayOfWeek);
            Program.DaysUntilWeekday(DayOfWeek.Wednesday, dayOfWeek);
            Program.DaysUntilWeekday(DayOfWeek.Thursday, dayOfWeek);
            Program.DaysUntilWeekday(DayOfWeek.Friday, dayOfWeek);
            CollectionAssert.AreEqual(new[] {
                "6 days (from \"Sunday\" to \"" + dayOfWeek+ "\")",
                "5 days (from \"Monday\" to \"" + dayOfWeek+ "\")",
                "4 days (from \"Tuesday\" to \"" + dayOfWeek+ "\")",
                "3 days (from \"Wednesday\" to \"" + dayOfWeek+ "\")",
                "2 days (from \"Thursday\" to \"" + dayOfWeek+ "\")",
                "1 days (from \"Friday\" to \"" + dayOfWeek+ "\")",
            }, console.Lines);
        }

        [TestMethod]
        public void Test_DaysUntilSunday_FromAllDays()
        {
            DayOfWeek dayOfWeek = DayOfWeek.Sunday;
            FakeConsole console = new FakeConsole();
            Program.DaysUntilWeekday(DayOfWeek.Monday, dayOfWeek);
            Program.DaysUntilWeekday(DayOfWeek.Tuesday, dayOfWeek);
            Program.DaysUntilWeekday(DayOfWeek.Wednesday, dayOfWeek);
            Program.DaysUntilWeekday(DayOfWeek.Thursday, dayOfWeek);
            Program.DaysUntilWeekday(DayOfWeek.Friday, dayOfWeek);
            Program.DaysUntilWeekday(DayOfWeek.Saturday, dayOfWeek);
            CollectionAssert.AreEqual(new[] {
                "6 days (from \"Monday\" to \"" + dayOfWeek+ "\")",
                "5 days (from \"Tuesday\" to \"" + dayOfWeek+ "\")",
                "4 days (from \"Wednesday\" to \"" + dayOfWeek+ "\")",
                "3 days (from \"Thursday\" to \"" + dayOfWeek+ "\")",
                "2 days (from \"Friday\" to \"" + dayOfWeek+ "\")",
                "1 days (from \"Saturday\" to \"" + dayOfWeek+ "\")",
            }, console.Lines);
        }
    }
}
