using EFGameShopDatabase.Models;
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
        public int OrderId { get; set; }

        public int UserId { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public DateTime OrderDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderEntryDb> OrderEntries { get; set; }

        public virtual UserDb Users { get; set; }

        public Order Map()
        {
            return new Order()
            {
                OrderId = OrderId,
                UserId = UserId,
                DeliveryDate = DeliveryDate,
                OrderDate = OrderDate
            };
        }
    }
}
