namespace DeeULib
{
    public static class DeeU
    {

        // Print object

        public static void Print(this string Input, ConsoleColor Color = ConsoleColor.White)
        {
            Console.ForegroundColor = Color;

            Console.WriteLine(Input);

            Console.ResetColor();
        }
        public static void Print(this int Input, ConsoleColor Color = ConsoleColor.White)
        {
            Console.ForegroundColor = Color;

            Console.WriteLine(Input);

            Console.ResetColor();
        }
        public static void Print(this double Input, ConsoleColor Color = ConsoleColor.White)
        {
            Console.ForegroundColor = Color;

            Console.WriteLine(Input);

            Console.ResetColor();
        }
        public static void Print(this char Input, ConsoleColor Color = ConsoleColor.White)
        {
            Console.ForegroundColor = Color;

            Console.WriteLine(Input);

            Console.ResetColor();
        }
        /// <summary>
        /// Print current variable to console
        /// </summary>
        /// <param name="Input">Input parameter to print</param>
        /// <param name="Colorize">False: sets default color, True: Sets the color of the text depending on the Input. true - green, false - red</param>
        public static void Print(this bool Input, bool Colorize = false)
        {
            if(Colorize)
            {
                if(Input)
                    Console.ForegroundColor = ConsoleColor.Green;
                else
                    Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.WriteLine(Input);

            Console.ResetColor();
        }


        // Params print

        public static void Print(params string[] Input)
        {
            foreach (var Item in Input)
                Console.WriteLine(Item);
        }
        public static void Print(params int[] Input)
        {
            foreach (var Item in Input)
                Console.WriteLine(Item);
        }
        public static void Print(params double[] Input)
        {
            foreach (var Item in Input)
                Console.WriteLine(Item);
        }
        public static void Print(params char[] Input)
        {
            foreach (var Item in Input)
                Console.WriteLine(Item);
        }
        public static void Print(params bool[] Input)
        {
            foreach (var Item in Input)
                Console.WriteLine(Item);
        }


        // Print Line

        public static void PrintL(this string input, ConsoleColor Color = ConsoleColor.White)
        {
            Console.ForegroundColor = Color;

            Console.Write(input);

            Console.ResetColor();
        }
        public static void PrintL(this int input, ConsoleColor Color = ConsoleColor.White)
        {
            Console.ForegroundColor = Color;
            Console.Write(input);
            Console.ResetColor();
        }
        public static void PrintL(this double input, ConsoleColor Color = ConsoleColor.White)
        {
            Console.ForegroundColor = Color;
            Console.Write(input);
            Console.ResetColor();
        }
        public static void PrintL(this char input, ConsoleColor Color = ConsoleColor.White)
        {
            Console.ForegroundColor = Color;
            Console.Write(input);
            Console.ResetColor();
        }
        public static void PrintL(this bool input, ConsoleColor Color = ConsoleColor.White)
        {
            Console.ForegroundColor = Color;
            Console.Write(input);
            Console.ResetColor();
        }
        

        //Print Array
        public static void Print(this int[] source, ConsoleColor Color = ConsoleColor.White)
        {
            Console.ForegroundColor = Color;
            foreach (var value in source)
                Console.WriteLine(value);
            Console.ResetColor();
        }
        public static void Print(this double[] source, ConsoleColor Color = ConsoleColor.White)
        {
            Console.ForegroundColor = Color;
            foreach (var value in source)
                Console.WriteLine(value);
            Console.ResetColor();
        }
        public static void Print(this bool[] source, ConsoleColor Color = ConsoleColor.White)
        {
            Console.ForegroundColor = Color;
            foreach (var value in source)
                Console.WriteLine(value);
            Console.ResetColor();
        }
        public static void Print(this char[] source, ConsoleColor Color = ConsoleColor.White)
        {
            Console.ForegroundColor = Color;
            foreach (var value in source)
                Console.WriteLine(value);
            Console.ResetColor();
        }




        // Extensions:

        /// <summary>
        /// Repeat string source "count" times. Ex: "6".Repeat(2) = "66"
        /// </summary>
        /// <param name="source">String to repeat</param>
        /// <param name="count">Count of repetitions</param>
        /// <returns></returns>
        public static string Repeat(this string source, int count)
        {
            string result = "";

            if (String.IsNullOrEmpty(source))
                return result;
            if (count <= 0)
                count = 1;

            

            for (int i = 0; i < count; i++)
                result += source;

            return result;
        }
        /// <summary>
        /// Returns Int32 from string
        /// </summary>
        /// <param name="source">Source to convert</param>
        /// <returns></returns>
        public static int ToInt(this string source)
        {
            Int32.TryParse(source, out int result);
            return result;
        }
        /// <summary>
        /// Returns Int32 from Double
        /// </summary>
        /// <param name="source">Source to convert</param>
        /// <returns></returns>
        public static int ToInt(this double source)
        {
            return Convert.ToInt32(source); 
        }
        /// <summary>
        /// Returns Double from String
        /// </summary>
        /// <param name="source">Source to convert</param>
        /// <returns></returns>
        public static double ToDouble(this string source)
        {
            
            Double.TryParse(source.Replace('.', ','), out double result);
            return result;
        }
        /// <summary>
        /// Returns Double from Int32
        /// </summary>
        /// <param name="source">Source to convert</param>
        /// <returns></returns>
        public static double ToDouble(this int source)
        {
            Double.TryParse(source.ToString(), out double result);
            return result;
        }

        /// <summary>
        /// Returns Int32 from console input
        /// </summary>
        /// <returns></returns>
        public static int ReadInt()
        {
            Int32.TryParse(Console.ReadLine(), out int result);
            return result;
        }

        /// <summary>
        /// Returns Double from console input. Can read input like 1,1 and 1.1
        /// </summary>
        /// <returns></returns>
        public static double ReadDouble()
        {
            var input = Console.ReadLine().Replace('.', ',');
            
            Double.TryParse(input, out double result);
            return result;
        }



        // Array extensions:

        /// <summary>
        /// Connect string into one
        /// </summary>
        /// <param name="input">string to add</param>
        /// <returns></returns>
        public static string Join(params string[] input)
        {
            if (input == null)
                throw new NullReferenceException();

            string result = "";

            foreach (string item in input)
                result += item;

            return result;
        }


        /// <summary>
        /// Returns combined array
        /// </summary>
        /// <param name="source_array">Source to expand</param>
        /// <param name="add">Added element</param>
        /// <returns></returns>
        public static int[] Add(this int[] source_array, params int[] add) // Add element to the int[] array
        {
            int[] result = new int[source_array.Length + add.Length]; // Creating array with needing length

            source_array.CopyTo(result, 0); // Copy source array to the new array
            add.CopyTo(result, source_array.Length); // Copy add array or nums to the new array
            
            return result;
        }
        public static double[] Add(this double[] source_array, params double[] add) // Add element to the double[] array
        {
            double[] result = new double[source_array.Length + add.Length]; // Creating array with needing length

            source_array.CopyTo(result, 0); // Copy source array to the new array
            add.CopyTo(result, source_array.Length); // Copy add array or nums to the new array

            return result;
        }
        public static string[] Add(this string[] source_array, params string[] add) // Add element to the string[] array
        {
            string[] result = new string[source_array.Length + add.Length]; // Creating array with needing length

            source_array.CopyTo(result, 0); // Copy source array to the new array
            add.CopyTo(result, source_array.Length); // Copy add array or nums to the new array

            return result;
        }

        /// <summary>
        /// Returns length of the source. preDot or afterDot
        /// </summary>
        /// <param name="source">Source to calc the length</param>
        /// <param name="afterDot">If true, returns fractional part's length, else: integer part</param>
        /// <returns></returns>
        
        // Other extensions:
        
        public static int Length(this double source, bool afterDot = false)
        {
            if(afterDot)
                return DeeM.GetFractionalPart(source).Length();
            return source.ToInt().Length();
        }
        /// <summary>
        /// Returns the length of the source
        /// </summary>
        /// <param name="source">Source to calc length</param>
        /// <returns></returns>
        public static int Length(this int source)
        {
            return source.ToString().Length;
        }




        // Other methods:

        /// <summary>
        /// Method to wait for console input
        /// </summary>
        public static void Wait()
        {
            Console.ReadLine();
        }
    }

    
}