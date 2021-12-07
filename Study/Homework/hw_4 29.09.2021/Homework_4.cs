using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study
{
    public class Homework_4
    {
        public static int Reverse_Num(int input)
        {
            if (input < 0)
            {
                input *= -1;
                DeeUseless.Print("A negative number was entered, replaced with a positive");
            } // Convert input to positive, if input is negative

            int length = DeeUseless.Length(input); // Calc length of the input
            int output = 0;

            if (DeeUseless.Is_zero_in(input)) // If zero in input => return input
            {
                DeeUseless.Print("Zero in num");
                return input;
            }
            else // Calc reversed num
            {
                for (int stage = 0; stage < length; stage++)
                {
                    output += input % 10 * DeeUseless.Pow(10, length - 1 - stage);
                    input = DeeUseless.DivRem(input, 10);
                }
                return output;
            }

            DeeUseless.Print("Something wrong", "red");
            return output;
        }

        public static int Fibonacci_numbers(int n)
        {


            if (n == 0)
                return 0;
            else if (n == 1 || n == -1)
                return 1;

            bool is_negative = false;

            // Save the value of negativity,
            // if it's true => apply -1 to the ready fib series

            if (n < 0)
            {
                is_negative = true;
                n *= -1;
            }


            // If n > 1 or n < 1

            int previous = 1;
            int current = 1;
            int summa = 0;

            for (int i = 2; i < n; i++) // Calc fibonacci series 
            {
                summa = previous + current;
                previous = current;
                current = summa;
            }

            if (is_negative && n % 2 == 0) // Set value to negative or return positive
                return current * -1;

            return current;
        }
    }
}
