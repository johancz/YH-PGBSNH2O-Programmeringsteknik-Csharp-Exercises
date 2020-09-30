using System;

namespace Paperbook_Exercises_Chapter_3
{
    class Program
    {
        static void Main(string[] args)
        {
            // 3.5
            Console.WriteLine();
            Console.WriteLine("Fråga 3.7:");

            Console.WriteLine((char)12);
            Console.WriteLine((char)24);
            Console.WriteLine((char)112);
            Console.WriteLine((char)1112);

            // 3.7
            Console.WriteLine();
            Console.WriteLine("Fråga 3.7:");

            {
                float a = 1f;
                int b = 2;
                float c = a / b;
                Console.WriteLine(c);
            }

            {
                float a = 1;
                int b = 2;
                float c = (float)a / b;
                Console.WriteLine(c);
            }

            // 3.8
            Console.WriteLine();
            Console.WriteLine("Fråga 3.8:");

            {
                int a = 8 % 3;
                Console.WriteLine(a);
            }

            {
                int a = 9 % 3;
                Console.WriteLine(a);
            }

            {
                //int a = 9 % 0; // No bueno. Division by zero.
                //Console.WriteLine(a);
            }

            {
                int a = 9 % 1;
                Console.WriteLine(a);
            }

            {
                int a = 9 % 9;
                Console.WriteLine(a);
            }
        }
    }
}
