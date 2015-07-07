using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem1_AnagramsOf_Documenting_
{
    public static class Class1
    {

        public static char[] ReplaceCharacter(char[] listOfCharacters, char character)
        {
            char[] toReturn;
            var regex = new Regex(Regex.Escape(character.ToString()));
            toReturn = regex.Replace(listOfCharacters.ToString(), "", 1).ToCharArray();
            return toReturn;
        }

        public static bool isAnagram(string firstString, string secondString)
        {
            //If the length of the strings is different, they are not annagrams
            if (firstString.Length != secondString.Length)
                return false;

            //Sort both of the strings
            var firstToChars = firstString.ToLower().ToArray().OrderBy(p => p);
            var secondToChars = secondString.ToLower().ToArray().OrderBy(p => p);
            
            //Parse the character arrays and check if the elements from the same
            //index in the lists are the same. If not, the strings are not annagrams
            for (int i = 0; i < firstToChars.Count(); i++)
            {
                if (!firstToChars.ElementAt(i).Equals(secondToChars.ElementAt(i)))
                    return false;
            }

            return true;
        }

        /*
        public static string canBeAnagram(string initialString, string stringFromFile)
        {
            var characters = initialString.ToCharArray();
            var myStringBuilder = new StringBuilder();
            string copyOfStringFromFile = stringFromFile;

            foreach (var c in characters)
            {
                if (copyOfStringFromFile.Contains(c))
                {
                    myStringBuilder.Append(c);
                    copyOfStringFromFile=copyOfStringFromFile.Replace(c.ToString(),"");

                }    
            }


            return null;
        }
        */

        public static string canBeAnagram(char[] characters, string givenString)
        {
            
            var myString = givenString.ToLower();
            //String builder used to manipulate the given string
            var strBuilder = new StringBuilder();
            strBuilder.Append(myString);
            

            //List in wich every character from the given list
            //(character has to be inside the given string)
            //is inserted
            var toReturn=new StringBuilder();

            foreach (char c in characters)
            {
                var character = Char.ToLower(c);
                if (strBuilder.ToString().Contains(character))
                {
                    //Add the character in the return list
                    toReturn.Append(c);
                    //Delete the character from the "input string"


                    var regex = new Regex(Regex.Escape(character.ToString()));
                    //Replace the first occurence of the character c in the given string
                    givenString = regex.Replace(givenString, "", 1);

                    strBuilder.Clear();
                    strBuilder.Append(givenString);
                }
            }
            //If every character from the given string was found, return the 
            //remaining characters from the input character list
            if (strBuilder.Length.Equals(givenString.Length))
                return toReturn.ToString();
            else
                return "";
        }

    }
}
