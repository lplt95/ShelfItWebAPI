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
    
    public partial class Autor_Pozycja
    {
        public int id { get; set; }
        public int pozycja_id { get; set; }
        public int autor_id { get; set; }
    
        public virtual Autor Autor { get; set; }
        public virtual Pozycja Pozycja { get; set; }
    }
}
