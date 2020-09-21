/* Exercise 14 - variant 1:
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
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Session_7_Exercise_problem_solving_14_rot13_encryption_variant_1
{
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Console.WriteLine("Input the string to encrypt:");
            string input = Console.ReadLine();

            int offset;
            Console.WriteLine("Input the ROT## offset (1-25):");
            if (!int.TryParse(Console.ReadLine(), out offset) || !(offset >= 1 && offset <= 25))
            {
                Console.WriteLine("Invalid offset!");
            }
            else
            {
                string input_ROTified = encrypt_ROT13(input, offset);
                Console.WriteLine("input_ROTified: " + input_ROTified);
            }
        }

        public static string encrypt_ROT13(string input, int offset)
        {
            string input_lowercase = input.ToLower();
            string input_ROTified = "";

            foreach (char c in input_lowercase)
            {
                int c_int = c;
                int end = 'z' - offset;
                int overflow = c + offset - 'z' - 1;

                if (c >= 'a' && c <= end)
                {
                    c_int = c + offset;
                }
                else if (c > end && c <= 'z')
                {
                    c_int = 'a' + overflow;
                }

                input_ROTified += (char)c_int;
            }

            return input_ROTified;
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Test_Alphabet_offset1()
        {
            using FakeConsole console = new FakeConsole("abcdefghijklmnopqrstuvwxyz", "1");
            Program.Main();
            Assert.AreEqual("input_ROTified: bcdefghijklmnopqrstuvwxyza", console.Output);
        }
        [TestMethod]
        public void Test_Alphabet_offset25()
        {
            using FakeConsole console = new FakeConsole("abcdefghijklmnopqrstuvwxyz", "25");
            Program.Main();
            Assert.AreEqual("input_ROTified: zabcdefghijklmnopqrstuvwxy", console.Output);
        }
        [TestMethod]
        public void Test_InvalidInput()
        {
            using FakeConsole console = new FakeConsole("abcdefghijklmnopqrstuvwxyz", "26");
            Program.Main();
            CollectionAssert.AreEqual(new[] {
                "Invalid offset!"
            }, new string[] { console.Lines[0] });
        }
        [TestMethod]
        public void Test_ROT25ed_Alphabet_offset25()
        {
            using FakeConsole console = new FakeConsole("zabcdefghijklmnopqrstuvwxy", "25");
            Program.Main();
            Assert.AreEqual("input_ROTified: yzabcdefghijklmnopqrstuvwx", console.Output);
        }
    }
}
