using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lektion_3_Exercise_4
{
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Console.WriteLine("President Possibility Checker");

            Console.WriteLine("What is your countryOfBirth of birth? ");
            string countryOfBirth = Console.ReadLine();

            Console.WriteLine("What is your age? ");
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine("How many times have you been president before? ");
            int termsServed = int.Parse(Console.ReadLine());

            // Variant 2.
            Console.WriteLine("Type \"Yes\" if you very wealthy (as in 1% of the %1 wealhy)? ");
            
            bool isVeryWealthy = Console.ReadLine() == "Yes" ? true : false;
            bool canBePresident = countryOfBirth == "United States" && age >= 35 && termsServed < 2;
            
            if (canBePresident || isVeryWealthy) {
                Console.WriteLine("You can be president!");
            }
            else
            {
                Console.WriteLine("Unfortunately, you cannot be president!");
            }
        }
    }

    [TestClass]
    public class ProgramTests
    {
        string expectedString_canBePresident = "You can be president!";
        string expectedString_cannotBePresident = "Unfortunately, you cannot be president!";

        [TestMethod]
        public void Test1()
        {
            using FakeConsole console = new FakeConsole("United States", "35", "1", "No");
            Program.Main();
            Assert.AreEqual(expectedString_canBePresident, console.Output);
        }
        [TestMethod]
        public void Test2()
        {
            using FakeConsole console = new FakeConsole("United States", "34", "1", "No");
            Program.Main();
            Assert.AreEqual(expectedString_cannotBePresident, console.Output);
        }
        [TestMethod]
        public void Test3()
        {
            using FakeConsole console = new FakeConsole("United States", "34", "1", "Yes");
            Program.Main();
            Assert.AreEqual(expectedString_canBePresident, console.Output);
        }
        [TestMethod]
        public void Test4()
        {
            using FakeConsole console = new FakeConsole("Sweden", "34", "2", "Yes");
            Program.Main();
            Assert.AreEqual(expectedString_canBePresident, console.Output);
        }
        [TestMethod]
        [ExpectedException(typeof(System.FormatException))]
        public void Test5_InvalidStringInput_shouldThrow()
        {
            using FakeConsole console = new FakeConsole("Sweden", "", "", "Yes");
            Program.Main();
        }
        [TestMethod]
        [ExpectedException(typeof(System.FormatException))]
        public void Test6_InvalidStringInput_shouldThrow2()
        {
            using FakeConsole console = new FakeConsole("Sweden", "40", "once", "Yes");
            Program.Main();
        }
        [TestMethod]
        public void Test7()
        {
            using FakeConsole console = new FakeConsole("", "34", "2", "");
            Program.Main();
            Assert.AreEqual(expectedString_cannotBePresident, console.Output);
        }
        public void Test8()
        {
            using FakeConsole console = new FakeConsole("United States", "35", "1", "Yes");
            Program.Main();
            Assert.AreEqual(expectedString_canBePresident, console.Output);
        }
        [TestMethod]
        public void Test9()
        {
            using FakeConsole console = new FakeConsole("", "34", "2", "Yes");
            Program.Main();
            Assert.AreEqual(expectedString_canBePresident, console.Output);
        }
    }
}
