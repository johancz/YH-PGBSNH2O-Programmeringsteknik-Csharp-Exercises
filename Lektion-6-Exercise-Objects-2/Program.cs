using System;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lektion_6_Exercise_Objects_2
{
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Console.Write("Enter a personnummer: ");
            string personnummer = Console.ReadLine();
            personnummer = personnummer.Length > 0 ? personnummer : "19810203-1234";

            string yearOfBirth = personnummer.Substring(0, 4);
            //string gender = (personnummer.Substring(personnummer.Length - 2, 1) % 2 == 0) ? "woman" : "man";
            string gender = (personnummer[11] % 2 == 0) ? "woman" : "man";

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
            Assert.AreEqual("This is a man born in 1981", console.Output);
        }
    }
}
