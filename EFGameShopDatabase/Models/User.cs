using EFGameShopDatabase.Entities;

namespace EFGameShopDatabase.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public int? LoyalityPoints { get; set; }

        public UserDb ReverseMap()
        {
            return new UserDb()
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
