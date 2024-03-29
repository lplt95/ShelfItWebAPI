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
    
    public partial class Uzytkownik
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Uzytkownik()
        {
            this.Poz_App_Mobilna = new HashSet<Poz_App_Mobilna>();
            this.Pozycja = new HashSet<Pozycja>();
            this.Prosby_Wypozyczen = new HashSet<Prosby_Wypozyczen>();
            this.Repozytorium = new HashSet<Repozytorium>();
            this.Repozytorium_Udostepnienie = new HashSet<Repozytorium_Udostepnienie>();
            this.Repozytorium_Udostepnienie1 = new HashSet<Repozytorium_Udostepnienie>();
            this.Uzytkownik_Potwierdzenie = new HashSet<Uzytkownik_Potwierdzenie>();
            this.Wypozyczenie = new HashSet<Wypozyczenie>();
            this.Zaproszenia = new HashSet<Zaproszenia>();
        }
    
        public int id { get; set; }
        public string email { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string sessionID { get; set; }
        public bool IsConfirmed { get; set; }
        public Nullable<bool> passwordReset { get; set; }
        public Nullable<bool> deactivated { get; set; }
        public Nullable<System.DateTime> deactDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Poz_App_Mobilna> Poz_App_Mobilna { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pozycja> Pozycja { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prosby_Wypozyczen> Prosby_Wypozyczen { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Repozytorium> Repozytorium { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Repozytorium_Udostepnienie> Repozytorium_Udostepnienie { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Repozytorium_Udostepnienie> Repozytorium_Udostepnienie1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Uzytkownik_Potwierdzenie> Uzytkownik_Potwierdzenie { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Wypozyczenie> Wypozyczenie { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zaproszenia> Zaproszenia { get; set; }
    }
}
