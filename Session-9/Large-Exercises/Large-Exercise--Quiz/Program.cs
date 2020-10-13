using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Large_Exercise__Quiz
{
    public class Program
    {
        public static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;


        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void ExampleTest()
        {
            using FakeConsole console = new FakeConsole("First input", "Second input");
            Program.Main();
            Assert.AreEqual("Hello!", console.Output);
        }
    }
}
