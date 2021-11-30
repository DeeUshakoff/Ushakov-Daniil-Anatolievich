
namespace Study
{
    /// <summary>
    /// Complex number is a number of the form a + bi, where a and b are real numbers. iPow = 1 by default
    /// </summary>
    public class CNum
    {
        /// <summary>
        /// x - Real part
        /// </summary>
        public double x;
        /// <summary>
        /// b - Imaginary part
        /// </summary>
        public double b;

        /// <summary>
        /// Pow of the i
        /// </summary>
        public int iPow;

        /// <summary>
        /// Sum of n CNum elements
        /// </summary>

        public CNum(double X = 0, double B = 0, int pow = 1)
        {
            x = X;
            b = B;
            iPow = pow;

            string i = iCalc(pow);

            if (i == "1")
            {
                pow = 0;
            }
            else if (i == "i")
            {
                pow = 1;
            }
            else if (i == "-1")
            {
                b = -b;
                pow = 0;
            }
            else if (i == "-i")
            {
                b = -b;
                pow = 1;
            }

        }

        public static CNum Sum(params CNum[] input)
        {
            var output = new CNum();

            foreach (var num in input)
            {
                output.Add(num);
            }
            return output;
        }
        public void Add(CNum input)
        {
            x += input.x;
            b += input.b;
        }

        public static CNum Multiply(params CNum[] input)
        {
            var output = input[0];
            for (int i = 1; i < input.Length; i++)
                output.Multiply(input[i]);
            return output;
        }
        public void Multiply(double real)
        {
            var input = new CNum(real, 0, 0);
            Multiply(input);
        }
        public void Multiply(CNum input)
        {
            var output = new CNum();

            output.x = (x * input.x - b * input.b);
            output.b = (b * input.x + x * input.b);

            x = output.x;
            b = output.b;
        }

        public static CNum Divide(params CNum[] input)
        {
            var output = input[0];
            for (int i = 1; i < input.Length; i++)
                output.Divide(input[i]);
            return output;
        }
        public void Divide(CNum input)
        {
            var output = new CNum();

            output.x = (x * input.x + b * input.b) / (input.x * input.x + input.b * input.b);
            output.b = (b * input.x - x * input.b) / (input.x * input.x + input.b * input.b);

            x = output.x;
            b = output.b;
        }

        private string iCalc(int pow)
        {
            int n = DeeU.DivRem(pow, 4);

            if (DeeU.ToDouble(pow) / 4 == 0)
                return "1";
            else if (pow == n + 1)
                return "i";
            else if (pow == n + 2)
                return "-1";
            else if (pow == n + 3)
                return "-i";
            else
                return "smth wrong";

            // 1 = i 
            // 2 = -1
            // 3 = -i
            // 4 = 1

            // 5 = i
            // 6 = -1
            // 7 = -i
            // 8 = 1

        }


        public static CNum Pow(CNum complexNumber, int pow)
        {
            if (pow == 0)
                return new CNum(1, 0);
            if (pow == 1)
                return complexNumber;
            complexNumber.Pow(pow);
            return complexNumber;
        }

        public void Pow(int pow)
        {
            var output = new CNum(
                Math.Pow(Length(), pow) * Math.Cos(pow * Arg()),
                Math.Pow(Length(), pow) * Math.Sin(pow * Arg()));
            x = output.x;
            b = output.b;
        }
        public double Length()
        {
            return Math.Sqrt(x * x + b * b);
        }

        public double Arg()
        {
            return Math.Atan(b / x);
        }

        public string toString()
        {
            if (x == 0 && b != 0)
                return ($"{b}i");
            else if (x != 0 && b == 0)
                return (x.ToString());
            else if (x == 0 && b == 0)
                return "0";
            else if (b > 0)
                return ($"{x}+{b}i");
            else
                return ($"{x}{b}i");
        }

        public static bool isEqual(CNum input_1, CNum input_2)
        {
            if (input_1.x == input_2.x && input_1.b == input_2.b && input_1.iPow == input_2.iPow)
                return true;
            return false;
        }
        public void Print()
        {
            DeeU.Print(toString());
        }

        private class Different_iPowException : ApplicationException { }

    }

    public class RationalFraction
    {
        public int Numerator, Denumenator;

        public RationalFraction(int numerator, int denumenator = 1)
        {
            Numerator = numerator;
            Denumenator = denumenator;

            if (denumenator == 0)
                throw new DivideByZeroException();
            if (DeeU.ToDouble(numerator) / denumenator == 0)
            {
                numerator /= denumenator;
                denumenator = 1;
            }
            Reduce();
        }

