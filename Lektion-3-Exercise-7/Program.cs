using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lektion_3_Exercise_7
{
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            // Rewrite the following expression so that it doesn't use the && operator: bool result = !(x && y).

            Console.WriteLine(testExpression(true, true)
                              + ", " + testExpression(false, true)
                              + ", " + testExpression(true, false)
                              + ", " + testExpression(false, false)
            );
        }

        private static bool testExpression(bool x, bool y)
        {
            return !(x && y) == !x || !y;
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Test_All_True()
        {
            using FakeConsole console = new FakeConsole();
            Program.Main();
            Assert.AreEqual("True, True, True, True", console.Output);
        }
    }
}
