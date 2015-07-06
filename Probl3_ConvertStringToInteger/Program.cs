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

            //Validate the input string
            clientString=validationFunction(clientString);
            var isNegativeNumber = clientString.StartsWith("-");
            var isFloatNumber = clientString.Contains('.');

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
        /// Validates the users input string
        /// If not valid, another string will be read
        /// </summary>
        /// <param name="stringToValidate">The initial users input</param>
        /// <returns>A valid string</returns>
        private static string validationFunction(string stringToValidate)
        {
            //The string cannot have any other characters than numbers from [0,9] and '.' or '-'
            Regex rgx = new Regex("^[0-9.-]+$");

            //The string cannot have more than one '.'
            var countDots = stringToValidate.Where(x => x.Equals('.')).Count();

            //The string cannot have more than one '-'
            var countminuses = stringToValidate.Where(x => x.Equals('-')).Count();

            while (!rgx.IsMatch(stringToValidate) || countDots > 1 || countminuses > 1 || (countminuses==1 && !stringToValidate[0].Equals('-')))
            {
                Console.WriteLine("The given input cannot be represented as Integer or float!");
                stringToValidate = readString();
                countDots = stringToValidate.Where(x => x.Equals('.')).Count();
                countminuses = stringToValidate.Where(x => x.Equals('-')).Count();
            }
            return stringToValidate;
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
               stringToConvert= stringToConvert.Substring(1, stringToConvert.Length - 1);
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

        /// <summary>
        /// Writes a message to the client, specifying if the given input can be a float or an integer 
        /// </summary>
        /// <param name="isNeg">Boolean</param>
        /// <param name="isFloat">Boolean</param>
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


    }
}
