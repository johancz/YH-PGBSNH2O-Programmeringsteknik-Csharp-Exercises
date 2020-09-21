using System;
using System.Diagnostics;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lektion_6_Exercise_Objects_2
{
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Exercise();
        }

        public static void Exercise()
        {
            Console.Write("Enter a personnummer (in this format: yyyymmdd-xxxx): ");
            string personnummer = Console.ReadLine();
            //personnummer = personnummer.Length > 0 ? personnummer : "19810203-1234";

            if (personnummer.Length != 13)
            {
                Console.WriteLine("Invalid personnummer!");
                return;
            }

            string yearOfBirth_substring = personnummer.Substring(0, 4);
            int yearOfBirth;

            if (!int.TryParse(yearOfBirth_substring, out yearOfBirth)
                || personnummer.Substring(8, 1) != "-")
            {
                Console.WriteLine("Invalid personnummer!");
                return;
            }

            string lastFourDigits_substring = personnummer.Substring(9, 4);
            if (!int.TryParse(lastFourDigits_substring, out int _))
            {
                Console.WriteLine("Invalid personnummer!");
                return;
            }

            string gender = int.Parse(personnummer.Substring(personnummer.Length - 2, 1)) % 2 == 0 ? "woman" : "man";
            //string gender = (personnummer[11] % 2 == 0) ? "woman" : "man";
            //string gender = int.Parse(lastFourDigits_substring.Substring(2, 1)) % 2 == 0 ? "woman" : "man";
            //string gender = (lastFourDigits_substring[2] % 2 == 0) ? "woman" : "man";

            Console.WriteLine("This is a " + gender + " born in " + yearOfBirth);
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Test()
        {
            using FakeConsole console = new FakeConsole("19810203-1234");
            Program.Main();
            string s = "";
            Assert.AreEqual("This is a man born in 1981", console.Output);
        }

        [TestMethod]
        public void Test2()
        {
            using FakeConsole console = new FakeConsole("19810203-123");
            Program.Main();
            Assert.AreEqual("Invalid personnummer!", console.Output);
        }

        [TestMethod]
        public void Test3()
        {
            using FakeConsole console = new FakeConsole("");
            Program.Main();
            Assert.AreEqual("Invalid personnummer!", console.Output);
        }

        [TestMethod]
        public void Test4()
        {
            using FakeConsole console = new FakeConsole("-------------");
            Program.Main();
            Assert.AreEqual("Invalid personnummer!", console.Output);
        }
    }
}
