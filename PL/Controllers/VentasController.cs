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
           
            result = BL.Cine.SumTotal();
            if (result.Correct)
            {
                cine.Cines = result.Objects;
                cine.Zona.Zonas = resultZona.Objects;
                if (cine.Cines != null)
                {
                    cine.TotalSum = cine.VentaN + cine.VentaS + cine.VentaE + cine.VentaO;
                    cine.VentaN = (cine.VentaN * 100) / cine.TotalSum;
                    cine.VentaS = (cine.VentaS * 100) / cine.TotalSum;
                    cine.VentaE = (cine.VentaE * 100) / cine.TotalSum;
                    cine.VentaO = (cine.VentaO * 100) / cine.TotalSum;

                    //
                    //cine.Cines = result.Objects;
                }
               
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
