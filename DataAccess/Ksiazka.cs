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
    
    public partial class Ksiazka
    {
        public int id { get; set; }
        public int iloscStron { get; set; }
        public string okladka { get; set; }
        public int pozycja_id { get; set; }
    
        public virtual Pozycja Pozycja { get; set; }
    }
}
