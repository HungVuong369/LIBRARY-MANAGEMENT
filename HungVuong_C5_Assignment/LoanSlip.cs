//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HungVuong_C5_Assignment
{
    using System;
    using System.Collections.Generic;
    
    public partial class LoanSlip
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoanSlip()
        {
            this.LoanDetails = new HashSet<LoanDetail>();
        }
    
        public string Id { get; set; }
        public string IdReader { get; set; }
        public int Quantity { get; set; }
        public System.DateTime LoanDate { get; set; }
        public System.DateTime ExpDate { get; set; }
        public decimal LoanPaid { get; set; }
        public decimal Deposit { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LoanDetail> LoanDetails { get; set; }
        public virtual Reader Reader { get; set; }
    }
}
