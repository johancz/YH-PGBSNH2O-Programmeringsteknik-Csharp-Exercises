using System;
using System.Linq;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Session_8_method_definitions_Exercise_3
{
    public class ConsoleHelper
    {
        public static string ReadString(string prompt)
        {
            Console.WriteLine(prompt);

            string input = Console.ReadLine();

            return input;
        }

        public static int ReadInt(string prompt)
        {
            int input_int;

            while (true)
            {
                Console.WriteLine(prompt);

                if (!int.TryParse(Console.ReadLine(), out input_int))
                {
                    Console.WriteLine("Invalid input, cannot convert to 'Integer'. Try again!");
                    continue;
                }

                break;
            }

            return input_int;
        }

        public static double ReadDouble(string prompt)
        {
            double input_double;

            while (true)
            {
                Console.WriteLine(prompt);

                if (!double.TryParse(Console.ReadLine(), out input_double))
                {
                    Console.WriteLine("Invalid input, cannot convert to 'Double'. Try again!");
                    continue;
                }

                break;
            }

            return input_double;
        }

        public static bool ReadBool(string prompt)
        {
            bool input_bool;

            while (true)
            {
                Console.WriteLine(prompt);

                string input = Console.ReadLine().Trim().ToLower();
                string[] trueStrings = { "yes", "y", "1" };
                string[] falseStrings = { "no", "no", "0" };
                bool couldParse = bool.TryParse(input, out input_bool);

                if (!couldParse && trueStrings.Contains(input))
                {
                    input_bool = true;
                }
                else if (!couldParse && falseStrings.Contains(input))
                {
                    input_bool = false;
                }
                else if (!couldParse)
                {
                    Console.WriteLine("Invalid input, cannot convert to 'Boolean'. Try again!");
                    continue;
                }

                break;
            }

            return input_bool;
        }
    }

    [TestClass]
    public class ConsoleHelper_ReadString
    {
        [TestMethod]
        public void Test_ReadString()
        {
            using FakeConsole console = new FakeConsole("This is a test string.");
            string input = ConsoleHelper.ReadString("String string test:");
            Assert.AreEqual("This is a test string.", input);
        }
    }

    [TestClass]
    public class ConsoleHelper_ReadInt
    {
        [TestMethod]
        public void Test_ReadInt()
        {
            //throw new NotImplementedException();
            using FakeConsole console = new FakeConsole("This is a test string.");
            int input = ConsoleHelper.ReadInt("String string test:");
            Assert.AreEqual("This is a test string.", input);
        }
    }

    [TestClass]
    public class ConsoleHelper_ReadDouble
    {
        [TestInitialize]
        public void TestInit()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
        }

        [TestMethod]
        public void Test_ReadDouble()
        {
            //throw new NotImplementedException();
            using FakeConsole console = new FakeConsole("This is a test string.", "1.1");
            double input = ConsoleHelper.ReadDouble("String string test:");
            Console.WriteLine(input);
            Assert.AreEqual(1.0, console.AllLines[1]);
        }
    }

    /* [START] Tests for ConsoleHelper.ReadBool() */
    [TestClass]
    public class ConsoleHelper_ReadBool
    {
        /* [START] Tests that should return bool:true */
        [TestMethod]
        public void Test_ReadBool_true()
        {
            using FakeConsole console = new FakeConsole("true");
            bool input_bool = ConsoleHelper.ReadBool("Bool string test:");
            Assert.AreEqual(true, input_bool);
        }

        [TestMethod]
        public void Test_ReadBool_yes()
        {
            using FakeConsole console = new FakeConsole("yes");
            bool input_bool = ConsoleHelper.ReadBool("Bool string test:");
            Assert.AreEqual(true, input_bool);
        }

        [TestMethod]
        public void Test_ReadBool_y()
        {
            using FakeConsole console = new FakeConsole("y");
            bool input_bool = ConsoleHelper.ReadBool("Bool string test:");
            Assert.AreEqual(true, input_bool);
        }
        [TestMethod]
        public void Test_ReadBool_TRUE()
        {
            using FakeConsole console = new FakeConsole("TRUE");
            bool input_bool = ConsoleHelper.ReadBool("Bool string test:");
            Assert.AreEqual(true, input_bool);
        }

        [TestMethod]
        public void Test_ReadBool_YES()
        {
            using FakeConsole console = new FakeConsole("YES");
            bool input_bool = ConsoleHelper.ReadBool("Bool string test:");
            Assert.AreEqual(true, input_bool);
        }

        [TestMethod]
        public void Test_ReadBool_Y()
        {
            using FakeConsole console = new FakeConsole("Y");
            bool input_bool = ConsoleHelper.ReadBool("Bool string test:");
            Assert.AreEqual(true, input_bool);
        }

        [TestMethod]
        public void Test_ReadBool_number1()
        {
            using FakeConsole console = new FakeConsole("1");
            bool input_bool = ConsoleHelper.ReadBool("Bool string test:");
            Assert.AreEqual(true, input_bool);
        }
        /* [END] Tests that should return bool:true */

        /* [START] Tests that should return bool:false */
        [TestMethod]
        public void Test_ReadBool_false()
        {
            using FakeConsole console = new FakeConsole("false");
            bool input_bool = ConsoleHelper.ReadBool("Bool string test:");
            Assert.AreEqual(false, input_bool);
        }

        [TestMethod]
        public void Test_ReadBool_no()
        {
            using FakeConsole console = new FakeConsole("no");
            bool input_bool = ConsoleHelper.ReadBool("Bool string test:");
            Assert.AreEqual(false, input_bool);
        }

        [TestMethod]
        public void Test_ReadBool_n()
        {
            using FakeConsole console = new FakeConsole("n");
            bool input_bool = ConsoleHelper.ReadBool("Bool string test:");
            Assert.AreEqual(false, input_bool);
        }
        [TestMethod]
        public void Test_ReadBool_FALSE()
        {
            using FakeConsole console = new FakeConsole("FALSE");
            bool input_bool = ConsoleHelper.ReadBool("Bool string test:");
            Assert.AreEqual(false, input_bool);
        }

        [TestMethod]
        public void Test_ReadBool_NO()
        {
            using FakeConsole console = new FakeConsole("NO");
            bool input_bool = ConsoleHelper.ReadBool("Bool string test:");
            Assert.AreEqual(false, input_bool);
        }

        [TestMethod]
        public void Test_ReadBool_N()
        {
            using FakeConsole console = new FakeConsole("N");
            bool input_bool = ConsoleHelper.ReadBool("Bool string test:");
            Assert.AreEqual(false, input_bool);
        }

        [TestMethod]
        public void Test_ReadBool_number0()
        {
            using FakeConsole console = new FakeConsole("0");
            bool input_bool = ConsoleHelper.ReadBool("Bool string test:");
            Assert.AreEqual(false, input_bool);
        }
        /* [END] Tests that should return bool:false */

        /* [START] Tests that should fail parsing and prompt the user again */
        // TODO(johancz) Figure out how to test output from before the latest Console.ReadLine. Modify FakeConsole.cs?
        /* [END] Tests that should fail parsing and prompt the user again */
    }
    /* [END] Tests for ConsoleHelper.ReadBool() */
}
