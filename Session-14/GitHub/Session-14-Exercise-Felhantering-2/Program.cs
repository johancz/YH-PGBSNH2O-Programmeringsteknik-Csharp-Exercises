using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Session_14_Exercise_Felhantering_2
{
    public class Program
    {
        public static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            string[] filmTitles = new[]
            {
                "Blade Runner 2049",
                "Children of Men",
                "Interstellar",
                "Deadpool",
                "Guardian of the Galaxy"
            };

            Console.WriteLine("Pick a movie (enter the index in the list):");
            for (int i = 0; i < filmTitles.Length; i++)
            {
                Console.WriteLine($"[{i + 1}] {filmTitles[i]}"); // Start displayed list index at 1.
            }
            Console.WriteLine("\nVariant1Exceptions:");
            Variant1Exceptions(filmTitles);
            Console.WriteLine("\nVariant2Conditionals:");
            Variant2Conditionals(filmTitles);
        }

        public static void Variant1Exceptions(string[] filmTitles)
        {
            while (true)
            {
                string input = Console.ReadLine();

                try
                {
                    int chosenTitleIndex = Int32.Parse(input);
                    // Correct for printed list starting at index 1.
                    string title = filmTitles[chosenTitleIndex - 1];
                    Console.WriteLine($"You chose {title}, well done.");
                    break;
                }
                catch
                {
                    Console.WriteLine("Please enter the index of the movie in the list above.");
                }
            }
        }

        public static void Variant2Conditionals(string[] filmTitles)
        {
            while (true)
            {
                string input = Console.ReadLine();
                int chosenTitleIndex = Int32.Parse(input);

                if (chosenTitleIndex >= 1 && chosenTitleIndex <= filmTitles.Length)
                {
                    // Correct for printed list starting at index 1.
                    string title = filmTitles[chosenTitleIndex - 1];
                    Console.WriteLine($"You chose {title}, well done.");
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter the index of the movie in the list above.");
                }
            }
        }
    }

    [TestClass]
    public class ProgramTests
    {
        private string[] filmTitles;

        [TestInitialize]
        public void TestInit()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            this.filmTitles = new[]
            {
                "Blade Runner 2049",
                "Children of Men",
                "Interstellar",
                "Deadpool",
                "Guardian of the Galaxy"
            };
        }

        [TestMethod]
        public void Test_Variant1Exceptions_inputValid3_printsSelectedMovie()
        {
            using FakeConsole console = new FakeConsole("3");
            Program.Variant1Exceptions(filmTitles);
            Assert.AreEqual("You chose Interstellar, well done.", console.AllLines[1]);
        }

        [TestMethod]
        public void Test_Variant2Conditionals_inputValid3_printsSelectedMovie()
        {
            using FakeConsole console = new FakeConsole("4");
            Program.Variant2Conditionals(filmTitles);
            Assert.AreEqual("You chose Deadpool, well done.", console.AllLines[1]);
        }

        [TestMethod]
        public void Test_Variant1Exceptions_notInBoundsTooSmall_promptToTryAgain_withinBounds_printsSelectedMovie()
        {
            using FakeConsole console = new FakeConsole("0", "1");
            Program.Variant1Exceptions(filmTitles);
            Assert.AreEqual("Please enter the index of the movie in the list above.", console.AllLines[1]);
            Assert.AreEqual("You chose Blade Runner 2049, well done.", console.AllLines[2]);
        }

        [TestMethod]
        public void Test_Variant2Conditionals_notInBoundsTooSmall_promptToTryAgain_withinBounds_printsSelectedMovie()
        {
            using FakeConsole console = new FakeConsole("0", "2");
            Program.Variant2Conditionals(filmTitles);
            Assert.AreEqual("Please enter the index of the movie in the list above.", console.AllLines[1]);
            Assert.AreEqual("You chose Children of Men, well done.", console.AllLines[2]);
        }

        [TestMethod]
        public void Test_Variant1Exception_notParsableToInt32_promptToTryAgain_withinBounds_printsSelectedMovie()
        {
            using FakeConsole console = new FakeConsole("two", "5");
            Program.Variant1Exceptions(filmTitles);
            Assert.AreEqual("Please enter the index of the movie in the list above.", console.AllLines[1]);
            Assert.AreEqual("You chose Guardian of the Galaxy, well done.", console.AllLines[2]);
        }

        [TestMethod]
        [ExpectedException(typeof(System.FormatException))]
        public void Test_Variant2Conditionals_notParsableToInt32_FormatException()
        {
            using FakeConsole console = new FakeConsole("two");
            Program.Variant2Conditionals(filmTitles);
            Assert.AreEqual("Please enter the index of the movie in the list above.", console.AllLines[1]);
            Assert.AreEqual("You chose Blade Runner 2049, well done.", console.AllLines[2]);
        }

        [TestMethod]
        public void Test_Variant1Exceptions_notInBoundsTooLarge_promptToTryAgain_withinBounds_printsSelectedMovie()
        {
            using FakeConsole console = new FakeConsole("6", "1");
            Program.Variant1Exceptions(filmTitles);
            Assert.AreEqual("Please enter the index of the movie in the list above.", console.AllLines[1]);
            Assert.AreEqual("You chose Blade Runner 2049, well done.", console.AllLines[2]);
        }

        [TestMethod]
        public void Test_Variant2Conditionals_notInBoundsTooLarge_promptToTryAgain_withinBounds_printsSelectedMovie()
        {
            using FakeConsole console = new FakeConsole("6", "2");
            Program.Variant2Conditionals(filmTitles);
            Assert.AreEqual("Please enter the index of the movie in the list above.", console.AllLines[1]);
            Assert.AreEqual("You chose Children of Men, well done.", console.AllLines[2]);
        }
    }
}
