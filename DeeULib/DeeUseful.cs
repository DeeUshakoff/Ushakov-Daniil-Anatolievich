using System.Text;
namespace DeeULib;


    /// <summary>
    /// Useful library for simplifying the work 
    /// </summary>
    public static class DeeU
    {

        // Print object
        public static void Print(this object obj, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(obj.ToString());
            Console.ResetColor();
        }
        public static void PrintL(this object obj, ConsoleColor color = ConsoleColor.White)
        {
           
            Console.ForegroundColor = color;
            Console.Write(obj.ToString());
            Console.ResetColor();
        }
        public static void Print(params object[] obj)
        {
            foreach (var el in obj)
                Console.WriteLine(el.ToString());
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


       

        //Print Array
        public static void Print(this string[] source, ConsoleColor Color = ConsoleColor.White)
        {
            Console.ForegroundColor = Color;
            foreach (var value in source)
                Console.WriteLine(value);
            Console.ResetColor();
        }
        public static void Print(this int[] source, ConsoleColor Color = ConsoleColor.White)
        {
            if (source == null) return;
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


        public static bool IsNum(this string source)
        {
            if(string.IsNullOrWhiteSpace(source)) return false;

            try
            {
                var num = int.Parse(source);
                return true;
            }
            catch
            {
                return false;
            }
      
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
            int.TryParse(source, out var result);
            return result;
        }
        /// <summary>
        /// Returns Int32 from Double
        /// </summary>
        /// <param name="source">Source to convert</param>
        /// <returns></returns>
        public static int ToInt(this double source) => Convert.ToInt32(source);
        /// <summary>
        /// Returns Double from String
        /// </summary>
        /// <param name="source">Source to convert</param>
        /// <returns></returns>
        public static double ToDouble(this string source)
        {
            
            double.TryParse(source.Replace('.', ','), out var result);
            return result;
        }
        /// <summary>
        /// Returns Double from Int32
        /// </summary>
        /// <param name="source">Source to convert</param>
        /// <returns></returns>
        public static double ToDouble(this int source)
        {
            Double.TryParse(source.ToString(), out var result);
            return result;
        }

        /// <summary>
        /// Returns Int32 from console input
        /// </summary>
        /// <returns></returns>
        public static int ReadInt()
        {
            Int32.TryParse(Console.ReadLine(), out var result);
            return result;
        }
        public static double ToDouble(this double[] source) => String.Join("", source).ToDouble();
        public static double ToDouble(this List<int> source) => String.Join("", source).ToDouble();
        public static double ToDouble(this List<double> source) => String.Join("", source).ToDouble();
        /// <summary>
        /// Returns Double from console input. Can read input like 1,1 and 1.1
        /// </summary>
        /// <returns></returns>
        public static double ReadDouble()
        {
            double.TryParse(Console.ReadLine().Replace('.', ','), out var result);
            return result;
        }



        // Array extensions:

        /// <summary>
        /// Connect strings into one
        /// </summary>
        /// <param name="separator">Separator between strings in new string</param>
        /// <param name="input">String to add</param>
        /// <returns></returns>
        public static string Join(string separator, params string[] input)
        {
            if (input == null)
                throw new NullReferenceException();

            string result = "";

            foreach (string item in input)
                result += item + separator;

            return result;
        }
        /// <summary>
        /// Connect strings into one
        /// </summary>
        /// <param name="separator">Separator between strings in new string</param>
        /// <param name="input">String to add</param>
        /// <returns></returns>
        public static string Join(string separator, params int[] input)
        {
            if (input == null)
                throw new NullReferenceException();

            string result = "";

            foreach (var item in input)
                result += item.ToString() + separator;

            return result;
        }
        /// <summary>
        /// Connect strings into one
        /// </summary>
        /// <param name="separator">Separator between strings in new string</param>
        /// <param name="input">String to add</param>
        /// <returns></returns>
        public static string Join(string separator, params double[] input)
        {
            if (input == null)
                throw new NullReferenceException();

            string result = "";

            foreach (var item in input)
                result += item.ToString() + separator;

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

        public static int Find(this string source, char find, bool returnFirstEntry = false)
        {
            int index = -1;

            for(int i = 0; i < source.Length; i++)
            {
                if (source[i] == find)
                {
                    if (returnFirstEntry) return i;
                    index = i;
                }
            }
            return index;
        }

        public static class DRandom
        {
            
            public static IEnumerable<int> GetRandomized(int from, int to, int count) =>
                Enumerable.Range(0, count - 1).Select(x => new Random().Next(from, to + 1));
            public static int Next(int from, int to) => new Random().Next(from, to);
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
        // File managment


        /// <summary>
        /// Creates file in certain directory
        /// </summary>
        /// <param name="filename">Name of the file, please set up file extension</param>
        /// <param name="directory">Directory where the file will be created</param>
        /// <param name="rewrite">Rewrite file, if file with same filename alredy exist in directory</param>
        public static void FileCreate(string filename, string directory, bool rewrite = false)
        {
            if(!Directory.Exists(directory))
            {
                Print("Directory not found", ConsoleColor.Red);
                return;
            }
            string path = $"{directory}\\{filename}";

            if(File.Exists(path) && !rewrite)
            {
                Print("File already exist", ConsoleColor.Red);
                return;
            }
            
            File.Create(path);

        }
        /// <summary>
        /// Creates file in certain directory
        /// </summary>
        /// <param name="path">Path to create file including the file name. Ex: C:\file.txt</param>
        /// <param name="rewrite">Rewrite file, if file with same filename alredy exist</param>
        public static void FileCreate(string path, bool rewrite = false)
        {

            if(!Directory.Exists(path.Substring(0, path.LastIndexOf('\\'))))
            {
                Print("Directory not found", ConsoleColor.Red);
                return;
            }

            if (File.Exists(path) && !rewrite)
            {
                Print("File already exist", ConsoleColor.Red);
                return;
            }

            File.Create(path);
        }


        /// <summary>
        /// WriteLine text into file
        /// </summary>
        /// <param name="path">Path of the file</param>
        /// <param name="text">Text to write</param>
        public static void FileWrite(string path, string text)
        {
            var outputFile = new StreamWriter(path, true);

            outputFile.Write(text);

            outputFile.Dispose();
                
            
        }

        /// <summary>
        /// Write text into file
        /// </summary>
        /// <param name="path">Path of the file</param>
        /// <param name="text">Text to write</param>
        public static void FileWriteL(string path, string text)
        {
            using (StreamWriter outputFile = new StreamWriter(path, true))
            {

                outputFile.WriteLine(text);
                outputFile.Close();
                outputFile.Dispose();

            }
        }


        // Other methods:
        public static DateTime ReadTime()
        {

            DeeU.PrintL("Year: ");
            int year = DeeU.ReadInt();

            DeeU.PrintL("Month: ");
            int month = DeeU.ReadInt();

            DeeU.PrintL("Day: ");
            int day = DeeU.ReadInt();

            DeeU.PrintL("Hour: ");
            int hour = DeeU.ReadInt();

            DeeU.PrintL("Minute: ");
            int minute = DeeU.ReadInt();

            DeeU.PrintL("Second: ");
            int second = DeeU.ReadInt();


            return new DateTime(year, month, day, hour, minute, second);
        }


        /// <summary>
        /// Method to wait for console input
        /// </summary>
        public static void Wait()
        {
            Console.ReadLine();
        }
    }

    
