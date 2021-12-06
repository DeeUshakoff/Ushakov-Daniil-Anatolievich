
namespace Study
{
    public static class DeeUseless
    {
        
        public static void Print(string input, string color = "")
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
        public static void Print(params int[] input) // Print int elements
        {

            foreach (int element in input)
            {
                Console.WriteLine(element);
            }

        }
        public static void Print(params double[] input) // Print int elements
        {

            foreach (double element in input)
            {
                Console.WriteLine(element);
            }

        }
        public static void PrintL(params int[] input) // Print int elements
        {

            foreach (int element in input)
            {
                Console.Write(element);
            }

        }
        public static void Print(string[] input) // Print elements in string[] array
        {
            foreach (string element in input)
            {
                Print(element);
            }
        }
        
        public static void Print(char input)
        {
            Console.WriteLine(input);
        }

        public static void Print(bool input)
        {
            Console.WriteLine(input);
        }


        




        public static double ReadDouble(bool is_line = true)
        {

            bool is_complete = false;
            double output = 0;



            while (is_complete != true)
            {
                try
                {
                    if (is_line)
#pragma warning disable CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL, для параметра "s" в "double double.Parse(string s)".
                        output = Double.Parse(Console.ReadLine());
#pragma warning restore CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL, для параметра "s" в "double double.Parse(string s)".
                    else
                        output = Console.Read();
                    return output;
                }
                catch (Exception )
                {
                    Print("Please, enter the num", "red");
                }
            }
            return output;
        }

        public static int ReadInt()
        {
            bool is_complete = false;
            int output = 0;

            while (is_complete != true)
            {
                try
                {

                    output = Int32.Parse(Console.ReadLine());
                    return output;
                }
                catch (Exception )
                {
                    Print("Please, enter the num", "red");
                }
            }
            return output;
        }

        public static bool Is_zero_in(double input) // Is zero in double. Return true/false
        {
            if (input == 0)
            {
                return true;
            }

            while (input > 0)
            {
                if (input % 10 == 0)
                {
                    return true;
                }

                input = Math.Floor(input / 10);
            }
            return false;
        }

        public static int ToInt(string input) // Convert String to Int32
        {
            Int32.TryParse(input, out int result);
            return result;
        }

        public static int ToInt(double input) // Convert Double to Int32
        {
            Int32.TryParse(input.ToString(), out int result);
            return result;
        }


        public static double ToDouble(string input) // Convert String to Double
        {
            Double.TryParse(input, out double result);
            return result;
        }

        public static double ToDouble(int input) // Convert Int to Double
        {
            Double.TryParse(input.ToString(), out double result);
            return result;
        }


        public static int Pow(int input, int pow) // Return Int32 input in pow "pow"
        {
            int output = 1;
            for (int current_pow = 0; current_pow < pow; current_pow++)
            {
                output *= input;
            }
            return output;
        }


        public static int DivRem(double input, int divider) // Division without remainder. Ex: DivRem(123, 10) = 12
        {
            return ToInt(Math.Floor(input / divider));
        }


        public static int DeleteLastSymbol(int input) //Remove last number in input. Ex: DeleteLastSymbol(123) = 12
        {
            return DivRem(input, 10);
        }


        public static int Length(double input) // Return length of Int32. Ex: Length(123) = 3
        {
            int input_length = 0;

            if (input == 0)
            {
                return 1;
            }

            while (input > 0)
            {
                input_length++;
                input = Math.Floor(input / 10);
            }

            return input_length;
        }

        public static int Length(string input)
        {
            int input_length = 0;

            char[] chars = input.ToCharArray();

            input_length = chars.Length;

            return input_length;
        }


        public static int[] Add(int[] source_array, params int[] add) // Add element to the int[] array
        {
            int[] result = new int[source_array.Length + add.Length]; // Creating array with needing length

            source_array.CopyTo(result, 0); // Copy source array to the new array
            add.CopyTo(result, source_array.Length); // Copy add array or nums to the new array

            return result;
        }

        public static double[] Add(double[] source_array, params double[] add) // Add element to the double[] array
        {
            double[] result = new double[source_array.Length + add.Length]; // Creating array with needing length

            source_array.CopyTo(result, 0); // Copy source array to the new array
            add.CopyTo(result, source_array.Length); // Copy add array or nums to the new array

            return result;
        }

        public static string[] Add(string[] source_array, params string[] add) // Add element to the string[] array
        {
            string[] result = new string[source_array.Length + add.Length]; // Creating array with needing length

            source_array.CopyTo(result, 0); // Copy source array to the new array
            add.CopyTo(result, source_array.Length); // Copy add array or nums to the new array

            return result;
        }

        public static Toy[] Add(Toy[] source_array, params Toy[] add)
        {
            if (source_array == null || source_array.Length == 0)
                return add;
            Toy[] result = new Toy[source_array.Length + add.Length]; // Creating array with needing length

            source_array.CopyTo(result, 0); // Copy source array to the new array
            add.CopyTo(result, source_array.Length); // Copy add array or nums to the new array

            return result;
        }

