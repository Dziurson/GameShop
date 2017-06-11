using EFGameShopDatabase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFGameShopDatabase.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public DateTime OrderDate { get; set; }

        public OrderDb ReverseMap()
        {
            return new OrderDb()
            {
                OrderId = OrderId,
                UserId = UserId,
                DeliveryDate = DeliveryDate,
                OrderDate = OrderDate
            };
        }
    }
}
