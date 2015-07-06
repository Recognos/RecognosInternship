using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem6_FromArabToRoman
{
    static class Class1
    {
        public static string TransformToRoman(int valueToTransform)
        {
            Dictionary<int, string> romanDictionary = new Dictionary<int, string>
            {
                { 1000, "M" },
                { 900, "CM" },
                { 500, "D" },
                { 400, "CD" },
                { 100, "C" },
                { 90, "XC" },
                { 50, "L" },
                { 40, "XL" },
                { 10, "X" },
                { 9, "IX" },
                { 5, "V" },
                { 4, "IV" },
                { 1, "I" },
            };

            StringBuilder sb = new StringBuilder();
            foreach (var no in romanDictionary)
            {
                while (valueToTransform >= no.Key)
                {
                    sb.Append(no.Value);
                    valueToTransform -= no.Key;
                }
            }

            return sb.ToString();
        }       

    }
}
