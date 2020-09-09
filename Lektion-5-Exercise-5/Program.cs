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
            string input = Console.ReadLine(); input = input.Length == 0 ? "happy birthday  HAPPY BIRTHDAY" : input;
            string output = "";

            //foreach (char c in input)
            for (int i = 0; i < input.Length; i++)
            {
                output += (i % 2 == 0) ? input[i] : '*';
            }

            Console.WriteLine(output);
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void ExampleTest()
        {
            using FakeConsole console = new FakeConsole("computer");
            Program.Main();
            Assert.AreEqual("c*m*u*e*", console.Output);
        }
    }
}
