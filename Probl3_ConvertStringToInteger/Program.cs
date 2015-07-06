using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Probl3_ConvertStringToInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            var clientString = readString();
            var lengthOfString = clientString.Length;
            var isNegativeNumber = clientString.StartsWith("-");
            var isFloatNumber = clientString.Contains('.');

            //Validate the input string
            validationFunction(clientString);

            /*
             * Print some messages to the user,
             * depending on the given input
             */
            helperMethod(isNegativeNumber,isFloatNumber);

            if (!isFloatNumber)
            {
                var result = convertToInt(clientString, isNegativeNumber);
                Console.WriteLine("The result is: {0}", result);
            }
            else
            {
                var result = convertToFloat(clientString, isNegativeNumber);
                Console.WriteLine("The result is: {0}", result);
            }
        
            //Console.WriteLine(clientString);
            Console.ReadLine();
        }

        /// <summary>
        /// Function used to convert a string into a float (negative or positive)
        /// </summary>
        /// <param name="stringToConvert">The string to be converted</param>
        /// <param name="isNegative">A boolean saying if the string can be considered as a negative float or a positive one</param>
        /// <returns>A float (negative or positive)</returns>
        private static float convertToFloat(string stringToConvert, bool isNegative)
        {
            int dotPosition=0;
            float toReturn = 0.0f;
            if (isNegative)
                stringToConvert.Substring(1, stringToConvert.Length - 1);
            for(int i=0;i<stringToConvert.Length;i++)
            {
                if (stringToConvert[i].Equals('.'))
                    dotPosition = stringToConvert.Length - i - 1;
                else
                    toReturn = toReturn * 10.0f + (stringToConvert[i] - '0');
            }
            while (dotPosition!=0)
            {
                toReturn /= 10.0f;
                dotPosition--;
            }

            if (isNegative)
                return -toReturn;
            else
                return toReturn;
        }


        /// <summary>
        /// Function used to convert a string into an Integer (negative or positive)
        /// </summary>
        /// <param name="stringToConvert"> The string to be converted</param>
        /// <param name="isNegative"> A boolean saying if the string can be considered as a negative integer or a positive one</param>
        /// <returns> An integer (negative or positive)</returns>
        private static int convertToInt(string stringToConvert,bool isNegative)
        {
            var toReturn = 0;
            /*
             * If the number has a '-' as the first character,
             * it will not be considered until the end
             */
            if (isNegative)
                stringToConvert = stringToConvert.Substring(1, stringToConvert.Length-1);

            foreach (char c in stringToConvert)
            {
                toReturn *= 10;
                toReturn += (c - '0');
            }

            if (isNegative)
                return -toReturn;
            else
                return toReturn;
        }


        private static string readString()
        {
            Console.Write("Give a string : ");
            var str = Console.ReadLine();
            return str;
        }

        private static void helperMethod(bool isNeg,bool isFloat){
            if (isNeg && isFloat)
                Console.WriteLine("The string will be a negative float");
            else if (isNeg)
                Console.WriteLine("The string will be a negative integer");
            else if (isFloat)
                Console.WriteLine("The string will be a float");
            else
                Console.WriteLine("The string will be an integer");
        }

        private static void validationFunction(string stringToValidate)
        {
            //Check if the given string contains invalid characters
            Regex rgx = new Regex("^[0-9.]+$");
            while (!rgx.IsMatch(stringToValidate))
            {
                Console.WriteLine("The given input cannot be represented as Integer or float!");
                stringToValidate = readString();
            }
        }
    }
}
