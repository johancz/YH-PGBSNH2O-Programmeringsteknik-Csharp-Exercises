using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Session_7_Exercise_problem_solving_10_compress_string
{
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Console.WriteLine("Enter the text you want to compress:");
            string input = Console.ReadLine().Trim();
            if (input.Length == 0) { input = "aaaaaabbbbbccccccccccccddeeeeeeeeeeeeeefffg".Trim(); }

            string compressedString = Compress(input);
            Console.WriteLine("Original:\t" + input);
            Console.WriteLine("Compressed:\t" + compressedString);
            Console.WriteLine("Decompressed:\t" + Decompress(compressedString));
        }
        
        public static string Compress(string s)
        {
            string s2 = "" + s[0];
            int charCounter = 1;
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] == s2.Last())
                {
                    charCounter++;
                }
                else
                {
                    s2 += charCounter;
                    s2 += s[i];
                    charCounter = 1;
                }
            }
            s2 += charCounter;

            return s2;
        }

        public static string Decompress(string s)
        {
            string s2 = "";

            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];

                if (char.IsLetter(c))
                {
                    string repeatCount = "";

                    while (++i < s.Length && char.IsDigit(s[i]))
                    {
                        repeatCount += s[i];
                    }

                    s2 += new string(c, int.Parse(repeatCount));

                    i--;
                }
            }

            return s2;
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void ExampleTest()
        {
            using FakeConsole console = new FakeConsole("aaaaaabbbbbccccccccccccddeeeeeeeeeeeeeefffg");
            Program.Main();
            CollectionAssert.AreEqual(new[] {
                "Original:\taaaaaabbbbbccccccccccccddeeeeeeeeeeeeeefffg",
                "Compressed:\ta6b5c12d2e14f3g1",
                "Decompressed:\taaaaaabbbbbccccccccccccddeeeeeeeeeeeeeefffg"
            }, console.Lines);
        }
    }
}
