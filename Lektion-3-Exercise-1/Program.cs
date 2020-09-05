using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lektion_3_Exercise_1
{
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Console.WriteLine("Hello mister/madam, I am from Microsoft adn you have virus on youre PC. Too fix this I need you're pasword.");
            Console.WriteLine("Plaese enter your passvord:");

            string password = Console.ReadLine();

            if (password == "secret123")
            {
                Console.WriteLine("Access granted!");
            }
            else
            {
                Console.WriteLine("Access denied!");
            }
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Test_CorrectPassord()
        {
            using FakeConsole console = new FakeConsole("secret123");
            Program.Main();
            Assert.AreEqual("Access granted!", console.Output);
        }
        [TestMethod]
        public void Test_IncorrectPassord()
        {
            using FakeConsole console = new FakeConsole("secret1234");
            Program.Main();
            Assert.AreEqual("Access denied!", console.Output);
        }
    }
}
