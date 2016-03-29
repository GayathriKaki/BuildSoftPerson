using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuildSoftPerson.Models
{
    public class GroupAll
    {
        

            public int Count { get; set; }
            public int MinAge { get; set; }
            public int MaxAge { get; set; }
            public double AverageAge { get; set; }

            public int[] DistinctRace { get; set; }

            public List<Group> Groups { get; set; }

            public GroupAll()
            {
                Groups = new List<Group>();
            }
        }

        public class Group
        {
            public string Race { get; set; }
            public int Count { get; set; }
        }
    
}