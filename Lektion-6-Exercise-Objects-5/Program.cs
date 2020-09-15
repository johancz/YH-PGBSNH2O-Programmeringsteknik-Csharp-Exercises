using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lektion_6_Exercise_Objects_5
{
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Exercise();
        }

        public static void Exercise()
        {
            Console.WriteLine("Enter some text:");
            string input = Console.ReadLine();

            // Method 1:
            string[] words = input.Split(new[] { ' ', ',', '.' }, StringSplitOptions.RemoveEmptyEntries);

            //Method 2:
            //List<string> words2 = new List<String>(input.Split(new[] { ' ', ',', '.' }));
            //words2.RemoveAll((w) =>
            //{
            //    return w == "";
            //});

            // Method 3:
            //List<string> words3 = new List<String>(input.Split(new[] { ' ', ',', '.' }));
            //for (int i = words3.Count() - 1; i >= 0; i--)
            //{
            //    //if (words3.ElementAt(i) == "")
            //    if (words3[i] == "")
            //    {
            //        words3.RemoveAt(i);
            //    }
            //}

            if (words.Length == 0)
            {
                Console.WriteLine("Could not find any words.");
                return;
            }

            Dictionary<string, int> wordCounts = new Dictionary<string, int>();

            foreach (string s in words)
            {
                if (!wordCounts.ContainsKey(s))
                {
                    wordCounts.Add(s, 1);
                }
                else
                {
                    wordCounts[s]++;
                }

            }

            // Create a "blank" KeyValuePair ('mostFrequentWord') so that there is something to compare to in the first iteration.
            KeyValuePair<string, int> mostFrequentWord = new KeyValuePair<string, int>(null, 0);
            foreach (KeyValuePair<string, int> wordCount in wordCounts)
            {
                if (wordCount.Value >= mostFrequentWord.Value)
                {
                    mostFrequentWord = wordCount;
                }
            }

            Console.WriteLine("The most frequent word is " + mostFrequentWord.Key + " with " + mostFrequentWord.Value + " occurances.");
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Test1()
        {
            using FakeConsole console = new FakeConsole("hello hello hi hello. hello, hi, hello, hello.");
            Program.Main();
            Assert.AreEqual("The most frequent word is hello with 6 occurances.", console.Output);
        }

        [TestMethod]
        public void Test2()
        {
            using FakeConsole console = new FakeConsole("hello hello hi hello. hello, hi, hello, hello. hi hi. hi hi,,");
            Program.Main();
            Assert.AreEqual("The most frequent word is hi with 6 occurances.", console.Output);
        }

        [TestMethod]
        public void Test3()
        {
            using FakeConsole console = new FakeConsole(" . . . ..  ,, ., .. ,. .., ., .,,");
            Program.Main();
            Assert.AreEqual("Could not find any words.", console.Output);
        }

        [TestMethod]
        public void Test4()
        {
            using FakeConsole console = new FakeConsole("e- -e e- e- - -");
            Program.Main();
            Assert.AreEqual("The most frequent word is e- with 3 occurances.", console.Output);
        }
    }
}
