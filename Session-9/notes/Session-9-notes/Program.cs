using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Session_9_notes
{
    public class Program
    {
        public static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            //Console.WriteLine("Hello!");
            //string email = "example3.example2@example.com";
            ////string email = "example3.example2@.com";
            //int i_atSymbol = email.IndexOf('@');
            //string[] topLevelDomains =
            //{
            //    ".com",
            //    ".co.uk",
            //    ".org",
            //    ".se",
            //    ".net"
            //};

            //string domainNameWithoutTLD = "";
            //if (i_atSymbol > -1)
            //{
            //    int i_tldDot = -1;
            //    foreach (string tld in topLevelDomains)
            //    {
            //        i_tldDot = email.IndexOf(tld, i_atSymbol);
            //        break;
            //    }

            //    if (i_tldDot > i_atSymbol)
            //    {
            //        domainNameWithoutTLD = email.Substring(i_atSymbol + 1, i_tldDot - i_atSymbol - 1);
            //    }
            //}

            //if (domainNameWithoutTLD.Length > 0)
            //{
            //    Console.WriteLine($"The domain name (without TLD) of \"{email}\" is \"{domainNameWithoutTLD}\".");
            //}
            //else
            //{
            //    Console.WriteLine($"Could not extract a domain name (without TLD) from \"{email}\".");
            //}

            while ((_ = Program.getInt()) < 2)
            {
                Console.WriteLine("true");
            }
        }

        public static int getInt() { return 1; }
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
