using System;
using System.Globalization;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lektion_5_Exercise_1
{
    // Exercise 2
    // Write a program that inserts hyphens between each character of a string. For example, the input "abcd" should result in the output "a-b-c-d". Make sure that there is no hyphen after the last letter.

    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            string keyboard = "keyboard", keyboar = "";

            for (int i = 0; i < keyboard.Length - 1; i++)
            {
                keyboar += keyboard[i];
            }

            Console.WriteLine($"If you remove the last character of \"{keyboard}\" you get \"{keyboar}\".");
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void ExampleTest()
        {
            using FakeConsole console = new FakeConsole();
            Program.Main();
            Assert.AreEqual("If you remove the last character of \"keyboard\" you get \"keyboar\".", console.Output);
        }
    }
}
