using EFGameShopDatabase.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFGameShopDatabase.Entities
{
    [Table("OrderEntries", Schema = "dbo")]
    public partial class OrderEntryDb
    {
        [Key]
        [Column("order_id", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderId { get; set; }

        [Key]
        [Column("item_id", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ItemId { get; set; }

        [Column("quantity")]
        public int? Quantity { get; set; }

        public virtual ItemDb Items { get; set; }

        public virtual OrderDb Orders { get; set; }

        public OrderEntry Map()
        {
            return new OrderEntry()
            {
                OrderId = OrderId,
                ItemId = ItemId,
                Quantity = Quantity
            };
        }
    }
}
