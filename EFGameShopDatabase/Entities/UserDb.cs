using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace EFGameShopDatabase.Entities
{
    [Table("Users")]
    public partial class UserDb
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserDb()
        {
            Orders = new HashSet<OrderDb>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int user_id { get; set; }

        [Required]
        [StringLength(50)]
        public string login { get; set; }

        [Required]
        [StringLength(50)]
        public string password { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [StringLength(50)]
        public string surname { get; set; }

        [StringLength(200)]
        public string address { get; set; }

        [StringLength(100)]
        public string city { get; set; }

        [StringLength(20)]
        public string postal_code { get; set; }

        [StringLength(20)]
        public string phone { get; set; }

        [StringLength(50)]
        public string mail { get; set; }

        public int? loyality_points { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDb> Orders { get; set; }
    }
}
