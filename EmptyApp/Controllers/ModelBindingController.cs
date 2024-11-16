using EmptyApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmptyApp.Controllers
{
    public class ModelBindingController : Controller
    {
        [Route("FromQuery")]
        public IActionResult FromQuery([FromQuery]int id,[FromQuery]string name)
        {
            return Content($"<h1>{id}</h1><p>{name}</p>","text/html");       
        }
        [Route("FromRoute/{id}/{name}")]
        public IActionResult FromRoute([FromRoute] int id, [FromRoute] string name)
        {
            return Content($"<h1>{id}</h1><p>{name}</p>", "text/html");
        }
        [HttpGet("FromForm")]
        public IActionResult FromForm(int id,string name,[FromForm]Student student)
        {
            string nme = string.Empty;
            if (ModelState.IsValid)
            {
                return Content($"<h1>{student.Id}</h1><p>{student.Name}</p>", "text/html");
            }
            else
            {
                foreach (var item in ModelState.Values)
                {
                    foreach (var item1 in item.Errors)
                    {
                         nme += "\n"+item1.ErrorMessage + "\n";
                    }
                } 
             
                return Content($"some are missing{nme}", "text/plain");
            }
        }
        [HttpPost("BindData")]
        //Bind Attribute for only query,routes and Form Data its Not applicable for complex data like raw JSon,Xml Type datas for those we use DTOs
        public IActionResult IvalidateObjectEx([Bind(nameof(EmployeeIValidate.Id))] EmployeeIValidate employeeIValidate)
        {
            string nme = string.Empty;
            if (ModelState.IsValid)
            {
                return Content($"<h1>{employeeIValidate.Id}</h1><p>{employeeIValidate.Name}</p>", "text/html");
            }
            else
            {
                foreach (var item in ModelState.Values)
                {
                    foreach (var item1 in item.Errors)
                    {
                        nme += "\n" + item1.ErrorMessage + "\n";
                    }
                }

                return Content($"some are missing{nme}", "text/plain");
            }
          
        }
        [Route("FromBody")]
        public IActionResult FromBody([FromBody]EmployeeIValidate employeeIValidate)
        {
            return Content($"<h1>{employeeIValidate.Id}</h1><p>{employeeIValidate.Name}</p>", "text/html");
        }
        [Route("CustomModelBinding")]
        public IActionResult FromBody(Animals animals)
        {
            return Content($"<h1>{animals.Id}</h1><p>{animals.AnimalName}</p><p>{animals.Description}</p>", "text/html");
        }
        [Route("FromHeader")]
        public IActionResult FromHeader([FromHeader(Name="id")] int id)
        {
            return Content($"<h1>{id}</h1>", "text/html");
        }



    }
}
