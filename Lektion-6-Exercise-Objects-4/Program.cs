using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lektion_6_Exercise_Objects_4
{
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Console.WriteLine("Enter some numbers, enter an empty line to finish:");

            string outputString = "The sum of";
            List<int> numbers = new List<int>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input.Length == 0) {
                    break;
                }

                if (int.TryParse(input, out int n))
                {
                    numbers.Add(n);
                    outputString += $" + {n}";
                }
            }

            Console.WriteLine("The sum of " + string.Join(" + ", numbers) + " = " + numbers.Sum() + ".");
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void ExampleTest()
        {
            using FakeConsole console = new FakeConsole("100", "52", "500", "10000", "7", "");
            Program.Main();
            Assert.AreEqual("The sum of 100 + 52 + 500 + 10000 + 7 = 10659.", console.Output);
        }
    }
}
