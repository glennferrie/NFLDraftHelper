//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DraftHelper.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class NFLPlayer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public int ESPNRank { get; set; }
        public int MyRank { get; set; }
        public int DepthChart { get; set; }
        public int NFLTeam_Id { get; set; }
    
        public virtual NFLTeam NFLTeam { get; set; }
        public virtual DraftPick DraftPick { get; set; }
    }
}
