﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Login_MVC.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EmpresasPatitoEntities : DbContext
    {
        public EmpresasPatitoEntities()
            : base("name=EmpresasPatitoEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<cstate> cstates { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<animal> animals { get; set; }
        public virtual DbSet<animal_clases> animal_clases { get; set; }
    }
}
