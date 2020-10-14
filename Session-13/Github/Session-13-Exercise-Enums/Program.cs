/* Exercise: Enums
Utgå från koden i EnumExample.
    1. Skriv om koden så att den använder enum istället för string till AgeCategory.
    2. Vad är fördelarna med enum i ett sånt här scenario?
*/

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Session_13_Exercise_Enums
{
    public enum AgeCategory {
        None,
        Senior,
        Child,
        Adult
    }
    // alt.
    //public enum AgeCategory
    //{
    //    Senior = 1,
    //    Child = 2,
    //    Adult = 3
    //}

    public class Person
    {
        public string FirstName;
        public string LastName;
        public AgeCategory AgeCategory;
    }

    public class Program
    {
        public static void Main()
        {
            Person p = new Person
            {
                FirstName = "Brad",
                LastName = "Pitt",
                AgeCategory = AgeCategory.Adult,
            };

            // 2. Fördelarna med enum är att du inte kan skriva fel i if-satsens uttryck.
            // "AgeCategory.Senior" finns men "AgeCategory.Senor" finns inte. Kompilatorn/VShade klagat på att
            // det inte finns en definition för "Senor" och därför inte kompilerat programmet.
            // Däremot så hade programmet kompilerats om uttrycket var "p.AgeCategory = "Senor",
            // och gjort så utan att producera några varningar.
            // Det kan på så sätt skapa buggar som kan vara svåra att identifiera.
            if (p.AgeCategory == AgeCategory.Senior)
            {
                Console.WriteLine("You will receive a pension.");
            }
            else if (p.AgeCategory == AgeCategory.Child)
            {
                Console.WriteLine("You will receive child benefit.");
            }
            else if (p.AgeCategory == AgeCategory.Adult)
            {
                Console.WriteLine("You will receive no extra money. :(");
            }
            else //  else if (p.AgeCategory == AgeCategory.None)
            {
                Console.WriteLine("Invalid category.");
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
