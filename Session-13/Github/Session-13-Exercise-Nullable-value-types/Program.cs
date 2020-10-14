using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Session_13_Exercise_Nullable_value_types
{
    public class Program
    {
        public static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Console.WriteLine("Enter one number on each line, and a blank line when you are done:");
            List<int> numbers = new List<int>();
            bool done = false;
            while (!done)
            {
                string s = Console.ReadLine();
                if (s == "")
                {
                    done = true;
                }
                else
                {
                    // An exception is thrown if the string can't be parsed to a number.
                    int n = int.Parse(s);
                    numbers.Add(n);
                }
            }

            // Numbers can be negative.
            // In the unmodified code (commented) below, if no numbers are entered by the user, -1 is printed as the largest number.
            // This behaviour is incorrect as -1 was not entered by the user.
            //int largest = -1;

            // There are at least two ways to solve this;
            // 1) by checking the length of the array of numbers entered by the user,
            // 2) by making the variable "largest" nullable, "int? largest".
            // Solution 2) is the most applicable for the purpose of this exercise.
            int? largest = null;

            foreach (int n in numbers)
            {
                if (largest == null || n > largest)
                {
                    largest = n;
                }
            }

            if (largest == null)
            {
                Console.WriteLine("No numbers were entered.");
            }
            else
            {
                Console.WriteLine("The largest number is: " + largest);
            }
         }
    }

    //[TestClass]
    //public class ProgramTests
    //{
    //    [TestMethod]
    //    public void ExampleTest()
    //    {
    //        using FakeConsole console = new FakeConsole("First input", "Second input");
    //        Program.Main();
    //        Assert.AreEqual("Hello!", console.Output);
    //    }
    //}
}
