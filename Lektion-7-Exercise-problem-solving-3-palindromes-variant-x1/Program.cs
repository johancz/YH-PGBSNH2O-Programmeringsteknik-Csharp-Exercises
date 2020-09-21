using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lektion_7_Exercise_problem_solving_3_palindromes_variant_x1
{
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            string input = Console.ReadLine(); if (input.Length == 0) input = "text txet text txet text txet";
            //string cleaned_input = RemoveAllExcept_LettersBlankspace(input);
            //string reversed = String_Reverse(cleaned_input);

            string[] words = input.Split(" ");
            //List<string> palindromes = new List<string>();
            Dictionary<string, int> palindromes = new Dictionary<string, int>();

            for (int i = 0; i < words.Length; i++)
            {
                string text = " ";

                for (int j = i; j < words.Length; j++)
                {
                    text += words[j] + " ";
                    string _text = text.Trim();

                    if (_text == String_Reverse(_text))
                    {
                        if (!palindromes.ContainsKey(_text))
                        {
                            palindromes.Add(_text, 0);
                        }

                        palindromes[_text]++;
                    }

                }
            }

            Console.WriteLine($"The text contains {palindromes.Count} unique palindromes and a total of {palindromes.Sum(p => p.Value)}.");
            foreach (KeyValuePair<string, int> s in palindromes)
            {
                Console.WriteLine(s);
            }

        }

        //public static string RemoveAllExcept_LettersBlankspace(string s)
        //{
        //    string new_s = "";

        //    foreach (char c in s)
        //    {
        //        if (char.IsLetter(c) || c == ' ')
        //        new_s += c;
        //    }

        //    return new_s;
        //}

        public static string String_Reverse(string s)
        {
            string reversed_s = "";

            for (int i = s.Length - 1; i >= 0; i--)
            {
                reversed_s += s[i];
            }

            return reversed_s;
        }
    }

        [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Test()
        {
            using FakeConsole console = new FakeConsole("text txet text txet text txet");
            Program.Main();
            CollectionAssert.AreEqual(new[] {
                "The text contains 5 unique palindromes and a total of 9.",
                "[text txet, 3]",
                "[text txet text txet, 2]",
                "[text txet text txet text txet, 1]",
                "[txet text, 2]",
                "[txet text txet text, 1]"
            }, console.Lines);
        }
    }
}
