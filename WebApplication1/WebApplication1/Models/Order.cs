//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public string OrderID { get; set; }
        public string ClientID { get; set; }
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public Nullable<int> Quantity { get; set; }
        public string Payment { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual Export Export { get; set; }
        public virtual Product Product { get; set; }
    }
}
