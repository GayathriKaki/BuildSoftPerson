using BuildSoftPerson.Models;
using BuildSoftPerson.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Mvc;



namespace BuildSoftPerson.Models
{
        
    public class PersonController : Controller 
    {


        public List<IPerson> GetListOfPeople()
        {
            var count = 10000;

            RaceController raceList = new RaceController();
            var races = raceList.GetListOfRace();
            var people = new List<IPerson>();
            Random rnd = new Random();
            for (int i = 0; i < count; i++)
            {
                var raceId = rnd.Next(0, 4);
                Race race = new Race();
                race = races[raceId];

                var person = new Person();
                person.Name = "Person #" + i.ToString();
                person.Age = rnd.Next(1, 99);
                person.height = race.height(person);

                people.Add(person);
            }



            return people;


        }



        public List<IPerson> IncrementAgeForAll()
        {
            var people = GetListOfPeople();

            foreach (var person in people)
            {
                person.IncrementAge();
            }


            return people;
        }


        public JsonResult GetRaces()
        {
            var factory = new RaceController();
            return Json(factory.GetListOfRace(), JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetPeopleDetail(int raceValue)
        {
            var raceobj = new RaceController();
            var peopleobj = new PersonController();
            var races = raceobj.GetListOfRace();

            var manager = new PeopleManager(peopleobj.GetListOfPeople());

            manager.FilteredPeople = manager.People.Where(x => x.race.raceName  == races[raceValue].raceName && x.Age % 2 == 0).OrderBy(x => x.Age).ToList();


            return Json(manager.FilteredPeople, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetStatistics(int raceValue)
        {
            var raceobj = new RaceController();
            var peopleobj = new PersonController();
            var races = raceobj.GetListOfRace();

            var manager = new PeopleManager(peopleobj.GetListOfPeople());


            manager.FilteredPeople = manager.People.Where(x => x.race.raceName == races[raceValue].raceName && x.Age % 2 == 0).OrderBy(x => x.Age).ToList();


            var stat = manager.GetStatistics();

            return Json(stat, JsonRequestBehavior.AllowGet);
        }

        public JsonResult IncrementAge(int year)
        {
            var raceobj = new RaceController();
            var peopleobj = new PersonController();
            peopleobj.IncrementAgeForAll();

            return Json("", JsonRequestBehavior.AllowGet);
        }



    }

}