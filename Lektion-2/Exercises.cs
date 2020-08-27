using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lektion_2
{
    class Exercises
    {
        //public static void Run()
        //{
        //}

        public static void Exercise4()
        {
            List<double> numbers = new List<double>();

            /* Get numbers */

            Console.WriteLine("Enter the first number:");
            double number1 = InputValidator.getInput_double();
            numbers.Add(number1);

            Console.WriteLine("Enter the second number:");
            double number2 = InputValidator.getInput_double();
            numbers.Add(number2);

            Console.WriteLine("Enter the third number:");
            double number3 = InputValidator.getInput_double();
            numbers.Add(number3);

            /* Find the smallest and largest number(s?). */

            double largestNumber_variant1 = Math.Max(Math.Max(number1, number2), number3);
            Console.WriteLine("The largest number is: " + largestNumber_variant1);

            double largestNumber_variant2 = numbers.Max();
            Console.WriteLine("The largest number is: " + largestNumber_variant2);

            double largestNumber_variant3 = (number1 > number2) ? (number1 > number3 ? number1 : number3) : (number2 > number3 ? number2 : number3);
            Console.WriteLine("The largest number is: " + largestNumber_variant3);

            double smallestNumber = numbers.Min();
            Console.WriteLine("The smallest number is: " + smallestNumber);
        }

        public static void Exercise5()
        {
            /* Take input */

            Console.Write("Enter the x-coordinate for Point 1:");
            double point1_x = double.Parse(Console.ReadLine());

            Console.Write("Enter the y-coordinate for Point 1:");
            double point1_y = double.Parse(Console.ReadLine());

            Console.Write("Enter the x-coordinate for Point 2:");
            double point2_x = double.Parse(Console.ReadLine());

            Console.Write("Enter the y-coordinate for Point 2:");
            double point2_y = double.Parse(Console.ReadLine());

            /* Calculate distance and print it */

            double dX = Math.Pow(point1_x - point2_x, 2);
            double dY = Math.Pow(point1_y - point2_y, 2);
            double distance = Math.Round(Math.Sqrt(dX + dY), 2);

            Console.WriteLine("The distance between Point 1 and Point 2 is: " + distance);
        }

        public static void Exercise6()
        {
            Console.WriteLine("How many children?");
            int children = int.Parse(Console.ReadLine());
            Console.WriteLine("How many pieces of candy?");
            int candy = int.Parse(Console.ReadLine());

            double candyPerChild = (double)candy / children;
            //Console.WriteLine(candyPerChild + " pieces of candy per child, and " + candy % children + " pieces for me.");
            Console.WriteLine(candyPerChild + " pieces of candy per child.");
        }

        public static void Exercise7()
        {
            Console.WriteLine("How many seconds?");
            int seconds = int.Parse(Console.ReadLine());
            int hours = seconds / 3600;
            seconds = seconds % 3600;
            int minutes = seconds / 60;
            seconds = seconds % 60;

            Console.WriteLine(hours + ":" + minutes + ":" + seconds);
        }
    }
}
