/*
 * Write a program that reads a string from the user and translates it to Pig Latin.
 * The rules of this language are described on both the Swedish and the English Wikipedia.
 * As in other text translation exercises, you can assume that words are separated by spaces
 * and that the string contains no commas, periods, or other punctuation.
 */

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Session_7_Exercise_problem_solving_13_pig_latin
{
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Console.WriteLine("Input the text you want to translate to \"pig latin\":");
            char[] consonants = new char[] {
                'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r',
                's', 't', 'v', 'w', 'x', 'y', 'z', 'B', 'C', 'D', 'F', 'G', 'H', 'J',
                'K', 'L', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'V', 'W', 'X', 'Y', 'Z'
            };

            string[] input = Console.ReadLine().Split(' ');
            input = "Wikipedia".Split(' ');
            //input = "How do you say ... in Pig Latin?".Split(' ');
            List<string> translatedText = new List<string>();

            foreach (string word in input)
            {
                string newWord = "", initialConsonants = "";

                for (int i = 0; i < word.Length; i++)
                {
                    char c = word[i];

                    if (!consonants.Contains(c))
                    {

                        newWord += word.Substring(i);
                        break;
                    }

                    initialConsonants += c;
                }

                if (initialConsonants.Length == 0)
                {
                    newWord += "yay";
                }
                else
                {
                    newWord += initialConsonants + "ay";
                }

                translatedText.Add(newWord);
            }

            string translatedText_string = string.Join(' ', translatedText);
            Console.WriteLine(translatedText_string);
        } // end of 'public static void Main()'
    } // end of 'public class Program'

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
