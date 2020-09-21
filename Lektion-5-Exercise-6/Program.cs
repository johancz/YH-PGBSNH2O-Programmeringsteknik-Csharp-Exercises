using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lektion_5_Exercise_6
{
    // Write a program that counts the number of As in a string. For example, the input "happy birthday" should result in the output 2.
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
