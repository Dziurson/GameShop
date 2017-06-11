using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFGameShopDatabase.Models;

namespace WarehouseWebAPI.Models
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

        public static Item Map(EFGameShopDatabase.Models.Item item)
        {
            return new Item()
            {
                ItemId = item.ItemId,
                AvailableQuantity = item.AvailableQuantity,
                Description = item.Description,
                LoyalityPoints = item.LoyalityPoints,
                Name = item.Name,
                Price = item.Price,
                TaxRate = item.TaxRate,
                Type = item.Type,
                Unit = item.Unit
            };
        }

        public static IEnumerable<Item> Map(IEnumerable<EFGameShopDatabase.Models.Item> items)
        {
            if (items == null)
                return null;
            else
            {
                List<Item> list = new List<Item>();
                foreach (var item in items)
                {
                    list.Add(new Item()
                    {
                        ItemId = item.ItemId,
                        AvailableQuantity = item.AvailableQuantity,
                        Description = item.Description,
                        LoyalityPoints = item.LoyalityPoints,
                        Name = item.Name,
                        Price = item.Price,
                        TaxRate = item.TaxRate,
                        Type = item.Type,
                        Unit = item.Unit
                    });
                }
                return list;
            }
        }


        public EFGameShopDatabase.Models.Item ReverseMap()
        {
            return new EFGameShopDatabase.Models.Item()
            {
                ItemId = this.ItemId,
                AvailableQuantity = this.AvailableQuantity,
                Description = this.Description,
                LoyalityPoints = this.LoyalityPoints,
                Name = this.Name,
                Price = this.Price,
                TaxRate = this.TaxRate,
                Type = this.Type,
                Unit = this.Unit
            };
        }
    }
}
