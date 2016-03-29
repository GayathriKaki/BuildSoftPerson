using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuildSoftPerson.Models
{
    public interface IPerson
    {
        string Name { get; set; }
        int Age { get; set; }

        IRace race { get; set; }

       double height { get; set; }

        void IncrementAge();
    }
}