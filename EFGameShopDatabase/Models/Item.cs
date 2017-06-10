using EFGameShopDatabase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFGameShopDatabase.Models
{
    public class Item
    {
        public int item_id { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public double tax_rate { get; set; }
        public string unit { get; set; }
        public string type { get; set; }
        public int available_quantity { get; set; }
        public string description { get; set; }
        public int? loyality_points { get; set; }

        public ItemDb ReverseMap()
        {
            return new ItemDb()
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
