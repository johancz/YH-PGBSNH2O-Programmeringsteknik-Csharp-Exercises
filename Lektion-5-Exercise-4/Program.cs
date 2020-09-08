using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lektion_5_Exercise_4
{
    //Exercise 4
    // Write a program that removes all vowels from a string. For example, the input "hello there" should result in the output "hll thr". For simplicity, assume that the letters A, E, I, O, U, and Y are vowels (even though Y is not always a vowel in English).
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            string swedishVowels = "aeiouyåäö";

            Console.Write("Input a string into the lowercase swedish vowels destroyer: ");
            string input = Console.ReadLine(),
                   output = "";

            for (int i = 0; i < input.Length; i++)
            {
                bool isVowel = false;

                for (int j = 0; j < swedishVowels.Length; j++)
                {
                    if (input[i] == swedishVowels[j])
                    {
                        isVowel = true;
                        break;
                    }
                }

                if (!isVowel)
                {
                    output += input[i];
                }
            }

            Console.WriteLine($"Original text: \"{input}\"\nall vowels removed: \"{output}\".");

            output = "";

            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];

                if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u' || c == 'y' || c == 'å' || c == 'ä' || c == 'ö')
                {
                    continue;
                }
                    
                output += input[i];
            }

            Console.WriteLine($"Original text: \"{input}\"\nall vowels removed: \"{output}\".");
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Test()
        {
            using FakeConsole console = new FakeConsole();
            Program.Main();
            Assert.AreEqual("\"keyboard\" reversed = \"draobyek\".", console.Output);
        }

        [TestMethod]
        public void Test2()
        {
            using FakeConsole console = new FakeConsole();
            Program.Main();
            Assert.AreEqual("\"keyboard\" reversed = \"draobyek\".", console.Output);
        }
    }
}
