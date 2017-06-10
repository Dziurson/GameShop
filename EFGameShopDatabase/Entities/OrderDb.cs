using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace EFGameShopDatabase.Entities
{
    [Table("Orders")]
    public partial class OrderDb
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OrderDb()
        {
            OrderEntries = new HashSet<OrderEntryDb>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int order_id { get; set; }

        public int user_id { get; set; }

        public DateTime? delivery_date { get; set; }

        public DateTime order_date { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderEntryDb> OrderEntries { get; set; }

        public virtual UserDb Users { get; set; }
    }
}
