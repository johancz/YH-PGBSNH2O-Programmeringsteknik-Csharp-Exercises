using System;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lektion_5_Exercise_Arrays_5
{
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            int size;
            Console.Write("How many integers do you want (at least 1)? ");
            while (!int.TryParse(Console.ReadLine(), out size) || size < 1)
            {
                Console.WriteLine("That's not a valid integer, try again:");
                Console.Write("How many integers do you want? ");
            }

            int[] numbers = new int[size];
            int countAbove10 = 0;
            Console.WriteLine($"Enter {size} integers below:");
            for (int i = 0; i < size; i++)
            {
                Console.Write($"Integer {i + 1}: ");
                while (!int.TryParse(Console.ReadLine(), out numbers[i]))
                {
                    Console.WriteLine("That's not an integer, try again:");
                    Console.Write($"Integer {i + 1}: ");
                }

                if (numbers[i] > 10)
                {
                    countAbove10++;
                }
            }

            Console.WriteLine();
            Console.WriteLine("countAbove10: " + countAbove10);
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void ExampleTest()
        {
            using FakeConsole console = new FakeConsole("5", "-11", "-10", "0", "10", "11");
            Program.Main();
            Assert.AreEqual("countAbove10: 1", console.Output);
        }
    }
}
