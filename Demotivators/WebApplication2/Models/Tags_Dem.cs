//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tags_Dem
    {
        public int ItemId { get; set; }
        public int TagsId { get; set; }
    
        public virtual Item Item { get; set; }
        public virtual Tags Tags { get; set; }
    }
}
