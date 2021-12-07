using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study
{
    public class homework_3_arrays
    {
        Homework_3_methods Lib = new Homework_3_methods();


        public void Task_1()
        {
            Lib.Print("--- Task 1, arrays ---", "yellow");
            int[,] array = { { 1, 2, 3 }, { -321, 21331, 999 } };

            int min = array[0, 0];

            foreach (int number in array)
            {
                min = Math.Min(number, min);
            }

            Lib.Print("Minimum = " + min, "green");
        }

        public void Task_2_A()
        {
            Lib.Print("--- Task 2, arrays ---", "yellow");
            string str = "";
            bool is_ready = false;

            while (is_ready == false)
            {
                Console.WriteLine("\nEnter string with lenght <= 36");
                str = Console.ReadLine();

                if (str.Length <= 36)
                {
                    is_ready = true;
                }
                else
                {
                    Lib.Print("Entered string's lenght > 36\n", "red");
                }
            }

            char[] chars = str.ToCharArray();

            Console.WriteLine("\nChars are:");

            foreach (char c in chars)
            {
                Console.Write(c + " ");
            }



        }
        public void Task_2_B()
        {
            string str = "";
            bool is_ready = false;

            while (is_ready == false)
            {
                Console.WriteLine("\nEnter string with lenght <= 36");
                str = Console.ReadLine();

                string[] res = {};

                if (str.Length == 0)
                {
                    Console.WriteLine("Entered string's lenght should be in range (0; 36] \n");
                }
                else if (str.Length <= 36)
                {
                    is_ready = true;

                    res = (string[])core_task_2_B(str);
                }

                else
                {
                    Lib.Print("Entered string's lenght > 36\n", "red");
                }

                foreach (string el in res)
                {
                    Console.WriteLine(el);
                }
            }
        }

        public Array core_task_2_B(string text)
        {
            string[] res = { };

            if (text.Length == 1)
            {
                res = new string[] { text };
            }
            else if (text.Length <= 4)
            {


            }

            return res;
        }
    }
}
