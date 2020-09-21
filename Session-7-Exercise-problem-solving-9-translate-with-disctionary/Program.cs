/* Write a program that reads a string from the user and translates it to a different language by using a dictionary.
 * For example, if the string is "Merry Christmas everybody" and the dictionary is
 * { ["Merry"] = "God", ["Christmas"] = "jul", ["everybody"] = "allihopa" }, the result should be "God jul allihopa".
 * Words in the string that do not appear in the dictionary should remain unchanged.
 * The dictionary should be defined in the source code, not provided by the user.
 * As in other text translation exercises, you can assume that words are separated by spaces and that the string 
 * contains no commas, periods, or other punctuation.
*/

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Session_7_Exercise_problem_solving_9_translate_with_disctionary
{
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Dictionary<string, string> translationDictionary = new Dictionary<string, string>
            {
                ["Merry"] = "God",
                ["Christmas"] = "jul",
                ["everybody"] = "allihopa"
            };

            Console.WriteLine("Enter the text you want to translate:");
            string input = Console.ReadLine();
            if (input.Length == 0) { input = "Merry Christmas everybody"; }
            List<string> input_list = input.Split(' ').ToList();
            string[] input_array = input.Split(' ');

            foreach (KeyValuePair<string, string> wordToTranslate in translationDictionary)
            {
                input_list = input_list.Select(s => s.Replace(wordToTranslate.Key, wordToTranslate.Value)).ToList();
            }

            Console.WriteLine(string.Join(' ', input_list));
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Test1()
        {
            using FakeConsole console = new FakeConsole("Merry Christmas everybody");
            Program.Main();
            Assert.AreEqual("God jul allihopa", console.Output);
        }
        [TestMethod]
        public void Test2()
        {
            using FakeConsole console = new FakeConsole("merry christmas EVERYBODY");
            Program.Main();
            Assert.AreEqual("merry christmas EVERYBODY", console.Output);
        }
    }
}
