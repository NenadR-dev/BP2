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
    
    public partial class MatchTicket
    {
        public int MatchID { get; set; }
        public int UserID { get; set; }
        public int TicketID { get; set; }
        public int MatchTicketID { get; set; }
    
        public virtual Match Match { get; set; }
        public virtual User User { get; set; }
        public virtual Ticket Ticket { get; set; }
    }
}