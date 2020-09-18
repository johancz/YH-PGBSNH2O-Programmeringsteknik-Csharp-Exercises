using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Session_7_Exercise_problem_solving_8_censor_string
{
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Console.WriteLine("Enter string to censor it:");
            string input_string = Console.ReadLine();
            //if (input_string.Length == 0) { input_string = "Luke's father is Vader and Rosebud is a sled"; }
            if (input_string.Length == 0) { input_string = "Vader Vadero sled sledo"; }
            Console.WriteLine("Enter a list of the words you wish to censor (separate with a space):");
            string input_wordsToCensor = Console.ReadLine();
            if (input_wordsToCensor.Length == 0) { input_wordsToCensor = "Vader sled"; }
            List<string> words = input_string.Split(' ').ToList();
            string[] wordsToCensor = input_wordsToCensor.Split(' ');

            for (int i = 0; i < words.Count; i++)
            {
                string word = words[i];

                foreach (string wordToCensor in wordsToCensor)
                {
                    if (word == wordToCensor)
                    {
                        // Can't use 'word' here since it's a value and not a reference.
                        words[i] = new string('*', word.Length);
                    }
                }
            }

            Console.WriteLine(string.Join(" ", words));
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void ExampleTest()
        {
            using FakeConsole console = new FakeConsole("Vader Vadero sled sledo", "Vader sled");
            Program.Main();
            Assert.AreEqual("***** Vadero **** sledo", console.Output);
        }
    }
}
