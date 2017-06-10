using EFGameShopDatabase.Models;
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
        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string Login { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Surname { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [StringLength(100)]
        public string City { get; set; }

        [StringLength(20)]
        public string PostalCode { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string Mail { get; set; }

        public int? LoyalityPoints { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDb> Orders { get; set; }

        public User Map()
        {
            return new User()
            {
                UserId = UserId,
                Password = Password,
                Name = Name,
                Surname = Surname,
                Address = Address,
                City = City,
                PostalCode = PostalCode,
                Phone = Phone,
                Mail = Mail,
                LoyalityPoints = LoyalityPoints
            };
        }

    }
}
