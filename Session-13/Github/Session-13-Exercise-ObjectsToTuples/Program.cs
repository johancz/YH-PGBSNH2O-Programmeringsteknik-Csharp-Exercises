using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Session_13_Exercise_ObjectsToTuples
{
    public class Program
    {
        public static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;


        }

        public static double DistanceBetween((double x, double y) p1, (double x, double y) p2)
        {
            double xDistance = p2.x - p1.x;
            double yDistance = p2.y - p1.y;
            double distance = Math.Sqrt(Math.Pow(xDistance, 2) + Math.Pow(yDistance, 2));
            return distance;
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void ExampleTest()
        {
            double distance = Program.DistanceBetween((0, 0), (3, 4));
            Assert.AreEqual(5, distance, 0.1);
        }
    }
}
