

namespace DeeULib
{
    /// <summary>
    /// Useful library for simplifying the work with math
    /// </summary>
    public static class DeeM
    {
        /// <summary>
        /// Returns number divided without remainder. Ex: 123.1 // 10 = 12 | 123.1.DivRem(10) = 12
        /// </summary>
        /// <param name="divider">Divider</param>
        /// <returns></returns>
        public static double DivRem(this double source, int divider)
        {
            return DeeU.ToInt(Math.Floor(source / divider));
        }

        /// <summary>
        /// Returns number divided without remainder. Ex: 123 // 10 = 12 | 123.DivRem(10) = 12
        /// </summary>
        /// <param name="divider">Divider</param>
        /// <returns></returns>
        public static int DivRem(this int input, int divider)
        {
            double converted_int = input.ToDouble();
            return DeeU.ToInt(Math.Floor(converted_int / divider));
        }

        /// <summary>
        /// Returns fractional part of the number
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static int GetFractionalPart(this double source)
        {
            string[] source_str = source.ToString().Split(',');
            return source_str[1].ToInt();

        }

        /// <summary>
        /// Returns True, if input is integer, else False
        /// </summary>
        /// <param name="source">Source to checkself</param>
        /// <returns></returns>
        public static bool IsInt(this double source)
        {
            int integer = DeeU.ToInt(source);

            if (source - integer > 0)
                return false;
            return true;
        }
        
        /// <summary>
        /// Round number. 1.48 to 1.5, 1.32 to 1.3
        /// </summary>
        /// <param name="source">Source to round</param>
        /// <param name="accurancy">nums after dot to round</param>
        /// <returns></returns>
        public static double Round(this double source, int accurancy)
        {
            return Math.Round(source, accurancy, MidpointRounding.AwayFromZero);
        }
        
        /// <summary>
        /// Class Angle: contains Angle Degree, Sin, Cos, Tan, Cot of that Angle
        /// </summary>
        public class Angle
        {

            
            private double sin;
            private double cos;
            private double tan;
            private double cot;

            private double degree;
            /// <summary>
            /// Degree of angle
            /// </summary>
            public double Degree
            {
                get
                {
                    return degree;
                }
                set
                {
                    degree = value;
                    Update();
                }
            }
            /// <summary>
            /// Create angle from degree
            /// </summary>
            /// <param name="Degree">Degree of angle</param>
            public Angle(double Degree)
            {
                this.Degree = Degree;
            }
            /// <summary>
            /// Convert radians to degrees
            /// </summary>
            private double DegreeMult = Math.PI / 180;
            
            void Update()
            {
                cos = Math.Cos(Degree * DegreeMult).Round(3);
                sin = Math.Sin(Degree * DegreeMult).Round(3);
                tan = Math.Tan(Degree * DegreeMult).Round(3);
                cot = cos/sin.Round(3);
            }

            /// <summary>
            /// Returns Sin of that angle
            /// </summary>
            /// <returns>Double</returns>
            public double GetSin()
            {
                return sin;
            }
            /// <summary>
            /// Returns Cos of that angle
            /// </summary>
            /// <returns>Double</returns>
            public double GetCos()
            {
                return cos;
            }
            /// <summary>
            /// Returns Tan of that angle
            /// </summary>
            /// <returns>Double</returns>
            public double GetTan()
            {
                return tan;
            }
            /// <summary>
            /// Returns Cot of that angle
            /// </summary>
            /// <returns>Double</returns>
            public double GetCot()
            {
                return cot;
            }

            /// <summary>
            /// Returns Degree as string
            /// </summary>
            /// <returns>String</returns>
            public override string ToString()
            {
                return Degree.ToString();
            }
            public static Angle operator +(Angle a, Angle b)
            {
                return new Angle(a.Degree + b.Degree);
            }
            public static Angle operator -(Angle a, Angle b)
            {
                return new Angle(a.Degree - b.Degree);
            }
            public static Angle operator *(Angle a, Angle b)
            {
                return new Angle(a.Degree * b.Degree);
            }
        }

        
    }
}
