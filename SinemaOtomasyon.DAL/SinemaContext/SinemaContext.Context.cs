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
    
        public virtual DbSet<BiletSati> BiletSatis { get; set; }
        public virtual DbSet<BiletTuru> BiletTurus { get; set; }
        public virtual DbSet<Cinsiyet> Cinsiyets { get; set; }
        public virtual DbSet<Film> Films { get; set; }
        public virtual DbSet<FilmTuru> FilmTurus { get; set; }
        public virtual DbSet<Gosterim> Gosterims { get; set; }
        public virtual DbSet<Koltuk> Koltuks { get; set; }
        public virtual DbSet<OdemeSekli> OdemeSeklis { get; set; }
        public virtual DbSet<Personel> Personels { get; set; }
        public virtual DbSet<Salon> Salons { get; set; }
        public virtual DbSet<Sean> Seans { get; set; }
        public virtual DbSet<Seyirci> Seyircis { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Unvan> Unvans { get; set; }
    }
}