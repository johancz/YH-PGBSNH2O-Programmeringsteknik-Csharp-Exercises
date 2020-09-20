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
using System.Text;
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
                's', 't', 'v', 'w', 'x', 'z', 'B', 'C', 'D', 'F', 'G', 'H', 'J',
                'K', 'L', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'V', 'W', 'X', 'Z'
            };

            string[] input = Console.ReadLine().Split(' ');
            List<string> translatedText = new List<string>();

            foreach (string word in input)
            {
                string newWord = "", initialConsonants = "";

                for (int i = 0; i < word.Length; i++)
                {
                    char c = word[i];

                    Console.WriteLine((i == 0 && (c == 'y' || c == 'Y')) == (i > 0 && !(c == 'y' || c == 'Y')));

                    // If 'y' || 'Y' is the first letter of the word, treat it as a consonant, otherwise a vowel.
                    if (i == 0 && (c == 'y' || c == 'Y'))
                    {
                    }
                    else if (!consonants.Contains(c))
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
                    // Decapitalize the first consonant that was moved.
                    bool firstWasUpper = char.IsUpper(initialConsonants[0]);
                    newWord += char.ToLower(initialConsonants[0]);
                    if (initialConsonants.Length > 1)
                    {
                        newWord += initialConsonants.Substring(1);
                    }

                    newWord += "ay";

                    // Capitilize the first letter of the word if the previous was.
                    if (firstWasUpper) {
                        newWord = char.ToUpper(newWord[0]) + newWord.Substring(1);
                    }
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
        public void Test1()
        {
            using FakeConsole console = new FakeConsole("Wikipedia");
            Program.Main();
            Assert.AreEqual("Ikipediaway", console.Output);
        }
        [TestMethod]
        public void Test2()
        {
            using FakeConsole console = new FakeConsole("How do you say in Pig Latin");
            Program.Main();
            Assert.AreEqual("Owhay oday ouyay aysay inyay Igpay Atinlay", console.Output);
        }
        [TestMethod]
        public void Test3()
        {
            using FakeConsole console = new FakeConsole("HLT");
            Program.Main();
            Assert.AreEqual("HLTay", console.Output);
        }
        [TestMethod]
        public void Test4()
        {
            using FakeConsole console = new FakeConsole("AEY");
            Program.Main();
            Assert.AreEqual("AEYyay", console.Output);
        }
        [TestMethod]
        public void Test5()
        {
            using FakeConsole console = new FakeConsole("strength");
            Program.Main();
            Assert.AreEqual("engthstray", console.Output);
        }
        [TestMethod]
        public void Test6()
        {
            using FakeConsole console = new FakeConsole("eight");
            Program.Main();
            Assert.AreEqual("eightyay", console.Output);
        }
        [TestMethod]
        public void Test7()
        {
            using FakeConsole console = new FakeConsole("Yearly");
            Program.Main();
            Assert.AreEqual("Earlyyay", console.Output);
        }
        [TestMethod]
        public void Test8()
        {
            using FakeConsole console = new FakeConsole("Aye");
            Program.Main();
            Assert.AreEqual("Ayeyay", console.Output);
        }
        [TestMethod]
        public void Test9()
        {
            using FakeConsole console = new FakeConsole("HOw do");
            Program.Main();
            Assert.AreEqual("Owhay oday", console.Output);
        }
    }
}
