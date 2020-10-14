using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Session_13_Exercise_Optional_arguments
{
    public class Program
    {
        public static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Console.WriteLine("0: " + HideStringChar("hello"));
            Console.WriteLine("1: " + HideStringChar("hello", 'x'));
            Console.WriteLine("2: " + HideStringChar2("hello"));
            Console.WriteLine("3: " + HideStringChar2("hello", 'x'));
            Console.WriteLine("4: " + HideString("hello"));
            Console.WriteLine("5: " + HideString("hello", "x"));
            Console.WriteLine("6: " + HideString2("hello"));
            Console.WriteLine("7: " + HideString2("hello", "x"));
            Console.WriteLine("8: " + HideString("hello", "xxx"));
            Console.WriteLine("9: " + HideString2("hello", "xxx"));
        }

        public static string HideStringChar(string s)
        {
            return new String('*', s.Length);
        }

        public static string HideStringChar(string s, char c)
        {
            return new String(c, s.Length);
        }

        public static string HideStringChar2(string s, char c = '*')
        {
            return new String(c, s.Length);
        }

        public static string HideString(string s)
        {
            return new String('*', s.Length);
        }

        public static string HideString(string s, string s2)
        {
            return String.Join("", s.Select(_c => s2).ToArray());
        }

        public static string HideString2(string s, string s2 = "*")
        {
            //return String.Join(s.Select(_c => s2).ToString(), "");
            return String.Join("", s.Select(_c => s2).ToArray());
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Test_HideStringChar_OneParam_ReplaceWithStars()
        {
            string result = Program.HideStringChar("hello");
            Assert.AreEqual("*****", result);
        }
        [TestMethod]
        public void Test_HideStringChar_TwoParams_ReplaceWithLowercaseX()
        {
            string result = Program.HideStringChar("hello", 'x');
            Assert.AreEqual("xxxxx", result);
        }
        [TestMethod]
        public void Test_HideStringChar2_OneParam_ReplaceWithStars()
        {
            string result = Program.HideStringChar2("hello");
            Assert.AreEqual("*****", result);
        }
        [TestMethod]
        public void Test_HideStringChar2_TwoParam_ReplaceWithLowercaseX()
        {
            string result = Program.HideStringChar2("hello", 'x');
            Assert.AreEqual("xxxxx", result);
        }
        [TestMethod]
        public void Test_HideString_OneParam_ReplaceWithStars()
        {
            string result = Program.HideString("hello");
            Assert.AreEqual("*****", result);
        }
        [TestMethod]
        public void Test_HideString_TwoParam_ReplaceWithLowercaseX()
        {
            string result = Program.HideString("hello", "x");
            Assert.AreEqual("xxxxx", result);
        }
        [TestMethod]
        public void Test_HideString2_OneParam_ReplaceWithStars()
        {
            string result = Program.HideString2("hello");
            Assert.AreEqual("*****", result);
        }
        [TestMethod]
        public void Test_HideString2_TwoParam_ReplaceWithLowercaseX()
        {
            string result = Program.HideString2("hello", "x");
            Assert.AreEqual("xxxxx", result);
        }
        [TestMethod]
        public void Test_HideString_TwoParam_ReplaceWithStringOfLowercaseX()
        {
            string result = Program.HideString("hello", "xxx");
            Assert.AreEqual("xxxxxxxxxxxxxxx", result);
        }
        [TestMethod]
        public void Test_HideString2_TwoParam_ReplaceWithStringOfLowercaseX()
        {
            string result = Program.HideString2("hello", "xxx");
            Assert.AreEqual("xxxxxxxxxxxxxxx", result);
        }
    }
}
