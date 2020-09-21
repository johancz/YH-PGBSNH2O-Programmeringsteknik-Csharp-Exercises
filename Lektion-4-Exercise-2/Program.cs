using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lektion_4_Exercise_2
{
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            int i;

            if (int.TryParse(Console.ReadLine(), out i))
            {
                if (i < 0)
                {
                    Console.WriteLine("Please enter a positive number.");
                    Environment.Exit(0);
                }

                int product = i;
                string output = $"The product of '{i}' is:";

                while (i > 1)
                {
                    product *= --i;
                }

                Console.WriteLine($"{output} {product}");
            }
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void TestIntAbove0()
        {
            using FakeConsole console = new FakeConsole("5");
            Program.Main();
            Assert.AreEqual("The factorial of '5' is: 120", console.Output);
        }

        [TestMethod]
        public void Test0()
        {
            using FakeConsole console = new FakeConsole("0");
            Program.Main();
            Assert.AreEqual("The factorial of '0' is: 1", console.Output);
        }

        [TestMethod]
        public void TestNegativeNumber()
        {
            using FakeConsole console = new FakeConsole("-1");
            Program.Main();
            Assert.AreEqual("Please enter a positive number.", console.Output);
        }
    }
}
