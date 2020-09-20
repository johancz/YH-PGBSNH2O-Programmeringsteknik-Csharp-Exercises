/*
 * Write a program that reads a string from the user and translates it to rövarspråket, or “The Robber Language”.
 * The rules of this language are described on both the Swedish and the English Wikipedia.
 * As in other text translation exercises, you can assume that words are separated by spaces and that the string
 * contains no commas, periods, or other punctuation.
 */

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Session_7_Exercise_problem_solving_12_rövarspråket
{
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Console.WriteLine("Input the text you want to translate to \"rövarspråket\":");
            char[] consonantsSwedish = new char[] {
                'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r',
                's', 't', 'v', 'w', 'x', 'z', 'B', 'C', 'D', 'F', 'G', 'H', 'J',
                'K', 'L', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'V', 'W', 'X', 'Z'
            };

            string input = Console.ReadLine();
            string translatedText = "";

            foreach (char c in input)
            {
                translatedText += c;

                if (consonantsSwedish.Contains(c))
                {
                    translatedText += "" + 'o' + c;
                }
            }

            Console.WriteLine(translatedText);
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Test()
        {
            using FakeConsole console = new FakeConsole("Jag talar rövarspråket");
            Program.Main();
            Assert.AreEqual("JoJagog totalolaror rorövovarorsospoproråkoketot", console.Output);
        }
    }
}
