using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lektion_2
{
    class Exercises
    {
        public static int Count = 7;

        public static void Exercise1()
        {
            Console.WriteLine("--- Exercise 1");
            int expression1 = 5 + 2;
            int expression2 = 5 + 2 * 7;
            double expression3 = (10 + 2) / 3;
            double expression4 = (3 * 8) / (4 * 2);

            Console.WriteLine(expression1 + ", " + expression2 + ", " + expression3 + ", " + expression4);

            Console.WriteLine(Environment.NewLine);
            //Console.WriteLine("--- Exercise 1 [END]");
        }

        public static void Exercise2()
        {
            Console.WriteLine("--- Exercise 2");

            double cash;
            double bank;

            /* Read, parse and validate user input. */
            {
                bool retry = false;

                while (true)
                {

                    Console.Write(retry ? "Try again! - Cash ($):" : "Cash($):");
                    string s_cash = Console.ReadLine();

                    if (double.TryParse(s_cash, out cash))
                    {
                        retry = false;
                        break;
                    }

                    retry = true;
                }

                while (true)
                {
                    Console.Write("Bank ($):");
                    string s_bank = Console.ReadLine();

                    if (double.TryParse(s_bank, out bank))
                    {
                        break;
                    }
                }
            }

            /* Calculate total amount and print it */

            double total = cash + bank;
            if (total == 0)
            {
                Console.WriteLine($"You're broke.");
            }
            else
            {
                Console.WriteLine($"You have a total of ${total}.");
            }

            Console.WriteLine(Environment.NewLine);
        }
        public static void Exercise3()
        {
            Console.WriteLine("--- Exercise 3");

            double fahrenheit;
            double v3_celsius;

            /* Read, parse and validate user input. */

            while (true)
            {
                Console.Write("Fahrenheit:");
                string s_fahrenheit = Console.ReadLine();

                if (double.TryParse(s_fahrenheit, out fahrenheit))
                {
                    break;
                }
            }

            /* Calculate total amount and print it */

            double celsius_variant1 = (fahrenheit - 32) * 0.556;
            double celsius_variant2_step1 = fahrenheit - 32;
            double celsius_variant2 = celsius_variant2_step1 * 0.556;
            Console.WriteLine($"(Variant 1) {fahrenheit} Fahrenheit = {celsius_variant1} Celsius.");
            Console.WriteLine($"(Variant 2) {fahrenheit} Fahrenheit = {celsius_variant2} Celsius.");

            /* Read, parse and validate user input. */

            while (true)
            {
                Console.Write("Fahrenheit:");
                string v3_s_celsius = Console.ReadLine();

                if (double.TryParse(v3_s_celsius, out v3_celsius))
                {
                    break;
                }
            }

            Console.WriteLine(Environment.NewLine);
        }

        public static void Exercise4()
        {
            List<double> numbers = new List<double>();

            /* Get numbers */

            Console.WriteLine("Enter the first number:");
            double number1 = InputParser.parseString_intoDouble();
            numbers.Add(number1);

            Console.WriteLine("Enter the second number:");
            double number2 = InputParser.parseString_intoDouble();
            numbers.Add(number2);

            Console.WriteLine("Enter the third number:");
            double number3 = InputParser.parseString_intoDouble();
            numbers.Add(number3);

            /* Find the smallest and largest numbers. */

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
            int children = InputParser.parseString_intoInt();
            Console.WriteLine("How many pieces of candy?");
            int candy = InputParser.parseString_intoInt();

            double candyPerChild = (double)candy / children;
            //Console.WriteLine(candyPerChild + " pieces of candy per child, and " + candy % children + " pieces for me.");
            Console.WriteLine(candyPerChild + " pieces of candy per child.");
        }

        public static void Exercise7()
        {
            Console.WriteLine("How many seconds?");
            int seconds = InputParser.parseString_intoInt();
            int hours = seconds / 3600;
            seconds = seconds % 3600;
            int minutes = seconds / 60;
            seconds = seconds % 60;

            Console.WriteLine(hours + ":" + minutes + ":" + seconds);
        }
    }
}
