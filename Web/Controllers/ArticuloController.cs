using Datos;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class ArticuloController : Controller
    {
        //nuevo cambio
        public ActionResult Index()
        {
            return View();
        }
        //otro cambio
        // otro cambio
        public ActionResult Buscar(string id)
        {
            return Json(Negocio.ArticuloBL.Listar(x => x.Nombre.Contains(id) || x.Codigo.Contains(id)), JsonRequestBehavior.AllowGet);
        }
        public ActionResult ListarTodo()
        {
            return Json(Negocio.ArticuloBL.Listar(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult ListarMarca()
        {
            var m = MarcaBL.Obtener(x => x.Nombre == "GENERAL");
            if (m==null)            
                MarcaBL.Crear(new Marca { Nombre = "GENERAL" });           
            return Json(MarcaBL.Listar(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult ListarCategoria()
        {
            var m = CategoriaBL.Obtener(x => x.Nombre == "GENERAL");
            if (m == null)
                CategoriaBL.Crear(new Categoria { Nombre = "GENERAL" });
            return Json(CategoriaBL.Listar(), JsonRequestBehavior.AllowGet);
        }        
        [HttpPost]
        public JsonResult Guardar(Articulo pArticulo)
        {
            try
            {
                pArticulo.Nombre = pArticulo.Nombre.ToUpper();
                ArticuloBL.Guardar(pArticulo);
                return Json(pArticulo.Id, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        public JsonResult NuevaMarca(Marca m)
        {
            try
            {
                m.Nombre = m.Nombre.ToUpper();
                MarcaBL.Crear(m);
                return Json(m, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        public JsonResult NuevaCategoria(Categoria m)
        {
            try
            {
                m.Nombre = m.Nombre.ToUpper();
                CategoriaBL.Crear(m);
                return Json(m, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}