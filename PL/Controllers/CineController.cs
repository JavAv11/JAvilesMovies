using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;

namespace PL.Controllers
{
    public class CineController : Controller
    {
        [HttpGet]
        public ActionResult GettAll()
        {
            //ML.Cine cine = new ML.Cine();

            //using(var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri("  https://www.google.com/maps/embed/v1/");
            //    var responseTask = client.GetAsync("MAP_MODE?key=AIzaSyBJB98-M9YPAuSyEZgnPUrKPp3djyA4364&parameters");
            //    responseTask.Wait();

            //    var result = responseTask.Result;
            //    if(result.IsSuccessStatusCode)
            //    {
            //        var readTask = result.Content.ReadAsStringAsync();
            //        dynamic resulJSON = JsonObject.Parse(readTask.Result.ToString());
            //        responseTask.Wait();
                    
            //    }
            //}
            return View();
        }

        public ActionResult Form()
        {
            return View();
        }
    }
}
