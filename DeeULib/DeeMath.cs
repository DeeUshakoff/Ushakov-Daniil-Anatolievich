using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeeULib
{
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
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsInt(this double source)
        {
            int integer = DeeU.ToInt(source);

            if (source - integer > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
