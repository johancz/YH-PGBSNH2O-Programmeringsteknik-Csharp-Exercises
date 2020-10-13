using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Session_13_Exercise_Implicitly_typed_variables_var
{
    public class Program
    {
        public static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            // Vilka av följande rader kod är ogiltiga? Varför?
            // Ogiltig, kan inte implicit välja datatyp om arrayen inte innehåller något värde, kan vara vilken datatyp som helst.
            // var a = new[] { };
            // Ogiltig, alla object kan ha värdet null, går inte att implicit avgöra vilken datatyp array bör vara.
            // var b = new[] { null };
            // var c = new[] { "" };            <- Giltig, dubbla citattecken, värdet är en string
            // var d = new[] { "abc", 123 };    <- ogiltig, kan inte avgöra datatypen om det finns flera datatyper.
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
