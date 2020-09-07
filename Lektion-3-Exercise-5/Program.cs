using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lektion_3_Exercise_5
{
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            // Exercise (Determine by hand (without a computer) the values of the following boolean expressions:)
            // 1. false || true                         == true
            // 2. false || false || true                == true
            // 3. true && false                         == false
            // 4. true && true && false                 == false
            // 5. (true && false) || (true || false)    == true
            // 6. !true || !false                       == true
            // 7. !true && !false                       == false
            // 8. !(true || false)                      == false
            // 9. !(true || false) && !false            == false
            // 10. !(!(true && false))                  == false

            Console.WriteLine("false || true == " + (false || true));
            Console.WriteLine("false || false || true == " + (false || false || true));
            Console.WriteLine("true && false == " + (true && false));
            Console.WriteLine("true && true && false == " + (true && true && false));
            Console.WriteLine("(true && false) || (true || false) == " + ((true && false) || (true || false)));
            Console.WriteLine("!true || !false == " + (!true || !false));
            Console.WriteLine("!true && !false == " + (!true && !false));
            Console.WriteLine("!(true || false) == " + (!(true || false)));
            Console.WriteLine("!(true || false) && !false == " + (!(true || false) && !false));
            Console.WriteLine("!(!(true && false)) == " + (!(!(true && false))));
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void TestOutput()
        {
            using FakeConsole console = new FakeConsole("First input", "Second input");
            Program.Main();
            CollectionAssert.AreEqual(new[] {
                "false || true == True",
                "false || false || true == True",
                "true && false == False",
                "true && true && false == False",
                "(true && false) || (true || false) == True",
                "!true || !false == True",
                "!true && !false == False",
                "!(true || false) == False",
                "!(true || false) && !false == False",
                "!(!(true && false)) == False"
                }, console.Lines);
        }
    }
}
