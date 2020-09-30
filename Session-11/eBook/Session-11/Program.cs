using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Session_11
{
    public class Program
    {
        public static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            string sampleFile = "SampleTextFile.txt";
            string contents = File.ReadAllText(sampleFile);
            Console.WriteLine("Contents of file: \n" + contents);
            Console.WriteLine();
            Console.WriteLine("Lines of file:");
            string[] lines = File.ReadAllLines(sampleFile);
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }

            lines[1] = "Brad Pitt";
            File.WriteAllLines(sampleFile, lines);

            Console.WriteLine(Path.GetTempPath());
            string outputPath = Path.GetTempPath();

            string[] lines_people = File.ReadAllLines("People.csv");
            foreach (string line in lines)
            {
                string[] columns = line.Split(',');
                string name = columns[0];
                int year = int.Parse(columns[0]);
                string gender = columns[0];
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
