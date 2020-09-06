using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lektion_4_Exercise_6
{
    public class Program
    {
        public struct Dice
        {
            public int min;
            public int max;

            public Dice(int min, int max)
            {
                this.min = min;
                this.max = max;
            }
        }

        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            //if (int.TryParse(Console.ReadLine(), out int input))
            //while (true)
            {
                Console.WriteLine("Choose variant (\"0\", \"1\", \"2\", \"3\", \"3.1\", or press 'x' to exit.");
                string input = Console.ReadLine();

                switch (input.Trim()) {
                    case "0":
                        Run_variant0();
                        break;
                    case "1":
                        Run_variant1();
                        break;
                    case "2":
                        Run_variant2();
                        break;
                    case "3":
                        Run_variant3_variant0();
                        break;
                    case "3.1":
                        Run_variant3_variant1();
                        break;
                    case "x":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("That is not a variant, goodbye.");
                        break;
                }

                Console.WriteLine(Environment.NewLine);
            }
        }

        public static void Run_variant0()
        {
            Console.WriteLine("::: Variant 0 :::");
            //int dice1_sides = 6;
            //int dice2_sides = 6;
            //var d1 = new { min = (int)1, max = (int)6 };
            //var d2 = new { min = (int)1, max = (int)6 };
            //int runCount_i1 = 0;
            //int runCount_i2 = 0;

            Dice d1 = new Dice(1, 6);
            Dice d2 = new Dice(1, 6);
            Console.Write("Output: ");

            for (int i1 = d1.min; i1 <= d1.max; ++i1)
            {
                for (int i2 = d2.min; i2 <= d2.max; ++i2)
                {
                    Console.Write($"({i1}, {i2}){((i1 == d1.max && i2 == d2.max) ? "" : ", ")}");
                }
            }
        }

        /* Write a variant of the program that reads an integer from the user and only shows those pairs whose sum is that high or higher.For example, if 10 is entered, the program should only print the following pairs: (4, 6), (5, 5), (5, 6), (6, 4), (6, 5), (6, 6). */
        public static void Run_variant1()
        {
            Console.WriteLine("::: Variant 1 :::");

            Console.Write("Enter a number: ");

            if (int.TryParse(Console.ReadLine(), out int input))
            {
                Dice d1 = new Dice(1, 6);
                Dice d2 = new Dice(1, 6);
                List<string> output = new List<string>();

                for (int i1 = d1.min; i1 <= d1.max; ++i1)
                {
                    for (int i2 = d2.min; i2 <= d2.max; ++i2)
                    {
                        if (i1 + i2 >= input)
                        {
                            output.Add($"({i1}, {i2})");
                        }
                    }
                }

                Console.Write("Output: " + string.Join(", ", output));
            }
        }

        /* Write a variant of the first program that can be used by a tabletop roleplayer with a flaming longsword. In other words, one of the dice should have eight sides (and the other still have six sides).
         * 
         * Question: Can you imagine two different but very similar ways of achieving this?
         * Answer: While-loops?
         */
        public static void Run_variant2()
        {
            Console.WriteLine("::: Variant 2 :::");

            Dice flamingLongsword = new Dice(1, 8);
            Dice normalDice = new Dice(1, 6);
            List<string> output = new List<string>();

            for (int i1 = flamingLongsword.min; i1 <= flamingLongsword.max; ++i1)
            {
                int i2 = normalDice.min;

                while (i2 <= normalDice.max)
                {
                    output.Add($"({i1}, {i2})");

                    i2++;
                }
            }

            Console.Write("Output: " + string.Join(", ", output));
        }

        /* WWhat do you need to do change in order to have the program roll three dice instead of two? Does the same principle hold for four, five, and even higher numbers of dice?
         */
        public static void Run_variant3_variant0()
        {
            Console.WriteLine("::: Variant 3 :::");

            Dice d1 = new Dice(1, 3);
            Dice d2 = new Dice(1, 3);
            Dice d3 = new Dice(1, 3);
            List<string> output = new List<string>();

            for (int i1 = d1.min; i1 <= d1.max; ++i1)
            {
                for (int i2 = d2.min; i2 <= d2.max; ++i2)
                {
                    for (int i3 = d3.min; i3 <= d3.max; ++i3)
                    {
                        output.Add($"({i1}, {i2}, {i3})");
                    }
                }
            }

            Console.Write("Output: " + string.Join(", ", output));
        }

        public static void Run_variant3_variant1()
        {
        }

        public static string Run_variant3_variant1(Dice dice, int diceCount, int diceLeft, int allIndexes, string output)
        {
            for (int index = dice.min; index <= dice.max; index++)
            {

            }


            return output;
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Test_variant0()
        {
            using FakeConsole console = new FakeConsole("0", "x");
            Program.Main();
            Assert.AreEqual("Output: (1, 1), (1, 2), (1, 3), (1, 4), (1, 5), (1, 6), (2, 1), (2, 2), (2, 3), (2, 4), (2, 5), (2, 6), (3, 1), (3, 2), (3, 3), (3, 4), (3, 5), (3, 6), (4, 1), (4, 2), (4, 3), (4, 4), (4, 5), (4, 6), (5, 1), (5, 2), (5, 3), (5, 4), (5, 5), (5, 6), (6, 1), (6, 2), (6, 3), (6, 4), (6, 5), (6, 6)", console.Output);
        }

        [TestMethod]
        public void Test_variant1_test1()
        {
            using FakeConsole console = new FakeConsole("1", "10", "x");
            Program.Main();
            Assert.AreEqual("Output: (4, 6), (5, 5), (5, 6), (6, 4), (6, 5), (6, 6)", console.Output);
        }

        [TestMethod]
        public void Test_variant1_test2()
        {
            using FakeConsole console = new FakeConsole("1", "13", "x");
            Program.Main();
            Assert.AreEqual("Output:", console.Output);
        }

        [TestMethod]
        public void Test_variant2_test1()
        {
            using FakeConsole console = new FakeConsole("2", "x");
            Program.Main();
            Assert.AreEqual("Output: (1, 1), (1, 2), (1, 3), (1, 4), (1, 5), (1, 6), (2, 1), (2, 2), (2, 3), (2, 4), (2, 5), (2, 6), (3, 1), (3, 2), (3, 3), (3, 4), (3, 5), (3, 6), (4, 1), (4, 2), (4, 3), (4, 4), (4, 5), (4, 6), (5, 1), (5, 2), (5, 3), (5, 4), (5, 5), (5, 6), (6, 1), (6, 2), (6, 3), (6, 4), (6, 5), (6, 6), (7, 1), (7, 2), (7, 3), (7, 4), (7, 5), (7, 6), (8, 1), (8, 2), (8, 3), (8, 4), (8, 5), (8, 6)", console.Output);
        }

        [TestMethod]
        public void Test_variant3_test1()
        {
            throw new NotImplementedException();
            using FakeConsole console = new FakeConsole("3", "x");
            Program.Main();
            Assert.AreEqual("", console.Output);
        }
    }
}
