//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AuthenticationAndAuthorizationPart2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblOrder
    {
        public int OrderId { get; set; }
        public Nullable<int> CartId { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<int> Total { get; set; }
    
        public virtual tblCart tblCart { get; set; }
    }
}