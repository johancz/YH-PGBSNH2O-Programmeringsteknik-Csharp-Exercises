using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lektion_6_Exercises_Objects_1
{
    // Write a program that creates a “URL-friendly” version of a string. A URL-friendly string should follow these rules:
    //  * All letters should be lowercase.
    //  * All spaces should be replaced with underscores (_).
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            string input = Console.ReadLine();
            if (input.Length == 0)
            {
                input = "https://CSHARP.jakobkallin.com/Composite data/#objects (OH HO)";
            }

            Console.WriteLine(input);
            Console.WriteLine(input.Replace(' ', '_').ToLower());
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Test()
        {
            using FakeConsole console = new FakeConsole("https://CSHARP.jakobkallin.com/Composite data/#objects (OH HO)");
            Program.Main();
            Assert.AreEqual("https://csharp.jakobkallin.com/composite_data/#objects_(oh_ho)", console.Output);
        }
    }
}
