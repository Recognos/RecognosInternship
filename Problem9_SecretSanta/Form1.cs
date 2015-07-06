using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
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
            List<Person> personArray = new List<Person>();
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
        }
    }
}
