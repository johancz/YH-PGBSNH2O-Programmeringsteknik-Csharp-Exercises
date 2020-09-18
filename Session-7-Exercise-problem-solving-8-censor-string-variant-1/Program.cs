using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Session_7_Exercise_problem_solving_8_censor_string_variant_1
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
            if (input_string.Length == 0) { input_string = "Vader Vader sledo"; }
            Console.WriteLine("Enter a list of the words you wish to censor (seperate with a space):");
            string input_wordsToCensor = Console.ReadLine();
            if (input_wordsToCensor.Length == 0) { input_wordsToCensor = "Vader sled"; }

            //List<string> words = input_string.Split(new[] { ' ', '.', ',', ';', ':', '"', '\'', '!', '?', '_' }).ToList();
            List<string> words = new List<string>();
            List<string> separators = new List<string>();
            string word = "";
            int words_i = 0;
            for (int i = 0, last_i = input_string.Length - 1; i < input_string.Length; i++)
            {
                char c = input_string[i];
                bool isLetterOrDigit = char.IsLetterOrDigit(c);

                if (i == last_i)
                {
                    word += c;
                    words.Add(word);
                    word = "";
                }
                else if ()


                    //////////
                    if (char.IsLetterOrDigit(c))
                    {
                        word += c;
                    }

                if (!char.IsLetterOrDigit(c) || i == last_i)
                {
                    words.Add(word);
                    //words.Add(c.ToString());
                }

                /////////////////

                if (char.IsLetterOrDigit(c))
                {
                    word += c;

                    if (i == last_i)
                    {
                        words.Add(word);
                    }
                }
                else
                {
                    words.Add(word);
                    words.Add(c.ToString());
                    word = "";
                }
            }

            string[] wordsToCensor = input_wordsToCensor.Split(' ');
            string input_string_censored = input_string;

            Console.WriteLine(string.Join(" ", input_string_censored));
        }
    }

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
