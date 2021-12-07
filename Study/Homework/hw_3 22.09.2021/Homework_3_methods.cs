using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study
{
    public class Homework_3_methods
    {
        public void Print(string input, string color)
        {
            color = color.ToLower();

            if (color == "red")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(input);
            }
            else if (color == "green")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(input);
            }
            else if (color == "yellow")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(input);
            }
            else
            {
                Console.WriteLine(input);
            }
            Console.ResetColor();
        }

        public double Task_1()
        {
            bool is_complete = false;
            double output = 0;


            while (is_complete != true)
            {
                Print("\n--- Task 1, methods ---", "yellow");
                Print("Enter the num to return it", "");

                try
                {
                    output = Double.Parse(Console.ReadLine());
                    return output;
                }
                catch (Exception ex)
                {
                    Print("Please, enter the num", "red");
                }
            }

            return output;
        }

        public void Task_2()
        {
            Print("\n--- Task 2, methods ---", "yellow");
            Print("Current date and time: " + DateTime.Now, "green");
        }

        public double Task_3()
        {
            Print("\n--- Task 3, methods ---", "yellow");
            bool is_ready = false;

            Print("Enter the numbers like: '10 10 10'", "");

            while (is_ready != true)
            {
                string[] input = Console.ReadLine().Split(' ');

                double sum = 0;
                int elements_count = 0;


                foreach (string element in input)
                {
                    try
                    {
                        double converted_element = Convert.ToDouble(element);

                        sum += converted_element;
                        elements_count++;
                    }
                    catch (Exception ex)
                    {
                        Print("Value '" + element + "' was missed because it's not a number", "red");

                    }
                }


                if (elements_count != 0)
                {
                    Print($"Average = {sum / elements_count}", "green");

                    is_ready = true;
                }

            }



            return 0;
        }
    }
}
