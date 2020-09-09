using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lektion_5_Exercise_5
{
    // Write a program that replaces every other character of a string with an asterisk. For example, the input "computer" should result in the output "c*m*u*e*".
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Console.Write("Input some text: ");
            //string input = Console.ReadLine();
            Console.ReadLine(); string input = "happy birthday HAPPY BIRTHDAY";
            int count_aA = 0;

            foreach (char c in input)
            {
                if (c == 'a' || c == 'A')
                {
                    count_aA++;
                }
            }

            Console.WriteLine($"aA count: {count_aA}.");
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void ExampleTest()
        {
            using FakeConsole console = new FakeConsole("happy birthday HAPPY BIRTHDAY");
            Program.Main();
            Assert.AreEqual("aA count: 4.", console.Output);
        }
    }
}
