using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Session_13_Exercise_TuplesToObjects
{
    public class Program
    {
        public static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
        }

        public static string SummarizePerson((string, int, double) person)
        {
            return person.Item1 + " is " + person.Item2 + " years old and " + person.Item3 + " meters tall";
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestInitialize]
        public void TestInit()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
        }

        [TestMethod]
        public void ExampleTest()
        {
            var person = ("Brad", 56, 1.82);
            string summary = Program.SummarizePerson(person);
            Assert.AreEqual("Brad is 56 years old and 1.82 meters tall", summary);
        }
    }
}
