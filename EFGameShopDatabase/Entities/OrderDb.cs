using EFGameShopDatabase.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace EFGameShopDatabase.Entities
{
    [Table("Orders", Schema = "dbo")]
    public partial class OrderDb
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OrderDb()
        {
            OrderEntries = new HashSet<OrderEntryDb>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("order_id")]
        public int OrderId { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [Column("delivery_date")]
        public DateTime? DeliveryDate { get; set; }

        [Column("order_date")]
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
