using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Session_7_Exercise_learning_datetime_2_variant_1_fancy_date_selector
{
    public class Program
    {
        public static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            DateTime dateOfBirth, programExecutionDate = default;

            FancyDateSelector.Init(5);

            //Console.Write("What is your date of birth? ");
            ////while (!DateTime.TryParse(Console.ReadLine(), CultureInfo.CreateSpecificCulture("en-GB"), DateTimeStyles.None, out dateOfBirth))
            //while (!DateTime.TryParse(Console.ReadLine(), out dateOfBirth))
            //{
            //    Console.Write("Incorrect date-format, try again: ");
            //}

            //Console.Write("Press enter or end-date: ");
            //string input_programExecutionDate = Console.ReadLine();
            //do
            //{
            //    Console.Write("Incorrect date-format, try again: ");
            //    input_programExecutionDate = Console.ReadLine();
            //}
            //while (input_programExecutionDate.Length > 0 && !DateTime.TryParse(input_programExecutionDate, out programExecutionDate));

            //double daysSinceBirth;
            //if (input_programExecutionDate.Length > 0)
            //{
            //    daysSinceBirth = HowManyDaysOld(dateOfBirth, DateTime.Parse("January 2020"), 0);
            //}
            //else
            //{
            //    daysSinceBirth = HowManyDaysOld(dateOfBirth, 0);
            //}

            //Console.WriteLine(daysSinceBirth);
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

    public static class FancyDateSelector
    {
        public static int Selected { get; private set; }

        public static DateTime Now;
        public static int Year { get; private set; }
        public static int Month { get; private set; }
        public static int Day { get; private set; }
        public static int DaysInMonth { get; private set; }

        public static void Init(int rows)
        {
            Selected = 0;
            Now = DateTime.Now;
            Year = Now.Year;
            Month = Now.Month;
            Day = Now.Day;
            DaysInMonth = DateTime.DaysInMonth(Now.Year, Now.Month);

            Console.WriteLine("now.Month: " + Month);
            Console.WriteLine("now.Day: " + Day);
            Console.WriteLine("DateTime.DaysInMonth(now.Year, now.Month): " + DaysInMonth);

            bool exitProgram = false;

            while (!exitProgram)
            {
                if (!Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();

                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.LeftArrow:
                            NavigateSelectors(-1, 0);
                            DrawMenu();
                            break;
                        case ConsoleKey.RightArrow:
                            NavigateSelectors(1, 0);
                            DrawMenu();
                            break;
                        case ConsoleKey.UpArrow:
                            NavigateSelectors(0, -1);
                            DrawMenu();
                            break;
                        case ConsoleKey.DownArrow:
                            NavigateSelectors(0, 1);
                            DrawMenu();
                            break;
                        case ConsoleKey.Escape:
                            exitProgram = true;
                            break;
                    }
                } // end of 'else' of 'if (!Console.KeyAvailable)'
            } // end of 'while (true)'
        } // end of 'public static void FancyDateSelector()'

        private static void DrawMenu()
        {
            Console.WriteLine("now.ToString(\"MMMM\")): " + Now.ToString("MMMM"));

            Console.Clear();
            Console.WriteLine("Year:\tMonth:\t\tDay:");
            Console.WriteLine(Now.Year + "\t" + Now.Month + "\t\t" + Now.Day);
            Thread.Sleep(100);
        }

        // Summary:
        //     Navigates between and in the selectors.
        //
        // Parameters:
        //   horizontal:
        //     Can be; -1 for moving left, 0 for no change, 1 for moving right
        //   vertical:
        //     Can be; -1 for moving up, 0 for no change, 1 for moving down
        public static void NavigateSelectors(int horizontal, int vertical)
        {
            // Calculate what to draw:
            // Depending on 'Key'

            if (vertical == -1 || vertical == 1)
            {
                if (Selected == 0)
                {
                    Now.AddYears(vertical);
                }
                else if (Selected == 1)
                {
                    Now.AddMonths(vertical);
                }
                else if (Selected == 2)
                {
                    Now.AddDays(vertical);
                }
            } // end of 'if (vertical == -1 || vertical == 1)'
            else if (horizontal == -1 || horizontal == 1)
            {
                if (horizontal == -1)
                {
                    if (Selected == 0)
                    {
                        Selected = 2;
                    }
                    else
                    {
                        Selected--;
                    }
                } // end of 'if (horizontal == -1)'
                else if (horizontal == 1)
                {
                    if (Selected == 2)
                    {
                        Selected = 0;
                    }
                    else
                    {
                        Selected++;
                    }
                } // end of 'else if (horizontal == 1)'
            } // end of 'else if (horizontal == -1 || horizontal == 1)'
        } // end of 'public static void NavigateSelectors(int horizontal, int vertical)'
    } // end of 'public static class FancyDateSelector'

    [TestClass]
    public class ProgramTests
    {
        //    [TestMethod]
        //    public void Main_TestOutput_7305daysRoundedToZeroDecimals()
        //    {
        //        FakeConsole console = new FakeConsole("January 2000");
        //        DateTime start = DateTime.Parse("January 2000");
        //        DateTime end = DateTime.Parse("January 2020");
        //        Program.Main();
        //        Assert.AreEqual(7305d, console.Output);
        //    }
        //    [TestMethod]
        //    public void HowManyDaysOld_January2000UntilJanuary2020_7305daysRoundedToZeroDecimals()
        //    {
        //        DateTime start = DateTime.Parse("January 2000");
        //        DateTime end = DateTime.Parse("January 2020");
        //        double days = Program.HowManyDaysOld(start, end, 0);
        //        Assert.AreEqual(7305d, days, 1.0d);
        //    }

        //    [TestMethod]
        //    public void HowManyDaysOld_January2000UntilJanuary2020_7305daysRoundedToOneDecimal()
        //    {
        //        DateTime start = DateTime.Parse("January 2000");
        //        DateTime end = DateTime.Parse("January 2020");
        //        double days = Program.HowManyDaysOld(start, end, 0);
        //        Assert.AreEqual(7305d, days, 1.0d);
        //    }

        //    [TestMethod]
        //    public void HowManyDaysOld_January2000UntilDateTimeNow_7305daysRoundedToOneDecimal()
        //    {
        //        DateTime start = DateTime.Parse("January 2000");
        //        DateTime now = DateTime.Now;
        //        double days = Program.HowManyDaysOld(start, 0);
        //        Assert.AreEqual(7305d, days, 1.0d);
        //    }
    }
}

