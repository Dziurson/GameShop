using EFGameShopDatabase.Enums;
using EFGameShopDatabase.Models;
using System.Collections.Generic;
using System.ServiceModel;

namespace WCFGameShopWarehouseService
{
    [ServiceContract]
    public interface IGameShopWarehouse
    {
        [OperationContract]
        IEnumerable<Item> GetAllItems();

        [OperationContract]
        IEnumerable<Item> GetItemsByType(ItemType itemtype);

        [OperationContract]
        IEnumerable<Item> GetItemsWithNoQty();

        [OperationContract]
        bool InsertNewItem(Item item);

        [OperationContract]
        bool InsertNewItems(IEnumerable<Item> items);

        [OperationContract]
        Item GetItemById(int itemid);

        [OperationContract]
        bool RemoveItem(Item item);

        [OperationContract]
        IEnumerable<Item> GetItemsInOrder(Order order);
    }
}
