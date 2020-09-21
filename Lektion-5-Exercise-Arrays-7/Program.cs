using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lektion_5_Exercise_Arrays_7
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

            int[] numbers0 = new int[size];
            int countZeros = 0;
            Console.WriteLine($"Enter {size} integers below:");
            for (int i = 0; i < size; i++)
            {
                Console.Write($"Integer {i + 1}: ");
                while (!int.TryParse(Console.ReadLine(), out numbers0[i]))
                {
                    Console.WriteLine("That's not an integer, try again:");
                    Console.Write($"Integer {i + 1}: ");
                }

                if (numbers0[i] == 0)
                {
                    countZeros++;
                }
            }

            int[] numbers = new int[size - countZeros];
            for (int i = 0, i2 = 0; i < numbers.Length; i++)
            {
                for (; i2 < size; i2++)
                {
                    if (numbers0[i2] != 0)
                    {
                        numbers[i] = numbers0[i2++];
                        break;
                    }
                }
            }

            Console.WriteLine("Here are your numbers, I took your zeros, think of it as a tax:");
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
        public void Test1()
        {
            using FakeConsole console = new FakeConsole("5", "5", "0", "7", "0", "2");
            Program.Main();
            Assert.AreEqual("5, 7, 2", console.Output);
        }
        [TestMethod]
        public void Test2()
        {
            using FakeConsole console = new FakeConsole("0");
            Program.Main();
            Assert.AreEqual("Here are your numbers, I took your zeros, think of it as a tax:", console.Output);
        }
        [TestMethod]
        public void Test3()
        {
            using FakeConsole console = new FakeConsole("1", "0");
            Program.Main();
            Assert.AreEqual("Here are your numbers, I took your zeros, think of it as a tax:", console.Output);
        }
    }
}
