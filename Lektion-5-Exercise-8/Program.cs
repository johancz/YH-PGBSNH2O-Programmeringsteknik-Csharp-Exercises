using System;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lektion_5_Exercise_8
{
    // Write a program that removes all spaces at the start and end of a string, but no spaces between words. For example, the input " welcome home " should result in the output "welcome home".
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Console.Write("Input some text: ");
            // For debug:
            //string input = Console.ReadLine(); input = input.Length == 0 ? "  w  elcome  home     " : input;
            string input = Console.ReadLine();
            string output = "";

            int firstNonSpaceI = -1;
            int lastNonSpaceI = -1;
            char[] a = Environment.NewLine.ToCharArray();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != ' ')
                {
                    firstNonSpaceI = i;
                    break;
                }
            }

            for (int i = input.Length - 1; i >= 0; i--)
            {
                if (input[i] != ' ')
                {
                    lastNonSpaceI = i;
                    break;
                }
            }

            if (firstNonSpaceI > -1)
            {
                for (int i = firstNonSpaceI; i <= lastNonSpaceI; i++)
                {
                    output += input[i];
                }
            }

            Console.WriteLine($"|{output}|");
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Test_EmptyInputString()
        {
            using FakeConsole console = new FakeConsole("");
            Program.Main();
            Assert.AreEqual("||", console.Output);
        }

        [TestMethod]
        public void Test_SpacesBeforeAndAfter()
        {
            using FakeConsole console = new FakeConsole("  w  elcome  home     ");
            Program.Main();
            Assert.AreEqual("|w  elcome  home|", console.Output);
        }

        [TestMethod]
        public void Test_SpacseBeforeOnly()
        {
            using FakeConsole console = new FakeConsole("  w  elcome  home");
            Program.Main();
            Assert.AreEqual("|w  elcome  home|", console.Output);
        }

        [TestMethod]
        public void Test_SpacesAfterOnly()
        {
            using FakeConsole console = new FakeConsole("w  elcome  home     ");
            Program.Main();
            Assert.AreEqual("|w  elcome  home|", console.Output);
        }

        [TestMethod]
        public void Test_OnlySpaces()
        {
            using FakeConsole console = new FakeConsole("     ");
            Program.Main();
            Assert.AreEqual("||", console.Output);
        }
    }
}
