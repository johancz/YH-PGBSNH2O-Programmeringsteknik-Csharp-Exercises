using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lektion_2
{
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Program.DrawMenu();
        }

        public static void DrawMenu()
        {
            Console.WriteLine("Choose which exercise to run (1-" + Exercises.Count + "), exit with 0:");

            //ConsoleKeyInfo key = Console.ReadKey();
            //Console.WriteLine();
            int key = InputParser.parseString_intoInt();
            Console.WriteLine("key" + key);

            //if (key.Key != System.ConsoleKey.Escape)
            //{
            //}
            switch (key)
            {
                case 1:
                    Exercises.Exercise1();
                    break;
                case 2:
                    Exercises.Exercise2();
                    break;
                case 3:
                    Exercises.Exercise3();
                    break;
                case 4:
                    Exercises.Exercise4();
                    break;
                case 5:
                    Exercises.Exercise5();
                    break;
                case 6:
                    Exercises.Exercise6();
                    break;
                case 7:
                    Exercises.Exercise7();
                    break;
                default:
                    Console.WriteLine("Invalid exercise number.");
                    Program.DrawMenu();
                    break;
            }
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Test_Exercise1()
        {
            using FakeConsole console = new FakeConsole("1");
            Program.Main();
            Assert.AreEqual("7, 19, 4, 3", console.Output);
        }

        [TestMethod]
        public void Test_Exercise2()
        {
            using FakeConsole console = new FakeConsole("2", "50", "1050");
            Program.Main();
            Assert.AreEqual("You have a total of $1100.", console.Output);
        }

        [TestMethod]
        public void Test_Exercise2_testForBroke()
        {
            using FakeConsole console = new FakeConsole("2", "0", "0");
            Program.Main();
            Assert.AreEqual("You're broke.", console.Output);
        }

        /* The testing "library" can't test anything but the last line. This test get stuck waiting. */
        //[TestMethod]
        //public void Test_Exercise2_testForEmptyInput()
        //{
        //    using FakeConsole console = new FakeConsole("2", "", "");
        //    Program.Main();
        //    Assert.AreEqual("Try again! - Cash ($):", console.Output);
        //}
    }
}
