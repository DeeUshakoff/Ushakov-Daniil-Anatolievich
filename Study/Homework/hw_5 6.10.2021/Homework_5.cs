using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study
{
    public class Homework_5
    {
        public static int Task_1(int[] input, int i = 0, int summa = 0) //Sum of array's elements
        {
            if (i == input.Length)
                return summa;
            return Task_1(input, i + 1, summa + input[i]);
        }

        public static int Task_2(int n)  // Factorial
        {
            if (n == 0 || n == 1)
                return 1;
            return n * Task_2(n - 1);
        }

        public static bool Task_3(int[] input_arr, int find, int start, int end)
        {
            if (input_arr == null)
                throw new NullReferenceException();
            else if (input_arr.Length == 0)
                throw new DeeUseless.ZeroLengthException();

            if (start > end)
            {
                return false;
            }

            var middle = (start + end) / 2;

            if (find == input_arr[middle])
            {
                return true;
            }

            if (find < input_arr[middle])
            {
                return Task_3(input_arr, find, start, middle - 1);
            }
            else
            {
                return Task_3(input_arr, find, middle + 1, end);
            }
        }

        public static string Task_4(string input) // Replace "mom" to "dad" in string
        {
            if (input == null)
                throw new NullReferenceException();
            if (input.Length == 0)
                throw new DeeUseless.ZeroLengthException();

            string compare = "mom";
            string[] input_arr = DeeUseless.ToArray(input);

            int count = 0; // Char hit counter.
                           // 1. If in input symbol == m, count += 1 | else count will be 0
                           // 2. symbol == o, count += 1 | else count will be 0
                           // 3. symbol == m, count += 1 | else count will be 0
                           // count == 3, if count = 3 => replace previous 3 elements in array to "dad"
                           // 1. count = 0, start cycle again

            for (int i = 0; i < input.Length; i++)
            {

                if (input_arr[i] == compare[count].ToString())
                {
                    count++;
                }
                else
                {
                    count = 0;
                }

                if (count == 3)
                {
                    input_arr[i - 2] = "d";
                    input_arr[i - 1] = "a";
                    input_arr[i] = "d";
                    count = 0;
                }
            }

            input = DeeUseless.Join(input_arr);

            return input;
        }
    }
}
