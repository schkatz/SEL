//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Resfull.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CheckIn
    {
        public int CheckIn_ID { get; set; }
        public int CheckInTournament_ID { get; set; }
        public int CheckInTeam_ID { get; set; }
        public byte[] CheckIn1 { get; set; }
    
        public virtual Teams Teams { get; set; }
        public virtual Tournaments Tournaments { get; set; }
    }
}