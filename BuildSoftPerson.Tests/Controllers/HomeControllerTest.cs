using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BuildSoftPerson;
using BuildSoftPerson.Controllers;
using BuildSoftPerson.Models;

namespace BuildSoftPerson.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetListOfPeople()
        {
            // Arrange
            HomeController controller = new HomeController();
            var people = new List<Person>();
            // Act
            people = controller.GeneratePeople();

            //Test Race Angle
            var Anglepeople = new List<Person>();           

            Anglepeople = people.Where(x => x.race .raceName == "Angle").OrderBy(x => x.Age).ToList();

          Assert.AreEqual((1.5 + (Anglepeople[0].Age * 0.45)), Anglepeople[0].height);

            //Test Race Saxonpeople
            var Saxonpeople = new List<Person>();

            Saxonpeople = people.Where(x => x.race.raceName == "Saxon").OrderBy(x => x.Age).ToList();

            Assert.AreEqual((1.5 + (Saxonpeople[0].Age * 0.45)), Saxonpeople[0].height);

            //Test Race Jute
            var Jutepeople = new List<Person>();

            Jutepeople = people.Where(x => x.race.raceName == "Jute").OrderBy(x => x.Age).ToList();

            Assert.AreEqual(((Jutepeople[0].Age * 1.6)/2), Jutepeople[0].height);


            //Test Race Asian
            var Asianpeople = new List<Person>();

            Asianpeople = people.Where(x => x.race.raceName == "Asian").OrderBy(x => x.Age).ToList();

            Assert.AreEqual((1.7+ ((Asianpeople[0].Age +2) * 0.23)), Asianpeople[0].height);



        }


        [TestMethod]
        public void IncrementAge()
        {
            // Arrange
            HomeController controller = new HomeController();
            var people = new List<Person>();
            int ageBefore = 0;
            int ageAfter = 0;

            // Act
            people = controller.GeneratePeople();
            var person = new Person();
            person = people[0];

            ageBefore = person.Age;
            person.IncrementAge();
            ageAfter = person.Age;
            Assert.AreEqual(ageBefore + 1, ageAfter);


        }

        [TestMethod]
        public void GetStatistics()
        {
            // Arrange
            HomeController controller = new HomeController();
            var people = new List<Person>();
           

            // Act
            people = controller.GeneratePeople();

            var stat = controller.GetPeopleCount(people);


            Assert.AreEqual(1,stat.MinAge);
            Assert.AreEqual(98, stat.MaxAge);
            Assert.AreEqual(1, stat.MinAge);
            Assert.AreEqual(10000, stat.Count);
            
        }

    }
}
