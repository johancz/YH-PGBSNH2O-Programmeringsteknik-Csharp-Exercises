using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lektion_5_Exercise_2
{
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            // solution 1:
            string text = "abcdef", text2 = "";

            for (int i = 0; i < text.Length - 1; i++)
            {
                text2 += "" + text[i] + '-';
            }

            text2 += text[text.Length - 1];

            Console.WriteLine($"string before: {text}, and after: {text2}");

            // solution 2:
            string textB = "abcdef", textB2 = "";

            for (int i = 0, last_i = textB.Length - 1; i <= last_i; i++)
            {
                textB2 += textB[i];

                if (i < last_i)
                {
                    textB2 += '-';
                }
            }

            Console.WriteLine($"string before: {textB}, and after: {textB2}");
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void ExampleTest()
        {
            using FakeConsole console = new FakeConsole();
            Program.Main();
            CollectionAssert.AreEqual(new[] {
                "string before: abcdef, and after: a-b-c-d-e-f",
                "string before: abcdef, and after: a-b-c-d-e-f"
            }, console.Lines);
        }
    }
}
