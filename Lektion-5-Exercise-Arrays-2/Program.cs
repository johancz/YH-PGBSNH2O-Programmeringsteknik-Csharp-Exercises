using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lektion_5_Exercise_Arrays_2
{
    // Write a program that doubles all integers in an array of integers. For example, the array { 5, 12, 4 } should become { 10, 24, 8 }.
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            int size;
            Console.Write("How many integers do you want? ");
            while (!int.TryParse(Console.ReadLine(), out size))
            {
                Console.WriteLine("That's not an integer, try again:");
                Console.Write("How many integers do you want? ");
            }

            int[] numbers = new int[size];

            Console.WriteLine($"Enter {size} integers below:");

            for (int i = 0; i < size; i++)
            {
                Console.Write($"Integer {i + 1}: ");
                while (!int.TryParse(Console.ReadLine(), out numbers[i]))
                {
                    Console.WriteLine("That's not an integer, try again:");
                    Console.Write($"Integer {i + 1}: ");
                }
            }

            Console.WriteLine("I doubled the numbers for you:");
            for (int i = 0; i < size; i++)
            {
                numbers[i] *= 2;
            }

            foreach (int n in numbers)
            {
                Console.WriteLine(n);
            }
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void ExampleTest()
        {
            using FakeConsole console = new FakeConsole("First input", "Second input");
            Program.Main();
            Assert.AreEqual("Hello!", console.Output);
        }
    }
}
