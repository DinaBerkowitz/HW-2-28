using AddPeopleHW.Data;
using AddPeopleHW.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AddPeopleHW.Web.Controllers
{
    public class HomeController : Controller
    {
        
        private string _connectionString = @"Data Source=.\sqlexpress;Initial Catalog=MyFirstDataBase; Integrated Security=true;";


        public IActionResult Index()
        {
            PeopleDBManager dbManager = new PeopleDBManager(_connectionString);

            return View(new PersonViewModel
            {
                people = dbManager.GetAllPeople()
            });
        }

        public IActionResult ShowAdd()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Add(List<Person> people)
        {
            PeopleDBManager dBManager = new PeopleDBManager(_connectionString);
           people = people.Where(p => p.FirstName != null && p.LastName != null && p.Age != 0).ToList();
            dBManager.AddManyPeople(people);
            return Redirect("/home/index");
        }

    
    }
}