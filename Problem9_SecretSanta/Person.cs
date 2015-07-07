using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem9_SecretSanta
{
    class Person
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }

        public override string ToString()
        {
            return this.FirstName + " " + this.SecondName;
        }
    }
}
