using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace EFGameShopDatabase.Entities
{
    public partial class Items
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Items()
        {
            OrderEntries = new HashSet<OrderEntries>();
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
        public virtual ICollection<OrderEntries> OrderEntries { get; set; }
    }
}
