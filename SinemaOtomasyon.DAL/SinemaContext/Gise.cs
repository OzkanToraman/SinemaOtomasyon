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
    
    public partial class Gise
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Gise()
        {
            this.BiletSatis = new HashSet<BiletSatis>();
        }
    
        public int GiseID { get; set; }
        public int KoltukID { get; set; }
        public int GosterimID { get; set; }
        public bool DoluMu { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BiletSatis> BiletSatis { get; set; }
        public virtual Gosterim Gosterim { get; set; }
        public virtual Koltuk Koltuk { get; set; }
    }
}
