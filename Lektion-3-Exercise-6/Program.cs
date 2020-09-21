using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lektion_3_Exercise_6
{
    // Write a program that recreates a decision flowchart, allowing the user to enter answers to questions and step by step arrive at an answer or suggestion. The program should start by asking a question, then read the answer to that question from the user, repeat the process, and finally stop once an end of the flowchart has been reached. Find any such flowchart online or use the one below:

    //// Do not bother with error handling, and simply assume that the user will always enter one of the valid answers in the current position on the flowchart.
    //// Does your decision flowchart contain any paths that can be followed forever? (In other words: a cycle or “loop”.) Does the program handle this? If yes, how? If no, what do you think you would need in order to support this as well?
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Console.WriteLine("What do you want to see?");
            Console.WriteLine("1. Forests");
            Console.WriteLine("2. Mountains");
            Console.WriteLine("3. Cities");
            Console.WriteLine("Type \"Exit\" to exit the program.");

            string input = Console.ReadLine();
            int selection;

            if (!int.TryParse(input, out selection))
            {
                switch (input.ToLowerInvariant())
                {
                    case "forests":
                        selection = 1;
                        break;
                    case "mountains":
                        selection = 2;
                        break;
                    case "cities":
                        selection = 3;
                        break;
                    case "exit":
                        selection = -1;
                        break;
                    default:
                        Console.WriteLine("Invalid input!");
                        break;
                }
            }

            if (selection == 3)
            {
                Console.WriteLine("Do you enjoy puns?");
                Console.WriteLine("0. Return to previous menu.");
                Console.WriteLine("1. Yes");
                Console.WriteLine("2. No");
                Console.WriteLine("Type \"Exit\" to exit the program.");

                string input2 = Console.ReadLine();
                int selection2;
                bool couldParseToInt = int.TryParse(input2, out selection2);

                if (!couldParseToInt)
                {
                    switch (input2.ToLowerInvariant())
                    {
                        case "yes":
                            selection = 4;
                            break;
                        case "no":
                            selection = 5;
                            break;
                        case "exit":
                            selection = -1;
                            break;
                        default:
                            Console.WriteLine("Invalid input!");
                            break;
                    }
                }
                else
                {
                    // If "1. Yes" or "1. No" is selected, adjust 'selection' to 3 and 4 respectively.
                    // This is because 1 and 2 are used by other selections.
                    selection = selection2 == 0 ? selection2 : selection2 + 3;
                }
            }

            /* If the user enters
             * -1: stop the program.
                0: restart the program. */
            if (selection == -1)
            {
                return;
            }
            else if (selection == 0)
            {
                Console.WriteLine();
                Main();
                return;
            }

            string suggestedPlace;

            switch (selection)
            {
                case 1:
                    suggestedPlace = "Småland";
                    break;
                case 2:
                    suggestedPlace = "Lappland";
                    break;
                case 4:
                    suggestedPlace = "Gothenburg";
                    break;
                case 5:
                    suggestedPlace = "Stockholm";
                    break;
                default:
                    suggestedPlace = "You should probably stay at home.";
                    break;
            }

            Console.WriteLine($"You should visit {suggestedPlace}.");

            // Restart the program, for testing.
            Console.WriteLine();
            Main();
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Test_Småland()
        {
            using FakeConsole console = new FakeConsole("Småland");
            Program.Main();
            Assert.AreEqual("You should visit Småland.", console.Output);

        }
        [TestMethod]
        public void Test_Lappland()
        {
            using FakeConsole console = new FakeConsole("Lappland");
            Program.Main();
            Assert.AreEqual("You should visit Lappland.", console.Output);

        }
        [TestMethod]
        public void Test_Gothenburg()
        {
            using FakeConsole console = new FakeConsole("Gothenburg", "Yes");
            Program.Main();
            Assert.AreEqual("You should visit Gothenburg.", console.Output);

        }
        [TestMethod]
        public void Test_Stockholm()
        {
            using FakeConsole console = new FakeConsole("Stockholm", "No");
            Program.Main();
            Assert.AreEqual("You should visit Stockholm.", console.Output);

        }
    }
}
