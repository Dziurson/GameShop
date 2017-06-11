using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using EFGameShopDatabase.Models;

namespace EFGameShopDatabase.Entities
{
    [Table("Items",Schema = "dbo")]
    public partial class ItemDb
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ItemDb()
        {
            OrderEntries = new HashSet<OrderEntryDb>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("item_id")]
        public int ItemId { get; set; }

        [Required]
        [StringLength(100)]
        [Column("name")]
        public string Name { get; set; }

        [Column("price", TypeName = "money")]
        public decimal Price { get; set; }

        [Column("tax_rate")]
        public double TaxRate { get; set; }

        [Required]
        [StringLength(20)]
        [Column("unit")]
        public string Unit { get; set; }

        [Required]
        [StringLength(50)]
        [Column("type")]
        public string Type { get; set; }

        [Column("available_quantity")]
        public int AvailableQuantity { get; set; }

        [Required]
        [StringLength(2000)]
        [Column("description")]
        public string Description { get; set; }

        [Column("loyality_points")]
        public int? LoyalPoints { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderEntryDb> OrderEntries { get; set; }

        public Item Map()
        {
            return new Item()
            {
                ItemId = this.ItemId,
                AvailableQuantity = this.AvailableQuantity,
                Description = this.Description,
                LoyalityPoints = this.LoyalPoints,
                Name = this.Name,
                Price = this.Price,
                TaxRate = this.TaxRate,
                Type = this.Type,
                Unit = this.Unit
            };
        }
    }
}
