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
    
    public partial class Repozytorium
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Repozytorium()
        {
            this.Pozycja = new HashSet<Pozycja>();
            this.Repozytorium_Udostepnienie = new HashSet<Repozytorium_Udostepnienie>();
        }
    
        public int id { get; set; }
        public int uzytkownik_id { get; set; }
        public string nazwa { get; set; }
        public string domyslny_id { get; set; }
        public int numer_repoz { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pozycja> Pozycja { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Repozytorium_Udostepnienie> Repozytorium_Udostepnienie { get; set; }
        public virtual Uzytkownik Uzytkownik { get; set; }
    }
}
