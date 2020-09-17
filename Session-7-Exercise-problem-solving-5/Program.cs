// 5. Write a program that reads two strings from the user and determines whether they are anagrams. Two words are anagrams if they contain exactly the same letters, just in a different order.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Session_7_Exercise_problem_solving_5
{
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Console.WriteLine("Anagram checker");
            Console.WriteLine("Enter two words:");
            string word1 = Console.ReadLine().Trim();
            string word2 = Console.ReadLine().Trim();
            List<char> word2_list = new List<char>(word2);
            bool areAnagrams = false;

            if (word1.Length == word2.Length)
            {
                foreach (char word1_c in word1)
                {
                    areAnagrams = false;

                    //for (int i = word2_list.Count - 1; i >= 0; i--)
                    //{
                    //    if (word1_c == word2_list[i])
                    //    {
                    //        areAnagrams = true;
                    //        word2_list.RemoveAt(i);
                    //        break;
                    //    }
                    //}

                    foreach (char word2_c in word2_list)
                    {
                        if (word1_c == word2_c)
                        {
                            areAnagrams = true;
                            word2_list.Remove(word2_c);
                            break;
                        }
                    }

                    if (!areAnagrams)
                    {
                        break;
                    }
                }
            }

            if (areAnagrams)
            {
                Console.WriteLine($"\"{word1}\" and \"{word2}\" are anagrams.");
            }
            else
            {
                Console.WriteLine($"\"{word1}\" and \"{word2}\" are NOT anagrams.");
            }
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Test_areAnagram()
        {
            using FakeConsole console = new FakeConsole("two", "tow");
            Program.Main();
            Assert.AreEqual("\"two\" and \"tow\" are anagrams.", console.Output);
        }
        [TestMethod]
        public void Test_areAnagram2()
        {
            using FakeConsole console = new FakeConsole("two", "owt");
            Program.Main();
            Assert.AreEqual("\"two\" and \"owt\" are anagrams.", console.Output);
        }
        [TestMethod]
        public void Test_areAnagram3()
        {
            using FakeConsole console = new FakeConsole("two", "wot");
            Program.Main();
            Assert.AreEqual("\"two\" and \"wot\" are anagrams.", console.Output);
        }
        [TestMethod]
        public void Test_areNotAnagram()
        {
            using FakeConsole console = new FakeConsole("two", "tww");
            Program.Main();
            Assert.AreEqual("\"two\" and \"tww\" are NOT anagrams.", console.Output);
        }
        [TestMethod]
        public void Test_areNotAnagram2()
        {
            using FakeConsole console = new FakeConsole("two", "ttt");
            Program.Main();
            Assert.AreEqual("\"two\" and \"ttt\" are NOT anagrams.", console.Output);
        }
        [TestMethod]
        public void Test_areNotAnagram3()
        {
            using FakeConsole console = new FakeConsole("two", "www");
            Program.Main();
            Assert.AreEqual("\"two\" and \"www\" are NOT anagrams.", console.Output);
        }
        [TestMethod]
        public void Test_areNotAnagram4()
        {
            using FakeConsole console = new FakeConsole("two", "ooo");
            Program.Main();
            Assert.AreEqual("\"two\" and \"ooo\" are NOT anagrams.", console.Output);
        }
        [TestMethod]
        public void Test_blankWords()
        {
            using FakeConsole console = new FakeConsole("", "");
            Program.Main();
            Assert.AreEqual("\"\" and \"\" are NOT anagrams.", console.Output);
        }
        [TestMethod]
        public void Test_differentLengthsButSameLetters()
        {
            using FakeConsole console = new FakeConsole("two", "towtow");
            Program.Main();
            Assert.AreEqual("\"two\" and \"towtow\" are NOT anagrams.", console.Output);
        }
    }
}
