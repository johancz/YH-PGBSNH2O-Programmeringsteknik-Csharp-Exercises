using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Session_13_Exercise_TuplesToObjects
{
    public class Person
    {
        public string Name;
        public int Age;
        public double Height;
    }

    public class Program
    {
        public static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            var person = new Person
            {
                Name = "Brad",
                Age = 56,
                Height = 1.82
            };
            string summary = Program.SummarizePerson(person);
            Console.WriteLine(summary);
        }

        public static string SummarizePerson(Person person)
        {
            return person.Name + " is " + person.Age + " years old and " + person.Height + " meters tall";
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
            var person = new Person
            {
                Name = "Brad",
                Age = 56,
                Height = 1.82
            };
            string summary = Program.SummarizePerson(person);
            Assert.AreEqual("Brad is 56 years old and 1.82 meters tall", summary);
        }
    }
}
