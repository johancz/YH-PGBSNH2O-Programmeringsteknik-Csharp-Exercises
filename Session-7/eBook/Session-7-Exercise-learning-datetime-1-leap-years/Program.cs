using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Session_7_Exercise_learning_datetime_1_leap_years
{
    public class Program
    {
        public static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            for (int i = 2000; i < DateTime.Now.Year; i++)
            {
                Console.WriteLine($"{i} is{(DateTime.IsLeapYear(i) ? " " :  " not ")}a leap year.");
            }

        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void AssertOutput_fromYear2000()
        {
            using FakeConsole console = new FakeConsole();
            Program.Main();
            CollectionAssert.AreEqual(new[] {
                "2000 is a leap year.",
                "2001 is not a leap year.",
                "2002 is not a leap year.",
                "2003 is not a leap year.",
                "2004 is a leap year.",
                "2005 is not a leap year.",
                "2006 is not a leap year.",
                "2007 is not a leap year.",
                "2008 is a leap year.",
                "2009 is not a leap year.",
                "2010 is not a leap year.",
                "2011 is not a leap year.",
                "2012 is a leap year.",
                "2013 is not a leap year.",
                "2014 is not a leap year.",
                "2015 is not a leap year.",
                "2016 is a leap year.",
                "2017 is not a leap year.",
                "2018 is not a leap year.",
                "2019 is not a leap year."
            }, console.Lines);
        }
    }
}