        public void Reduce()
        {
            int CBD = findCBD(Numerator, Denumenator);

            int findCBD(int a, int b) // Common biggest divider
            {
                while (b != 0)
                {
                    var temp = b;
                    b = a % b;
                    a = temp;
                }
                return a;
            }

            if (CBD == 1)
                return;
            else
            {
                Numerator /= CBD;
                Denumenator /= CBD;
            }

        }

        public void Add(RationalFraction input, bool isPlus = true)
        {

            if (Denumenator == input.Denumenator && isPlus)
            {
                Numerator += input.Numerator;
                Reduce();
                return;
            }
            else if (Denumenator == input.Denumenator && !isPlus)
            {
                Numerator -= input.Numerator;
                Reduce();
                return;
            }


            var output = new RationalFraction(1, Denumenator * input.Denumenator);
            if (isPlus)
                output.Numerator = Numerator * output.Denumenator / Denumenator + input.Numerator * output.Denumenator / input.Denumenator;
            else
                output.Numerator = (Numerator * output.Denumenator / Denumenator) - (input.Numerator * output.Denumenator / input.Denumenator);
            output.Reduce();
            Numerator = output.Numerator;
            Denumenator = output.Denumenator;
            Reduce();
        }

        public static RationalFraction Sum(params RationalFraction[] input)
        {
            var output = new RationalFraction(0, 1);

            foreach (RationalFraction Item in input)
            {
                output.Add(Item);
            }


            return output;
        }

        public void Multiply(RationalFraction input)
        {
            Numerator *= input.Numerator;
            Denumenator *= input.Denumenator;
            Reduce();
        }
        public static RationalFraction Multiply(params RationalFraction[] input)
        {
            var output = new RationalFraction(1, 1);

            foreach (RationalFraction Item in input)
            {
                output.Multiply(Item);
            }


            return output;
        }

        public void Divide(RationalFraction input)
        {
            Numerator *= input.Denumenator;
            Denumenator *= input.Numerator;
            Reduce();
        }
        public static RationalFraction Divide(params RationalFraction[] input)
        {
            var output = input[0];

            for (int i = 1; i < input.Length; i++)
            {
                output.Divide(input[i]);
            }


            return output;
        }

        public int NumberPart()
        {
            return Convert.ToInt32(Value());
        }

        public static int NumberPart(RationalFraction input)
        {
            return input.NumberPart();
        }
        public string toString()
        {
            if (Numerator == 0)
                return "0";
            else if ((Denumenator == 1 && Numerator > 0) || (Denumenator == -1 && Numerator < 0))
                return Numerator.ToString();
            else if ((Denumenator == 1 && Numerator < 0) || (Denumenator == -1 && Numerator > 0))
                return Numerator.ToString();
            else if ((Numerator < 0 && Denumenator < 0) || (Numerator > 0 && Denumenator > 0))
                return $"{Numerator} / {Denumenator}";
            else if ((Denumenator < 0 && Numerator > 0) || (Denumenator > 0 && Numerator < 0))
                return $"-{Numerator} / {Denumenator}";
            else
                return "Hmmm";
        }

        public void Print()
        {
            Console.WriteLine(toString());
        }

        public double Value()
        {
            return Denumenator / Numerator;
        }

        public static bool IsEqual(RationalFraction input, RationalFraction input_2)
        {
            if (input.Numerator == input_2.Numerator && input.Denumenator == input_2.Denumenator)
                return true;
            return false;
        }

    }

    public class Matrix2x2
    {
        double[,] MatrixDouble = new double[2, 2];
        public CNum[,] MatrixComplex = new CNum[2, 2];
        public RationalFraction[,] MatrixRational = new RationalFraction[2, 2];

        int matrixType = 0;
        // 0 - Double
        // 1 - CNum
        // 2 - RationalFraction

        public Matrix2x2(double[,] input)
        {
            if (input.Length != 4)
                throw new Not2x2InputException();
            MatrixDouble = input;
        }

        public Matrix2x2(double num_1 = double.NaN, double num_2 = 0, double num_3 = 0, double num_4 = 0)
        {
            matrixType = 0;
            if (num_1 != double.NaN && num_2 == 0 && num_3 == 0 && num_4 == 0)
            {
                MatrixDouble[0, 0] = num_1;
                MatrixDouble[0, 1] = num_1;
                MatrixDouble[1, 0] = num_1;
                MatrixDouble[1, 1] = num_1;
            }
            else
            {
                MatrixDouble[0, 0] = num_1;
                MatrixDouble[0, 1] = num_2;
                MatrixDouble[1, 0] = num_3;
                MatrixDouble[1, 1] = num_4;
            }


        }

