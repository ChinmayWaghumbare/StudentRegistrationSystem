//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SudentRegistrationSystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Project
    {
        public int ID { get; set; }
        public string PrjctName { get; set; }
        public Nullable<int> StudId { get; set; }
        public Nullable<int> TeamSize { get; set; }
        public string Description { get; set; }
    
        public virtual Student Student { get; set; }
    }
}
