using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/*
 * Exercise 7 - Extract domain name
 * Write a program that extracts the domain name without the top-level domain (TLD) from an email address.
 * For example, if the email address is brad@example.com, the result should be example.
 * The program should also handle email addresses with periods in the user name (such as brad.pitt@example.com).
 */

namespace Session_7_Exercise_problem_solving_7_extract_domain_name
{
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Console.WriteLine("Input an email address:");
            string input_email_address = Console.ReadLine();
            //if (input_email_address.Length == 0) { input_email_address = "example.example@example.com"; }
            URL_Part[] uRL_Parts2 = {
                new URL_Part("username", '@'),
                new URL_Part("hostname", '.'),
                new URL_Part("tld", ' ')
            };
            int current_part_i = 0;

            // This requires a valid email address or it will not extract its parts correctly.
            // E.g. if '@' is missing, example.exampleexample.com, the program will extract 'example.exampleexample.com' as the username.
            foreach (char c in input_email_address)
            {
                if (c == uRL_Parts2[current_part_i].partSeparator)
                {
                    current_part_i++;
                }
                else
                {
                    uRL_Parts2[current_part_i].partText += c;
                }
            }

            foreach (URL_Part urlpart in uRL_Parts2)
            {
                if (urlpart.partName == "hostname")
                {
                    if (urlpart.partText.Length == 0)
                    {
                        Console.WriteLine($"Malformed email address (missing hostname)!");
                    }
                    else
                    {
                        Console.WriteLine($"{urlpart.partName}: {urlpart.partText}");
                    }
                }
            }
        } // end of 'void Main'

        [TestClass]
        public class ProgramTests
        {
            [TestMethod]
            public void Test1()
            {
                using FakeConsole console = new FakeConsole("mad@example.com");
                Program.Main();
                Assert.AreEqual("hostname: example", console.Output);
            }
            [TestMethod]
            public void Test2()
            {
                using FakeConsole console = new FakeConsole("mad.git@example.com");
                Program.Main();
                Assert.AreEqual("hostname: example", console.Output);
            }
            [TestMethod]
            public void Test3()
            {
                using FakeConsole console = new FakeConsole("mad.git@");
                Program.Main();
                Assert.AreEqual("Malformed email address (missing hostname)!", console.Output);
            }
            [TestMethod]
            public void Test4()
            {
                using FakeConsole console = new FakeConsole("@");
                Program.Main();
                Assert.AreEqual("Malformed email address (missing hostname)!", console.Output);
            }
            [TestMethod]
            public void Test5()
            {
                using FakeConsole console = new FakeConsole("example.exampleexample.com");
                Program.Main();
                Assert.AreEqual("Malformed email address (missing hostname)!", console.Output);
            }
            [TestMethod]
            public void Test6_malformedEmailAddress_missingTLD()
            {
                using FakeConsole console = new FakeConsole("example.example@examplecom");
                Program.Main();
                Assert.AreEqual("hostname: examplecom", console.Output);
            }
        }
    } // end of 'class Program'

    public struct URL_Part
    {
        public string partName { get; private set; }
        public char partSeparator { get; private set; }
        public string partText { get; set; }

        public URL_Part(string partName, char partSeparator)
        {
            this.partName = partName;
            this.partSeparator = partSeparator;
            this.partText = "";
        }
    }
} // end of 'namespace'
