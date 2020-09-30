/*  C# Programmeringsteknik
 *  Paperbook
 *  Chapter 4
 *  Exercise 8: Bank Simulator
 *  
 *  Skriv ett program som simulerar en enkel bank.
 *  Man skall kunna sätta in pengar och ta ut pengar, samt kolla saldo. Detta görs via en meny. Använd switch-satsen och loop.
 *  Menyn:
 *      [I]nsättning
 *      [U]ttag
 *      [S]aldo
 *      [A]vsluta
 */

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Session_3_Paperbook_Chapter_4_Exercise_8_Bank_Simulator
{
    public class Program
    {
        public static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            bool run = true;
            decimal balance = 0;

            // Loop until "A" or "a" is pressed.
            while (run)
            {
                Console.WriteLine("Bank Simulator");

                // Print the menu.
                Console.WriteLine("[I]nsättning");
                Console.WriteLine("[U]ttag");
                Console.WriteLine("[S]aldo");
                Console.WriteLine("[A]vsluta");

                ConsoleKeyInfo cki = Console.ReadKey();
                Console.Clear();

                switch (cki.Key)
                {
                    case ConsoleKey.I:
                        {
                            decimal deposit;

                            Console.Write("How much do you wish to deposit? ");
                            while (!decimal.TryParse(Console.ReadLine(), out deposit))
                            {
                                Console.Write("Try again: ");
                            }

                            balance += deposit;
                            Console.WriteLine("You deposited " + deposit + " SEK into your account.");
                        }
                        break;
                    case ConsoleKey.U:
                        {
                            decimal withdrawal;

                            Console.Write("How much do you wish to withdraw? ");
                            while (!decimal.TryParse(Console.ReadLine(), out withdrawal))
                            {
                                Console.Write("Try again: ");
                            }

                            balance -= withdrawal;
                            Console.WriteLine("You withdrew " + withdrawal + " SEK from your account.");
                        }
                        break;
                    case ConsoleKey.S:
                        Console.WriteLine("You account balance is " + balance + " SEK.");
                        break;
                    case ConsoleKey.A:
                        run = false;
                        Console.WriteLine("Goodbye...");
                        break;
                    default:
                        Console.WriteLine("Press one of the highlighted letters in the menu below...");
                        break;
                }

                Console.WriteLine();
            }
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
