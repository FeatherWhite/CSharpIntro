//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRUD
{
    using System;
    using System.Collections.Generic;
    
    public partial class MyClassChild
    {
        public int MyClassChildID { get; set; }
        public int MyClassID { get; set; }
        public string Informatin { get; set; }
    
        public virtual MyClass MyClass { get; set; }
    }
}
