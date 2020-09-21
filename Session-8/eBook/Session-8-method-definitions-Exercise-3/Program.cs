using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Session_8_method_definitions_Exercise_3
{
    public class Program
    {
        public static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            //CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            //string s = "999.99";
            //Console.WriteLine(double.TryParse(s, out double d));

            //var input = ConsoleHelper.ReadDouble("");
            //bool isLarge = Program.IsLarge(input);
        }

        public static bool IsLarge(string input)
        {
            return input.Length > 50;
        }

        public static bool IsLarge(int input)
        {
            return input > 1000;
        }

        public static bool IsLarge(double input)
        {
            return input > 1000;
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Test_String_tooShort()
        {
            using FakeConsole console = new FakeConsole("abc");
            var input = ConsoleHelper.ReadString("");
            bool isLarge = Program.IsLarge(input);
            Assert.AreEqual(false, isLarge);
        }

        [TestMethod]
        public void Test_String_longEnough()
        {
            using FakeConsole console = new FakeConsole("abcabcabcabcabcabcabcabcabcabcabcabcabcabcabcabcabc");
            var input = ConsoleHelper.ReadString("");
            bool isLarge = Program.IsLarge(input);
            Assert.AreEqual(true, isLarge);
        }

        [TestMethod]
        public void Test_Int_tooSmall()
        {
            using FakeConsole console = new FakeConsole("1000");
            var input = ConsoleHelper.ReadInt("");
            bool isLarge = Program.IsLarge(input);
            Assert.AreEqual(false, isLarge);
        }

        [TestMethod]
        public void Test_Int_LargeEnough()
        {
            using FakeConsole console = new FakeConsole("1001");
            var input = ConsoleHelper.ReadInt("");
            bool isLarge = Program.IsLarge(input);
            Assert.AreEqual(true, isLarge);
        }

        [TestMethod]
        public void Test_Double_tooSmall()
        {
            using FakeConsole console = new FakeConsole("999.99");
            var input = ConsoleHelper.ReadDouble("");
            bool isLarge = Program.IsLarge(input);
            Assert.AreEqual(true, isLarge);
        }

        [TestMethod]
        public void Test_Double_LargeEnough()
        {
            using FakeConsole console = new FakeConsole("1000.01");
            var input = ConsoleHelper.ReadDouble("");
            bool isLarge = Program.IsLarge(input);
            Assert.AreEqual(true, isLarge);
        }
    }
}
