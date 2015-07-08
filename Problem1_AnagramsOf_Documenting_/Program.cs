using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem1_AnagramsOf_Documenting_
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get the string from the application config
            var initialWord = ConfigurationManager.AppSettings["initialString"];

            initialWord = initialWord.ToLower();
            var initialWordFrequence=Class1.getFrequenceVector(initialWord);

            //The words from the file are kept in a dictionary, together with their frequence vector
            var wordsFromFileDict = new Dictionary<string, Dictionary<char, int>>();

            //The result strings are kept in a dictionary
            var resultDict = new Dictionary<string, string>();           

            var reader = new StreamReader("wordList.txt");
            var line = "";
            while (line != null)
            {
                line = reader.ReadLine();
                
                if (line == null)
                    break;
                line = line.ToLower();
                if(!wordsFromFileDict.ContainsKey(line))
                    wordsFromFileDict.Add(line, Class1.getFrequenceVector(line));
            }

            foreach (var x in wordsFromFileDict)
            {
                
                //Console.WriteLine(x.ToLower());
                foreach (var y in wordsFromFileDict)
                {
                    initialWordFrequence = Class1.getFrequenceVector(initialWord);
                    if (Class1.canBeAnagrams(x.Value, y.Value, initialWordFrequence))

                        if (Class1.areAnagrams(x.Value, y.Value, initialWordFrequence))
                            //Doesn't add duplicates in the result
                            if(!(resultDict.ContainsKey(x.Key) && resultDict.ContainsValue(y.Key))
                                && !(resultDict.ContainsKey(y.Key) && resultDict.ContainsValue(x.Key) ))
                                    resultDict.Add(x.Key, y.Key);                 
                }
            }

            //Print the results
            foreach (var item in resultDict)
            {
                Console.WriteLine(String.Format("Anagrams of {0} : {1} - {2}", initialWord, item.Key, item.Value));
            }

            Console.ReadLine();
        }




    }
}
