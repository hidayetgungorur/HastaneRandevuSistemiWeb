//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BeykentHastaRandevuSistemiData
{
    using System;
    using System.Collections.Generic;
    
    public partial class Hasta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hasta()
        {
            this.HastaRandevu = new HashSet<HastaRandevu>();
        }
    
        public int RecId { get; set; }
        public int KullaniciId { get; set; }
        public int StatusTypeId { get; set; }
    
        public virtual KullaniciBilgileri KullaniciBilgileri { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HastaRandevu> HastaRandevu { get; set; }
    }
}