        public void Add(Matrix2x2 input, bool plus = true)
        {
            int sign = 1;
            if (!plus) sign = -1;

            if (matrixType != input.matrixType)
                throw new DifferentMatrixTypeException();
            if (matrixType == 0)
            {
                MatrixDouble[0,0] += sign * (input.MatrixDouble[0, 0]);
                MatrixDouble[0,1] += sign * (input.MatrixDouble[0, 1]);
                MatrixDouble[1,0] += sign * (input.MatrixDouble[1, 0]);
                MatrixDouble[1,1] += sign * (input.MatrixDouble[1, 1]);
            }
        }
        
        public void Multiply(Matrix2x2 input)
        {
            


            if (matrixType != input.matrixType)
                throw new DifferentMatrixTypeException();
            if (matrixType == 0)
            {
                double[,] output = new double[2, 2];

                output[0,0] += MatrixDouble[0, 0] * input.MatrixDouble[0, 0] + MatrixDouble[0, 1] * input.MatrixDouble[1, 0];
                output[0,1] += MatrixDouble[0, 0] * input.MatrixDouble[0, 1] + MatrixDouble[0, 1] * input.MatrixDouble[1, 1];
                output[1,0] += MatrixDouble[1, 0] * input.MatrixDouble[0, 0] + MatrixDouble[1, 1] * input.MatrixDouble[1, 0];
                output[1,1] += MatrixDouble[1, 0] * input.MatrixDouble[0, 1] + MatrixDouble[1, 1] * input.MatrixDouble[1, 1];
                MatrixDouble = output;
            }
        }

        public void Multiply (double input)
        {
            if (Double.IsNaN(input))
                throw new WrongDataTypeException();
            if (matrixType == 0)
            {
                MatrixDouble[0, 0] *= input;
                MatrixDouble[0, 1] *= input;
                MatrixDouble[1, 0] *= input;
                MatrixDouble[1, 1] *= input;
            }
        }

        public double Det()
        {
            if (matrixType == 0)
            {
                return MatrixDouble[0,0] * MatrixDouble[1,1] - MatrixDouble[0,1]*MatrixDouble[1,0];
            }
            return 1;
        }

        public void Transpose()
        {
            if (matrixType == 0)
            {
                double[,] temp = new double[2, 2];
                temp[0, 0] = MatrixDouble[0,0];
                temp[0, 1] = MatrixDouble[1,0];
                temp[1, 1] = MatrixDouble[1,1];
                temp[1, 0] = MatrixDouble[0,1];

                MatrixDouble = temp;
            }
        }

        public static Matrix2x2 Transpose(Matrix2x2 input)
        {
            input.Transpose();
            return input;
        }

        public Matrix2x2 Inverse()
        {
            double det = Det();
            var output = new Matrix2x2();

            if (det == 0)
                throw new ZeroDetException();
            if (matrixType == 0)
            {

                output.MatrixDouble[0, 0] = MatrixDouble[1,1];
                output.MatrixDouble[0, 1] = -MatrixDouble[0,1];
                output.MatrixDouble[1, 0] = -MatrixDouble[1,0];
                output.MatrixDouble[1, 1] = MatrixDouble[0,0];


                output.Multiply(1 / det);
                return output; 
            }
            throw new ZeroDetException();
        }

        public void Print()
        {
            if (matrixType == 0)
            {
                Console.Write($"{ MatrixDouble[0, 0]} {MatrixDouble[0, 1]} \n{ MatrixDouble[1, 0]} {MatrixDouble[1, 1]}\n");
            }

        }

        public static void Print(Matrix2x2 input)
        {
            input.Print();
        }

        public Vector2D multVector(Vector2D input)
        {

            if (matrixType == 0)
                return new Vector2D(MatrixDouble[0,0] * input.X + MatrixDouble[0, 1] * input.Y,
                                    MatrixDouble[1, 0] * input.X + MatrixDouble[1, 1] * input.Y);
            return new Vector2D(0, 0);
        }

        public class Not2x2InputException : ApplicationException { }
        public class ZeroDetException : ApplicationException { }
        public class WrongDataTypeException : ApplicationException { }
        public class DifferentMatrixTypeException : ApplicationException { }
        

    }

    public class Vector2D
    {
        int vectorType = 0;
        // 0 - double
        // 1 - CNum
        // 2 - RationalFraction

        public double X;
        public double Y;

        public CNum c_X;
        public CNum c_Y;

