using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Problem9_SecretSanta
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            t1.ReadOnly = true;
            t2.ReadOnly = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //List which will contain all the persons from the file
            List<Person> personArray = new List<Person>();
            //List containing all the persons which already have a gift
            List<Person> hasAGift = new List<Person>();

            //Read all the persons from the file and save them in a list
            StreamReader readFile = new StreamReader("Fisier.txt");
            var line = "";
            while (line != null)
            {
                line = readFile.ReadLine();
                if (line == null)
                    break;
                var names = line.Split(' ');

                Person newPerson = new Person();
                newPerson.FirstName = names[0];
                newPerson.SecondName = names[1];
                personArray.Add(newPerson);

                t1.AppendText(line + "\r\n");
            }
            /*
            var result=from person in personArray
                       select new {Santa=findSecretSanta(personArray,person),person};
            */

            foreach (Person person in personArray)
            {
                Person isGoodChild = findSecretSanta(personArray, person,hasAGift);
                //Add the chosen child in the "lucky" list
                hasAGift.Add(isGoodChild);
                t2.AppendText(person.ToString() + " -> " + isGoodChild.ToString());
                t2.AppendText("\r\n");
            }
            
        }

        /// <summary>
        /// This function is used to get a random child from a list, for which the secret santa will buy a gift
        /// </summary>
        /// <param name="persons">A list containing all the persons</param>
        /// <param name="person">The person which is the Secret Santa</param>
        /// <param name="theyAlreadyHaveGifts">A list containing all the persons which already have a secret santa</param>
        /// <returns>A lucky child, "chosen" by the Secret Santa</returns>
        private Person findSecretSanta(List<Person> persons,Person person,List<Person> theyAlreadyHaveGifts){
            /*
            var res = from a in persons
                      where a.FirstName != person.FirstName
                      select a;
            List<Person> pers=res.ToList<Person>();
            */
            Person toReturn = new Person();
            toReturn.FirstName =person.FirstName;
            toReturn.SecondName = person.SecondName;
            while (toReturn.FirstName == person.FirstName || theyAlreadyHaveGifts.Contains(toReturn))
            {
                Random rnd = new Random();
                int no = rnd.Next(0, persons.Count());

                toReturn=persons[no];
            }
            return toReturn;
        }


    }
}
