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
            Assert.AreEqual("", console.Output);
        }
    }
}
