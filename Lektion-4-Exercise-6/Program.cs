using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lektion_4_Exercise_6
{
    public class Program
    {
        struct Dice
        {
            public int min;
            public int max;

            public Dice(int min, int max)
            {
                this.min = min;
                this.max = max;
            }
        }

        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Run_variant1();
        }

        public static void Run_variant1()
        {
            //int dice1_sides = 6;
            //int dice2_sides = 6;
            //var d1 = new { min = (int)1, max = (int)6 };
            //var d2 = new { min = (int)1, max = (int)6 };
            //int runCount_i1 = 0;
            //int runCount_i2 = 0;

            Dice d1 = new Dice(1, 6);
            Dice d2 = new Dice(1, 6);

            for (int i1 = d1.min; i1 <= d1.max; ++i1)
            {
                for (int i2 = d2.min; i2 <= d2.max; ++i2)
                {
                    Console.Write($"({i1}, {i2}){((i1 == d1.max && i2 == d2.max) ? "" : ", ")}");
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
            using FakeConsole console = new FakeConsole();
            Program.Main();
            Assert.AreEqual("(1, 1), (1, 2), (1, 3), (1, 4), (1, 5), (1, 6), (2, 1), (2, 2), (2, 3), (2, 4), (2, 5), (2, 6), (3, 1), (3, 2), (3, 3), (3, 4), (3, 5), (3, 6), (4, 1), (4, 2), (4, 3), (4, 4), (4, 5), (4, 6), (5, 1), (5, 2), (5, 3), (5, 4), (5, 5), (5, 6), (6, 1), (6, 2), (6, 3), (6, 4), (6, 5), (6, 6)", console.Output);
        }
    }
}
