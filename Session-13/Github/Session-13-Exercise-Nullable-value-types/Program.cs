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
                    int n = int.Parse(s);
                    numbers.Add(n);
                }
            }

            int largest = -1;
            foreach (int n in numbers)
            {
                if (n > largest)
                {
                    largest = n;
                }
            }
            Console.WriteLine("The largest number is: " + largest);
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
