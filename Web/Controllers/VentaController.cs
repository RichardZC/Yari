﻿using Datos;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Web.Controllers
{
    public class VentaController : Controller
    {
        public ActionResult Comprobante(int id)
        {
            return View(VentaBL.Obtener(x => x.Id == id, includeProperties: "VentaDetalle,VentaDetalle.Articulo,Persona"));
        }
        public JsonResult ObtenerVentaDetalle(int id)
        {
            return Json(
                VentaDetalleBL.Listar(x=>x.VentaId==id
            , includeProperties: "Articulo")
            .Select(x => new
            {
                x.Id,
                x.ArticuloId,
                x.Cantidad,
                x.Precio,
                x.Importe,
                x.Articulo.Nombre
            }).ToList()
            , JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Guardar(Venta pVenta, List<VentaDetalle> pLista)
        {
            try
            {
                decimal total = 0;
                for (int i = 0; i < pLista.Count; i++)
                {
                    pLista[i].Importe = pLista[i].Cantidad * pLista[i].Precio;
                    total += pLista[i].Importe;
                }
                pVenta.Fecha = DateTime.Now;
                pVenta.Estado = "P";
                pVenta.Total = total;
                pVenta.VentaDetalle = pLista;
                pVenta.Serie = VentaBL.ObtenerSerieDoc(pVenta.Tipo);
                pVenta.Numero = VentaBL.ObtenerNumeroDoc(pVenta.Tipo);
                VentaBL.Crear(pVenta);
                pVenta.VentaDetalle = null;
                return Json(new
                {
                    pVenta.Id,
                    pVenta.Fecha,
                    pVenta.Serie,
                    pVenta.Numero,
                    pVenta.Total,
                    Cliente = pVenta.ClienteId.HasValue ? PersonaBL.Obtener(pVenta.ClienteId.Value).NombreCompleto : "",
                    pVenta.Estado
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public JsonResult ListarVenta10()
        {
            return Json(
                VentaBL.Listar(orderBy: x => x.OrderByDescending(y => y.Id)
            , includeProperties: "Persona").Take(25)
            .Select(x => new
            {
                x.Id,
                x.Fecha,
                x.Serie,
                x.Numero,
                x.Total,
                Cliente = x.Persona != null ? x.Persona.NombreCompleto : "",
                x.Estado
            }).ToList()
            , JsonRequestBehavior.AllowGet);
        }
        //public JsonResult ListarVentaDetalle(int id) {
        //    return Json(VentaBL.Listar(x=>x.Id==id, includeProperties:"VentaDetalle"), JsonRequestBehavior.AllowGet);
        //}
    }
}