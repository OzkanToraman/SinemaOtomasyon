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
    
    public partial class BiletSatis
    {
        public int BiletID { get; set; }
        public decimal BiletFiyat { get; set; }
        public bool Satıldı { get; set; }
        public int SeyirciID { get; set; }
        public int GosterimID { get; set; }
        public int PersonelID { get; set; }
        public int KoltukID { get; set; }
        public int BiletTurID { get; set; }
        public int OdemeSekliID { get; set; }
    
        public virtual BiletTuru BiletTuru { get; set; }
        public virtual Gosterim Gosterim { get; set; }
        public virtual Koltuk Koltuk { get; set; }
        public virtual OdemeSekli OdemeSekli { get; set; }
        public virtual Personel Personel { get; set; }
        public virtual Seyirci Seyirci { get; set; }
    }
}