using System;

namespace Paperbook_Exercises_Chapter_4
{
    class Program
    {
        static void Main(string[] args)
        {
            // 4.6
            Console.WriteLine("Fråga 4.6:");

            {
                // Felaktig kod:
                //int var = 10;
                //if (var = 10) // Tilldelningstecken (=) istället för likamedstecken (==)
                //{
                //    Console.WriteLine("den är 10!");
                //}
            }
            {
                // Felaktig kod:
                bool var = false;
                if (var = true) // Tilldelningstecken (=) istället för likamedstecken (==)
                {
                    Console.WriteLine("den är 10!");
                }
            }

            // 4.7
            Console.WriteLine();
            Console.WriteLine("Fråga 4.7:");

            {
                string s = "abc";
                switch (s)
                {
                    case "abc":
                        Console.WriteLine("abc");
                        break;
                    default:
                        Console.WriteLine("default");
                        break;
                }
            }
            {
                double d = 10.5;
                switch (d)
                {
                    case 10.5:
                        Console.WriteLine("10.5");
                        break;
                    default:
                        Console.WriteLine("default");
                        break;
                }
            }
            {
                bool d = false;
                switch (d)
                {
                    case 10.5 < 11:
                        Console.WriteLine("10.5");
                        break;
                    default:
                        Console.WriteLine("default");
                        break;
                }
            }

            // 4.8
            Console.WriteLine();
            Console.WriteLine("Fråga 4.8:");
            RunBankSimulator();
        }

        private static void RunBankSimulator()
        {
            // TODO(johancz): code bank simulator.
            throw new NotImplementedException();
        }
    }
}
