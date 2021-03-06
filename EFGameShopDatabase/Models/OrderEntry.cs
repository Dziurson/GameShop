﻿using EFGameShopDatabase.Entities;

namespace EFGameShopDatabase.Models
{
    public class OrderEntry
    {
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public int? Quantity { get; set; }

        public OrderEntryDb ReverseMap()
        {
            return new OrderEntryDb()
            {
                OrderId = OrderId,
                ItemId = ItemId,
                Quantity = Quantity
            };
        }
    }
}
