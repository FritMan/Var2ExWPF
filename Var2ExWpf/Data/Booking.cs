//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Var2ExWpf.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Booking
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Booking()
        {
            this.Payment = new HashSet<Payment>();
        }
    
        public int Id { get; set; }
        public int Guest_id { get; set; }
        public int Room_id { get; set; }
        public System.DateTime Check_in_date { get; set; }
        public System.DateTime Check_out_date { get; set; }
        public string Total_price { get; set; }
        public int Status_booking_Id { get; set; }
    
        public virtual Guest Guest { get; set; }
        public virtual Status_Booking Status_Booking { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Payment> Payment { get; set; }
        public virtual Room Room { get; set; }
    }
}
