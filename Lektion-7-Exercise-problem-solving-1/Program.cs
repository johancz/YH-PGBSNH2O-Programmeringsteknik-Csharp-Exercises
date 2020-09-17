using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lektion_7_Exercise_problem_solving_1
{
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Console.Write("Enter a string: ");
            string s = Console.ReadLine();
            Console.Write("How many times should the string be repeated? ");
            int repeat = int.Parse(Console.ReadLine());
            int repeatBackup = repeat;

            Console.WriteLine("String repeated:");

            // Method 1:
            for (int i = 0; i++ < repeat;)
            {
                Console.Write(s);
            }

            Console.WriteLine();

            // Method 2:
            while (repeat-- > 0)
            {
                Console.Write(s);
            }

            Console.WriteLine();
            // Reset
            repeat = repeatBackup;

            // Method 3:
            Console.Write(s);
            while (--repeat > 0)
            {
                Console.Write(s);
            }

            Console.WriteLine();
            // Reset
            repeat = repeatBackup;

            // Method 4:
            do
            {
                Console.Write(s);
            } while (--repeat > 0);
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Test()
        {
            using FakeConsole console = new FakeConsole("First input", "5");
            Program.Main();
            CollectionAssert.AreEqual(new[] {
                "String repeated:",
                "First inputFirst inputFirst inputFirst inputFirst input",
                "First inputFirst inputFirst inputFirst inputFirst input",
                "First inputFirst inputFirst inputFirst inputFirst input",
                "First inputFirst inputFirst inputFirst inputFirst input"
            }, console.Lines);
        }

        [TestMethod, ExpectedException(typeof(FormatException))]
        public void Test_InvalidInput()
        {
            using FakeConsole console = new FakeConsole("First input", "a");
            Program.Main();
        }
    }
}
