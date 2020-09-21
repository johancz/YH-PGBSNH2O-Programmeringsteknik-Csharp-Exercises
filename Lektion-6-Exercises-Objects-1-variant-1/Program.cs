using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lektion_6_Exercises_Objects_1_variant_1
{
    // Write a variant (of Lektion_6_Exercises_Objects_1) that removes all special character except numbers and English letters. You might have to convert/cast the characters to integers in order to check this. Optionally, also translate a set of specific characters to English equivalents (such as translating Å, Ä, and Ö to A and O).
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            string input = Console.ReadLine();
            if (input.Length == 0)
            {
                //input = "https://CSHARP.jakobkallin.com/Composite data/#objects (OH HO)älåläÖÄÖaÅö#¤a\\¤/?_-a-!\"\'a";
                input = "https:://CSHARP..jakobkallin..com//Composite  data//##objects  (OH  HO)äälåålääÖÖÄÖaÅÅöö##¤¤a\\\\//??__--a!!\"\"\'\'a";
            }
            Console.WriteLine(input);

            input = input.Replace('å', 'a').Replace('ä', 'a').Replace('ö', 'o').Replace('Å', 'A').Replace('Ä', 'A').Replace('Ö', 'O');
            List<char> charsToRemove = new List<char>();

            foreach (char c in input)
            {
                int ci = (int)c;
                if (!((ci >= 48 && ci <= 57) || (ci >= 65 && ci <= 90) || (ci >= 97 && ci <= 122)))
                {
                    charsToRemove.Add(c);
                }
            }

            foreach (char c in charsToRemove)
            {
                input = input.Replace(c.ToString(), "");
            }

            Console.WriteLine(input);
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void ExampleTest()
        {
            throw new NotImplementedException();
            using FakeConsole console = new FakeConsole("First input", "Second input");
            Program.Main();
            Assert.AreEqual("Hello!", console.Output);
        }
    }
}
