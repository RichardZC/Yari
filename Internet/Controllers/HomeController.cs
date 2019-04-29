using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Internet.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult ListarArticulo()
        {
            return Json(ArticuloBL.Listar()
                          .ToList()
            , JsonRequestBehavior.AllowGet);
        }

    }
}