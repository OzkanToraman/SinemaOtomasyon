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
    
    public partial class Seyirci
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Seyirci()
        {
            this.BiletSatis = new HashSet<BiletSati>();
        }
    
        public int SeyirciID { get; set; }
        public string SeyirciAd { get; set; }
        public string SeyirciSoyad { get; set; }
        public string SeyirciAdres { get; set; }
        public string SeyirciTelefon { get; set; }
        public string Meslek { get; set; }
        public bool Üyelik { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BiletSati> BiletSatis { get; set; }
    }
}