        public RationalFraction r_X;
        public RationalFraction r_Y;

#pragma warning disable CS8618 // поле "r_Y", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающий значения NULL.
#pragma warning disable CS8618 // поле "c_Y", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающий значения NULL.
#pragma warning disable CS8618 // поле "c_X", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающий значения NULL.
#pragma warning disable CS8618 // поле "r_X", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающий значения NULL.
        public Vector2D(double x = 0, double y = 0)
#pragma warning restore CS8618 // поле "r_X", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающий значения NULL.
#pragma warning restore CS8618 // поле "c_X", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающий значения NULL.
#pragma warning restore CS8618 // поле "c_Y", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающий значения NULL.
#pragma warning restore CS8618 // поле "r_Y", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающий значения NULL.
        {

            X = x;
            Y = y;
        }
#pragma warning disable CS8618 // поле "r_Y", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающий значения NULL.
#pragma warning disable CS8618 // поле "r_X", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающий значения NULL.
        public Vector2D(CNum x, CNum y)
#pragma warning restore CS8618 // поле "r_X", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающий значения NULL.
#pragma warning restore CS8618 // поле "r_Y", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающий значения NULL.
        {
            vectorType = 1;
            c_X = x;
            c_Y = y;
        }
#pragma warning disable CS8618 // поле "c_Y", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающий значения NULL.
#pragma warning disable CS8618 // поле "c_X", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающий значения NULL.
        public Vector2D(RationalFraction x, RationalFraction y)
#pragma warning restore CS8618 // поле "c_X", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающий значения NULL.
#pragma warning restore CS8618 // поле "c_Y", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающий значения NULL.
        {
            vectorType = 2;
            r_X = x;
            r_Y = y;
        }
        
        public void Add(Vector2D input, bool plus = true)
        {
            int sign = 1;
            if (!plus) sign = -1;

            if (vectorType != input.vectorType)
                throw new DifferentVectorTypeException();
            if (vectorType == 0) // Add double to double
                { X += sign * (input.X); Y += sign * (input.Y); }
            else if (vectorType == 1) // Add CNum to CNum
                if (plus)
                    { c_X.Add(input.c_X); c_Y.Add(input.c_Y); }
                else
                {
                    input.c_X.x = -input.c_X.x;
                    input.c_X.x = -input.c_X.b;
                    c_X.Add(input.c_X); c_Y.Add(input.c_Y); 
                }

            else if (vectorType == 2) // Add RationalFraction to RationalFraction
                if (plus)
                    { r_X.Add(input.r_X); r_Y.Add(input.r_Y); }
                else
                    { r_X.Add(input.r_X, false); r_Y.Add(input.r_Y, false); }
        }
        public static Vector2D Add(Vector2D input, Vector2D input_2)
        {
            input.Add(input_2);
            return input;
        }

        public void Multiply(double input)
            {
            if (vectorType == 0) { X *= input; Y *= input; }
            else throw new DifferentVectorTypeException();
                
        }
        public void Multiply(CNum input)
        {
            if (vectorType == 1) { c_X.Multiply(input); c_Y.Multiply(input); }
            else throw new DifferentVectorTypeException();
        }
        public void Multiply(RationalFraction input)
        {
            if (vectorType == 2) { r_X.Multiply(input); r_Y.Multiply(input); }
            else throw new DifferentVectorTypeException();
        }
        
        public double Multiply (Vector2D input)
        {
            if (vectorType != input.vectorType) throw new DifferentVectorTypeException();

            if (vectorType == 0) { return X * input.X + Y * input.Y; }
            
            // Here should be CNum

            if (vectorType == 2) {
                return RationalFraction.Sum(RationalFraction.Multiply(r_X, r_X),
                       RationalFraction.Multiply(r_Y, r_Y)).Value(); }
            throw new DifferentVectorTypeException();
        }

        public double Length()
        {
            if (vectorType == 0)
                return Math.Sqrt(X * X + Y * Y);
            else if (vectorType == 1)
            {

                var ret = CNum.Sum(CNum.Multiply(c_X, c_X), CNum.Multiply(c_Y, c_Y));
                DeeU.Print($"Sqaure root from {ret.toString()}");
                return 0;
            }
            else if (vectorType == 2)
            {
                return Math.Sqrt(RationalFraction.Sum(RationalFraction.Multiply(r_X, r_X),
                                 RationalFraction.Multiply(r_Y, r_Y)).Value());
            }
            else
                throw new DifferentVectorTypeException();
        }

        public double Cos(Vector2D input)
        {
            return 1;
        } // Will do it later

        public bool IsEqual(Vector2D input)
        {
            if (vectorType != input.vectorType) return false;

            if (vectorType == 0)
                { if (X == input.X) return true; return false; }
            else if (vectorType == 1)
                { if (c_X == input.c_X) return true; return false; }
            else if (vectorType == 2)
                { if (r_X == input.r_X) return true; return false; }
            throw new DifferentVectorTypeException();
        }
        public void Print()
        {
            if (vectorType == 0)
                Console.Write($"{X} {Y}\n");
            else if (vectorType == 1)
                { c_X.Print(); c_Y.Print(); }
            else if (vectorType == 2)
                { r_X.Print(); r_Y.Print(); }
            else
                throw new DifferentVectorTypeException();
        }

        public class DifferentVectorTypeException : ApplicationException { }
    }
}