using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Session_13_Exercise_ObjectsToTuples
{
    public class Point
    {
        public double X;
        public double Y;
    }

    public class Program
    {
        public static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Console.WriteLine("Hello!");
        }

        public static double DistanceBetween(Point p1, Point p2)
        {
            double xDistance = p2.X - p1.X;
            double yDistance = p2.Y - p1.Y;
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
            Point p1 = new Point
            {
                X = 0,
                Y = 0
            };
            Point p2 = new Point
            {
                X = 3,
                Y = 4
            };
            double distance = Program.DistanceBetween(p1, p2);
            Assert.AreEqual(5, distance, 0.1);
        }
    }
}
