using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
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

            Console.Write("Enter a string of numbers separated with commas: ");
            string input = Console.ReadLine();
            int[] _numbers = new int[input.Length];
            int index = 0;

            string _stringnumber = "";
            for (int i = 0, len = input.Length; i < len; i++)
            {
                char c = input[i];

                //if (c >= 48 && c <= 57)
                if (c - '0' >= 0 && c - '0' <= 9)
                {
                    _stringnumber += c;
                }

                if (c == ',' || i + 1 == len)
                {
                    int.TryParse(_stringnumber, out _numbers[index++]);
                    _stringnumber = "";
                }
            }

            int[] numbers = new int[index];
            int[] numbersMultiplied = new int[index];
            for (int i = 0; i < index; i++)
            {
                numbersMultiplied[i] = numbers[i] = _numbers[i];
                numbersMultiplied[i] *= 2;
            }

            for (int i = 0; i < index; i++)
            {
                Console.WriteLine($"{numbers[i]} * 2 = {numbersMultiplied[i]}");
            }
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void ExampleTest()
        {
            using FakeConsole console = new FakeConsole("3,3004,35,500,40");
            Program.Main();
            CollectionAssert.AreEqual(new[] {
            "3 * 2 = 6",
            "3004 * 2 = 6008",
            "35 * 2 = 70",
            "500 * 2 = 1000",
            "40 * 2 = 80"
            }, console.Lines);
        }

        [TestMethod]
        public void ExampleTest2()
        {
            using FakeConsole console = new FakeConsole("FF3,30f04,35x0%,5$00,-40");
            Program.Main();
            CollectionAssert.AreEqual(new[] {
            "3 * 2 = 6",
            "3004 * 2 = 6008",
            "350 * 2 = 700",
            "500 * 2 = 1000",
            "40 * 2 = 80"
            }, console.Lines);
        }
    }
}
