using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuildSoftPerson.Models;
using BuildSoftPerson.Controllers;
using PagedList.Mvc;
using PagedList;

namespace BuildSoftPerson.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

       

        public ActionResult GetListOfPeople(int? page,int id=-1)
        {
            var people = new List<Person>();
            RaceController raceList = new RaceController();
            var races = raceList.GetListOfRace();           

            ViewBag.racesall = new SelectList(races, "raceId", "raceName",id);           

            if (id > -1)
            {
                people =  Session["people"] as List<Person>;
                people = people.Where(x => x.race.raceId == id && x.Age % 2 == 0).OrderBy(x => x.Age).ToList();

            }
            else
            {
                people = GeneratePeople();
                Session["people"] = people;
            }
            ViewBag.id = id;
            int pageSize = 15;
            int pageNumber = (page ?? 1);
            return View(people.ToPagedList(pageNumber, pageSize));


        }

        public List<Person> GeneratePeople()
        {
            var count = 10000;
            var people = new List<Person>();
            Random rnd = new Random();
            RaceController raceList = new RaceController();
            var races = raceList.GetListOfRace();
            for (int i = 0; i < count; i++)
            {
                var raceId = rnd.Next(0, 4);
                Race race = new Race();
                race = races[raceId];

                var person = new Person();
                person.Name = "Person #" + i.ToString();
                person.Age = rnd.Next(1, 99);
                person.height = race.height(person);
                person.race = race;

                people.Add(person);
            }

            return people;
        }

        public JsonResult IncrementAge()
        {
            List<Person> people = Session["people"] as List<Person>;
            foreach (var person in people)
            {
                person.IncrementAge();
            }

            return Json(people, JsonRequestBehavior.AllowGet);

        }


        public GroupAll GetPeopleCount(List<Person> people)
        {
            var stat = new GroupAll();
            stat.Count = people.Count;

            stat.MinAge = people.Min(x => x.Age);
            stat.MaxAge = people.Max(x => x.Age);
            stat.AverageAge = people.Average(x => x.Age);

            var query = from person in people
                        group person by person.race.raceName into grouping
                        select new Group { Race = grouping.Key, Count = grouping.Count() };

            stat.Groups = query.ToList();

            return stat;
        }

        public JsonResult GetStatistics()
        {
            var people = new List<Person>();
            people = Session["people"] as List<Person>;

            var stat = GetPeopleCount(people);

            return Json(stat, JsonRequestBehavior.AllowGet);
        }

    }
}