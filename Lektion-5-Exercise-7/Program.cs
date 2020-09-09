using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lektion_5_Exercise_7
{
    // Write a program that removes all spaces at the start of a string (or "trims" it). For example, the input " welcome home" should result in the output "welcome home".
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Console.Write("Input some text: ");
            string input = Console.ReadLine(); input = input.Length == 0 ? "  w  elcome  home" : input;
            string output = "";

            bool foundFirstNonSpace = false;
            foreach (char c in input)
            {
                if (!foundFirstNonSpace)
                {
                    if (c == ' ')
                    {
                        continue;
                    }

                    foundFirstNonSpace = true;
                }

                output += c;
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
            using FakeConsole console = new FakeConsole("  w  elcome  home");
            Program.Main();
            Assert.AreEqual("w  elcome  home", console.Output);
        }
    }
}
