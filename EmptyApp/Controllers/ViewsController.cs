using EmptyApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace EmptyApp.Controllers
{
    public class ViewsController : Controller
    {
       // public Class1 class1 { get; set; }
        [Route("view")]
        public IActionResult Index()
        {
            ViewData["namesi"] = new List<Animals>(){
                new Animals{Id=1,AnimalName="Elephant",Description="Very Strong"},
                new Animals{Id=2,AnimalName="Deer",Description="Speed And Beautiful"},
                new Animals{Id=3,AnimalName="Lion",Description="Very Strong"},
                new Animals{Id=4,AnimalName="Giraffee",Description="Speed And Beautiful"},
                new Animals{Id=5,AnimalName="Dog",Description="Very Strong"},
                new Animals{Id=6,AnimalName="Zebra",Description="Speed And Beautiful"}
            };
            var anis = new List<Animals>(){
                new Animals{Id=1,AnimalName="Elephant",Description="Very Strong"},
                new Animals{Id=2,AnimalName="Deer",Description="Speed And Beautiful"}
            };
            ViewBag.Animals = anis;
            ViewBag.Title = "My Web page";
            return View();
        }
        [Route("stronglytyped/{name?}")]
        public IActionResult Stronglytyped(string? name)
        {
            List<Animals> animals = new List<Animals>(){
                new Animals{Id=1,AnimalName="Elephant",Description="Very Strong"},
                new Animals{Id=2,AnimalName="Deer",Description="Speed And Beautiful"},
                new Animals{Id=3,AnimalName="Lion",Description="Very Strong"},
                new Animals{Id=4,AnimalName="Giraffee",Description="Speed And Beautiful"},
                new Animals{Id=5,AnimalName="Dog",Description="Very Strong"},
                new Animals{Id=6,AnimalName="Zebra",Description="Speed And Beautiful"}
            };


            if (name == null)
            {
                return View(animals);
            }
            else
            {
                List<Animals>? animals1 = animals.Where(a => a.AnimalName == name).ToList();
                return View(animals1);
            }


        }
        [Route("Merge")]
        public IActionResult Merging()
        {
            List<Animals> animals = new List<Animals>(){
                new Animals{Id=1,AnimalName="Elephant",Description="Very Strong"},
                new Animals{Id=2,AnimalName="Deer",Description="Speed And Beautiful"},
                new Animals{Id=3,AnimalName="Lion",Description="Very Strong"},
                new Animals{Id=4,AnimalName="Giraffee",Description="Speed And Beautiful"},
                new Animals{Id=5,AnimalName="Dog",Description="Very Strong"},
                new Animals{Id=6,AnimalName="Zebra",Description="Speed And Beautiful"}
            };
            ViewData["namesi"] = new List<Animals>(){
                new Animals{Id=1,AnimalName="Elephant",Description="Very Strong"},
                new Animals{Id=2,AnimalName="Deer",Description="Speed And Beautiful"},
                new Animals{Id=3,AnimalName="Lion",Description="Very Strong"},
                new Animals{Id=4,AnimalName="Giraffee",Description="Speed And Beautiful"},
                new Animals{Id=5,AnimalName="Dog",Description="Very Strong"},
                new Animals{Id=6,AnimalName="Zebra",Description="Speed And Beautiful"}
            };
            List<Student> students = new List<Student>
            {
                new Student { Id = 1, Name = "Vinay" },
                new Student { Id = 2, Name = "chethan" },
                new Student { Id = 3, Name = "madhu" },
                new Student { Id = 4, Name = "laxman" }
            };
            MergingtwoModels model = new MergingtwoModels() { Animal = animals[0], Student = students[0] };        
            return View(model);
        }
        [Route("partialview")]
        public PartialViewResult PartialViewResult()
        {
            var model = new Animals() { AnimalName="ravi"};
            return PartialView("_PartialView", model);
        }
        [HttpGet]
        [Route("ViewComponentResult")]
        public IActionResult viewComponentResult()
        {
            return ViewComponent("MyFirst");
        }
       
    }
}
