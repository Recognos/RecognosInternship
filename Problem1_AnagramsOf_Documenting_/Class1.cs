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

        public static Dictionary<char, int> getFrequenceVector(string myString)
        {
            if (myString == null) throw new ArgumentNullException("The string is empty!");
            var myDict = new Dictionary<char, int>();
            foreach (var c in myString)
            {
                if (myDict.ContainsKey(c))
                    myDict[c]++;
                else
                    myDict.Add(c, 1);
            }
            return myDict;
        }

        public static bool canBeAnagrams(Dictionary<char, int> firstDict, Dictionary<char, int> secondDict, Dictionary<char, int> initialDict)
        {
            var helping = 0;
            foreach (var item in firstDict)
            {
                helping += item.Value;
            }
            foreach (var item in secondDict)
            {
                helping += item.Value;
            }
            foreach (var item in initialDict)
            {
                helping -= item.Value;
            }
            if (helping != 0)
                return false;
            return true;
        }

        public static bool areAnagrams(Dictionary<char, int> firstDict, Dictionary<char, int> secondDict, Dictionary<char,int> initialDict)
        {
            foreach (var item in firstDict)
            {
                if (initialDict.ContainsKey(item.Key))
                    initialDict[item.Key]-=item.Value;
            }

            foreach (var item in secondDict)
            {
                if (initialDict.ContainsKey(item.Key))
                    initialDict[item.Key]-=item.Value;
            }
            //foreach (var item in initialDict)
                //Console.WriteLine(item.Key + " " + item.Value);
            return initialDict.Values.All(i => i == 0);

        }

        /*
        public static bool areAnagrams(string firstString, string secondString,string initialString)
        {
            if (initialString == null) throw new ArgumentNullException("First string is null!");
            if (secondString == null) throw new ArgumentNullException("Second string is null!");
            if (initialString == null) throw new ArgumentNullException("The initial string is null!");
            
             //*firstString and secondString are words read from the given file.
             //*If the length of these two words is not equal to the length of the initialString("Documenting")
             //*in out case, they cannot be annagrams
             
            if (firstString.Length + secondString.Length != initialString.Length)
                return false;

            //The frequence vector will keep in memory the characters of the initialString/firstString/secondString
            // (and an integer, representing the number of appearances of the character in the string)
            
            var frequenceVector = new Dictionary<char, int>();

            //Initialize the frequence vector with the initial string characters
            foreach (char c in initialString)
            {
                try{
                    frequenceVector[c]++;
                }catch
                {
                    frequenceVector.Add(c, 1);
                }
            }

            //Parse the first string and the second string  and decrement the frequence vector according
            //to their characters
            foreach (char c in firstString)
            {
                try
                {
                    frequenceVector[c]--;
                }
                catch
                {
                    frequenceVector.Add(c, 1);
                }
            }

            foreach (char c in secondString)
            {
                try
                {
                    frequenceVector[c]--;
                }
                catch
                {
                    frequenceVector.Add(c, 1);
                }
            }


            //If the frequence Vector is empty, then the words are anagrams
            return frequenceVector.Values.All(i => i == 0);
        }
        */

        

    }
}
