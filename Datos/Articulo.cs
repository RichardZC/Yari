//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class Articulo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Articulo()
        {
            this.IngresoDetalle = new HashSet<IngresoDetalle>();
            this.VentaDetalle = new HashSet<VentaDetalle>();
        }
    
        public int Id { get; set; }
        public int CategoriaId { get; set; }
        public int MarcaId { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal Costo { get; set; }
        public decimal Venta { get; set; }
        public int Stock { get; set; }
        public int StockMin { get; set; }
        public bool Activo { get; set; }
    
        public virtual Categoria Categoria { get; set; }
        public virtual Marca Marca { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IngresoDetalle> IngresoDetalle { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VentaDetalle> VentaDetalle { get; set; }
    }
}
