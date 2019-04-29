using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class ComunController : Controller
    {
        public JsonResult ListarCategoria()
        {
            return Json(CategoriaBL.Listar(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult ListarMarca()
        {
            return Json(MarcaBL.Listar(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult ListarArticuloAutocomplete()
        {
            return Json(ArticuloBL.Listar()
                          .Select(x => new { value = x.Codigo + " - " + x.Nombre + " (S/ " + x.Venta + ")", data = x.Id })
                          .ToList()
            , JsonRequestBehavior.AllowGet);
        }
        public JsonResult ObtenerArticulo(int id)
        {
            return Json(ArticuloBL.Obtener(id), JsonRequestBehavior.AllowGet);
        }

        public JsonResult BuscarArticuloCodigo(string id) {
            return Json(ArticuloBL.Obtener(x=>x.Codigo==id), JsonRequestBehavior.AllowGet);
        }
        public JsonResult ObtenerPersonaDocumento(string id)
        {
            return Json(PersonaBL.Obtener(x => x.NumDocumento == id), JsonRequestBehavior.AllowGet);
        }
    }
}