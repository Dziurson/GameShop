using EFGameShopDatabase.Entities;

namespace EFGameShopDatabase.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public double TaxRate { get; set; }
        public string Unit { get; set; }
        public string Type { get; set; }
        public int AvailableQuantity { get; set; }
        public string Description { get; set; }
        public int? LoyalityPoints { get; set; }

        public ItemDb ReverseMap()
        {
            return new ItemDb()
            {
                ItemId = this.ItemId,
                AvailableQuantity = this.AvailableQuantity,
                Description = this.Description,
                LoyalPoints = this.LoyalityPoints,
                Name = this.Name,
                Price = this.Price,
                TaxRate = this.TaxRate,
                Type = this.Type,
                Unit = this.Unit
            };
        }
    }
}
