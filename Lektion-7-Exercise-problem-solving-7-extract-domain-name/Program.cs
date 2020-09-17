/*
 * Exercise 7 - Extract domain name
 * Write a program that extracts the domain name without the top-level domain (TLD) from an email address.
 * For example, if the email address is brad@example.com, the result should be example.
 * The program should also handle email addresses with periods in the user name (such as brad.pitt@example.com).
 */

using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Session_7_Exercise_problem_solving_7_extract_domain_name
{
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

    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            string input_email_address = Console.ReadLine();
            //string[] tlds = { "com", "net", "se", "org" };
            //string username = "", hostname = "", tld = "";
            //string[] URL_parts = { "username", "hostname", "tld" };
            //string current_part = "username";
            //Dictionary<string, char> partsAndSeparators = new Dictionary<string, char>
            //{
            //    ["username"] = '@',
            //    ["hostname"] = '.',
            //    ["tld"] = ' '
            //};
            //Dictionary<int, URL_Part> URL_Parts_Data = new Dictionary<int, URL_Part>
            //{
            //    [0] = new URL_Part("username", '@'),
            //    [1] = new URL_Part("hostname", '.'),
            //    [2] = new URL_Part("tld", ' ')
            //};
            //Dictionary<string, URL_Part> URL_Parts_Data2 = new Dictionary<string, URL_Part>
            //{
            //    ["username"] = new URL_Part("username", '@'),
            //    ["hostname"] = new URL_Part("hostname", '.'),
            //    ["tld"] = new URL_Part("tld", ' ')
            //};
            URL_Part[] uRL_Parts2 = {
                new URL_Part("username", '@'),
                new URL_Part("hostname", '.'),
                new URL_Part("tld", ' ')
            };
            int current_part_dict = 0;

            foreach (char c in input_email_address)
            {
                //partsAndSeparators[]
                if (c == uRL_Parts2[current_part_dict].partSeparator)
                {
                    current_part_dict++;
                }
                else
                {
                    uRL_Parts2[current_part_dict].partText += c;
                }
            }

            foreach (URL_Part urlpart in uRL_Parts2)
            {
                Console.WriteLine($"{urlpart.partName}: {urlpart.partText}");
            }

            //foreach (char c in input_email_address)
            //{
            //    if (current_part == "username")
            //    {
            //        if (c == '@')
            //        {
            //        }
            //    }

            //    if (current_part == "username")
            //    {
            //        if (c != '@')
            //        {
            //            username += c;
            //        }
            //        else
            //        {
            //            current_part = "hostname";
            //        }
            //    }
            //    else if (current_part == "hostname")
            //    {
            //        if (c != '.')
            //        {
            //            hostname += c;
            //        }
            //        else
            //        {
            //            current_part = "tld";
            //        }
            //    }
            //    else if (current_part == "tld")
            //    {
            //        tld += c;
            //    }
            //}
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
}
