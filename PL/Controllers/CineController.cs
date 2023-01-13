using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;

namespace PL.Controllers
{
    public class CineController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Cine cine = new ML.Cine();
            cine.Zona = new ML.Zona();
            ML.Result resultZona = new ML.Result();
            ML.Result result = new ML.Result();
            result = BL.Cine.GetAll();
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

        [HttpGet]
        public ActionResult Form(int?IdCine)
        {
            ML.Cine cine = new ML.Cine();
            cine.Zona = new ML.Zona();
            
            ML.Result resultZona =BL.Zona.GetAll();

            if (IdCine == null)
            {
                cine.Zona.Zonas=resultZona.Objects;
                return View(cine);
            }
            else
            {
                ML.Result result = new ML.Result();
                result = BL.Cine.GetById(IdCine.Value);

                if (result.Correct)
                {
                    
                    cine=(ML.Cine)result.Object;
                    cine.Zona.Zonas = resultZona.Objects;
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error";
                    return PartialView("Modal");
                }
            }
            return View(cine);
        }

        [HttpPost]
        public ActionResult Form(ML.Cine cine)
        {
            if (cine.IdCine == 0)
            {
                ML.Result result = BL.Cine.Add(cine);

                if (result.Correct)
                {
                    ViewBag.Message = "Se ha registrado el Cine";
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Message = "No se ha registrado el Cine" + result.ErrorMessage;
                    return PartialView("Modal");
                }
            }
            else
            {
                ML.Result result=BL.Cine.Update(cine);
                if (result.Correct)
                {

                    ViewBag.Message = "Se ha Actualizado el Cine";
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Message = "No ha registrado el Cine" + result.ErrorMessage;
                    return PartialView("Modal");
                }
            }
        }

        [HttpGet]
        public ActionResult Delete(int IdCine)
        {
            ML.Result result = new ML.Result();

            result = BL.Cine.Delete( IdCine);
            if (result.Correct)
            {
                ViewBag.Message = "Se ha elimnado el registro";
                return PartialView("Modal");
            }
            else
            {
                ViewBag.Message = "No see ha elimnado el registro" + result.ErrorMessage;
                return PartialView("Modal");
            }

        }
    }
}
