using EFGameShopDatabase.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace EFGameShopDatabase.Entities
{
    [Table("Users", Schema = "dbo")]
    public partial class UserDb
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserDb()
        {
            Orders = new HashSet<OrderDb>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("user_id")]
        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        [Column("login")]
        public string Login { get; set; }

        [Required]
        [StringLength(50)]
        [Column("password")]
        public string Password { get; set; }

        [StringLength(50)]
        [Column("name")]
        public string Name { get; set; }

        [StringLength(50)]
        [Column("surname")]
        public string Surname { get; set; }

        [StringLength(200)]
        [Column("address")]
        public string Address { get; set; }

        [StringLength(100)]
        [Column("city")]
        public string City { get; set; }

        [StringLength(20)]
        [Column("postal_code")]
        public string PostalCode { get; set; }

        [StringLength(20)]
        [Column("phone")]
        public string Phone { get; set; }

        [StringLength(50)]
        [Column("mail")]
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
