//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoSICOVE.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_DetalleVentas
    {
        public int IdDetalleVenta { get; set; }
        public Nullable<int> IdVenta { get; set; }
        public Nullable<int> IdProducto { get; set; }
        public Nullable<int> IdCategoria { get; set; }
        public Nullable<decimal> PrecioVenta { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal SubTotal { get; set; }
        public Nullable<decimal> Descuento { get; set; }
        public Nullable<decimal> IVA { get; set; }
        public decimal Total { get; set; }
    
        public virtual tb_Categorias tb_Categorias { get; set; }
        public virtual tb_Productos tb_Productos { get; set; }
        public virtual tb_Ventas tb_Ventas { get; set; }
    }
}
