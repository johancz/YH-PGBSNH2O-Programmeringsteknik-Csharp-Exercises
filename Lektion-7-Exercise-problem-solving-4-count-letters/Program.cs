using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lektion_7_Exercise_problem_solving_4_count_letters
{
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Console.WriteLine("Enter text:");
            string input = Console.ReadLine();
            Dictionary<char, int> letters = new Dictionary<char, int>();

            foreach (char c in input)
            {
                if (!char.IsLetter(c))
                {
                    continue;
                }
                
                if (!letters.ContainsKey(c))
                {
                    letters.Add(c, 0);
                }

                letters[c]++;
            }

            if (letters.Count > 0)
            {
                Console.WriteLine($"The string \"{input}\" contains the following letters.");
                Console.WriteLine("Letter\tOccurrences");
                foreach (KeyValuePair<char, int> letter in letters)
                {
                    Console.WriteLine($"{letter.Key}\t{letter.Value}");
                }
            }
            else
            {
                Console.WriteLine("The text contains no letters.");
            }

        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Test()
        {
            using FakeConsole console = new FakeConsole("text txet text txet text txet");
            Program.Main();
            CollectionAssert.AreEqual(new[] {
                "The string \"text txet text txet text txet\" contains the following letters.",
                "Letter\tOccurrences",
                "t\t12",
                "e\t6",
                "x\t6"
            }, console.Lines);
        }

        [TestMethod]
        public void Test_noLetters()
        {
            using FakeConsole console = new FakeConsole(" #¤_-~¨*``´´^^¨¨)=#)===£$£@£€\t@ \'\\\\\"");
            Program.Main();
            Assert.AreEqual("The text contains no letters.", console.Output);
        }
    }
}
