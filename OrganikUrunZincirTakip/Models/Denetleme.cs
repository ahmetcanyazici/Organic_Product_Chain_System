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
    using System.ComponentModel;

    public partial class Denetleme
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Denetleme()
        {
            this.Depolamas = new HashSet<Depolama>();
        }
    
        public int DenetlemeID { get; set; }
        public Nullable<int> SertifikaID { get; set; }
        public string DenetlemeAcıklama { get; set; }
        [DisplayName("Denetleyici")]
        public int UserId { get; set; }
    
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Depolama> Depolamas { get; set; }
    }
}
