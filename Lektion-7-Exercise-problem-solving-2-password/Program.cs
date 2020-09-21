using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lektion_7_Exercise_problem_solving_2_password
{
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Console.WriteLine("Password Validator");
            Console.Write("Enter a password: ");
            string passwordString = Console.ReadLine().Trim();
            bool passwordIsValid = false, validLength = false, hasUpperCaseLetter = false, hasLowerCaseLetter = false, hasDigit = false;
            int minPasswordLength = 8;

            if (passwordString.Length >= minPasswordLength)
            {
                validLength = true;
            }

            foreach (char c in passwordString)
            {
                if (!hasDigit && char.IsDigit(c))
                {
                    hasDigit = true;
                }
                else if (!hasUpperCaseLetter && char.IsUpper(c))
                {
                    hasUpperCaseLetter = true;
                }
                else if (!hasLowerCaseLetter && char.IsLower(c))
                {
                    hasLowerCaseLetter = true;
                }

                if (validLength && hasUpperCaseLetter && hasLowerCaseLetter && hasDigit)
                {
                    passwordIsValid = true;
                    break;
                }
            }

            if (passwordIsValid)
            {
                Console.WriteLine("The password is valid.");
            }
            else
            {
                Console.WriteLine("You did not enter a valid password.");
                if (!validLength)
                {
                    Console.WriteLine($"* The password is too short ({passwordString.Length}), " +
                        $"it needs to be at least {minPasswordLength} characters long.");
                }

                if (!hasLowerCaseLetter)
                {
                    Console.WriteLine("* It must include at least 1 lowercase letter.");
                }

                if (!hasUpperCaseLetter)
                {
                    Console.WriteLine("* It must include at least 1 uppercase letter.");
                }

                if (!hasDigit)
                {
                    Console.WriteLine("* It must include at least 1 digit.");
                }
            }
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Test_valid()
        {
            using FakeConsole console = new FakeConsole("pASSWORD1");
            Program.Main();
            CollectionAssert.AreEqual(new[] {
                "The password is valid."
            }, console.Lines);
        }

        [TestMethod]
        public void Test_allInvalid()
        {
            using FakeConsole console = new FakeConsole("!\"#¤%&/");
            Program.Main();
            CollectionAssert.AreEqual(new[] {
                "You did not enter a valid password.",
                "* The password is too short (7), it needs to be at least 8 characters long.",
                "* It must include at least 1 lowercase letter.",
                "* It must include at least 1 uppercase letter.",
                "* It must include at least 1 digit."
            }, console.Lines);
        }

        [TestMethod]
        public void Test_noLowercase()
        {
            using FakeConsole console = new FakeConsole("PASSWORD1");
            Program.Main();
            CollectionAssert.AreEqual(new[] {
                "You did not enter a valid password.",
                "* It must include at least 1 lowercase letter."
            }, console.Lines);
        }

        [TestMethod]
        public void Test_noUppercase()
        {
            using FakeConsole console = new FakeConsole("password1");
            Program.Main();
            CollectionAssert.AreEqual(new[] {
                "You did not enter a valid password.",
                "* It must include at least 1 uppercase letter."
            }, console.Lines);
        }

        [TestMethod]
        public void Test_noDigits()
        {
            using FakeConsole console = new FakeConsole("Password");
            Program.Main();
            CollectionAssert.AreEqual(new[] {
                "You did not enter a valid password.",
                "* It must include at least 1 digit."
            }, console.Lines);
        }

        [TestMethod]
        public void Test_tooShort()
        {
            using FakeConsole console = new FakeConsole("Passwo2");
            Program.Main();
            CollectionAssert.AreEqual(new[] {
                "You did not enter a valid password.",
                "* The password is too short (7), it needs to be at least 8 characters long."
            }, console.Lines);
        }

        [TestMethod]
        public void Test_noUppercaseNorDigits()
        {
            using FakeConsole console = new FakeConsole("password");
            Program.Main();
            CollectionAssert.AreEqual(new[] {
                "You did not enter a valid password.",
                "* It must include at least 1 uppercase letter.",
                "* It must include at least 1 digit."
            }, console.Lines);
        }

        [TestMethod]
        public void Test_noLowercaseNorDigits()
        {
            using FakeConsole console = new FakeConsole("PASSWORD");
            Program.Main();
            CollectionAssert.AreEqual(new[] {
                "You did not enter a valid password.",
                "* It must include at least 1 lowercase letter.",
                "* It must include at least 1 digit."
            }, console.Lines);
        }

        [TestMethod]
        public void Test_noLowerNorUppercase()
        {
            using FakeConsole console = new FakeConsole("12345678");
            Program.Main();
            CollectionAssert.AreEqual(new[] {
                "You did not enter a valid password.",
                "* It must include at least 1 lowercase letter.",
                "* It must include at least 1 uppercase letter.",
            }, console.Lines);
        }
    }
}
