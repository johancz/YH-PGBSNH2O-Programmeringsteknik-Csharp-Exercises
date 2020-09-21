using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Session8_method_definitions_Exercise1
{
    public class Program
    {
        public static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            string input_string = ConsoleHelper.ReadString("Example:");
            int input_int = ConsoleHelper.ReadInt("Example:");
            double input_double = ConsoleHelper.ReadDouble("Example:");
            bool input_bool = ConsoleHelper.ReadBool("Example:");

            Console.WriteLine(input_string);
            Console.WriteLine(input_int);
            Console.WriteLine(input_double);
            Console.WriteLine(input_bool);
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
