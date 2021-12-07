using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study
{
    // Интерфейсы реализованы в Homework_7.cs, т.к именно там находятся классы CNum, RationalFraction
    public static class StringExtension
    {
        public static string StangeJoin(this string source_1, string source_2)
        {
            string output = "";

            if (source_1 == null || source_2 == null)
                return output;

            string[] str_1 = source_1.Split(' ');
            string[] str_2 = source_2.Split(' ');
            


            if (str_1.Length >= str_2.Length)
            {
                for(int i = 0; i < str_1.Length; i++)
                {
                    output+= str_1[i];

                    if(i+1 < str_2.Length)
                        output += str_2[i + 1];
                }
            }
            else
            {
                for(int i = 1; i < str_2.Length; i++)
                {
                    if(i-1 < str_1.Length)
                        output += str_1[i-1];
                    output += str_2[i];
                }
            }

            return output;
        }

        
    }
}
