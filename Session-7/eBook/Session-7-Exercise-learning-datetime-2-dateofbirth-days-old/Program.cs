using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Session_7_Exercise_learning_datetime_2_dateofbirth_days_old
{
    public class Program
    {
        public static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            DateTime dateOfBirth, programExecutionDate = default;

            Console.Write("What is your date of birth? ");
            //while (!DateTime.TryParse(Console.ReadLine(), CultureInfo.CreateSpecificCulture("en-GB"), DateTimeStyles.None, out dateOfBirth))
            while (!DateTime.TryParse(Console.ReadLine(), out dateOfBirth))
            {
                Console.Write("Incorrect date-format, try again: ");
            }

            Console.Write("Press enter or end-date: ");
            string input_programExecutionDate = Console.ReadLine();
            do
            {
                Console.Write("Incorrect date-format, try again: ");
                input_programExecutionDate = Console.ReadLine();
            }
            while (input_programExecutionDate.Length > 0 && !DateTime.TryParse(input_programExecutionDate, out programExecutionDate));

            double daysSinceBirth;
            if (input_programExecutionDate.Length > 0)
            {
                daysSinceBirth = HowManyDaysOld(dateOfBirth, DateTime.Parse("January 2020"), 0);
            }
            else
            {
                daysSinceBirth = HowManyDaysOld(dateOfBirth, 0);
            }

            Console.WriteLine(daysSinceBirth);
        }

        public static double HowManyDaysOld(DateTime dateOfBirth, int decimals)
        {
            return HowManyDaysOld(dateOfBirth, DateTime.Now, decimals);
        }

    public static double HowManyDaysOld(DateTime dateOfBirth, DateTime programExecutionDate, int decimals)
        {
            int daysOld = 0;

            TimeSpan difference = programExecutionDate - dateOfBirth;

            return Math.Round(difference.TotalDays, decimals);
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Main_TestOutput_7305daysRoundedToZeroDecimals()
        {
            FakeConsole console = new FakeConsole("January 2000");
            DateTime start = DateTime.Parse("January 2000");
            DateTime end = DateTime.Parse("January 2020");
            Program.Main();
            Assert.AreEqual(7305d, console.Output);
        }
        [TestMethod]
        public void HowManyDaysOld_January2000UntilJanuary2020_7305daysRoundedToZeroDecimals()
        {
            DateTime start = DateTime.Parse("January 2000");
            DateTime end = DateTime.Parse("January 2020");
            double days = Program.HowManyDaysOld(start, end, 0);
            Assert.AreEqual(7305d, days, 1.0d);
        }

        [TestMethod]
        public void HowManyDaysOld_January2000UntilJanuary2020_7305daysRoundedToOneDecimal()
        {
            DateTime start = DateTime.Parse("January 2000");
            DateTime end = DateTime.Parse("January 2020");
            double days = Program.HowManyDaysOld(start, end, 0);
            Assert.AreEqual(7305d, days, 1.0d);
        }

        [TestMethod]
        public void HowManyDaysOld_January2000UntilDateTimeNow_7305daysRoundedToOneDecimal()
        {
            DateTime start = DateTime.Parse("January 2000");
            DateTime now = DateTime.Now;
            double days = Program.HowManyDaysOld(start, 0);
            Assert.AreEqual(7305d, days, 1.0d);
        }
    }
}
