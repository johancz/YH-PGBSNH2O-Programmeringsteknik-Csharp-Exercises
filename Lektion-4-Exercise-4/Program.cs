using System;
using System.Globalization;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lektion_4_Exercise_4
{
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Console.Write("Countdown from: ");
            if (int.TryParse(Console.ReadLine(), out int countdownFrom))
            {
                while (countdownFrom > 0)
                {
                    Console.WriteLine(countdownFrom--);
                    Thread.Sleep(1000);
                }

                Console.WriteLine("Lift off!");
            }
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void ExampleTest()
        {
            using FakeConsole console = new FakeConsole("5");
            Program.Main();
            CollectionAssert.AreEqual(new[] {
                "5",
                "4",
                "3",
                "2",
                "1",
                "Lift off!"
            }, console.Lines);
        }

        [TestMethod]
        public void TestNegative()
        {
            using FakeConsole console = new FakeConsole("-5");
            Program.Main();
            CollectionAssert.AreEqual(new[] {
                "Lift off!"
            }, console.Lines);
        }
    }
}
