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
            Console.WriteLine("Choose which exercise to run (1-" + Exercises.Count + "):");

            ConsoleKeyInfo key = Console.ReadKey();
            Console.WriteLine();

            if (key.Key != System.ConsoleKey.Escape)
            {
                int i_key;
                int.TryParse(key.KeyChar.ToString(), out i_key);

                switch (i_key)
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
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void ExampleTest()
        {
            //using FakeConsole console = new FakeConsole("First input", "Second input");
            //Program.Main();
            //Assert.AreEqual("Hello!", console.Output);
        }
    }
}
