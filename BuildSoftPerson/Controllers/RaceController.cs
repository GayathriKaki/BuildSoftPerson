using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuildSoftPerson.Models;

namespace BuildSoftPerson.Controllers
{
    public class RaceController : Controller
    {
        // GET: Race
        public List<Race> GetListOfRace()
        {


            var races = new List<Race>();


            races.Add(new Race() { raceName = "Angle", raceId = 0});
            races.Add(new Race() { raceName = "Saxon", raceId = 1 });
            races.Add(new Race() { raceName = "Jute", raceId = 2 });
            races.Add(new Race() { raceName = "Asian", raceId = 3});

            return races;


        }
    }
}