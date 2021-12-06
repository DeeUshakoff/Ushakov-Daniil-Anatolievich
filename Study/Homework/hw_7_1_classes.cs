
namespace Study
{
    public class Student
    {

        private string name;

        public string Name
        {
            get {  return name; }
            set { name = WithoutDigits(value); }
        }

 
        private string surname;
 
        public string Surname
        {
            get { return surname; }
            set { surname = WithoutDigits(value); }
        }

 
        private string patronymic;
 
        public string Patronymic
        {
            get { return patronymic; }
            set { patronymic = WithoutDigits(value); }
        }

 
        public string Group {  get; set; }
 

        public double Progress { get; set; }

        public bool Is_in_SNO { get; set; }

        public DateTime Birthday {  get; set; }
        public int Age
        {
            get { return DateTime.Now.Year - Birthday.Year; }
        }

        private string WithoutDigits(string input) // Removes all unnecessary symbols in string
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }
            
            string output = "";
            foreach (char element in input)
            {
                if(Char.IsLetter(element) || Char.IsWhiteSpace(element))
                    output += element.ToString();
            }
            return output;
            
        }
    }

    public class Circle
    {
        public double Radius, Diameter;
        private double Square, Length;

        /// <summary>
        /// Calculating Diameter using Radius
        /// </summary>
        /// <returns></returns>
        public double GetDiameter()
        {
            if (Diameter != 0)
                return Diameter;
            else if (Radius > 0)
            {
                Diameter = 2 * Radius;
                return Diameter;
            }
            else
                throw new NullReferenceException();
        }

        public double GetRadius()
        {
            if (Diameter > 0)
                return Diameter / 2;
            throw new NullReferenceException();
        }

        /// <summary>
        /// Calculating Square using Radius or Diameter
        /// </summary>
        /// <returns></returns>
        public double GetSquare()
        {
            if (Radius > 0)
            {
                Square = Math.PI * Radius * Radius;
                return Square;
            }

            else if (Diameter > 0)
            {
                Square = Math.PI * Math.Pow(Diameter / 2, 2);
                return Square;
            }

            else
                throw new NullReferenceException();
        }

        /// <summary>
        /// Calculating Circle's Length using Radius or Diameter
        /// </summary>
        /// <returns></returns>
        public double GetLength()
        {
            if (Radius > 0)
            {
                Length = Math.PI * Radius * 2;
                return Length;
            }

            else if (Diameter > 0)
            {
                {
                    Length = Math.PI * Diameter;
                    return Length;
                }
            }

            else
                throw new NullReferenceException();
        }

    }

    public class BigNum // Сделал входное значание 
    {
        public int[] Num = { 0 };
        public int IntNum { get; set; } 
        public bool IsPositive = true;


        public void Add(int input_2)
        {
            if (IntNum < 0 && input_2 < 0)
            {
                IsPositive = false;
            }
            

            IntNum = Math.Abs(IntNum);
            input_2 = Math.Abs(input_2);


            int[] a = DeeUseless.ToArray(IntNum);
            int[] b = DeeUseless.ToArray(input_2);


            int[] summa;

            if (a.Length >= b.Length)
                summa = Summ_core(a, b);
            else
                summa = Summ_core(b, a);
            Num = summa;
        }

        public void Add(int[] input)
        {
            int[] summa;

            if (Num.Length >= input.Length)
                summa = Summ_core(Num, input);
            else
                summa = Summ_core(input, Num);
            Num = summa;
        }

        private int[] Summ_core(int[] a, int[] b)
        {
            int[] summa = new int[a.Length];

            if (a.Length > b.Length)
                b = DeeUseless.Add(new int[a.Length - b.Length], b);

            int in_brain = 0;

            for (int i = a.Length - 1; i >= 0; i--)
            {
                if (i <= b.Length)
                {
                    if (a[i] + b[i] + in_brain < 10)
                    {
                        summa[i] = a[i] + b[i] + in_brain;
                        in_brain = 0;
                    }
                    else
                    {

                        summa[i] = (a[i] + b[i] + in_brain) % 10;
                        in_brain = 1;
                    }
                }
            }
            if (in_brain == 1)
            {
                int[] new_summa = { 1 };
                new_summa = DeeUseless.Add(new_summa, summa);
                return new_summa;
            }

            return summa;
        }


        public void Diff(int input)
        {
            if (IsPositive == true && input < 0)
            {
                Add(Math.Abs(input));
                return;
            }
                
            else if (IsPositive == false && input > 0)
            {
                Add(-input);
                return;
            }
                
            else if ((IsPositive == false && input < 0 && Math.Abs(IntNum) > Math.Abs(input)) ||
                (IsPositive == true && input > 0 && Math.Abs(IntNum) < Math.Abs(input)))
            {
                IsPositive = false;
            }

            input = Math.Abs(input);

            int[] a = DeeUseless.ToArray(IntNum);
            int[] b = DeeUseless.ToArray(input);

            
            if (a.Length >= b.Length)
            {
                Num = Diff_core(a, b);
            }
            else
                Num = Diff_core(b, a);
        }

        public void Diff(int[] input, bool Positivity = true)
        {
            if (IsPositive == true && Positivity == false)
            {
                Add(input);
                return;
            }

            else if (IsPositive == false && Positivity == true)
            {
                Add(input);
                return;
            }

            else if ((IsPositive == false && Positivity == false && IsMore(Num, input) ||
                (IsPositive == true && Positivity == true && !IsMore(Num, input))))
            {
                IsPositive = false;
            }



            if (Num.Length >= input.Length)
            {
                Num = Diff_core(Num, input);
            }
            else
                Num = Diff_core(input, Num);
        }

        private int[] Diff_core(int[] a, int[] b)
        {
            if (a.Length > b.Length)
                b = DeeUseless.Add(new int[a.Length - b.Length], b);
            //DeeUseless.Print(b.Length);
            int[] res = new int[a.Length];

            int in_brain = 0;

            for (int i = a.Length - 1; i >= 0; i--)
            {
                if (i <= b.Length)
                {
                    if (a[i] - (b[i] + in_brain) >= 0)
                    {
                        res[i] = (a[i] - (b[i] + in_brain));
                        in_brain = 0;
                    }
                    else
                    {
                        res[i] = ((10 + a[i]) - (b[i] + in_brain));
                        in_brain = 1;
                    }
                }
            }

            int zero_counter = 0;

            for (int i = 0; i < res.Length; i++)
            {
                if (res[i] == 0)
                {
                    zero_counter++;
                }
                else
                    break;
            }

            return DeeUseless.Slice(res, zero_counter);
        }


        public void Mult(int input_2)
        {
            if ((IntNum > 0 && input_2 < 0) || (IntNum < 0 && input_2 > 0))
                IsPositive = false;

            int[] a = DeeUseless.ToArray(Math.Abs(IntNum));
            int[] b = DeeUseless.ToArray(Math.Abs(input_2));


            if (IntNum == 0 || input_2 == 0)
                Num = new int[1] { 0 };
            else if (input_2 == 1 || input_2 == -1)
                Num = a;
            else if (IntNum == 1 || IntNum == -1)
                Num = b;
            else if (a.Length >= 1 && b.Length == 1)
                Mult_Core_Single(a, b[0]);
            else if (b.Length >= 1 && a.Length == 1)
                Mult_Core_Single(b, a[0]);

        }

        private void Mult_Core_Single(int[] a, int b)
        {
            int in_brain = 0;
            int[] res = new int[a.Length];

            for (int i = a.Length - 1; i >= 0; i--)
            {
                if ((a[i] * b) + in_brain < 10)
                {
                    res[i] = (a[i] * b) + in_brain;
                    in_brain = 0;
                }
                    
                else
                {
                    int tmp = (a[i] + in_brain) * b;
                    DeeUseless.Print(tmp);
                    res[i] = ((a[i] + in_brain) * b) % 10;
                    if (DeeUseless.Length(tmp) == 1)
                        in_brain = tmp;
                    else if (DeeUseless.Length(tmp) == 2)
                        in_brain = DeeUseless.ToArray(tmp)[0];
                    else if (DeeUseless.Length(tmp) > 2)
                        in_brain = DeeUseless.ToInt(DeeUseless.Slice(tmp.ToString(), 0, tmp.ToString().Length - 2));
                }
            }
            Num = res;
        }



        public void PrintNum(bool is_line = false)
        {
            if (IsPositive == false)
                DeeUseless.Print("Number is negative", "red");
            if (is_line)
                DeeUseless.PrintL(Num);
            else
            {
                
                DeeUseless.PrintL(Num);
                Console.WriteLine();
            }

        }

        private bool IsMore(int[] a, int[] b)
        {
            if (a.Length > b.Length)
                return true;
            else if (a.Length < b.Length)
                return false;
#pragma warning disable CS0162 // Обнаружен недостижимый код
            for (int i = 0; i < a.Length; i++)
#pragma warning restore CS0162 // Обнаружен недостижимый код
            {
                if (a[i] > b[i])
                    return true;
                else
                    return false;
            }
            return true;
        }
    }
}
