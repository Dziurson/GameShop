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
    }
}
