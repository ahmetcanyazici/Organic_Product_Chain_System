//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OrganikUrunZincirTakip.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sati
    {
        public int SatısID { get; set; }
        public int NakliyeID { get; set; }
        public System.DateTime SatısTarih { get; set; }
        public string SatisAcıklama { get; set; }
        public int UserId { get; set; }
    
        public virtual Nakliye Nakliye { get; set; }
        public virtual User User { get; set; }
    }
}