        public static Garland[] Add(Garland[] source_array, params Garland[] add)
        {
            if (source_array == null || source_array.Length == 0)
                return add;
            Garland[] result = new Garland[source_array.Length + add.Length]; // Creating array with needing length

            source_array.CopyTo(result, 0); // Copy source array to the new array
            add.CopyTo(result, source_array.Length); // Copy add array or nums to the new array

            return result;
        }

        public static Toy[] Sort(Toy[] input)
        {
            Toy temp;
            for (int i = 0; i < input.Length - 1; i++)
            {
                for (int j = i + 1; j < input.Length; j++)
                {
                    if (input[i].DecorationSquare > input[j].DecorationSquare)
                    {
                        temp = input[i];
                        input[i] = input[j];
                        input[j] = temp;
                    }
                }
            }
            
            return input;
        }
        public static int[] Slice(int[] source_array, int from, int to = -1, bool sorted = false) // Slice int[] array in range of index [from, to]
        {
            if (to == -1)
                to = source_array.Length;
            else
                to += 1;

            int[] result = new int[to - from];

            int new_index = 0;
            for (int i = from; i < to; i++)
            {
                result[new_index] = source_array[i];
                new_index++;
            }

            if (sorted == true)
                Array.Sort(result);

            return result;
        }

        public static string[] Slice(string[] source_array, int from, int to = -1, bool sorted = false) // Slice string[] array in range of index [from, to]
        {
            if (to == -1)
                to = source_array.Length;
            else
                to += 1;

            string[] result = new string[to - from];

            int new_index = 0;
            for (int i = from; i < to; i++)
            {
                result[new_index] = source_array[i];
                new_index++;
            }

            Array.Sort(result);

            return result;
        }

        public static string Slice(string source_string, int from, int to = -1)
        {
            if (to == -1)
                to = source_string.Length;
            else
                to += 1;

            string result = "";

            char[] temp = source_string.ToCharArray();


            for (int i = from; i < to; i++)
            {
                result += temp[i].ToString();
            }


            return result;
        }

        public static string MultString(string str, int count)
        {
            if (count <= 0)
            {
                count = 1;
            }

            string result = "";

            for (int i = 0; i < count; i++)
            {
                result += str;
            }

            return result;
        } // Write string count times

        public static string Reverse(string input)
        {
            if (input == null)
                throw new NullReferenceException();
            else if (input.Length == 0 || input.Length == 1)
                return input;

            string reversed = "";

            char[] chars = input.ToCharArray();

            for (int i = input.Length - 1; i >= 0; i--)
            {
                reversed += chars[i].ToString();
            }
            return reversed;
        }

        public static int Reverse(int input)
        {
            if (Length(input) == 1)
                return input;

            int length = Length(input); // Calc length of the input
            int output = 0;

            for (int stage = 0; stage < length; stage++)
            {
                output += input % 10 * Pow(10, length - 1 - stage);
                input = DivRem(input, 10);
            }
            return output;
        }

        public static bool IsIn(string input, string find) // Is string "find" in string "input", return bool
        {
            if (input == null || find == null)
                throw new NullReferenceException();

            else if (input.Length == 0 || find.Length == 0 || find.Length > input.Length)
                return false;

            else if (input == find)
                return true;

            string[] find_arr = ToArray(find);
            string[] input_arr = ToArray(input);

            int count = 0;

            for (int i = 0; i < input_arr.Length; i++)
            {
                if (count == find.Length)
                    return true;
                if (input_arr[i] == find_arr[count])
                {
                    count++;
                }
                else
                {
                    count = 0;
                }

            }

            return false;
        }



        public static bool IsInt(double input)
        {
            int integer = DeeUseless.ToInt(input);

            if (input - integer > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static string[] ToArray(string input)
        {
            string[] output = new string[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                output[i] = input[i].ToString();
            }

            return output;
        }

        public static int[] ToArray(int input)
        {
            int length = DeeUseless.Length(input);
            int[] output = new int[length];

            for (int i = length - 1; i >= 0; i--)
            {
                output[i] = input % 10;
                input = DeeUseless.DeleteLastSymbol(input);
            }

            return output;
        }

        public static string Join(params string[] input)
        {
            if (input == null)
                throw new NullReferenceException();

            string result = "";

            foreach (string element in input)
                result += element;

            return result;
        }
        public static string Replace(string input, string replaceable, string replacement) // Not ready
        {
            return input;
        }


        public static double CheckLessZero(double input)
        {
            if (input < 0)
                return 0;
            return input;
        }

        public static int CheckLessZero(int input)
        {
            if (input < 0)
                return 0;
            return input;
        }
        public class Angle3
        {

            private double angleValue;
            public double AngleValue
            {
                
                set
                {
                    angleValue = CheckAngle(value);
                }
                get
                {
                    return angleValue;
                }
            }

            public static double CheckAngle(double input_Angle)
            {
                if (input_Angle < 180)
                    return input_Angle;
                else
                {
                    DeeUseless.Print("Wrong Angle value, must be <180");
                    return 0;
                }
            }
            public Angle3 (double input_Angle)
            {
                AngleValue = input_Angle;
            }


        }
       
        public static void Wait()
        {
            Console.ReadLine();
        }
        public class ZeroLengthException : ApplicationException
        {

        }

    }
    
}
