
namespace Study
{
    public class Homework_2
    {
        public void Task_1_A()
        {
            Console.WriteLine("--- Task 1 A --- \n Enter the height of the tree:");
            bool is_complete = false;

            while (is_complete != true)
            {
                try
                {
                    int height = Int32.Parse(Console.ReadLine()); // Getting the height of the tree
                    int stars = 0; // Count of the '*'

                    /*

                    In every cycle count of stars += 1, count of nulls -= 1

                    Example:

                    height = 3

                    while height > 0
                        {
                            creating string in core_Task_4(), then print it and height--
                        }

                    str #1 - * // 2 nulls + 1 star + 2 nulls , height = 3
                    str #2 - _***_ // 1 null + 3 stars + 1 null , height = 2
                    str #3 - ***** // 0 nulls + 5 stars + 0 nulls , height = 1

                    */


                    while (height > 0)
                    {
                        stars++;
                        string n = core_Task_1_A(height, stars);
                        Console.WriteLine(n);
                        height--;
                    }
                    is_complete = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Print num instead text");
                }
            }

            string core_Task_1_A(int nulls, int stars)
            {
                nulls--;
                string str = "";

                str += new string(' ', nulls) + new string('*', stars) + new string('*', stars - 1) + new string(' ', nulls);
                return str;
            }

        }



        public void Task_1_B()
        {
            Console.WriteLine("\n --- Task 1 B --- \n Enter the height of the tree:");
            bool is_complete = false;

            while (is_complete != true)
            {
                try
                {
                    int height = Int32.Parse(Console.ReadLine()); // Getting the height of the tree
                    int current_height = 0;
                    int nulls = height;
                    int stars = 1;

                    if (height == 1)
                    {
                        Console.WriteLine("*");
                        is_complete = true;
                    }

                    while (current_height < height / 2)
                    {
                        Console.WriteLine(new string(' ', nulls) + new string('*', stars) + new string('*', stars - 1) + new string(' ', nulls));
                        stars++;
                        nulls--;
                        current_height++;

                    }

                    int width = 2 * stars - 3;



                    if (height % 2 == 0)
                    {
                        stars = 1;
                        while (current_height < height)
                        {
                            Console.WriteLine(new string(' ', nulls) + new string('*', stars) + new string(' ', width) + new string('*', stars) + new string(' ', nulls));
                            nulls--;
                            stars += 2;
                            width -= 2;
                            current_height++;
                        }
                    }
                    else
                    {
                        Console.WriteLine();
                        height--;
                        nulls--;
                        stars = 1;
                        width += 2;

                        while (current_height < height)
                        {
                            Console.WriteLine(new string(' ', nulls) + new string('*', stars) + new string(' ', width) + new string('*', stars) + new string(' ', nulls));
                            nulls--;
                            stars += 2;
                            width -= 2;
                            current_height++;
                        }
                    }

                    is_complete = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Print num instead text");
                }
            }

            string core_Task_1_B(int nulls, int stars)
            {
                return "";
            }

        }

        public void Task_2_A()
        {
            Console.WriteLine("\n --- Task 2 A --- \n To compute Maclaurin series for the exponential function e^x \n Enter x:");
            bool is_complete = false;

            while (is_complete != true)
            {
                try
                {

                    double x = Double.Parse(Console.ReadLine());

                    Console.WriteLine("Enter accuracy (allowable error), like 0,001:");
                    double accuracy = Double.Parse(Console.ReadLine());

                    Console.WriteLine("\n Maclaurin series for the exponential function e^x = " + Maclaurin_series_exp(x, accuracy).ToString());

                    is_complete = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Print X as num instead text");
                }
            }
        }

        int factorial(int n) // calculate n!
        {
            int res = 1; // Result
            int count = 1; // 1 + 2 + 3 + ... + while count != n, when n++ every step

            if (n == 0) // 0! = 1
            {
                return 1;
            }
            while (count != n)
            {
                res *= count + 1;
                count++;
            }
            return res;
        }

        double Maclaurin_series_exp(double x, double accuracy)
        {
            int pow = 0;
            double exp = Math.Exp(x);
            double res = 0;
            while (exp - res > accuracy)
            {
                res += Math.Pow(x, pow) / factorial(pow);
                pow++;
            }

            return Math.Round(res, 9);
        }

        public void Task_2_B()
        {
            Console.WriteLine("\n --- Task 2 B --- \n To compute Maclaurin series for the exponential function sin(x) with the custom accuracy \n Enter x:");
            bool is_complete = false;

            while (is_complete != true)
            {
                try
                {

                    double x = Double.Parse(Console.ReadLine());

                    Console.WriteLine("Enter accuracy in range (-infinity to 0,1] (allowable error), like 0,001:");
                    double accuracy = Double.Parse(Console.ReadLine());

                    if (accuracy < 0.00000000001)
                    {
                        Console.WriteLine("Accuracy = 0,00000001");
                        accuracy = 0.00000000001;
                    }
                    else if (accuracy < 0 || accuracy > 0)
                    {
                        Console.WriteLine("Accuracy = 0,01");
                        accuracy = 0.01;
                    }

                    Console.WriteLine("\n Result = " + Maclaurin_series_sinx((x * Math.PI) / 180, accuracy).ToString());

                    is_complete = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Print X as num instead text");
                }
            }


        }

        double Maclaurin_series_sinx(double x, double accuracy)
        {
            double sin = Math.Sin(x);
            int count = 0;

            double res = 0;

            while (Math.Abs(Math.Abs(sin) - Math.Abs(res)) > accuracy)
            {

                res += ((Math.Pow((-1), count) * Math.Pow(x, 2 * count + 1)) / factorial(2 * count + 1));
                count++;
            }

            return Math.Round(res, 9);
        }
    }
}
