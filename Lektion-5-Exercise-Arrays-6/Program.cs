using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lektion_5_Exercise_Arrays_6
{
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

            // Method 1:
            int[] numbers0 = new int[size];
            Console.WriteLine($"Enter {size} integers below:");
            for (int i = 0; i < size; i++)
            {
                Console.Write($"Integer {i + 1}: ");
                while (!int.TryParse(Console.ReadLine(), out numbers0[i]))
                {
                    Console.WriteLine("That's not an integer, try again:");
                    Console.Write($"Integer {i + 1}: ");
                }
            }

            // Method 1.1
            //int[] numbers = new int[size * 2];
            //for (int i = 0; i < size; i++)
            //{
            //    numbers[i] = numbers0[i];
            //}
            //for (int i = size; i < numbers.Length; i++)
            //{
            //    numbers[i] = numbers0[i - 3];
            //}

            // Method 1.2
            int[] numbers = new int[size * 2];
            for (int i = 0; i < numbers.Length; i++)
            {
                //numbers[i] = numbers0[i - size * (i / size)];
                numbers[i] = numbers0[i % size];
            }

            // Method 2:
            //int[] numbers = new int[size * 2];
            //Console.WriteLine($"Enter {size} integers below:");
            //for (int i = 0; i < size; i++)
            //{
            //    int n;

            //    Console.Write($"Integer {i + 1}: ");
            //    while (!int.TryParse(Console.ReadLine(), out n))
            //    {
            //        Console.WriteLine("That's not an integer, try again:");
            //        Console.Write($"Integer {i + 1}: ");
            //    }

            //    numbers[i] = numbers[i + size] = n;
            //}

            Console.WriteLine("Here are your numbers, repeated incase you forgot the numbers the first time you read them:");
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + (i < numbers.Length - 1 ? ", " : ""));
            }
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Test()
        {
            using FakeConsole console = new FakeConsole("3", "1", "2", "3");
            Program.Main();
            Assert.AreEqual("1, 2, 3, 1, 2, 3", console.Output);
        }

        [TestMethod]
        public void Test2()
        {
            using FakeConsole console = new FakeConsole("0");
            Program.Main();
            Assert.AreEqual("Here are your numbers, repeated incase you forgot the numbers the first time you read them:", console.Output);
        }
    }
}
