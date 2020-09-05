using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lektion_4_Exercise_1
{
    public class Program
    {
        public static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            while (true)
            {
                //if (!Console.KeyAvailable)
                //{
                //    continue;
                //}

                //ConsoleKeyInfo key = Console.ReadKey();
                //if (key.Key == ConsoleKey.Escape)
                //{
                //    break;
                //}

                // Combine ReadKey and ReadLine.
                //string input = ("\r" + key.KeyChar + Console.ReadLine() + "\n").Trim(new[] { '\b' });
                Console.WriteLine("Press 'x' to exit.");
                Console.WriteLine("Enter two numbers (with a space inbetween): ");
                string input = Console.ReadLine();

                if (input.Trim() == "x")
                {
                    break;
                    //Environment.Exit(0);
                }

                // Split the input-string into an array.
                string[] inputArray = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int n1, n2;
                bool foundTwoNumbersInString = false;

                if (inputArray.Length < 2)
                {
                    Console.WriteLine("Not enough numbers entered. Try again.");
                    continue;
                }

                // Check if numbers in the string[] can be parsed to integers. The & operator evaluates both operands.
                foundTwoNumbersInString = int.TryParse(inputArray[0], out n1) & int.TryParse(inputArray[1], out n2);

                if (!foundTwoNumbersInString)
                {
                    Console.WriteLine("You did not enter two valid numbers. Try again.");
                    continue;
                }

                string outputString = "";

                for (; n1 <= n2; ++n1)
                {
                    outputString += n1 + " ";
                }

                outputString = outputString.TrimEnd();

                Console.WriteLine($"outputString: {outputString}");
                Console.WriteLine();
                //printMainMenuText();
            }
        }

        public static void printMainMenuText()
        {
            //Console.WriteLine("Press 'ESC' to exit.");
            Console.WriteLine("Press 'x' to exit.");
            Console.WriteLine("Enter two numbers (with a space inbetween): ");
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void ExampleTest()
        {
            using FakeConsole console = new FakeConsole("2 5", "x");
            Program.Main();
            Debug.WriteLine(String.Join("\n", console.Lines));
            CollectionAssert.AreEqual(new[] {
                "outputString: 2 3 4 5",
                "",
                "Press 'x' to exit.",
                "Enter two numbers (with a space inbetween):"
            }, console.Lines);
        }
    }
}
