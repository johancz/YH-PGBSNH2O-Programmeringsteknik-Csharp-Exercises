/* Session_7_Exercise_problem_solving_11_dice:
 * 
 * Write a program that reads a string from the user describing a dice roll
 * and then performs that dice roll (using the Random class) and prints the result.
 * 
 * The rules of the string are as follows: the number of dice is specified first,
 * followed by the character 'd' (for “dice”), followed by the number of sides on
 * each die (which doesn't need to be 6), optionally followed by '+' or '-' and a
 * number that should be added or subtracted from the roll.
 */

using System;
using System.Globalization;
#if DEBUG
using System.Text.RegularExpressions; // We only need this for the unit tests.
using Microsoft.VisualStudio.TestTools.UnitTesting; // We only need this for the unit tests.
#endif

namespace Session_7_Exercise_problem_solving_11_dice
{
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Console.Write("Enter a dice string to parse:");
            string input = Console.ReadLine();
            if (input.Length == 0) { input = "3d10+2"; }

            ParseDiceRoll(input);
        }

        public static void ParseDiceRoll(string diceRoll)
        {
            Console.WriteLine("Dice roll string:\t " + diceRoll);
            //string[] input_array = input.Split(new[] { 'd', '+', '-' });
            int i_of_d = diceRoll.IndexOf('d');

            // Get string after 'd'.
            if (i_of_d > 0 && i_of_d + 1 < diceRoll.Length)
            {
                int current_i = i_of_d + 1;

                // NumberOfDice
                string numberOfDice = diceRoll.Substring(0, i_of_d);

                // Check for '-' or '+'.
                int i_of_plus = diceRoll.IndexOf('+', current_i);
                int i_of_minus = diceRoll.IndexOf("-", current_i);
                int i_of_modifier = -1;
                int len_of_sidesString = 0;
                if (i_of_plus > current_i || i_of_minus > current_i)
                {
                    i_of_modifier = (i_of_minus > i_of_plus ? i_of_minus : i_of_plus);
                    len_of_sidesString = i_of_modifier  - current_i;
                }
                else
                {
                    len_of_sidesString = diceRoll.Length - current_i;
                }

                if (len_of_sidesString > 0)
                {
                    // Number of sides on each die.
                    string diceSides = diceRoll.Substring(current_i, len_of_sidesString);
                    if (int.TryParse(numberOfDice, out int dieCount) && int.TryParse(diceSides, out int sideCount))
                    {
                        Random random = new Random();
                        int sumOfRolls = 0;
                        for (int i = 0; i < dieCount; i++)
                        {
                            // 1 sided die? a möbius strip?
                            sumOfRolls += random.Next(1, sideCount);
                        }

                        if (i_of_modifier > -1
                            && int.TryParse(diceRoll.Substring(i_of_modifier), out int modifierValue))
                        {
                            sumOfRolls += modifierValue;

                        }

                        Console.WriteLine("Sum of rolls:\t " + sumOfRolls);
                        Console.WriteLine();

                        // The string was succesfully parsed, exit out of method.
                        return;
                    }
                }
            }

            Console.WriteLine("Invalid dice roll string format!");
            Console.WriteLine();
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Test()
        {
            using FakeConsole console = new FakeConsole("3d10+");
            Program.Main();
            Assert.AreEqual("Dice roll string:\t 3d10+", console.Lines[0]);
            //StringAssert.StartsWith(console.Output, "Sum of rolls:\t ");
            StringAssert.Matches(console.Output, new Regex(@"Sum of rolls:\t \d+"));
        }
        [TestMethod]
        public void Test2()
        {
            using FakeConsole console = new FakeConsole("3d5-");
            Program.Main();
            Assert.AreEqual("Dice roll string:\t 3d5-", console.Lines[0]);
            //StringAssert.StartsWith(console.Output, "Sum of rolls:\t ");
            StringAssert.Matches(console.Output, new Regex(@"Sum of rolls:\t \d+"));
        }
        [TestMethod]
        public void Test3()
        {
            using FakeConsole console = new FakeConsole("3d10");
            Program.Main();
            Assert.AreEqual("Dice roll string:\t 3d10", console.Lines[0]);
            //StringAssert.StartsWith(console.Output, "Sum of rolls:\t ");
            StringAssert.Matches(console.Output, new Regex(@"Sum of rolls:\t \d+"));
        }
        [TestMethod]
        public void Test4()
        {
            using FakeConsole console = new FakeConsole("3d5");
            Program.Main();
            Assert.AreEqual("Dice roll string:\t 3d5", console.Lines[0]);
            //StringAssert.StartsWith(console.Output, "Sum of rolls:\t ");
            StringAssert.Matches(console.Output, new Regex(@"Sum of rolls:\t \d+"));
        }
        [TestMethod]
        public void Test5()
        {
            using FakeConsole console = new FakeConsole("d1");
            Program.Main();
            CollectionAssert.AreEqual(new[] {
                "Dice roll string:\t d1",
                "Invalid dice roll string format!"
            }, console.Lines);
        }
        [TestMethod]
        public void Test6()
        {
            using FakeConsole console = new FakeConsole("d");
            Program.Main();
            CollectionAssert.AreEqual(new[] {
                "Dice roll string:\t d",
                "Invalid dice roll string format!"
            }, console.Lines);
        }
        [TestMethod]
        public void Test7()
        {
            using FakeConsole console = new FakeConsole("d10");
            Program.Main();
            CollectionAssert.AreEqual(new[] {
                "Dice roll string:\t d10",
                "Invalid dice roll string format!"
            }, console.Lines);
        }
        [TestMethod]
        public void Test8()
        {
            using FakeConsole console = new FakeConsole("5d6-5");
            Program.Main();
            Assert.AreEqual("Dice roll string:\t 5d6-5", console.Lines[0]);
            StringAssert.Matches(console.Output, new Regex(@"Sum of rolls:\t \d+"));
        }
        [TestMethod]
        public void Test9()
        {
            using FakeConsole console = new FakeConsole("5d6-1");
            Program.Main();
            Assert.AreEqual("Dice roll string:\t 5d6-1", console.Lines[0]);
            StringAssert.Matches(console.Output, new Regex(@"Sum of rolls:\t \d+"));
        }
        [TestMethod]
        public void Test10()
        {
            using FakeConsole console = new FakeConsole("5d6+-11");
            Program.Main();
            CollectionAssert.AreEqual(new[] {
                "Dice roll string:\t 5d6+-11",
                "Invalid dice roll string format!"
            }, console.Lines);
        }
        [TestMethod]
        public void Test11()
        {
            using FakeConsole console = new FakeConsole("5d6+-");
            Program.Main();
            CollectionAssert.AreEqual(new[] {
                "Dice roll string:\t 5d6+-",
                "Invalid dice roll string format!"
            }, console.Lines);
        }
        [TestMethod]
        public void Test12()
        {
            using FakeConsole console = new FakeConsole("5d6+10-11");
            Program.Main();
            CollectionAssert.AreEqual(new[] {
                "Dice roll string:\t 5d6+10-11",
                "Invalid dice roll string format!"
            }, console.Lines);
        }
    }
}
