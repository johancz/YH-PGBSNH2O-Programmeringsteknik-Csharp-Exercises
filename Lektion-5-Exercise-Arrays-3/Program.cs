using System;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Added_Lektion_5_Exercise_Arrays_3
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

            int[] numbers = new int[size];
            int[] numbersUnmodified = new int[size];
            Console.WriteLine($"Enter {size} integers below:");
            for (int i = 0; i < size; i++)
            {
                Console.Write($"Integer {i + 1}: ");
                while (!int.TryParse(Console.ReadLine(), out numbers[i]))
                {
                    Console.WriteLine("That's not an integer, try again:");
                    Console.Write($"Integer {i + 1}: ");
                }

                numbersUnmodified[i] = numbers[i];
            }

            // Replace every other integer 0
            for (int i = 0; i < size; i += 2)
            {
                numbers[i] = 0;
            }

            Console.WriteLine();
            Console.WriteLine("Every other integer replaced with 0:");
            Console.WriteLine(String.Join(", ", numbersUnmodified) + " ---> " + String.Join(", ", numbers));
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
