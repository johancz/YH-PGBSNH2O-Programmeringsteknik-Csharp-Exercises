using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Session_7_Exercise_learning_datetime_5_current_datetime_format
{
    public class Program
    {
        public static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            DateTime dt = DateTime.Today;
            String dt_string = dt.ToString("dd/MM/yyyy (a dddd in MMMM)");
            String dt_string2 = dt.ToString("dd/MM/yyyy");
            Console.WriteLine(dt_string);
            Console.WriteLine(dt_string2 + $" (a {dt.DayOfWeek} in {dt.ToString("MMMM")})");
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void ExampleTest()
        {
            using FakeConsole console = new FakeConsole("First input", "Second input");
            Program.Main();
            Assert.AreEqual("Hello!", console.Output);
        }
    }
}
