using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lektion_4_Exercise_7
{
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            int grains = 1;
            int total_grains = 1;

            for (int i = 2; i <= 24; ++i)
            {
                total_grains += grains *= 2;
            }
            Console.WriteLine("Total grains: " + total_grains);

            // Bitwise shift :D
            int total_grains2 = (1 << 24) - 1;
            Console.WriteLine("Total grains: " + total_grains2);
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
            Assert.AreEqual("Total grains: 16777215", console.Output);
        }
    }
}
