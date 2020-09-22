using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Large_Exercise__Guest_the_number_game
{
    public class Program
    {
        public static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            // generate random number
            // read input from user, parse to int {
            //     compare user input to the random number
            //     if higher or lower, inform the user of this
            // } do this until the user has guessed the correct number

            Game_New();
        }

        public static void Game_New()
        {
            Random rCPU = new Random();
            List<int> games = new List<int>();

            int selectedOption;
            do
            {
                selectedOption = ShowMenu("Game Menu", new[] { "Play", "Lowscore", "Exit" });

                if (selectedOption == 0)
                {
                    int guesses = Game_NextRound(rCPU.Next(1, 100));
                    games.Add(guesses);
                }
                else if (selectedOption == 1)
                {
                    int i = 0;
                    foreach (int guesses in games)
                    {
                        Console.WriteLine($"Game {++i}: {guesses}");
                    }

                    Console.WriteLine();
                    Console.WriteLine("Press 'Enter' to return to the menu.");
                    Console.ReadLine();
                }

                Console.Clear();
            } while (selectedOption != 2);
        }

        public static int Game_NextRound(int rCPU_number)
        {
            Console.Clear();
            int guesses = 0;

            Console.WriteLine("rCPU_number: " + rCPU_number);

            while (true)
            {
                Console.Write("Guess the CPU's number (1-99): ");
                string input = Console.ReadLine();
                Console.Clear();
                int input_int;

                if (!int.TryParse(input, out input_int)) {
                    Console.WriteLine("You did not enter a valid number, try again!");
                }
                else if (input_int == rCPU_number)
                {
                    Console.WriteLine("You guessed correctly.");
                    
                    return ++guesses;
                }
                else if (input_int < rCPU_number)
                {
                    Console.WriteLine("Too Small!");
                    guesses++;
                }
                else if (input_int > rCPU_number)
                {
                    Console.WriteLine("Too Large!");
                    guesses++;
                }
                else
                {
                    Console.WriteLine("que");
                }
            }
        }

        public static int ShowMenu(string prompt, string[] options)
        {
            if (options == null || options.Length == 0)
            {
                throw new ArgumentException("Cannot show a menu for an empty array of options.");
            }

            Console.WriteLine(prompt);

            int selected = 0;

            // Hide the cursor that will blink after calling ReadKey.
            Console.CursorVisible = false;

            ConsoleKey? key = null;
            while (key != ConsoleKey.Enter)
            {
                // If this is not the first iteration, move the cursor to the first line of the menu.
                if (key != null)
                {
                    Console.CursorLeft = 0;
                    Console.CursorTop = Console.CursorTop - options.Length;
                }

                // Print all the options, highlighting the selected one.
                for (int i = 0; i < options.Length; i++)
                {
                    var option = options[i];
                    if (i == selected)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine("- " + option);
                    Console.ResetColor();
                }

                // Read another key and adjust the selected value before looping to repeat all of this.
                key = Console.ReadKey().Key;
                if (key == ConsoleKey.DownArrow)
                {
                    selected = Math.Min(selected + 1, options.Length - 1);
                }
                else if (key == ConsoleKey.UpArrow)
                {
                    selected = Math.Max(selected - 1, 0);
                }
            }

            // Reset the cursor and return the selected option.
            Console.CursorVisible = true;
            return selected;
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
