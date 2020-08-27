using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lektion_2
{
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Console.WriteLine("Choose which exercise to run (1-7:");

            ConsoleKeyInfo key = Console.ReadKey();
            Console.WriteLine("");
            int i_key;
            int.TryParse(key.KeyChar.ToString(), out i_key);
            switch (i_key) {
                case 1:
                    Program.exercise1();
                    break;
                case 2:
                    Program.exercise2();
                    break;
                case 3:
                    Program.exercise3();
                    break;
                case 4:
                    Exercises.Exercise4();
                    break;
                case 5:
                    Exercises.Exercise5();
                    break;
                case 6:
                    Exercises.Exercise6();
                    break;
                case 7:
                    Exercises.Exercise7();
                    break;
                default:
                    Console.WriteLine("Invalid key");
                    break;
            }
            //int key = int.Parse(Console.ReadKey());
            //Exercises.Run();
            //Program.exercise1();
            //Program.exercise2();
            //Program.exercise3();
            //Exercises.Exercise4();
            //Exercises.Exercise5();
            //Exercises.Exercise6();
        }

        public static void exercise1()
        {
            Console.WriteLine("--- Exercise 1");
            int expression1 = 5 + 2;
            int expression2 = 5 + 2 * 7;
            double expression3 = (10 + 2) / 3;
            double expression4 = (3 * 8) / (4 * 2);

            Console.WriteLine(expression1);
            Console.WriteLine(expression2);
            Console.WriteLine(expression3);
            Console.WriteLine(expression4);

            Console.WriteLine(Environment.NewLine);
        }

        public static void exercise2()
        {
            Console.WriteLine("--- Exercise 2");

            double cash;
            double bank;

            /* Read, parse and validate user input. */

            while (true)
            {
                Console.Write("Cash ($):");
                string s_cash = Console.ReadLine();

                if (double.TryParse(s_cash, out cash))
                {
                    break;
                }
            }

            while (true)
            {
                Console.Write("Bank ($):");
                string s_bank = Console.ReadLine();

                if (double.TryParse(s_bank, out bank))
                {
                    break;
                }
            }

            /* Calculate total amount and print it */

            double total = cash + bank;
            if (total == 0)
            {
                Console.WriteLine($"You're broke.");
            }
            else
            {
                Console.WriteLine($"You have a total of ${total}.");
            }

            Console.WriteLine(Environment.NewLine);
        }

        public static void exercise3()
        {
            Console.WriteLine("--- Exercise 3");

            double fahrenheit;
            double v3_celsius;

            /* Read, parse and validate user input. */

            while (true)
            {
                Console.Write("Fahrenheit:");
                string s_fahrenheit = Console.ReadLine();

                if (double.TryParse(s_fahrenheit, out fahrenheit))
                {
                    break;
                }
            }

            /* Calculate total amount and print it */

            double celsius_variant1 = (fahrenheit - 32) * 0.556;
            double celsius_variant2_step1 = fahrenheit - 32;
            double celsius_variant2 = celsius_variant2_step1 * 0.556;
            Console.WriteLine($"(Variant 1) {fahrenheit} Fahrenheit = {celsius_variant1} Celsius.");
            Console.WriteLine($"(Variant 2) {fahrenheit} Fahrenheit = {celsius_variant2} Celsius.");

            /* Read, parse and validate user input. */

            while (true)
            {
                Console.Write("Fahrenheit:");
                string v3_s_celsius = Console.ReadLine();

                if (double.TryParse(v3_s_celsius, out v3_celsius))
                {
                    break;
                }
            }

            Console.WriteLine(Environment.NewLine);
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
