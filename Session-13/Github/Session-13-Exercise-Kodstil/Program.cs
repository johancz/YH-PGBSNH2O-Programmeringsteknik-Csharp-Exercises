using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Session_13_Exercise_Kodstil
{
    public class Persons
    {
        //public string first_name;
        //public string lastName;
        //public int AGE;
        public string FirstName; // PascalCase and no underscore
        public string LastName; // PascalCase
        public int Age; // don't use all caps
    }

    public class Program
    {
        public static void Main()
        {
            Console.Write("First name: ");
            // Before:
            //string strFirstName = Console.ReadLine();
            // After:
            // Don't use hungarian notation. Keep camelcassing: First -> first
            string firstName = Console.ReadLine();

            Console.Write("Last name: ");

            // Before:
            //string lastName = Console.ReadLine();
            // After:
            // no change
            string lastName = Console.ReadLine();

            Console.Write("Age: ");
            int x = int.Parse(Console.ReadLine()); // before
            int age = int.Parse(Console.ReadLine()); // after: "age" better describes the variable

            //persons p = new persons
            //{
            //    first_name = strFirstName,
            //    lastName = lastName,
            //    AGE = x
            //};
            // After:
            // ClassName should be PascalCase
            // member variables should be Pascal case and should not include underscores,
            // "age" describes the variables better than "x"
            Persons p = new Persons
            {
                FirstName = firstName,
                LastName = lastName,
                Age = age
            };

            //if (p.AGE == 20)
            if (p.Age == 20) // member variables should be Pascal case
            {
                Console.WriteLine("You are 20");
            }
            //else if (p.AGE != 20)
            else // member variables should be Pascal case. Unnecessary conditional, use else instead
            {
                Console.WriteLine("You are not 20");
            }
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
