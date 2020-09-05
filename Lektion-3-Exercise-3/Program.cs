using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lektion_3_Exercise_3
{
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Console.WriteLine("Enter your indoor temperature (C): ");
            float tempCelsius = float.Parse(Console.ReadLine());

            Console.WriteLine("Choose exercise variant (1 or 2): ");
            int variant = int.Parse(Console.ReadLine());

            switch (variant)
            {
                case 1: Exercise3_Variant1(tempCelsius); break;
                case 2: Exercise3_Variant2(tempCelsius); break;
                default: Console.WriteLine("Try again!"); Main(); break;
            }
        }

        public static void Exercise3_Variant1(float tempCelsius)
        {
            Console.WriteLine("Exercise variant 1:");
            Console.WriteLine(
                (tempCelsius >= 18 && tempCelsius <= 26 ? "Appropriate" : "Unacceptable")
                + " temperature!");
        }

        public static void Exercise3_Variant2(float tempCelsius)
        {
            Console.WriteLine("Exercise variant 1:");
            if (tempCelsius < 18)
            {
                Console.WriteLine("Unacceptable temperature! Temperature too low.");
            }
            else if (tempCelsius > 26)
            {
                Console.WriteLine("Unacceptable temperature! Temperature too high.");
            }
            else
            {
                Console.WriteLine("Appropriate temperature!");
            }

        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Test_Exercise3_Variant1_InvalidTemperature1()
        {
            using FakeConsole console = new FakeConsole("17", "1");
            Program.Main();
            Assert.AreEqual("Unacceptable temperature!", console.Output);
        }
        [TestMethod]
        public void Test_Exercise3_Variant1_ValidTemperature1()
        {
            using FakeConsole console = new FakeConsole("18", "1");
            Program.Main();
            Assert.AreEqual("Appropriate temperature!", console.Output);
        }
        [TestMethod]
        public void Test_Exercise3_Variant1_ValidTemperature2()
        {
            using FakeConsole console = new FakeConsole("26", "1");
            Program.Main();
            Assert.AreEqual("Appropriate temperature!", console.Output);
        }
        [TestMethod]
        public void Test_Exercise3_Variant1_InvalidTemperature2()
        {
            using FakeConsole console = new FakeConsole("27", "1");
            Program.Main();
            Assert.AreEqual("Unacceptable temperature!", console.Output);
        }

        [TestMethod]
        public void Test_Exercise3_Variant2_InvalidTemperature1()
        {
            using FakeConsole console = new FakeConsole("17", "2");
            Program.Main();
            Assert.AreEqual("Unacceptable temperature! Temperature too low.", console.Output);
        }
        [TestMethod]
        public void Test_Exercise3_Variant2_ValidTemperature1()
        {
            using FakeConsole console = new FakeConsole("18", "2");
            Program.Main();
            Assert.AreEqual("Appropriate temperature!", console.Output);
        }
        [TestMethod]
        public void Test_Exercise3_Variant2_ValidTemperature2()
        {
            using FakeConsole console = new FakeConsole("26", "2");
            Program.Main();
            Assert.AreEqual("Appropriate temperature!", console.Output);
        }
        [TestMethod]
        public void Test_Exercise3_Variant2_InvalidTemperature2()
        {
            using FakeConsole console = new FakeConsole("27", "2");
            Program.Main();
            Assert.AreEqual("Unacceptable temperature! Temperature too high.", console.Output);
        }
    }
}
