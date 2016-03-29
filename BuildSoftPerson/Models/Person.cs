using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuildSoftPerson.Models
{
    public class Person : IPerson 
    {

        public string Name { get; set; }
        public int Age { get; set; }
        public double height { get; set; }
        public override string ToString()
        {
            return "My name is '" + Name + "' and I am " + Age + " years old.";
        }

       public IRace race { get; set; }

        public virtual void IncrementAge()
        {
            Age++;
        }

        

    }
    

}