﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SinemaOtomasyon.DAL.SinemaContext
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SinemaContext : DbContext
    {
        public SinemaContext()
            : base("name=SinemaContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BiletSatis> BiletSatis { get; set; }
        public virtual DbSet<BiletTuru> BiletTuru { get; set; }
        public virtual DbSet<Cinsiyet> Cinsiyet { get; set; }
        public virtual DbSet<Film> Film { get; set; }
        public virtual DbSet<FilmTuru> FilmTuru { get; set; }
        public virtual DbSet<Gosterim> Gosterim { get; set; }
        public virtual DbSet<Koltuk> Koltuk { get; set; }
        public virtual DbSet<OdemeSekli> OdemeSekli { get; set; }
        public virtual DbSet<Personel> Personel { get; set; }
        public virtual DbSet<Salon> Salon { get; set; }
        public virtual DbSet<Seans> Seans { get; set; }
        public virtual DbSet<Seyirci> Seyirci { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Unvan> Unvan { get; set; }
    }
}
