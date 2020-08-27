using System;
using System.Collections.Generic;
using System.Text;

namespace Lektion_2
{
    class InputValidator
    {
        public static double getInput_double()
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
    }
}
