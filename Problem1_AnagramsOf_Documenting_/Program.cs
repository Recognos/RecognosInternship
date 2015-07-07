using System;
using System.Collections.Generic;
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
            //var initialString = "Documenting".ToLower().OrderBy(p => p).ToArray();
            //Console.WriteLine(initialString);
            /*
            string toCheck = "Hello";
            var a = toCheck.ToCharArray();
            var res = Class1.canBeAnagram(a, "Hell");
            Console.WriteLine(res);

            string aa = "Ionut";
            aa=aa.Replace('o'.ToString(),"");
            Console.WriteLine(aa);
            */
            //var x = "asdsa".ToCharArray();



            var wordsFromFile = new List<string>();

            /*
            var a = "Hello".ToCharArray();
            var res = Class1.canBeAnagram(a, "Hell");
            Console.WriteLine(res);
            */
            var reader = new StreamReader("wordList.txt");
            StringBuilder myStringBuilder=new StringBuilder();
            var line = "";

            while (line != null)
            {
                line = reader.ReadLine();
                if (line == null)
                    break;
                wordsFromFile.Add(line);
            }
            

            //Console.WriteLine(wordsFromFile.Count);
            var helpingString = "";
            foreach (var x in wordsFromFile)
            {
                var initialString = "Documenting".ToLower().ToCharArray();
                var xy = 0;
                var firstResult = Class1.canBeAnagram(initialString, x);
                //Console.WriteLine(x+" "+firstResult+" string: Documenting");
               
                if (firstResult != null)
                {
                    foreach (char c in firstResult)
                    {
                        var regex = new Regex(Regex.Escape(c.ToString()));
                        helpingString = regex.Replace(initialString.ToString(), "", 1);
                        //initialString = regex.Replace(initialString.ToString(), "", 1);
                        //Console.Write(c.ToString());
                    }
                    
                    foreach (var y in wordsFromFile)
                    {
                        var secondResult = Class1.canBeAnagram(helpingString.ToCharArray(), y);
                        //Console.WriteLine(y + " " + secondResult);
                        var help = "";
                        foreach (char c in secondResult)
                        {
                            var regex = new Regex(Regex.Escape(c.ToString()));
                            help = regex.Replace(helpingString.ToString(), "", 1);
                        }
                        Console.WriteLine(help.ToString());

                        if (secondResult != null && secondResult.Length == y.Length )
                        {
                            Console.WriteLine(firstResult + " -> " + secondResult);
                            xy++;
                            break;
                        }
                    }
                    
                }
                if (xy == 100)
                    break;

            }


            Console.ReadLine();
        }




    }
}
