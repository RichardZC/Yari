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
        public ActionResult Index()
        {
            return View();
        }
       
        public ActionResult Buscar(string id)
        {
            var lista = ArticuloBL.Listar(x => x.Nombre.Contains(id) || x.Codigo.Contains(id),
                includeProperties: "Marca,Categoria");
            return Json(lista.Select(x => new
            {
                x.Id,
                x.CategoriaId,
                x.MarcaId,
                x.Nombre,
                x.Stock,
                x.StockMin,
                x.Codigo,
                x.Costo,
                x.Venta,
                x.Activo,
                NombreMarca = x.Marca.Nombre,
                NombreCategoria = x.Categoria.Nombre
            }).ToList(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult ListarTodo()
        {
            return Json(ArticuloBL.Listar(), JsonRequestBehavior.AllowGet);
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
