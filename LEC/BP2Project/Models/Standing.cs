//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BP2Project.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Standing
    {
        public int TeamID { get; set; }
        public int Wins { get; set; }
        public int Loses { get; set; }
        public int Rank { get; set; }
    
        public virtual Team Team { get; set; }
    }
}