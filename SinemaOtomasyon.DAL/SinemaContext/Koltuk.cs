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
    
    public partial class Koltuk
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Koltuk()
        {
            this.BiletSatis = new HashSet<BiletSati>();
        }
    
        public int KoltukID { get; set; }
        public string KoltukAD { get; set; }
        public decimal KoltukFiyatSapma { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BiletSati> BiletSatis { get; set; }
    }
}
