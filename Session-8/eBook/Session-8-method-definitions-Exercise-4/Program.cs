using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Session_8_method_definitions_Exercise_4
{
    public class Program
    {
        private static Random random;

        public static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            random = new Random();

            Console.WriteLine("Answer with 'y' or 'n'");
            Console.WriteLine("----------------------");
            IsItBroken();
        }

        public static void IsItBroken()
        {
            Console.WriteLine("Is it broken?");
            string input = Console.ReadLine();

            if (input == "y")
            {
                CanAFriendFixIt();
            }
            else if (input == "n")
            {
                GoodDoNotTouchIt();
            }
            else
            {
                IsItBroken();
            }
        }

        public static void CanAFriendFixIt()
        {
            Console.WriteLine("CanAFriendFixIt");
            string input = Console.ReadLine();

            if (input == "y")
            {
                GoodDoNotTouchIt();
            }
            else if (input == "n")
            {
                PressARandomButton("w");
            }
            else
            {
                CanAFriendFixIt();
            }
        }

        public static void PressARandomButton(string bypassRandom = null)
        {
            Console.WriteLine("Press a random letter ('q', 'w' or 'e') - Is it working?");
            string input = Console.ReadLine();
            string randomLetter;

            if (bypassRandom is null) {
                int random_i = random.Next(0, 3);
                char[] letters = { 'q', 'w', 'e' };
                randomLetter = "" + letters[random_i];
                Console.WriteLine(letters[random_i]);
            }
            else
            {
                randomLetter = bypassRandom;
            }

            if (input == randomLetter)
            {
                GoodDoNotTouchIt();
            }
            else
            {
                PressARandomButton("w");
            }
        }

        public static void GoodDoNotTouchIt()
        {
            Console.WriteLine("Good don't touch it");

            IsItBroken();
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
