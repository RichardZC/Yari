using Datos;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Internet.Controllers
{
    public class ComunController : Controller
    {
        public JsonResult ObtenerPersonaDocumento(string id)
        {
            return Json(PersonaBL.Obtener(x => x.NumDocumento == id), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GuardarPersona(Persona p)
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