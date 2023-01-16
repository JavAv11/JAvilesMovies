using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class VentasController : Controller
    {
        [HttpGet]
        public ActionResult VentasGetAll()
        {
            ML.Cine cine = new ML.Cine();
            cine.Zona = new ML.Zona();
            ML.Result resultZona = new ML.Result();
            ML.Result result = new ML.Result();
            result = BL.Zona.SumaZona();
            if (result.Correct)
            {
                cine.Zona.Zonas = resultZona.Objects;
                cine.Cines = result.Objects;
                return View(cine);
            }
            else
            {
                ViewBag.Message = "Ocurrio un error";
                return PartialView("Modal");
            }
        }
    }
}
