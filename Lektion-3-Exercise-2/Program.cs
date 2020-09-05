using System;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lektion_3_Exercise_2
{
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Console.WriteLine("You need to be 18 or older to enter.");
            Console.Write("Please enter your age: ");

            int age;

            // If the input is not a valid int, print a warning and restart the program.
            if (!int.TryParse(Console.ReadLine(), out age))
            {
                Console.Clear();
                Console.WriteLine("You need to enter a valid age (only numbers)!\n");
                Main();
            }
            else
            {
                Console.Write("Choose variant: ");
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                    {
                        /* Variant 1 */
                        if (age >= 18)
                        {
                            Console.WriteLine("Access granted!");
                        }
                        else
                        {
                            Console.WriteLine("Access denied!");
                        }
                        break;
                    }
                    case 2:
                    {
                        /* Variant 2 */
                        // Negative age is OK, becaues that would be impressive.
                        if (Array.BinarySearch(System.Linq.Enumerable.Range(0, 18).ToArray(), age) < 0)
                        {
                            Console.WriteLine("Access granted!" + (age < 0 ? " cool!" : ""));
                        }
                        else
                        {
                            Console.WriteLine("Access denied!");
                        }
                        break;
                    }
                    default:
                        Console.WriteLine("You didn't enter a valid variant number.");
                        Main();
                        break;
                }
            }
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Test_Is18OrAbove_variant1()
        {
                                                        //age, variant
            using FakeConsole console = new FakeConsole("18", "1");
            Program.Main();
            Assert.AreEqual("Access granted!", console.Output);
        }
        [TestMethod]
        public void Test_IsBelow18_variant1()
        {
            //age, variant
            using FakeConsole console = new FakeConsole("17", "1");
            Program.Main();
            Assert.AreEqual("Access denied!", console.Output);
        }
        [TestMethod]
        public void Test_Is18OrAbove_variant2()
        {
            //age, variant
            using FakeConsole console = new FakeConsole("-1", "2");
            Program.Main();
            Assert.AreEqual("Access granted! cool!", console.Output);
        }
        [TestMethod]
        public void Test_IsBelow18_variant2()
        {
            //age, variant
            using FakeConsole console = new FakeConsole("17", "2");
            Program.Main();
            Assert.AreEqual("Access denied!", console.Output);
        }
    }
}
