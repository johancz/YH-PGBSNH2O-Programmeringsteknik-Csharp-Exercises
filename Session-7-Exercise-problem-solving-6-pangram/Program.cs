/*
 * Write a program that reads a string from the user and determines whether it is a pangram. A pangram is a text that contains every letter of the(English) alphabet at least once. For example, the string "The five boxing wizards jump quickly" is a pangram.
 * Variant:
        * Write a variant of the program that also allows the user to provide their own alphabet to use instead of the English one, either by reading the alphabet from the console or by having an array in its source code that the user can edit. For example, if the user provides the alphabet “e, h, l, o, r, t”, the string "hello there" is also a pangram. 
 * */

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Session_7_Exercise_problem_solving_6_pangram
{
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            // Input stuff
            Console.WriteLine("Enter some text to see if it's a pangram:");
            string input = Console.ReadLine();
            if (input.Length == 0) { input = "The quick brown fox jumps over the lazy dog"; }
            string input_lowercase = input.ToLower();

            List<char> alphabet = BuildAlphabet_variant1();
            //List<char> alphabet = BuildAlphabet_variant2();
            //List<char> alphabet = BuildAlphabet_variant3();
            Console.Write("Alphabet: " + string.Join("", alphabet) + Environment.NewLine);

            foreach (char c in input_lowercase)
            {
                foreach (char alphabet_letter in alphabet)
                {
                    if (c == alphabet_letter)
                    {
                        alphabet.Remove(alphabet_letter);
                        break;
                    }
                }
            }

            if (alphabet.Count == 0)
            {
                Console.WriteLine($"\"{input}\" is a pangram.");
            }
            else
            {
                Console.WriteLine($"\"{input}\" is NOT a pangram.");
            }
        }

        public static List<char> BuildAlphabet_variant1()
        {
            List<char> alphabet = new List<char>();

            for (char letter = 'a'; letter <= 'z';)
            {
                alphabet.Add(letter++);
            }

            return alphabet;
        }

        public static List<char> BuildAlphabet_variant2()
        {
            List<char> alphabet = new List<char>();

            do
            {
                alphabet.Add((char)('a' + alphabet.Count));
            } while (alphabet[alphabet.Count - 1] < 'z');

            return alphabet;
        }

        public static List<char> BuildAlphabet_variant3()
        {
            List<char> alphabet = new List<char> { 'a' };

            do
            {
                alphabet.Add((char)(alphabet[alphabet.Count - 1] + 1));
            } while (alphabet[alphabet.Count - 1] < 'z');

            return alphabet;
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Test_Pangram1()
        {
            using FakeConsole console = new FakeConsole("abcdefghijklmnopqrstuvwxyz");
            Program.Main();
            Assert.AreEqual("\"abcdefghijklmnopqrstuvwxyz\" is a pangram.", console.Output);
        }
        [TestMethod]
        public void Test_Pangram2()
        {
            using FakeConsole console = new FakeConsole("The quick brown fox jumps over the lazy dog");
            Program.Main();
            Assert.AreEqual("\"The quick brown fox jumps over the lazy dog\" is a pangram.", console.Output);
        }
        [TestMethod]
        public void Test_Pangram3()
        {
            using FakeConsole console = new FakeConsole("abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyz");
            Program.Main();
            Assert.AreEqual("\"abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyz\" is a pangram.", console.Output);
        }
        [TestMethod]
        public void Test_Pangram4()
        {
            using FakeConsole console = new FakeConsole("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
            Program.Main();
            Assert.AreEqual("\"ABCDEFGHIJKLMNOPQRSTUVWXYZ\" is a pangram.", console.Output);
        }
        [TestMethod]
        public void Test_NotAPangram1()
        {
            using FakeConsole console = new FakeConsole("abcdefghijklmnopqrstuvwxy");
            Program.Main();
            Assert.AreEqual("\"abcdefghijklmnopqrstuvwxy\" is NOT a pangram.", console.Output);
        }
        [TestMethod]
        public void Test_BuildAlphabet_variant1()
        {
            List<char> testAlphabet = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
                'k', 'l', 'm','n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            List<char> alphabet = Program.BuildAlphabet_variant1();
            CollectionAssert.AreEqual(testAlphabet, alphabet);
        }
        [TestMethod]
        public void Test_BuildAlphabet_variant2()
        {
            List<char> testAlphabet = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
                'k', 'l', 'm','n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            List<char> alphabet = Program.BuildAlphabet_variant2();
            CollectionAssert.AreEqual(testAlphabet, alphabet);
        }
        [TestMethod]
        public void Test_BuildAlphabet_variant3()
        {
            List<char> testAlphabet = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
                'k', 'l', 'm','n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            List<char> alphabet = Program.BuildAlphabet_variant3();
            CollectionAssert.AreEqual(testAlphabet, alphabet);
        }
    }
}
