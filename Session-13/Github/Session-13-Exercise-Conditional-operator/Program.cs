using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Session_13_Exercise_Conditional_operator
{
    public class Program
    {
        public static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            //double temperature = -1;
            //double temperature = 0;
            //double temperature = 50;
            //double temperature = 100;
            double temperature = 101;

            //Skriv om följande kod så att den använder conditional operator istället för if-satser:
            {
                string message;
                if (temperature >= 100)
                {
                    message = "Boiling";
                }
                else
                {
                    message = "Normal";
                }
                Console.WriteLine(message);
            }
            // svar/lösning:
            {
                string message = temperature >= 100 ? "Boiling" : "Normal";
                Console.WriteLine(message);
            }

            //Skriv om följande kod så att den använder conditional operator istället för if-satser:
            {
                string message;
                if (temperature >= 100)
                {
                    message = "Boiling";
                }
                else if (temperature <= 0)
                {
                    message = "Freezing";
                }
                else
                {
                    message = "Normal";
                }
                Console.WriteLine(message);
            }
            // svar/lösning:
            {
                string message = temperature >= 100 ? "Boiling" : (temperature <= 0 ? "Freezing" : "Normal");
                Console.WriteLine(message);
            }
        }
    }

    //[TestClass]
    //public class ProgramTests
    //{
    //    [TestMethod]
    //    public void ExampleTest()
    //    {
    //        using FakeConsole console = new FakeConsole("First input", "Second input");
    //        Program.Main();
    //        Assert.AreEqual("Hello!", console.Output);
    //    }
    //}
}
