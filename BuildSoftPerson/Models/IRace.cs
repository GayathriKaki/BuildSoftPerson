using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuildSoftPerson.Models
{
    public interface IRace
    {
         string raceName { get; set; }
         int raceId { get; set; }
        double height(IPerson person);
       
        }
}