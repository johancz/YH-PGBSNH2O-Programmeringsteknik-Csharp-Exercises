using System;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lektion_5_Exercise_Arrays_1
{
    // Write a program that asks the user for a number, then reads that number of integers from the user and stores them in an array. After this, it should write the square of each integer (x^2) to the console.

    //Here is an example of what running the program should look like:
    //    How many integers do you want? 3
    //    Enter 3 integers below:
    //    5
    //    4
    //    7
    //    Here are the squares of your integers:
    //    25
    //    16
    //    49

    //Use the code from this exercise in the upcoming exercises below, to put user-provided values in an array in the same way.

    //Note: Having to tell the computer in advance how many values you want to provide might seem like a bad user experience, and it is, but at this point we need to do it because arrays have a fixed size.In future exercises, we will handle any number of values without having to count them beforehand.
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
                    Console.Write($"Integer {i+1}: ");
                }
            }

            Console.WriteLine("Here are the squares of your integers:");
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"Sqrt of {numbers[i]} is {Math.Pow(numbers[i], 2)}");
            }
        }


    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void ExampleTest()
        {
            throw new NotImplementedException();
            using FakeConsole console = new FakeConsole("First input", "Second input");
            Program.Main();
            Assert.AreEqual("Hello!", console.Output);
        }
    }
}
