using Datos;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class PersonaController : Controller
    {
        [HttpPost]
        public JsonResult Guardar(Persona p)
        {
            try
            {
                PersonaBL.Guardar(p);
                return Json(p.Id, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}