using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lektion_4_Exercise_3
{
    // Write a program that reads an integer from the user and sums all even numbers up to that integer. For example, entering the number 10 should result in the output 30, because the sum of 2, 4, 6, 8, and 10 is 30.

    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Console.Write("Enter a number: ");
            if (int.TryParse(Console.ReadLine(), out int i))
            {
                int sum_v1 = 0, sum_v2 = 0;

                /* Variant 1 */
                {
                    //for (int j = 0; j <= i; ++j)
                    //{
                    //    sum += (j % 2 == 0) ? j : 0;
                    //}
                    for (int j = 2; j <= i; j += 2)
                    {
                        sum_v1 += j;
                    }
                }

                /* Variant 2 */
                {
                    //for (int j = 0; j <= i; ++j)
                    //{
                    //    sum_v2 += (j % 2 != 0) ? j : 0;
                    //}
                    for (int j = 1; j <= i; j += 2)
                    {
                        sum_v2 += j;
                    }
                }

                /* Variant 1 */
                Console.WriteLine($"The sum of all even numbers up to '{i}' is: {sum_v1}");
                /* Variant 2 */
                Console.WriteLine($"The sum of all odd numbers up to '{i}' is: {sum_v2}");
            }
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Test_BothVariants()
        {
            using FakeConsole console = new FakeConsole("10");
            Program.Main();
            /* Variant 1 */
            Assert.AreEqual("The sum of all even numbers up to '10' is: 30", console.Lines[0]);
            /* Variant 2 */
            Assert.AreEqual("The sum of all odd numbers up to '10' is: 25", console.Lines[1]);
        }
    }
}
