//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Typ
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Typ()
        {
            this.Poz_App_Mobilna = new HashSet<Poz_App_Mobilna>();
            this.Pozycja = new HashSet<Pozycja>();
        }
    
        public int id { get; set; }
        public string nazwa { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Poz_App_Mobilna> Poz_App_Mobilna { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pozycja> Pozycja { get; set; }
    }
}
