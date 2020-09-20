/* Exercise 14:
 * 
 * Write a program that reads a string from the user and encrypts it with the classic (and outdated) ROT13 encryption technique.
 * Convert the user's string to lowercase before encrypting it;
 * handling uppercase letters as well is possible but tedious and not very interesting for the purposes of this exercise.

 * Variants:
 *  1.  Write a dynamic ROT13 encryption program that allows the user to choose a different offset than 13,
 *      to make the text more difficult for spies to decrypt. Valid offsets are 1 to 25.
 *  2.  Write a program that tries to decrypt a text encrypted with your dynamic ROT13 program, 
 *      without knowing which offset the original author selected. Do this by trying all combinations (1–25),
 *      then selecting the one with the highest number of common letters in the English alphabet.
 *      Use the following list of most common letters: E, T, A, O, I. Note that this strategy is a heuristic (guess),
 *      so it's not guaranteed to give the right answer for every text. When testing the program,
 *      use complete sentences rather than single words, to increase the chances of making a correct guess.
 */

using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Session_7_Exercise_problem_solving_14_rot13_encryption
{
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            string input = Console.ReadLine();
            string input_lowercase = input.ToLower();
            string input_rot13ified = "";

            //// For method 1:
            //foreach (char c in input_lowercase)
            //{
            //    int c_int = c;

            //    if (c >= 'a' && c <= 'm')
            //    {
            //        c_int += 13;
            //    }
            //    else if (c >= 'n' && c <= 'z')
            //    {
            //        c_int += 'a' - 'n';
            //    }

            //    input_rot13ified += (char)c_int;
            //}
            //// end of 'Method 1'

            // For method 2:
            Dictionary<char, char> translationTable = new Dictionary<char, char>
            {
                ['a'] = 'n',
                ['b'] = 'o',
                ['c'] = 'p',
                ['d'] = 'q',
                ['e'] = 'r',
                ['f'] = 's',
                ['g'] = 't',
                ['h'] = 'u',
                ['i'] = 'v',
                ['j'] = 'w',
                ['k'] = 'x',
                ['l'] = 'y',
                ['m'] = 'z',
                ['n'] = 'a',
                ['o'] = 'b',
                ['p'] = 'c',
                ['q'] = 'd',
                ['r'] = 'e',
                ['s'] = 'f',
                ['t'] = 'g',
                ['u'] = 'h',
                ['v'] = 'i',
                ['w'] = 'j',
                ['x'] = 'k',
                ['y'] = 'l',
                ['z'] = 'm'
            };

            foreach (char c in input_lowercase)
            {
                if (translationTable.TryGetValue(c, out char c2))
                {
                    input_rot13ified += c2;
                }
                else
                {
                    input_rot13ified += c;
                }
            }
            // end of 'Method 2'

            Console.WriteLine(input_lowercase);
            Console.WriteLine(input_rot13ified);
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Test_Alphabet()
        {
            using FakeConsole console = new FakeConsole("abcdefghijklmnopqrstuvwxyz");
            Program.Main();
            Assert.AreEqual("nopqrstuvwxyzabcdefghijklm", console.Output);
        }
        [TestMethod]
        public void Test_Blankspace()
        {
            using FakeConsole console = new FakeConsole(" ");
            Program.Main();
            Assert.AreEqual("", console.Output);
        }
        [TestMethod]
        public void Test_NonLetters()
        {
            using FakeConsole console = new FakeConsole("?_-\"\'!#¤%&/ (\\@£$€{{[]}");
            Program.Main();
            Assert.AreEqual("?_-\"\'!#¤%&/ (\\@£$€{{[]}", console.Output);
        }
        [TestMethod]
        public void Test_LettersAndOtherCharacters()
        {
            using FakeConsole console = new FakeConsole("?_-\"\'abcdefghijklm!#¤%&/ (\\@£$€{{[nopqrstuvwxyz]}");
            Program.Main();
            Assert.AreEqual("?_-\"\'nopqrstuvwxyz!#¤%&/ (\\@£$€{{[abcdefghijklm]}", console.Output);
        }
    }
}
