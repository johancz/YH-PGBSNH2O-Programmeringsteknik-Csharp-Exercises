using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lektion_6_Exercise_Objects_3
{
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Console.WriteLine("Enter text to automatically redact sensitive information from it: ");
            string input = Console.ReadLine();
            if (input.Length == 0) { input = "Classified: There are extraterrestrials at Area 51. Don't trespass into Area 51."; }
            
            string inputRedacted = input;
            if (input.StartsWith("Classified:")) {
                inputRedacted = inputRedacted.Remove(0, 11);
                inputRedacted = inputRedacted.Replace("Area 51", "[AN UNDISCLOSED LOCATION]");
                inputRedacted = inputRedacted.Trim();
            }

            Console.WriteLine(inputRedacted);
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Test()
        {
            using FakeConsole console = new FakeConsole("Classified: There are extraterrestrials at Area 51. Don't trespass into Area 51.");
            Program.Main();
            Assert.AreEqual("There are extraterrestrials at [AN UNDISCLOSED LOCATION]. Don't trespass into [AN UNDISCLOSED LOCATION].", console.Output);
        }
    }
}
