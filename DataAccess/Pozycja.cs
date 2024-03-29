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
    
    public partial class Pozycja
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pozycja()
        {
            this.Autor_Pozycja = new HashSet<Autor_Pozycja>();
            this.Film = new HashSet<Film>();
            this.Ksiazka = new HashSet<Ksiazka>();
            this.Muzyka = new HashSet<Muzyka>();
            this.Prosby_Wypozyczen = new HashSet<Prosby_Wypozyczen>();
            this.Wypozyczenie = new HashSet<Wypozyczenie>();
        }
    
        public int id { get; set; }
        public int repozytorium_id { get; set; }
        public string tytul { get; set; }
        public int rokWydania { get; set; }
        public Nullable<int> udostepnioneDla { get; set; }
        public int typ { get; set; }
        public Nullable<int> notatka { get; set; }
        public Nullable<int> ocena { get; set; }
        public int wydawca { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Autor_Pozycja> Autor_Pozycja { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Film> Film { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ksiazka> Ksiazka { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Muzyka> Muzyka { get; set; }
        public virtual Notatka Notatka1 { get; set; }
        public virtual Ocena Ocena1 { get; set; }
        public virtual Repozytorium Repozytorium { get; set; }
        public virtual Typ Typ1 { get; set; }
        public virtual Uzytkownik Uzytkownik { get; set; }
        public virtual Wydawca Wydawca1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prosby_Wypozyczen> Prosby_Wypozyczen { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Wypozyczenie> Wypozyczenie { get; set; }
    }
}
