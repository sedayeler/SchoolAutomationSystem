//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OkulOtomasyonSistemi
{
    using System;
    using System.Collections.Generic;
    
    public partial class Veliler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Veliler()
        {
            this.Ogrenciler = new HashSet<Ogrenciler>();
        }
    
        public int VELIID { get; set; }
        public string VELIANNE { get; set; }
        public string VELIBABA { get; set; }
        public string VELITEL1 { get; set; }
        public string VELITEL2 { get; set; }
        public string VELIMAIL { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ogrenciler> Ogrenciler { get; set; }
    }
}