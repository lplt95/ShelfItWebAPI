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
    
    public partial class Poz_App_Mobilna
    {
        public int id { get; set; }
        public string tytul { get; set; }
        public int uzytkownik_id { get; set; }
        public int typ_id { get; set; }
    
        public virtual Typ Typ { get; set; }
        public virtual Uzytkownik Uzytkownik { get; set; }
    }
}
