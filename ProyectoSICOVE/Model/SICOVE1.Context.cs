﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SICOVE1Entities2 : DbContext
    {
        public SICOVE1Entities2()
            : base("name=SICOVE1Entities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tb_Categorias> tb_Categorias { get; set; }
        public virtual DbSet<tb_Clientes> tb_Clientes { get; set; }
        public virtual DbSet<tb_Compras> tb_Compras { get; set; }
        public virtual DbSet<tb_DetalleCompras> tb_DetalleCompras { get; set; }
        public virtual DbSet<tb_DetalleVentas> tb_DetalleVentas { get; set; }
        public virtual DbSet<tb_Empleados> tb_Empleados { get; set; }
        public virtual DbSet<tb_FormaPago> tb_FormaPago { get; set; }
        public virtual DbSet<tb_Inventarios> tb_Inventarios { get; set; }
        public virtual DbSet<tb_Productos> tb_Productos { get; set; }
        public virtual DbSet<tb_Proveedores> tb_Proveedores { get; set; }
        public virtual DbSet<tb_Roles> tb_Roles { get; set; }
        public virtual DbSet<tb_Usuarios> tb_Usuarios { get; set; }
        public virtual DbSet<tb_Ventas> tb_Ventas { get; set; }
    }
}