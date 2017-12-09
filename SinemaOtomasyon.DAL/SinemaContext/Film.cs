//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Film
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Film()
        {
            this.Gosterims = new HashSet<Gosterim>();
        }
    
        public int FilmID { get; set; }
        public string FilmAd { get; set; }
        public string Yonetmen { get; set; }
        public string Oyuncular { get; set; }
        public System.DateTime VizyonGrsTarih { get; set; }
        public System.DateTime VizyonCksTarih { get; set; }
        public Nullable<int> FilmSuresi_dk { get; set; }
        public bool Vizyonda { get; set; }
        public int FilmTurID { get; set; }
    
        public virtual FilmTuru FilmTuru { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Gosterim> Gosterims { get; set; }
    }
}
