using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lektion_7_Exercise_problem_solving_3_palindromes
{
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Console.WriteLine("Input text:");
            string input = Console.ReadLine(); if (input.Length == 0) input = "text txet text txet text txet";
            string reversed_input = "";

            for (int i = input.Length - 1; i >= 0; i--)
            {
                reversed_input += input[i];
            }

            if (input == reversed_input)
            {
                Console.WriteLine("The text is a palindrome.");
            }
            else
            {
                Console.WriteLine("The text is not a palindrome.");
            }
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Test1()
        {
            using FakeConsole console = new FakeConsole("text txet text txet text txet");
            Program.Main();
            Assert.AreEqual("The text is a palindrome.", console.Output);
        }

        [TestMethod]
        public void Test2()
        {
            using FakeConsole console = new FakeConsole("");
            Program.Main();
            Assert.AreEqual("The text is a palindrome.", console.Output);
        }

        [TestMethod]
        public void Test3()
        {
            using FakeConsole console = new FakeConsole("text");
            Program.Main();
            Assert.AreEqual("The text is not a palindrome.", console.Output);
        }

        [TestMethod]
        public void Test4()
        {
            using FakeConsole console = new FakeConsole("x");
            Program.Main();
            Assert.AreEqual("The text is a palindrome.", console.Output);
        }

        [TestMethod]
        public void Test5()
        {
            using FakeConsole console = new FakeConsole("oko");
            Program.Main();
            Assert.AreEqual("The text is a palindrome.", console.Output);
        }

        [TestMethod]
        public void Test6()
        {
            using FakeConsole console = new FakeConsole("  ");
            Program.Main();
            Assert.AreEqual("The text is a palindrome.", console.Output);
        }

        [TestMethod]
        public void Test7()
        {
            using FakeConsole console = new FakeConsole("Was it a rat I saw?");
            Program.Main();
            Assert.AreEqual("The text is not a palindrome.", console.Output);
        }

        [TestMethod]
        public void Test8()
        {
            using FakeConsole console = new FakeConsole("A man, a plan, a canal: Panama!");
            Program.Main();
            Assert.AreEqual("The text is not a palindrome.", console.Output);
        }
    }
}
