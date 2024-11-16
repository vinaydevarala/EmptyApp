using EmptyApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace EmptyApp.Controllers
{
    [Controller]//use this way if you need not suffix controller to ur class name
    public class IactionMethods_Controller : Controller
    {
        

        [Route("Display")]
        public string DisplayName()
        {
            return "this is Vinay";
        }
        [Route("ContentResult")]
        public ContentResult ContentResult()
        {
            ContentResult content = new ContentResult()
            {
                Content =
                "<fieldset>MyName<legend>Vinay</legend></fieldset>",
                StatusCode = 201,
                ContentType = "text/html"
            };
            //return new ContentResult
            //{
            //    Content = "my name is Vinay",
            //    ContentType = "text/plain",
            //    StatusCode = 209
            //};
            return Content(content.Content, content.ContentType);
        }
        [Route("JsonResult")]
        public JsonResult JsonResult()
        {
           Student student = new Student()
           {
               Id = 1,
               Name="VINAY"
           };
            return Json("{\"name\":\"vinay\"}");
          //  return new JsonResult(student);
        }
        [Route("FileResult")]
        public FileResult FileResult()
        {
            return File("/resume.pdf","application/pdf");
        }
        [Route("PhysicalPath")]
        public PhysicalFileResult VirtualFileResult()
        {
            return  new PhysicalFileResult(@"C:\Users\vinay\Downloads\\ASP.NET Assignment.pdf","application/pdf");
        }
        [Route("Bytes")]
        public FileContentResult FileContentResult()
        {
          byte[] bytes=  System.IO.File.ReadAllBytes(@"C:\Users\vinay\Downloads\\ASP.NET Assignment.pdf");
            return File(bytes,"application/pdf");
        }
        [Route("IactionResult")]
        public IActionResult IactionResult()
        {
            if (Request.Query.ContainsKey("id"))
            {
                int? id = int.Parse(Request.Query["id"]);

                return new ContentResult() { Content = $"<h1>id :-{id}</h1>", ContentType = "text/html" };
            }
            else if (Request.Query.ContainsKey("name"))
            {
                return Json(new { Id = 1, name = $"{Request.Query["name"]}" });
            }
            else
            {
                return File("/resume.pdf", "application/pdf");
            }
          
        }
    }
}
