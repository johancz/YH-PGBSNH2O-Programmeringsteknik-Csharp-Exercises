using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lektion_5_Exercise_3
{
    //Exercise 3
    // Write a program that reverses a string. For example, the input "summer time" should result in the output "emit remmus".
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            string text = "keyboard", reversed = "";

            for (int i = text.Length - 1; i >= 0; i--)
            {
                reversed += text[i];
            }

            Console.WriteLine($"\"{text}\" reversed = \"{reversed}\".");
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Test()
        {
            using FakeConsole console = new FakeConsole();
            Program.Main();
            Assert.AreEqual("\"keyboard\" reversed = \"draobyek\".", console.Output);
        }

        [TestMethod]
        public void Test2()
        {
            using FakeConsole console = new FakeConsole();
            Program.Main();
            Assert.AreEqual("\"keyboard\" reversed = \"draobyek\".", console.Output);
        }
    }
}
