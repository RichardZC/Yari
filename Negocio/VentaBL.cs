using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class VentaBL : Repositorio<Venta>
    {
        public static string ObtenerNumeroDoc(string TipoDoc)
        {
            var doc = new Venta();
            using (var BD = new YARIEntities())
            {
                doc = BD.Venta.Where(x => x.Tipo == TipoDoc).OrderByDescending(x => x.Id).FirstOrDefault();
            }

            if (doc != null)
            {
                return (int.Parse(doc.Numero) + 1).ToString("D6");
            }
            else
                return "000001";
        }
        public static string ObtenerSerieDoc(string TipoDoc)
        {
            switch (TipoDoc)
            {
                case "V":
                    return "001";
                case "B":
                    return "B001";
                case "F":
                    return "F001";
            }
            return string.Empty;            
        }
    }
}
