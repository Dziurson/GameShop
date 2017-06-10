using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using EFGameShopDatabase.Models;

namespace EFGameShopDatabase.Entities
{
    [Table("Items")]
    public partial class ItemDb
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ItemDb()
        {
            OrderEntries = new HashSet<OrderEntryDb>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int item_id { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }

        [Column(TypeName = "money")]
        public decimal price { get; set; }

        public double tax_rate { get; set; }

        [Required]
        [StringLength(20)]
        public string unit { get; set; }

        [Required]
        [StringLength(50)]
        public string type { get; set; }

        public int available_quantity { get; set; }

        [Required]
        [StringLength(2000)]
        public string description { get; set; }

        public int? loyality_points { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderEntryDb> OrderEntries { get; set; }

        public Item Map()
        {
            return new Item()
            {
                item_id = this.item_id,
                available_quantity = this.available_quantity,
                description = this.description,
                loyality_points = this.loyality_points,
                name = this.name,
                price = this.price,
                tax_rate = this.tax_rate,
                type = this.type,
                unit = this.unit
            };
        }
    }
}
