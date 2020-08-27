using System;
using System.Collections.Generic;
using System.Text;

namespace Lektion_2
{
    class InputParser
    {
        public static double parseString_intoDouble()
        {
            double number;

            while (true)
            {
                string input = Console.ReadLine();

                if (double.TryParse(input, out number))
                {
                    break;
                }
            }

            return number;
        }

        public static int parseString_intoInt()
        {
            int number;

            while (true)
            {
                string input = Console.ReadLine();

                if (int.TryParse(input, out number))
                {
                    break;
                }
            }

            return number;
        }
    }
}
