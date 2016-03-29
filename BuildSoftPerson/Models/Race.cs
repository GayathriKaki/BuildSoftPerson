using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuildSoftPerson.Models
{
    public class Race : IRace 
    {
        public string raceName {get; set; }
        public int raceId { get; set; }

        public double height(IPerson person)
        {
            double heightval=0.0;
            switch (raceId)
            {
                case 0:
                    heightval = (1.5 + (person.Age * 0.45));
                    break;
                case 1:
                    heightval = (1.5 + (person.Age * 0.45));
                    break;
                case 2:
                    heightval = ((person.Age * 1.6) / 2);
                    break;
                case 3:
                    heightval = (1.7 + ((person.Age + 2) * 0.23));
                    break;


            }

            return heightval;
        }
        
    }
   
}